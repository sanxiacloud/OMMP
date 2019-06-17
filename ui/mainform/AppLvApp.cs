using System;
using System.Collections.Generic;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;
using ommp.bll.service;

namespace ommp.ui
{
	public static class AppLvApp
	{
		public static void ReDraw()
		{
			var form = FT.Forms["主窗口"];
			var lv = (WF.ListView)form.Controls["lv_app_app"];
			var snode = ((WF.TreeView)form.Controls["tv_app_org"]).SelectedNode;
			Clear();

			lv.StopRedraw();

			var count = 0;
			var stack1 = new Stack<WF.TreeNode>();
			var stack2 = new Stack<WF.TreeNode>();
			WF.TreeNode tnCur;

			stack1.Push(snode);
			while (stack1.Count > 0)
			{
				tnCur = stack1.Pop();
				stack2.Push(tnCur);
				foreach (var tnChd in tnCur.Nodes)
				{
					stack1.Push(tnChd);
				}
			}
			foreach (var node in stack2)
			{
				var _id = node.Tag;
				foreach (var drLK in FT.DataTables["LnkFunctionalCIToOrganization"].Select(string.Format("_IsDeleted=0 And organization_identify ={0}",_id)))
				{
					var drCI = FT.DataTables["FunctionalCI"].Find(string.Format("_IsDeleted=0 And _Identify={0}", drLK["functionalci_identify"]));
					if (drCI != null && (string)drCI["finalclass"] == "ApplicationSolution")
					{
						var drAS = FT.DataTables["ApplicationSolution"].Find(string.Format("_IsDeleted=0 And id={0}", drLK["functionalci_identify"]));
						var row = lv.Rows.Add();
						count += 1;
						row["name"] = (string)drCI["name"];
						row["organization"] = (string)FT.DataTables["Organization"].Find(string.Format("_IsDeleted=0 And _Identify={0}", drLK["organization_identify"]))["name"];
						row["status"] = CommonService.TranslateCode("应用程序状态", (int)drAS["code_application_status"]);
						row["start_date"] = ((DateTime)drCI["move2production"]).ToString();						
						row["sla"] = CommonService.TranslateCode("保障要求", (int)drAS["code_sla"]);						
						row.Tag = drCI;
					}
				}
			}
			var tcApp = (WF.TabControl)form.Controls["tc_app_app"];
			var tabApp = tcApp.TabPages["app"];
			tabApp.Text = string.Format("应用系统({0})", count);
			
			lv.ResumeRedraw();
			((WF.Control)form.Controls["bt_app_app_add"]).Enabled = true;
		}

		public static void Clear()
		{
			var form = FT.Forms["主窗口"];
			var lv = (WF.ListView)form.Controls["lv_app_app"];
			lv.StopRedraw();
			lv.Rows.Clear();
			lv.ResumeRedraw();

			var tcApp = (WF.TabControl)form.Controls["tc_app_app"];
			var tabApp = tcApp.TabPages["app"];
			tabApp.Text = "应用系统";

			((WF.Control)form.Controls["bt_app_app_add"]).Enabled = false;
			((WF.Control)form.Controls["bt_app_app_del"]).Enabled = false;

			AppLvHost.Clear();
		}

		#region event
		public static void RowActivate(ControlEventArgs e)
		{
			var drCI = (DataRow)((WF.ListView)e.Sender).Current.Tag;
			var identify = ((int)drCI["_Identify"]);			
			var drLK = FT.DataTables["LnkFunctionalCIToOrganization"].Find(string.Format("_IsDeleted=0 And functionalci_identify={0}", identify));
			FormApplicationSolution.Open((int)drLK["organization_identify"], identify);
		}

		public static void RowSelectionChanged(ListViewRowEventArgs e)
		{
			var row = ((WF.ListView)e.Sender).Current;
			if (row != null)
			{
				((WF.Control)e.Form.Controls["bt_app_app_del"]).Enabled = true;
				var dr = (DataRow)row.Tag;
				AppLvHost.ReDraw(dr["_Identify"].ToString());
			}
		}
		#endregion event
	}
}

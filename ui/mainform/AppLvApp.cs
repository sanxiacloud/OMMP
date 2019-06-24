using System;
using System.Collections.Generic;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;
using ommp.bll.service;
using ommp.bll.dto;
using ommp.bll.dto.structure;

namespace ommp.ui
{
	public static class AppLvApp
	{
		public static void ReDraw()
		{
			var form = FT.Forms["主窗口"];
			var lv = (WF.ListView)form.Controls["lv_app_app"];
			var snode = ((WF.TreeView)form.Controls["tv_app_org"]).SelectedNode;
			var sorg = OrganizationService.Find(int.Parse(snode.Tag));
			Clear();
			lv.StopRedraw();
		
			var rnode = AppTvOrg.RootTNode;

			TreeNode<Organization> cnode;
			if (sorg.Code == "01")
			{
				cnode = rnode;
			}
			else
			{
				cnode = rnode.FindNode(sorg.Code);
			}

			var applist = ApplicationSolutionService.ListByOrganizationTreeNode(cnode);
			foreach (var app in applist)
			{
				var row = lv.Rows.Add();
				row["name"] = app.Name;				
				row["status"] = CommonService.TranslateCode("应用程序状态", app.CodeApplicationStatus);
				row["start_date"] = app.Move2Production.ToString("yyyy-MM-dd");
				row["sla"] = CommonService.TranslateCode("保障要求", app.CodeSla);
				var org = OrganizationService.Find(app.OrgID);
				row["organization"] = org.Name;
				row.Tag = app;
			}
			var tcApp = (WF.TabControl)form.Controls["tc_app_app"];
			var tabApp = tcApp.TabPages["app"];
			tabApp.Text = string.Format("应用系统({0})", applist.Count);					
			
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
			var app = (ApplicationSolution)((WF.ListView)e.Sender).Current.Tag;		
			FormApplicationSolution.Open(app.OrgID, app.Identify);
		}

		public static void RowSelectionChanged(ListViewRowEventArgs e)
		{
			var row = ((WF.ListView)e.Sender).Current;
			if (row != null)
			{
				((WF.Control)e.Form.Controls["bt_app_app_del"]).Enabled = true;
				var app = (ApplicationSolution)row.Tag;
				AppLvHost.ReDraw(app.Identify);
			}
		}
		#endregion event
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;

namespace ommp.ui
{
    public static class AppTvOrg
    {
		public static void ReDraw() {
			var form = FT.Forms["主窗口"];
			var filter = ((WF.TextBox)form.Controls["tb_app_org_sch"]).Text.Trim();
			var tv = (WF.TreeView)form.Controls["tv_app_org"];
			var dt = FT.DataTables["Organization"];
			var drs = dt.Select(string.Format("name like '%{0}%' And _IsDeleted = false", filter), "code");
			var rowCount = drs.Count;
			Clear();
			if (rowCount != 0 )
			{	
				tv.StopRedraw();
				var drAnc = dt.Find(string.Format("code='{0}'", ((string)drs[0]["code"]).Substring(0, 2)));
				var rnode = tv.Nodes.Add((string)drAnc["code"], (string)drAnc["name"]);
				rnode.Tag = drAnc["_Identify"].ToString();				
				for (int i = 0; i < rowCount - 1; i++)
				{
					var len = 5;
					var dr = drs[i];
					var pnode = rnode;
					while (len <= ((string)dr["code"]).Length)
					{
						drAnc = dt.Find(string.Format("code='{0}'", ((string)dr["code"]).Substring(0, len)));
						if (!pnode.Nodes.Contains((string)drAnc["code"]))
						{
							pnode = pnode.Nodes.Add((string)drAnc["code"], (string)drAnc["name"]);
							pnode.Tag = drAnc["_Identify"].ToString();
						}
						else
						{
							pnode = pnode.Nodes[(string)drAnc["code"]];
						}
						len += 3;
					}
				}
				foreach (var node in tv.AllNodes)
				{
					var ncount = node.AllNodes.Count;
					if (ncount > 0)
					{
						node.Text = string.Format("{0}({1})", node.Text, ncount);
					}
				}
				if (filter != "")
				{
					tv.ExpandAll();
				}
				tv.Nodes[0].Expand();

				tv.ResumeRedraw();
			}
			((WF.Control)form.Controls["tb_app_org_sch"]).Enabled = true;
			((WF.Control)form.Controls["bt_app_org_sch"]).Enabled = true;
			((WF.Control)form.Controls["bt_app_org_add"]).Enabled = true;
			((WF.Control)form.Controls["bt_app_org_rfh"]).Enabled = true;
		}

		static void Clear()
		{
			var form = FT.Forms["主窗口"];
			var tv = (WF.TreeView)form.Controls["tv_app_org"];
			tv.StopRedraw();
			tv.Nodes.Clear();
			tv.ResumeRedraw();

			((WF.Control)form.Controls["tb_app_org_sch"]).Enabled = false;
			((WF.Control)form.Controls["bt_app_org_sch"]).Enabled = false;
			((WF.Control)form.Controls["bt_app_org_add"]).Enabled = false;
			((WF.Control)form.Controls["bt_app_org_mod"]).Enabled = false;
			((WF.Control)form.Controls["bt_app_org_rfh"]).Enabled = false;

			AppLvApp.Clear();
		}

		public static void AfterSelectNode(ControlEventArgs e)
		{
			var form = FT.Forms["主窗口"];
			AppLvApp.ReDraw();
			((WF.Control)form.Controls["bt_app_org_mod"]).Enabled = true;
		}
	}

	
}

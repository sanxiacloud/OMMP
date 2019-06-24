using System;
using System.Collections.Generic;
using System.Text;
using ommp.bll.service;
using ommp.bll.dto;
using ommp.bll.dto.structure;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;

namespace ommp.ui
{
    public static class AppTvOrg
    {
		public static TreeNode<Organization> RootTNode { get; private set; }
		public static void ReDraw() {
			var form = FT.Forms["主窗口"];
			var filter = ((WF.TextBox)form.Controls["tb_app_org_sch"]).Text.Trim();
			var tv = (WF.TreeView)form.Controls["tv_app_org"];

			Clear();
		
			RootTNode = OrganizationService.GetOrganizationTree(filter);
			if (RootTNode != null)
			{
				tv.StopRedraw();
				var queue = new Queue<(TreeNode<Organization>, WF.TreeNode)>();
				var rtn = tv.Nodes.Add(RootTNode.Data.Code, RootTNode.Data.Name);
				rtn.Tag = RootTNode.Data.Identify.ToString();
				queue.Enqueue((RootTNode, rtn));
				while (queue.Count > 0)
				{
					var (pNode, ptn) = queue.Dequeue();
					for (int i = 0; i < pNode.Nodes.Count; i++)
					{
						var cNode = pNode.Nodes[i];
						var ctn = ptn.Nodes.Add(cNode.Data.Code, cNode.Data.Name);
						ctn.Tag = cNode.Data.Identify.ToString();
						queue.Enqueue((cNode, ctn));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ommp.bll.service;
using ommp.bll.dto;
using ommp.bll.dto.structure;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;

namespace ommp.ui
{
	public static class FormOrgDropDownTree
	{
		public static string Filter {  set; private get; }
		
		static FormOrgDropDownTree()
		{
			Filter = "";			
		}

		public static void ReDraw()
		{
			FODDTTv1.ReDraw(Filter);
		}

		#region events
		public static void DropDownOpening(FormEventArgs e)
		{
			FODDTTv1.ReDraw(Filter);
		}

		public static void DropDownOpened(FormEventArgs e)
		{
			e.Form.DropDownBox.Select();
		}
		#endregion events
	} 

	public static class FODDTTv1
	{
		public static void ReDraw(string filter)
		{
			var form = FT.Forms["主管部门下拉树"];
			var self = (WF.TreeView)form.Controls["TreeView1"];

			self.StopRedraw();
			self.Nodes.Clear();
			var rTNode = OrganizationService.GetOrganizationTree(filter);
			if (rTNode != null)
			{
				var queue = new Queue<(TreeNode<Organization>, WF.TreeNode)>();
				var rtn = self.Nodes.Add(rTNode.Data.Code, rTNode.Data.Name);
				rtn.Tag = rTNode.Data.Identify.ToString();
				queue.Enqueue((rTNode, rtn));
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

				if (filter != "")
				{
					self.ExpandAll();
				}
				self.Nodes[0].Expand();
			}
			self.ResumeRedraw();
		}
		
		#region events
		public static void NodeMouseClick(TreeViewEventArgs e)
		{
			var node = e.Node;
			if (node.Nodes.Count == 0)
			{
				e.Form.DropDownBox.Value = node.Text;
				e.Form.DropDownBox.CloseDropdown();
			}
		}
		#endregion events
	}
}

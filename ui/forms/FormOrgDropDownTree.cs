using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			var dt = FT.DataTables["Organization"];
			var drs = dt.Select(string.Format("name like '%{0}%' And _IsDeleted = false", filter), "code");
			var rowCount = drs.Count;

			self.StopRedraw();
			self.Nodes.Clear();			
			if (rowCount != 0)
			{
				var drAnc = dt.Find(string.Format("code='{0}'", ((string)drs[0]["code"]).Substring(0, 2)));
				var rnode = self.Nodes.Add((string)drAnc["code"], (string)drAnc["name"]);
				rnode.Tag = drAnc["_Identify"].ToString();
				for (int i = 0; i < rowCount; i++)
				{
					var len = 5;
					var dr = drs[i];
					var pnode = rnode;
					while (len <= ((string)dr["code"]).Length)
					{
						drAnc = dt.Find(string.Format("code='{0}'", dr["code"].ToString().Substring(0, len)));
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

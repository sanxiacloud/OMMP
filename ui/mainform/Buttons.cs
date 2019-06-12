using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;

namespace ui
{
	public class AppOrgSch
	{
		public static void Click(ControlEventArgs e)
		{
			AppTvOrg.ReDraw();
		}
	}

	public class AppOrgAdd
	{
		public static void Click(ControlEventArgs e) {

		}
	}

	public class AppOrgMod
	{
		public static void Click(ControlEventArgs e)
		{

		}
	}

	public class AppOrgRfh
	{
		public static void Click(ControlEventArgs e)
		{
			var tv = (WF.TreeView)e.Form.Controls["tv_app_org"];
			var tbSch = (WF.TextBox)e.Form.Controls["tb_app_org_sch"];
			tbSch.Value = "";
			AppTvOrg.ReDraw();
		}
	}

	public class AppAppAdd
	{
		public static void Click(ControlEventArgs e) {
			int identify = -1;
			int.TryParse(((WF.TreeView)e.Form.Controls["tv_app_org"]).SelectedNode.Tag, out identify);
			FormApplicationSolution.Open(ModifyType.create, identify);
		}
	}
}

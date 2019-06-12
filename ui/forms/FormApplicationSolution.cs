using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;
using MB = System.Windows.Forms.MessageBox;

namespace ui
{
	public static class FormApplicationSolution
	{
		public static ModifyType Type { set; private get; }
		public static int OrgId { set; private get; }
		public static int Identify { set; private get; }

		public static void Open(ModifyType type, int orgId, int identify=-1)
		{
			var self = FT.Forms["应用系统编辑"];
			Type = type;
			OrgId = orgId;
			Identify = identify;
			self.Open();
		}

		public static bool Save()
		{
			var self = FT.Forms["应用系统编辑"];
			if (OrgId == -1)
			{
				var result = MB.Show("请正确选择所属组织");
				((WF.DropDownBox)self.Controls["db_org"]).Select();
				return false;
			}			
			return true;
		}

		#region event
		public static void AfterLoad(FormEventArgs e) {
			((WF.ComboBox)e.Form.Controls["cb_sla"]).ComboList = FT.DataTables["Code"].GetComboListString("label", "[t] = '保障要求'", "v");
			((WF.ComboBox)e.Form.Controls["cb_risk"]).ComboList = FT.DataTables["Code"].GetComboListString("label", "[t] = '风险评级'", "v");
			((WF.ComboBox)e.Form.Controls["cb_stat"]).ComboList = FT.DataTables["Code"].GetComboListString("label", "[t] = '应用程序状态'", "v");

			if (Type == ModifyType.modify)
			{
				e.Form.Text = "修改应用系统";
				var drCI = FT.DataTables["FunctionalCI"].Find(string.Format("_Identify={0}", Identify));
				var drAS = FT.DataTables["ApplicationSolution"].Find(string.Format("id={0}", Identify));
				((WF.TextBox)e.Form.Controls["tb_name"]).Value = (string)drCI["name"];
				((WF.ComboBox)e.Form.Controls["cb_sla"]).SelectedIndex = (int)drAS["code_sla"];
				((WF.ComboBox)e.Form.Controls["cb_risk"]).SelectedIndex = (int)drCI["code_risk_rating"];
				((WF.ComboBox)e.Form.Controls["cb_stat"]).SelectedIndex = (int)drAS["code_application_status"];
				((WF.DateTimePicker)e.Form.Controls["dtp_mtp"]).Value = (DateTime)drCI["move2production"];
				var drOrg = FT.DataTables["Organization"].Find(string.Format("_Identify={0}", OrgId));
				((WF.DropDownBox)e.Form.Controls["db_org"]).Value = (string)drOrg["name"];
			}
			else
			{
				e.Form.Text = "新增应用系统";
				((WF.ComboBox)e.Form.Controls["cb_sla"]).SelectedIndex = 0;
				((WF.ComboBox)e.Form.Controls["cb_risk"]).SelectedIndex = 0;
				((WF.ComboBox)e.Form.Controls["cb_stat"]).SelectedIndex = 0;
				((WF.DateTimePicker)e.Form.Controls["dtp_mtp"]).Value = DateTime.Today;
				var drOrg = FT.DataTables["Organization"].Find(string.Format("_Identify={0}", OrgId));
				((WF.DropDownBox)e.Form.Controls["db_org"]).Value = (string)drOrg["name"];
			}
		}
		#endregion event
	}

	public static class FASDbOrg
	{
		public static void TextChanged(ControlEventArgs e)
		{
			var drp = (WF.DropDownBox)e.Sender;
			if (drp.DroppedDown)
			{
				FormOrgDropDownTree.Filter = drp.Text;
				FormOrgDropDownTree.ReDraw();
			}
		}

		public static void Click(ControlEventArgs e)
		{
			var drp = (WF.DropDownBox)e.Sender;
			if (drp.DroppedDown)
			{
				drp.CloseDropdown();
			}
			else
			{
				FormOrgDropDownTree.Filter = ((WF.DropDownBox)e.Form.Controls["db_org"]).Text; 
				drp.OpenDropDown();
			}
		}

		public static void Leave(ControlEventArgs e)
		{
			var drp = (WF.DropDownBox)e.Sender;
			if (drp.DroppedDown)
			{
				drp.CloseDropdown();
			}
			drp.Value = drp.Text;
			var dr = FT.DataTables["Organization"].Find(string.Format("name='{0}'", drp.Value));
			if (dr is null)
			{
				FormApplicationSolution.OrgId = -1;
			}
			else
			{
				FormApplicationSolution.OrgId = (int)dr["_Identify"];
			}
		}

		public static void KeyPress(ControlKeyPressEventArgs e)
		{
			var drp = (WF.DropDownBox)e.Sender;
			if (!drp.DroppedDown)
			{
				FormOrgDropDownTree.Filter = ((WF.DropDownBox)e.Form.Controls["db_org"]).Text;
				drp.OpenDropDown();
			}
		}
	}

	public static class FASBtCancel
	{
		public static void Click(ControlEventArgs e)
		{
			e.Form.Close();
		}
	}

	public static class FASBtSave
	{
		public static void Click(ControlEventArgs e)
		{
			var result = FormApplicationSolution.Save();
			if (result)
			{
				e.Form.Close();
			}			
		}
	}
}

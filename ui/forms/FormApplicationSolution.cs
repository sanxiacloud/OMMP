﻿using Foxtable;
using System;
using FT = Foxtable.OO_00oOO;
using MB = System.Windows.Forms.MessageBox;
using WF = Foxtable.WinForm;
using ommp.bll.dto;
using service=ommp.bll.service;

namespace ommp.ui
{
	public static class FormApplicationSolution
	{
		private static ModifyType type;
		public static int OrgId { set; private get; }		
		public static ApplicationSolution Origin { set; private get; }

		public static void Open(int orgId)
		{
			var self = FT.Forms["应用系统编辑"];
			type = ModifyType.create;
			OrgId = orgId;
			Origin = null;
			self.Open();
		}
		public static void Open(int orgID, int identify)
		{
			var self = FT.Forms["应用系统编辑"];
			type = ModifyType.modify;
			Origin = service.ApplicationSolutionService.Find(identify);
			OrgId = orgID;
			self.Open();
		}
		public static bool Save()
		{
			var self = FT.Forms["应用系统编辑"];
			var name = (string)((WF.TextBox)self.Controls["tb_name"]).Value;
			if (name == null || name == "")
			{			
				MB.Show("请填写应用系统名称");
				((WF.TextBox)self.Controls["tb_name"]).Select();
				return false;
			}
			if (OrgId == -1)
			{
				MB.Show("请正确选择所属组织");
				((WF.DropDownBox)self.Controls["db_org"]).Select();
				return false;
			}
			var obj = new ApplicationSolution
			{
				Name = name,
				CodeSla = ((WF.ComboBox)self.Controls["cb_sla"]).SelectedIndex,
				Move2Production = (DateTime)((WF.DateTimePicker)self.Controls["dtp_mtp"]).Value,
				CodeRiskRating = ((WF.ComboBox)self.Controls["cb_risk"]).SelectedIndex,
				CodeApplicationStatus = ((WF.ComboBox)self.Controls["cb_stat"]).SelectedIndex,
				Attention = (string)((WF.TextBox)self.Controls["tb_notice"]).Value,
				OrgID = OrgId
			};
			if (type == ModifyType.create)
			{
				var (oid, desc) = service.ApplicationSolutionService.Create(obj);
				if (oid == -1)
				{
					MB.Show("创建失败，请检查数据完整性");
				}
			}
			else
			{
				obj.Identify = Origin.Identify;
				Common.Log(obj.ToString());
				Common.Log(Origin.ToString());
				if (Origin.NotChanged(obj))
				{
					return true;
				}
				var (code, desc) = service.ApplicationSolutionService.Update(obj, Origin.OrgID);
				if (code != 0)
				{
					MB.Show("修改失败，请检查数据完整性");
				}
			}
			return true;
		}			

		#region event
		public static void AfterLoad(FormEventArgs e)
		{
			((WF.ComboBox)e.Form.Controls["cb_sla"]).ComboList = FT.DataTables["Code"].GetComboListString("label", "[t] = '保障要求'", "v");
			((WF.ComboBox)e.Form.Controls["cb_risk"]).ComboList = FT.DataTables["Code"].GetComboListString("label", "[t] = '风险评级'", "v");
			((WF.ComboBox)e.Form.Controls["cb_stat"]).ComboList = FT.DataTables["Code"].GetComboListString("label", "[t] = '应用程序状态'", "v");

			if (type == ModifyType.modify)
			{
				e.Form.Text = "修改应用系统";
				((WF.TextBox)e.Form.Controls["tb_name"]).Value = Origin.Name;
				((WF.ComboBox)e.Form.Controls["cb_sla"]).SelectedIndex = Origin.CodeSla;
				((WF.ComboBox)e.Form.Controls["cb_risk"]).SelectedIndex = Origin.CodeRiskRating;
				((WF.ComboBox)e.Form.Controls["cb_stat"]).SelectedIndex = Origin.CodeApplicationStatus;
				((WF.DateTimePicker)e.Form.Controls["dtp_mtp"]).Value = Origin.Move2Production;
				// todo 改成通过bll获取org信息
				var drOrg = FT.DataTables["Organization"].Find(string.Format("_Identify={0}", Origin.OrgID));
				((WF.DropDownBox)e.Form.Controls["db_org"]).Value = (string)drOrg["name"];
				((WF.TextBox)e.Form.Controls["tb_notice"]).Value = Origin.Attention;
			}
			else
			{
				e.Form.Text = "新增应用系统";
				((WF.TextBox)e.Form.Controls["tb_name"]).Value = "";
				((WF.TextBox)e.Form.Controls["tb_notice"]).Value = "";
				((WF.ComboBox)e.Form.Controls["cb_sla"]).SelectedIndex = 0;
				((WF.ComboBox)e.Form.Controls["cb_risk"]).SelectedIndex = 0;
				((WF.ComboBox)e.Form.Controls["cb_stat"]).SelectedIndex = 1;
				((WF.DateTimePicker)e.Form.Controls["dtp_mtp"]).Value = DateTime.Today;
				// todo 改成通过bll获取org信息
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
				AppLvApp.ReDraw();
			}
		}
	}
}

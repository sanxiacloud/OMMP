using System;
using System.Collections.Generic;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;


namespace ui
{
	public static class AppLvHost
	{
		public static void ReDraw(string appid)
		{
			var form = FT.Forms["主窗口"];
			var lv = (WF.ListView)form.Controls["lv_app_dev_host"];
			var pmSelected = ((WF.CheckBox)form.Controls["cb_app_dev_host_pm"]).Checked;
			var vmSelected = ((WF.CheckBox)form.Controls["cb_app_dev_host_vm"]).Checked;
			
			Clear();
			
			lv.StopRedraw();

			var count = 0;
			foreach (var drLK in FT.DataTables["LnkApplicationSolutionToFunctionalCI"].Select(string.Format("_IsDeleted=0 And applicationsolution_identify={0}", appid))) 
			{
				var drCI = FT.DataTables["FunctionalCI"].Find(string.Format("_Identify={0}", (int)drLK["functionalci_identify"]));
				if ((string)drCI["finalclass"] == "VirtualMachine" && vmSelected)
				{
					var row = lv.Rows.Add();
					var drVM = FT.DataTables["VirtualMachine"].Find(string.Format("id={0}", drLK["functionalci_identify"].ToString()));
					var drIP = FT.DataTables["IPAddressv4"].Find(string.Format("id={0}", drVM["managementip_identify"].ToString()));
					count += 1;
					row["type"] = "虚拟机";
					row["name"] = drCI["name"].ToString();
					row["ip"] = drIP["ip"].ToString();
					row["start_date"] = drCI["move2production"].ToString();
					row["description"] = drCI["description"].ToString();
					row.Tag = drCI;
				}
				else if (drCI["finalclass"].ToString() == "Server" && pmSelected)
				{

				}				
			}

			var tcDev = (WF.TabControl)form.Controls["tc_app_dev"];
			var tabHost = tcDev.TabPages["host"];
			tabHost.Text = string.Format("主机({0})", count);
			lv.ResumeRedraw();

			((WF.Control)form.Controls["bt_app_host_add"]).Enabled = true;
			((WF.Control)form.Controls["cb_app_dev_host_pm"]).Enabled = true;
			((WF.Control)form.Controls["cb_app_dev_host_vm"]).Enabled = true;
		}

		public static void Clear() {
			var form = FT.Forms["主窗口"];
			var lv = (WF.ListView)form.Controls["lv_app_dev_host"];
			lv.StopRedraw();
			lv.Rows.Clear();
			lv.ResumeRedraw();

			var tcDev = (WF.TabControl)form.Controls["tc_app_dev"];
			var tabHost = tcDev.TabPages["host"];
			tabHost.Text = "主机";

			((WF.Control)form.Controls["bt_app_host_add"]).Enabled = false;
			((WF.Control)form.Controls["bt_app_host_del"]).Enabled = false;
			((WF.Control)form.Controls["cb_app_dev_host_pm"]).Enabled = false;
			((WF.Control)form.Controls["cb_app_dev_host_vm"]).Enabled = false;
		}

		#region event
		public static void RowSelectionChanged(ListViewRowEventArgs e) {
			var row = ((WF.ListView)e.Sender).Current;
			if (row != null)
			{
				((WF.Control)e.Form.Controls["bt_app_host_del"]).Enabled = true;
			}
		}
		#endregion event
	}
}

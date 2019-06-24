using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using ommp.bll.service;
using ommp.bll.dto;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;


namespace ommp.ui
{
	public static class AppLvHost
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static void ReDraw(int appid=0)
		{
			log.Debug("In AppLvHost->Redraw:");
			var form = FT.Forms["主窗口"];
			if (appid == 0)
			{
				var row = ((WF.ListView)form.Controls["lv_app_app"]).Current;
				var app = (ApplicationSolution)row.Tag;
				appid = app.Identify;
			}
			
			var lv = (WF.ListView)form.Controls["lv_app_dev_host"];
			var pmSelected = ((WF.CheckBox)form.Controls["cb_app_dev_host_pm"]).Checked;
			var vmSelected = ((WF.CheckBox)form.Controls["cb_app_dev_host_vm"]).Checked;
			log.Debug(string.Format("\tApplicationSolution ID is '{0}'", appid));
			Clear();
			
			lv.StopRedraw();

			var count = 0;
			var hosts = HostService.ListByApplicationSolution(appid, vmSelected, pmSelected);
			log.Debug(string.Format("\tGot {0} hosts", hosts.Count));
			foreach (var host in hosts)
			{
				log.Debug(string.Format("\tHost : {0}", host.ToString()));
				var row = lv.Rows.Add();
				count += 1;				
				row["name"] = host.Name;
				row["ip"] = host.IP;
				row["start_date"] = host.Move2Production.ToString("yyyy-MM-dd");
				row["description"] = host.Description;
				row["type"] = host.TypeName;				
				row.Tag = host;
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

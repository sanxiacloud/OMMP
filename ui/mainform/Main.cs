using System;
using System.Collections.Generic;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;

namespace ommp.ui
{
	public class MainForm
	{
		public static void AfterLoad(FormEventArgs e) {

			AppTvOrg.ReDraw();

			var form = e.Form;
			var lvApp = (WF.ListView)form.Controls["lv_app_app"];
			string[] colAppn = { "name", "organization", "status", "start_date", "sla" };
			string[] colAppt = { "应用名称", "归属单位", "系统状态", "上线日期", "保障要求" };
			int[] colAppw = { 240, 150, 75, 95, 95 };
			Common.InitListView(lvApp, colAppn, colAppt, colAppw);

			var lvHost = (WF.ListView)form.Controls["lv_app_dev_host"];
			string[] colHostn = { "type", "name", "ip", "start_date", "description" };
			string[] colHostt = { "主机类型", "主机名称", "IP", "上线日期", "描述" };
			int[] colHostw = { 100, 200, 120, 120, 120 };
			Common.InitListView(lvHost, colHostn, colHostt, colHostw);
		}
	}
}

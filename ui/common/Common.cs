using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;

namespace ui
{
	public enum ModifyType
	{
		modify,
		create
	}

	class Common
	{
		public static void InitListView(WF.ListView lv, string[] names, string[] texts, int[] wds=null) {
			lv.StopRedraw();
			lv.MultiSelect = false;
			lv.Columns.Clear();
			lv.Rows.Clear();
			lv.Images.Clear();
			lv.View = View.Details;
			lv.GridLines = true;

			for (int i = 0; i < names.Length; i++)
			{
				var col = lv.Columns.Add();
				col.Text = texts[i];
				col.Name = names[i];
				if (wds != null)
				{
					col.Width = wds[i];
				}
			}

			lv.ResumeRedraw();
		}

		public static void ClearListView(WF.ListView lv) {
			lv.StopRedraw();
			lv.Rows.Clear();
			lv.ResumeRedraw();
		}

		
	}	
		
}

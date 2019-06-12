using System;
using System.Collections.Generic;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;

namespace bll
{
    public class Common
    {
		public static string TranslateCode(string type, int code) {
			var dt = FT.DataTables["Code"];
			var dr = dt.Find(string.Format("t='{0}' And v={1}", type, code));
			if (dr is null)
			{
				return "参数错误";
			}
			else
			{
				return (string)dr["label"];
			}
		}
    }
}

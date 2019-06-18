using System;
using System.Collections.Generic;
using System.Text;
using FT = Foxtable.OO_00oOO;
using WF = Foxtable.WinForm;
using Foxtable;
using ommp;
using ommp.bll;
using ommp.bll.service;
using System.IO;

namespace ommp.bll.service
{
	public static class CommonService
	{		
		public static string TranslateCode(string type, int code)
		{
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

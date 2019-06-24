using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using ommp.bll.dto;
using ommp.dal.dao;
using dato = ommp.dal.dto;

namespace ommp.bll.service
{
	public class HostService
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static IList<Host> ListByApplicationSolution(int asid, bool needVM, bool needPM)
		{
			var list = new List<Host>();
			if (needVM)
			{
				foreach (var vm in VirtualMachineService.ListByApplicationSolution(asid))
				{
					list.Add(vm);
				}
			}
			if (needPM)
			{
				//todo 增加物理机相关操作
			}			
			return list;
		}

		public static Host Find(int identify)
		{
			var ret = VirtualMachineService.Find(identify);
			if (ret == null)
			{
				//todo 加入物理机
			}
			return ret;
		}
	}
}

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
	public class VirtualMachineService
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		static readonly VirtualMachineDAO vmdao;
		static readonly IPAddressv4DAO ipdao;
		static readonly LnkApplicationSolutionToFunctionalCIDAO lkdao;

		static VirtualMachineService()
		{
			vmdao = new VirtualMachineDAO();
			ipdao = new IPAddressv4DAO();
			lkdao = new LnkApplicationSolutionToFunctionalCIDAO();
		}

		public static IList<VirtualMachine> ListByApplicationSolution(int asid)
		{
			log.Debug("In VirtualMachieService->ListByApplicationSolution:");
			var vmlist = new List<VirtualMachine>();
			var lnks = lkdao.ListByLeft(asid);
			log.Debug(string.Format("\tGot {0} Lnks", lnks.Count));
			foreach (var lnk in lnks)
			{
				var vm = vmdao.Find(lnk.functionalci_identify);
				log.Debug(string.Format("\t\tGot VM: {0}", vm.ToString()));
				if (vm != null)
				{
					var ipObj = ipdao.Find(vm.managementip_identify);
					log.Debug(string.Format("\t\tGot IPv4Obj: {0}", ipObj.ToString()));
					var ip = "";
					if (ipObj == null)
					{
						ip = ipObj.ip;
					}
					vmlist.Add(new VirtualMachine(vm, ip));								
				}
			}
			return vmlist;
		}

		public static VirtualMachine Find(int identify)
		{
			log.Debug("In VirtualMachieService->Find:");
			var vm = vmdao.Find(identify);
			log.Debug(string.Format("\tGot VM: {0}", vm.ToString()));
			if (vm == null)
			{
				return null;
			}
			var ipObj = ipdao.Find(vm.managementip_identify);
			log.Debug(string.Format("\tGot IPv4Obj: {0}", ipObj.ToString()));
			var ip = "";
			if (ipObj == null)
			{
				ip = ipObj.ip;
			}
			return new VirtualMachine(vm, ip);
		}


	}
}

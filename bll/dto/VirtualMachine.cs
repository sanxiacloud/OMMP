using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dato = ommp.dal.dto;

namespace ommp.bll.dto
{
	public class VirtualMachine : Host
	{
		public VirtualMachine()
		{
			Type = HostType.vm;
		}
		public VirtualMachine(dato.VirtualMachine vm, string ip=""): this()
		{
			Identify = vm._Identify;
			Name = vm.name;
			Move2Production = vm.move2production;
			Description = vm.description;
			IP = ip;
		}

		public dato.VirtualMachine GetDalDTO()
		{
			return new dato.VirtualMachine
			{
				name = Name,
				_Identify = Identify,
				move2production = Move2Production,
				description = Description
			};
		}
	}
}

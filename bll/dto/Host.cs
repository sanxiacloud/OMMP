using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ommp.bll.dto
{
	public enum HostType
	{
		vm,
		pm
	}
	public class Host : BaseDTO
	{

		public int Identify { set; get; }
		public string Name { set; get; }
		public string IP { set; get; }
		public DateTime Move2Production { set; get; }
		public string Description { set; get; }
		public HostType Type { protected set; get; }
		public string TypeName
		{
			get
			{
				if (Type == HostType.vm)
				{
					return "虚拟机";
				}
				else
				{
					return "物理机";
				}
			}
		}


	}
}

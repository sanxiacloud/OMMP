using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dato = ommp.dal.dto;

namespace ommp.bll.dto
{
	public class Organization: BaseDTO
	{
		public int Identify { set; get; }
		public string Name { set; get; }
		public int Parent { set; get; }
		public bool Status { set; get; }
		public string Code { set; get; }
		public string ShortName { set; get; }
		public string Description { set; get; }

		public Organization(dato.Organization o)
		{
			Identify = o._Identify;
			Name = o.name;
			Parent = o.parent_identify;
			Status = o.status;
			Code = o.code;
			ShortName = o.short_name;
			Description = o.description;
		}
	}
}

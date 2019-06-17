using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ommp.bll.service;

namespace ommp.bll.dto
{
	public class BaseDTO
	{
		public bool NotChanged(BaseDTO other)
		{
			var type = this.GetType();
			var otype = other.GetType();
			if (type != otype)
			{
				return false;
			}
			foreach (var pi in type.GetProperties())
			{
				if (pi.Name != "Identify" && pi.Name != "Id")
				{
					// !!! 无法用==进行比较，否则比较的是地址
					if (!object.Equals(pi.GetValue(this, null), pi.GetValue(other, null)))
					{
						CommonService.Log(string.Format("diff in {0}", pi.Name));
						return false;
					}
				}
			}
			return true;
		}

		public override string ToString()
		{
			var type = GetType();
			var sb = new StringBuilder();
			sb.Append(string.Format("{0} object:\n", type.Name));
			foreach (var pi in type.GetProperties())
			{
				sb.Append(string.Format("'\t{0}({1})' is '{2}'\n", pi.Name, pi.PropertyType, pi.GetValue(this, null)));
			}
			return sb.ToString();
		}
	}
}

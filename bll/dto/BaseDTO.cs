using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using ommp.bll.service;

namespace ommp.bll.dto
{
	public class BaseDTO
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
						log.Info(string.Format("Found differ in attribute '{0}'", pi.Name));
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
				if (pi.GetValue(this, null) == null)
				{
					sb.Append(string.Format("'\t{0}({1})' is null\n", pi.Name, pi.PropertyType));
				}
				else
				{
					sb.Append(string.Format("'\t{0}({1})' is '{2}'\n", pi.Name, pi.PropertyType, pi.GetValue(this, null)));
				}		
			}
			return sb.ToString();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ommp.bll.dto
{
	public class ApplicationSolution : BaseDTO
	{
		public int Identify { set; get; }
		public string Name { set; get; }
		public string Attention { set; get; }
		public int CodeSla { set; get; }
		public int CodeRiskRating { set; get; }
		public int CodeApplicationStatus { set; get; }
		public DateTime Move2Production { set; get; }
		public int OrgID { set; get; }		
	}
}

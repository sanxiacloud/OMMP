using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dato=ommp.dal.dto;

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


		public ApplicationSolution()
		{
		}
		public ApplicationSolution(dato.ApplicationSolution o, int orgid=0)
		{
			if (o != null)
			{
				Identify = o._Identify;
				Name = o.name;
				Attention = o.attention;
				CodeSla = o.code_sla;
				CodeRiskRating = o.code_risk_rating;
				CodeApplicationStatus = o.code_application_status;
				Move2Production = o.move2production;
				OrgID = orgid;
			}
		}

		public dato.ApplicationSolution GetDalDTO()
		{
			return new dato.ApplicationSolution
			{
				name = Name,
				code_application_status = CodeApplicationStatus,
				code_risk_rating = CodeRiskRating,
				code_sla = CodeSla,
				attention = Attention,
				move2production = Move2Production,
				_Identify = Identify
			};
		}
	}
}

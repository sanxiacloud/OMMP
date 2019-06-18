using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ommp.bll.dto;
using ommp.dal.dao;
using dato=ommp.dal.dto;
using FT = Foxtable.OO_00oOO;

namespace ommp.bll.service
{
	public class ApplicationSolutionService
	{
		static readonly ApplicationSolutionDAO odao;
		static readonly LnkFunctionalCIToOrganizationDAO ldao;
		static ApplicationSolutionService()
		{
			odao = new ApplicationSolutionDAO();
			ldao = new LnkFunctionalCIToOrganizationDAO();
		}

		public static ApplicationSolution Find(int identify)
		{
			var obj = odao.FindObject <dato.ApplicationSolutionQT>(identify);
			//todo 需切换为dal查询
			var drLK = FT.DataTables["LnkFunctionalCIToOrganization"].Find(string.Format("_IsDeleted=0 And functionalci_identify={0}", identify));
			return new ApplicationSolution
			{
				Identify = identify,
				Name = obj.name,
				Attention = obj.attention,
				CodeSla = obj.code_sla,
				CodeRiskRating = obj.code_risk_rating,
				CodeApplicationStatus = obj.code_application_status,
				Move2Production = obj.move2production,
				OrgID = (int)drLK["organization_identify"]
			};
		}

		public static (int oid, string desc) Create(ApplicationSolution o)
		{
			var obj = new dato.ApplicationSolution
			{
				name = o.Name,
				code_application_status = o.CodeApplicationStatus,
				code_risk_rating = o.CodeRiskRating,
				code_sla = o.CodeSla,
				attention = o.Attention,
				move2production = o.Move2Production
			};
			var oid = odao.Insert(obj);
			if (oid != -1)
			{
				if (!ldao.Link(oid, o.OrgID))				
				{
					odao.Delete(oid);
					oid = -1;
				}
			}
			return (oid, "");
		}

		public static (int code, string desc) Update(ApplicationSolution o, int oOrgID)
		{
			var code = -1;
			var desc = "";
			var obj = new dato.ApplicationSolution
			{
				name = o.Name,
				code_application_status = o.CodeApplicationStatus,
				code_risk_rating = o.CodeRiskRating,
				code_sla = o.CodeSla,
				attention = o.Attention,
				move2production = o.Move2Production,
				_Identify = o.Identify
			};
			var ret = odao.Update(obj);
			if (ret)
			{
				if (o.OrgID != oOrgID)
				{
					if (ldao.UnLink(o.Identify, oOrgID) && ldao.Link(o.Identify, o.OrgID))
					{
						code = 0;
					}
				}
				else
				{
					code = 0;
				}
			}
			return (code, desc);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using ommp.bll.dto;
using ommp.bll.dto.structure;
using ommp.dal.dao;
using dato=ommp.dal.dto;

namespace ommp.bll.service
{
	public class ApplicationSolutionService
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		static readonly ApplicationSolutionDAO odao;
		static readonly LnkFunctionalCIToOrganizationDAO ldao;

		static ApplicationSolutionService()
		{
			odao = new ApplicationSolutionDAO();
			ldao = new LnkFunctionalCIToOrganizationDAO();
		}

		public static IList<ApplicationSolution> ListByOrganization(int orgid)
		{
			var aslist = new List<ApplicationSolution>();
			var lnks = ldao.ListByRight(orgid);			
			foreach (var lnk in lnks)
			{
				var app = odao.Find(lnk.functionalci_identify);
				if (app != null)
				{
					aslist.Add(new ApplicationSolution(app, orgid));				
				}				
			}
			return aslist;
		}

		public static IList<ApplicationSolution> ListByOrganizationTreeNode(TreeNode<Organization> rnode)
		{
			var aslist = new List<ApplicationSolution>();
			var stack1 = new Stack<TreeNode<Organization>>();
			var stack2 = new Stack<TreeNode<Organization>>();
			stack1.Push(rnode);
			TreeNode<Organization> curNode;
			while (stack1.Count > 0)
			{
				curNode = stack1.Pop();
				stack2.Push(curNode);
				for (int i = 0; i < curNode.Nodes.Count; i++)
				{
					stack1.Push(curNode.Nodes[i]);
				}
			}
			foreach (var node in stack2)
			{
				var org = node.Data;
				var lnks = ldao.ListByRight(org.Identify);
				foreach (var lnk in lnks)
				{
					var app = odao.Find(lnk.functionalci_identify);
					if (app != null)
					{
						aslist.Add(new ApplicationSolution(app, org.Identify));
					}
				}
			}
			return aslist;
		}

		public static ApplicationSolution Find(int identify)
		{
			var obj = odao.Find(identify);
			if (obj == null)
			{
				return null;
			}
			var lk = ldao.ListByLeft(identify);
			var orgid = 0;
			if (lk != null)
			{
				orgid = lk[0].organization_identify;
			}
			return new ApplicationSolution(obj, orgid);			
		}

		public static (int oid, string desc) Create(ApplicationSolution o)
		{
			var obj = o.GetDalDTO();
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
			var obj = o.GetDalDTO();
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

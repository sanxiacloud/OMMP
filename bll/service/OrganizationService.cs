using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using ommp.bll.dto;
using ommp.bll.dto.structure;
using ommp.dal.dao;
using dato = ommp.dal.dto;

namespace ommp.bll.service
{
	public class OrganizationService
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		static readonly OrganizationDAO odao;

		static OrganizationService()
		{
			odao = new OrganizationDAO();
		}

		public static IList<Organization> List()
		{
			return null;
		}

		public static TreeNode<Organization> GetOrganizationTree(string filter)
		{
			var orgs = odao.List(string.Format("name like '%{0}%'", filter, "code"));
			if (orgs.Count == 0)
			{
				return null;
			}
			var rNode = new TreeNode<Organization>(new Organization(odao.Find(515)));			
			foreach (var org in orgs)
			{
				var len = 5;
				var pnode = rNode;
				while (len <= org.code.Length)
				{
					var ancOrg = odao.Find(string.Format("code='{0}'", org.code.Substring(0, len)));
					var ancNode = new TreeNode<Organization>(new Organization(ancOrg));
					if (!pnode.Nodes.Contains(ancOrg.code))
					{
						pnode.Nodes.Add(ancOrg.code, ancNode);
						pnode = ancNode;
					}
					else
					{
						pnode = pnode.Nodes[ancOrg.code];
					}
					len += 3;
				}				
			}
			return rNode;
		}

		public static Organization Find(int identify)
		{
			var obj = odao.Find(identify);
			if (obj == null)
			{
				return null;
			}
			return new Organization(obj);
		}

		public static Organization FindByName(string name)
		{
			var obj = odao.Find(string.Format("name='{0}'", name));
			if (obj == null)
			{
				return null;
			}
			return new Organization(obj);
		}
	}
}

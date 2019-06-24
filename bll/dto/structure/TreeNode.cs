using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using log4net;

namespace ommp.bll.dto.structure
{
	public class TreeNode<T>
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		//private List<TreeNode<T>> children;
		private readonly TreeNodes<T> children;

		public TreeNode<T> Parent { set; get; }
		public T Data { private set; get; }

		public TreeNodes<T> Nodes
		{
			get
			{
				return children;
			}
		}

		public TreeNode(T data)
		{
			Data = data;
			children = new TreeNodes<T>(this);			
		}

		public TreeNode<T> FindNode(string key=null)
		{
			if (key == null)
			{
				return this;
			}
			var queue = new Queue<TreeNode<T>>();
			queue.Enqueue(this);
			while (queue.Count > 0)
			{
				var pnode = queue.Dequeue();
				if (pnode.Nodes.Contains(key))
				{
					return pnode.Nodes[key];
				}
				for (int i = 0; i < pnode.Nodes.Count; i++)
				{
					queue.Enqueue(pnode.Nodes[i]);
				}
			}

			return null;
		}

		private IDictionary<string, TreeNode<T>> AllNodes
		{
			get
			{
				var allnodes = new Dictionary<string, TreeNode<T>>();

				return allnodes;
			}
			
		}

	}
}

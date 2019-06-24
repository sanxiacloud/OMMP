using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using log4net;

namespace ommp.bll.dto.structure
{
	public class TreeNodes<T>:IDictionary<string, TreeNode<T>>
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private readonly OrderedDictionary nodes;
		private TreeNode<T> parent;
		public TreeNode<T> Parent
		{
			set
			{
				parent = value;
				foreach (var tn in this.Values)
				{
					tn.Parent = value;
				}
			}
			get
			{
				return parent;
			}
		}

		public TreeNodes(TreeNode<T> parent)
		{
			//由于Parent set中使用到了nodes，需要在parent赋值之前声明
			nodes = new OrderedDictionary();
			Parent = parent;			
		}

		public TreeNode<T> this[string key]
		{
			get
			{	
				return (TreeNode<T>)nodes[key];
			}		
		}

		public TreeNode<T> this[int key]
		{
			get
			{
				return (TreeNode<T>)nodes[key];
			}
		}

		public int Count
		{
			get
			{
				return nodes.Count;
			}
		}

		public ICollection<string> Keys
		{
			get
			{
				var coll = new List<string>();
				foreach (var key in nodes.Keys)
				{
					coll.Add((string)key);
				}
				return coll;
			}
		}

		public ICollection<TreeNode<T>> Values
		{
			get
			{
				var coll = new List<TreeNode<T>>();
				foreach (var value in nodes.Values)
				{
					coll.Add((TreeNode<T>)value);
				}
				return coll;
			}
		}

		public bool IsReadOnly => throw new NotImplementedException();

		TreeNode<T> IDictionary<string, TreeNode<T>>.this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void Add(string key, TreeNode<T> value)
		{
			if (this.Contains(key))
			{
				log.Warn(string.Format("Key '{0}' already existed, Current value will be override!!", key));
			} 
			nodes.Add(key, value);
			value.Parent = Parent;
		}

		public void Add(KeyValuePair<string, TreeNode<T>> item)
		{
			Add(item.Key, item.Value);
		}

		public bool Contains(KeyValuePair<string, TreeNode<T>> item)
		{
			throw new NotImplementedException();
		}

		public bool Contains(string key)
		{
			return nodes.Contains(key);
		}

		public bool ContainsKey(string key)
		{
			throw new NotImplementedException();
		}

		public bool Remove(string key)
		{
			throw new NotImplementedException();
		}

		public bool TryGetValue(string key, out TreeNode<T> value)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public void CopyTo(KeyValuePair<string, TreeNode<T>>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool Remove(KeyValuePair<string, TreeNode<T>> item)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<KeyValuePair<string, TreeNode<T>>> GetEnumerator()
		{
			return (IEnumerator < KeyValuePair<string, TreeNode<T>>>)nodes.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}

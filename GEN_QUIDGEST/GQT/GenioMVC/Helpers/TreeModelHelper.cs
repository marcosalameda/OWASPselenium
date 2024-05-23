using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Helpers
{
	public class TreeViewControl<T> where T : class
	{
		private TreeBranchInfo<T> Root => Branches.TryGetValue(0, out TreeBranchInfo<T> root) ? root : null;
		private readonly Dictionary<int, TreeBranchInfo<T>> Branches = new Dictionary<int, TreeBranchInfo<T>>();

		public void AddBranch(TreeBranchInfo<T> branch)
		{
			if (Branches.Count != 0)
			{
				TreeBranchInfo<T> _branch = Branches.Last().Value;
				branch.Parent = _branch;
				_branch.Child = branch;
			}

			branch.BranchLevel = Branches.Count;
			Branches.Add(Branches.Count, branch);
		}

		public ICollection<TreeNode> BuildTree(IEnumerable<T> items, bool orderBySelector)
		{
			return Root?.BuildBranch(items, orderBySelector) ?? new List<TreeNode>();
		}

		/// <summary>
		/// PROTO
		/// </summary>
		/// <param name="branchId"></param>
		/// <param name="selectedKey"></param>
		/// <param name="selectedIdentifier"></param>
		/// <returns></returns>
		public CriteriaSet GetBranchCondition(int branchId, string selectedKey, string selectedIdentifier)
		{
			CriteriaSet condition = null;

			if (Branches.TryGetValue(branchId, out TreeBranchInfo<T> branch))
			{
				if (branch.IsTree == false && (bool)(branch.Child?.IsTree))
				{
					condition = CriteriaSet.And()
						.Equal(branch.SqlKeySelector, selectedKey);
				}
			}

			return condition;
		}
	}

	public class TreeBranchInfo<T> where T : class
	{
		public int BranchLevel { get; set; } = 0;

		/// <summary>
		/// Reflection to obter a key primaria do registo que pertence a TreeNode
		/// </summary>
		public Func<T, string> KeySelector { get; set; }

		/// <summary>
		/// Campo para obter a key primaria do registo que pertence a TreeNode
		/// </summary>
		public FieldRef SqlKeySelector { get; set; }

		/// <summary>
		/// Reflection to obter identifier do TreeNode
		/// </summary>
		public Func<T, string> Selector { get; set; }

		/// <summary>
		/// Campo para obter identifier do TreeNode
		/// </summary>
		public FieldRef SqlSelector { get; set; }

		/// <summary>
		/// Reflection to obter identifier do parent TreeNode
		/// </summary>
		public Func<T, string> ParentSelector { get; set; }

		/// <summary>
		/// Campo para obter identifier do parent TreeNode
		/// </summary>
		public FieldRef SqlParentSelector { get; set; }

		/// <summary>
		/// Reflection to obter o text que irá aparecer na interface
		/// </summary>
		public Func<T, string> TextSelector { get; set; }

		/// <summary>
		/// Expresão para obter o text que irá aparecer na interface
		/// </summary>
		public ISqlExpression SqlTextSelector { get; set; }

		public FieldRef[] SqlTextFieldsSelector { get; set; }

		/// <summary>
		/// Reflection to obter qual registo que irá ser usado to obter o text do groupo dos TreeNodes.
		/// Só usado no BuildBranch quando criado um ramo do level a cima, antes de criar o prximo level da arvore.
		/// </summary>
		/// <remarks>
		/// Normalmente preenchido por código manual to customizar a arvore.
		/// </remarks>
		public Func<T, bool> GroupSelector { get; set; }

		/// <summary>
		/// Reflection para obter o valor do nível do TreeNode
		/// </summary>
		public Func<T, decimal> LevelSelector { get; set; }

		/// <summary>
		/// Campo para obter o valor do nível do TreeNode
		/// </summary>
		public FieldRef SqlLevelSelector { get; set; }

		/// <summary>
		/// Reflection to obter o byte array do icon que irá aparecer na interface
		/// </summary>
		public Func<T, byte[]> ImageSelector { get; set; }

		public FieldRef SqlImageSelector { get; set; }

		public TreeBranchInfo<T> Parent;

		public TreeBranchInfo<T> Child;

		/// <summary>
		/// Identifica se os dados do Branch atual estão com estrutura em arvore
		/// </summary>
		public bool IsTree { get; set; }

		public bool IsTreeTable { get { return ParentSelector != null && LevelSelector != null; } }

		public string Area { get; set;  }

		public string Form { get; set; }

		public TreeNode CreateNode(T element)
		{
			var node = new TreeNode();

			if (Selector != null)
				node.Identifier = Selector(element);
			if (ParentSelector != null)
				node.ParentIdentifier = ParentSelector(element);
			if (LevelSelector != null)
				node.Level = LevelSelector(element);
			if (TextSelector != null)
				node.Text = TextSelector(element);
			if (KeySelector != null)
				node.Key = KeySelector(element);
			if (ImageSelector != null)
				node.ImageData = ImageSelector(element);
			// Insert form information
			if (!IsTree && Child != null)
			{
				node.InsertFormArea = Child.Area;
				node.InsertFormName = Child.Form;
			}
			else if (IsTree)
			{
				node.InsertFormArea = Area;
				node.InsertFormName = Form;
			}
			// Support form
			node.Area = Area;
			node.Form = Form;

			// Fields
			node.Fields = element;

			node.Action = string.Empty;
			return node;
		}

		public ICollection<TreeNode> BuildBranch(IEnumerable<T> items, bool orderBySelector)
		{
			var nodes = new List<TreeNode>();

			if (IsTree)
				return BuildTree(items, orderBySelector);
			else
			{
				var itemGroups = items.GroupBy(i => Selector(i));
				foreach (IGrouping<string, T> group in itemGroups)
				{
					TreeNode node = null;
					if (GroupSelector == null)
						node = CreateNode(group.ElementAt(0));
					else
					{
						var g = group.Where(GroupSelector).FirstOrDefault();
						node = CreateNode(g ?? group.ElementAt(0));
					}

					node.Children.AddRange(Child.BuildBranch(group, orderBySelector));
					nodes.Add(node);
				}
			}

			return nodes;
		}

		/// <summary>
		/// Generic method to build the tree model of a list of entities given a selector to pivot the table into a tree
		/// </summary>
		/// <typeparam name="TModel">The type of the model at each node</typeparam>
		/// <param name="entityList">The list of entities to transform into a tree</param>
		/// <param name="orderBySelector">Order the entity list by selector</param>
		/// <returns>The tree form of the original list</returns>
		private ICollection<TreeNode> BuildTree(IEnumerable<T> entityList, bool orderBySelector)
		{
			//Order the entity list by selector
			if (orderBySelector)
				entityList = entityList.OrderBy(x => Selector(x));

			//Create TreeNodes for all elements
			var treeNodes = new List<TreeNode>();
			var entityGroups = entityList.GroupBy(i => Selector(i));
			foreach (IGrouping<string, T> group in entityGroups)
			{
				var firstGroupElement = group.First();
				treeNodes.Add(CreateNode(firstGroupElement));
			}

			//Calculate the children of each node

			//MH - Por enquanto, devolvemos todos itens para poder processar os ramos seguintes
			treeNodes = GetChildren(treeNodes, entityList, orderBySelector);

			//Next level childs
			if (Child?.ParentSelector != null)
			{
				treeNodes.FindAll(x => x.Children == null || x.Children.Count == 0).ForEach(lastChild =>
				{
					IEnumerable<T> group = entityList.Where(i => Child.ParentSelector(i) == lastChild.Identifier);
					lastChild.Children.AddRange(Child.BuildBranch(group, orderBySelector));
				});
			}

			//filter the final list to only include the top nodes
			return treeNodes.FindAll(x => x.hasParent == false);
		}

		private List<TreeNode> GetChildren(List<TreeNode> treeNodes, IEnumerable<T> entityList, bool orderBySelector)
		{
			ILookup<string, TreeNode> childNodesByParentId = null;
			ILookup<int, TreeNode> childNodesByIdLength = null;
			ILookup<string, T> entityById = null;

			if (IsTreeTable || ParentSelector != null)
				childNodesByParentId = treeNodes.ToLookup(n => n.ParentIdentifier);
			else
				childNodesByIdLength = treeNodes.ToLookup(n => n.Identifier.Length);

			if (IsTree && Child != null)
				entityById = entityList.ToLookup(row => Selector(row));

			//Calculate the children of each node
			foreach (TreeNode node in treeNodes)
			{
				IEnumerable<TreeNode> childs = null;
				if (IsTreeTable || ParentSelector != null)
				{
					if (childNodesByParentId.Contains(node.Identifier))
						childs = childNodesByParentId[node.Identifier];
				}
				else
				{
					int levelLength = 1,
						currentLevelLength = node.Identifier.Length + levelLength;

					if (childNodesByIdLength.Contains(currentLevelLength))
					{
						var _childs = childNodesByIdLength[currentLevelLength];
						childs = _childs.Where(n => n.Identifier.StartsWith(node.Identifier));
					}
				}

				if (IsTree && Child != null && entityById.Contains(node.Identifier))
				{
					var group = entityById[node.Identifier];
					node.Children.AddRange(Child.BuildBranch(group, orderBySelector));
				}

				if (childs != null)
					node.Children.AddRange(childs);
				node.Children.ForEach(c => c.hasParent = true);
			}

			return treeNodes;
		}
	}
}

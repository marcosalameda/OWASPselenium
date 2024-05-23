using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GenioMVC.Helpers
{
	/// <summary>
	/// Simple implementation of a generic tree node
	/// </summary>
	public class TreeNode
	{
		/// <summary>
		/// Def-Constructor
		/// </summary>
		public TreeNode()
		{
			Children = new List<TreeNode>();
		}

		/// <summary>
		/// Has Parent?
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool hasParent { get; set; }

		/// <summary>
		/// List containing all the children of this node
		/// </summary>
		public List<TreeNode> Children { get; set; }

		/// <summary>
		/// Get visual value of TreeNode
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Identifier of TreeNode
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public string Identifier { get; set; }

		/// <summary>
		/// Identifier of Parent TreeNode
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public string ParentIdentifier { get; set; }

		/// <summary>
		/// Level of TreeNode
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public decimal Level { get; set; }

		/// <summary>
		/// Area
		/// </summary>
		public string Area { get; set; }

		/// <summary>
		/// Form name
		/// </summary>
		public string Form { get; set; }

		/// <summary>
		/// Key value
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// Action (HTML)
		/// </summary>
		public string Action { get; set; }

		/// <summary>
		/// Icon
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public byte[] ImageData { get; set; }

		/// <summary>
		/// Icon (HTML)
		/// </summary>
		public string Image { get; set; } = null;

		/// <summary>
		/// Node Fields
		/// </summary>
		public object Fields { get; set; }

		/// <summary>
		/// Insert support form area
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public string InsertFormArea { get; set; }

		/// <summary>
		/// Insert support form name
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public string InsertFormName { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace GenioMVC
{
	public class SpecialRenderingsCfg
	{
		/// <summary>
		/// The special renderings of this menu 
		/// </summary>
		public List<SpecialRendering> SpecialRenderings { get; set; }
		
		/// <summary>
		/// Returns if the control is in exclusive mode
		/// </summary>
		public bool InExclusiveMode()
		{
			return SpecialRenderings.Count == 2;
		}
	}
	
	/// <summary>
	/// Specifies a special rendering type 
	/// </summary>
	public class SpecialRendering
	{
		public string Id { get; set; }
		public int Ordem { get; set; }
		public string Subtipo { get; set; }
		public List<SpecialRenderingVariable> MappingVariables { get; set; }
		public List<SpecialRenderingVariable> StyleVariables { get; set; }
	}

	/// <summary>
	/// Specifies a special rendering variable
	/// </summary>
	public class SpecialRenderingVariable
	{
		public string Value { get; set; }
		public string Variable { get; set; }
		public bool AllowMultiple { get; set; }
	}
}

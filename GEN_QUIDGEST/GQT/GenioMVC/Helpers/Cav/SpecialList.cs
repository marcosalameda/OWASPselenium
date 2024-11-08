using System;
using System.Collections.Generic;

namespace GenioMVC.Helpers.Cav
{
	public class SpecialList : List<string>
	{
		public LineType Type { get; set; }

		public string[] Items
		{
			get
			{
				return this?.ToArray();
			}
		}
	}

}
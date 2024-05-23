using System.Collections.Generic;

namespace GenioMVC.Helpers
{
	public class TableFilterField
	{
		public string Field { get; set; }
		public string Area { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
		public bool DefaultSearch { get; set; }
		public Dictionary<string, string> Array { get; set; }
		public bool DistinctValue { get; set; }

		public TableFilterField(string area, string field, string title, string type, Dictionary<string, string> array, bool defaultSearch = false, bool distinctValue = false)
		{
			this.Area = area;
			this.Field = field;
			this.Title = title;
			this.Type = type;
			this.Array = array;
			this.DefaultSearch = defaultSearch;
			this.DistinctValue = distinctValue;
		}

		public TableFilterField(string area, string field, string title, string type, bool defaultSearch = false, bool distinctValue = false) : this(area, field, title, type, new Dictionary<string, string>(), defaultSearch, distinctValue) {}

		public string FullName()
		{
			return this.Area + "." + this.Field;
		}
	}
}
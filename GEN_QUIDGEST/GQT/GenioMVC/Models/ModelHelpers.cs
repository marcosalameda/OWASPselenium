using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Models
{
	public class RefreshDBedit
	{
		public string OModel { get; set; }

		public string DModel { get; set; }

		public int Elements { get; set; }

		public Dictionary<string, string> FilterFields { get; set; }

		//area : [field]
		public Dictionary<string, List<string>> Fields { get; set; }

		// Last updated by [CJP] at [2015.02.02]
		// Receives the control identifier so that it uses the correct query
		[Newtonsoft.Json.JsonIgnore]
		public string Identifier { get; set; }
	}

	public class ReloadDBedit
	{
		public string Model { get; set; }

		public int Elements { get; set; }

		//area : [field: value]
		public Dictionary<string, Dictionary<string, string>> FilterFields { get; set; }

		//area : [field: order]
		public Dictionary<string, Dictionary<string, string>> Sorts { get; set; }

		//area : [field]
		public Dictionary<string, List<string>> Fields { get; set; }

		// Last updated by [CJP] at [2015.02.06]
		// Receives the control identifier so that it uses the correct query
		[Newtonsoft.Json.JsonIgnore]
		public string Identifier { get; set; }
	}
	
	public class FlashModel
	{
		public string Type { get; set; }
		
		public string Id { get; set; }
		
		public string Function { get; set; }

		public string ExternalInterface { get; set; }

		public string Command { get; set; }

		public string Parameter { get; set; }

		public List<string> HistoryKeys { get; set; }
	}
}

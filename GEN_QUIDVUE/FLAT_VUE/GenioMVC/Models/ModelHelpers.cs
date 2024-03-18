using System.Text.Json.Serialization;

using CSGenio.framework;
using GenioMVC.ViewModels.Dashboard;

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
		[JsonIgnore]
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
		[JsonIgnore]
		public string Identifier { get; set; }
	}

	/// <summary>
	/// Enables the parsing of Id requests sent through Json in the http Body
	/// </summary>
	public class RequestIdModel
	{
		public string Id { get; set; } = string.Empty;
	}

	public class RequestOpenModel : RequestIdModel
	{
		public string FormMode { get; set; } = string.Empty;
	}

	/// <summary>
	/// Enables the parsing of primary Key requests sent through Json in the http Body
	/// </summary>
	public class RequestKeyModel
	{
		public string Key { get; set; } = string.Empty;
	}

	/// <summary>
	/// Request model for menu list requests
	/// </summary>
	public class RequestMenuModel
	{
		[JsonConverter(typeof(VariantToStringDictionaryConverter))]
		public Dictionary<string, string> QueryParams { get; set; } = new Dictionary<string, string>();
		[JsonIgnore]
		public bool AllSelected { get; set; } = false;
	}

	public class RequestRangeLimitModel<T> : RequestMenuModel
	{
		public T? MinLimit { get; set; } = default;
		public T? MaxLimit { get; set; } = default;
	}

	public class RequestFieldLimitModel<T> : RequestMenuModel
	{
		public T? FieldLimit { get; set; } = default;
	}

	public class RequestSelectionsModel
	{
		public List<string> Ids { get; set; } = new List<string>();
	}

	public class RequestReportModel
	{
		public string? Name { get; set; }
		public bool AllSelected { get; set; } = false;
	}

	public class RequestNewGetModel : RequestIdModel
	{
		public bool IsNewLocation { get; set; } = true;
		[JsonConverter(typeof(VariantToStringDictionaryConverter))]
		public Dictionary<string, string>? PrefillValues { get; set; }
	}

	public class RequestEditModel<T>
	{
		public T Model {get; set;}
		public bool Redirect {get; set;} = true;
	}

	public class RequestSaveAllModel<T>
	{
		public T[] Models {get; set;}
		string FieldToChange {get; set;}
	}

	public class RequestInsertAllModel
	{
		public List<string[]> Models {get; set;}
	}

	public class RequestCargaModel
	{
		public string Idsrc {get; set;}
		public string Iddst {get; set;}
	}

	public class RequestReorderModel : RequestIdModel
	{
		public int Position {get; set;}
	}

	public class RequestLookupModel
	{
		public string? Id {get; set;}
		[JsonConverter(typeof(VariantToStringDictionaryConverter))]
		public Dictionary<string, string> QueryParams {get; set;} = new Dictionary<string, string>();
		[JsonConverter(typeof(VariantToStringDictionaryConverter))]
		public Dictionary<string, string>? Limits {get; set;}
	}

	public class RequestReloadDBEditModel
	{
		public string? Identifier { get; set; }
		[JsonConverter(typeof(VariantToStringDictionaryConverter))]
		public Dictionary<string, string>? Values { get; set; }
	}

	public class RequestDependantsModel
	{
		public string? Identifier { get; set; }
		public string? Selected { get; set; }
		[JsonConverter(typeof(VariantToStringDictionaryConverter))]
		public Dictionary<string, string>? Limits { get; set; }
	}

	public class RequestSingleFieldModel : RequestIdModel
	{
		public string Modelname { get; set; } = string.Empty;
		public string Fldname { get; set; } = string.Empty;
	}

	public class RequestDocumGetTicketsModel
	{
		public string TableName { get; set; } = string.Empty;
		public string FieldName { get; set; } = string.Empty;
		public string KeyValue { get; set; } = string.Empty;
	}

	public class RequestDocumTicketsModel
	{
		public string? Ticket { get; set; }
		public DocumentViewTypeMode ViewType { get; set; } = DocumentViewTypeMode.Print;
	}

	public class RequestDocumDeleteModel : RequestDocumTicketsModel
	{
		public Controllers.ControllerBase.VersionDeleteAction Action { get; set; } = Controllers.ControllerBase.VersionDeleteAction.All;
	}

	public class RequestWidgetModel
	{
		public WidgetType WidgetType { get; set; }
		public string WidgetId { get; set; } = string.Empty;
	}

	public class RequestExternalAppModel
	{
		public string CtrlId { get; set; }
		public string Command { get; set; }
		public string Param { get; set; }
		public List<string> HistValues { get; set; } = new List<string>();
	}

	public class RequestWizardModel
	{
		public string FormId { get; set; }
		public string CurrentStep { get; set; }
	}

	public class RequestRoutineSingleModel
	{
		public string Id { get; set; }
		public string Area { get; set; }
	}

	public class RequestRoutineMultipleModel
	{
		public List<string> Ids { get; set; }
		[JsonConverter(typeof(VariantToStringDictionaryConverter))]
		public Dictionary<string, string> QueryParams { get; set; }
		public bool AllSelected { get; set; } = false;
	}
}

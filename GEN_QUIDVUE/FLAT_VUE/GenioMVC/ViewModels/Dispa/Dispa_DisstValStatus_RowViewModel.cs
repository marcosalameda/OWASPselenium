
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Dispa
{
    public class Dispa_DisstValStatus_RowViewModel : Models.Disst
    {
		#region constructors
		public Dispa_DisstValStatus_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public Dispa_DisstValStatus_RowViewModel(UserContext userContext, CSGenioAdisst val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
		#endregion

		[JsonPropertyName("btnPermission")]
		public TableRowCrudButtonPermissions BtnPermission { get; set; } = null;


		///// <summary>
		///// Foreground color formula 
		///// 
		///// </summary> 
		//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		//public string? ForegroundColor => null;

		///// <summary>
		///// Background color formula 
		///// 
		///// </summary> 
		////[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		////public string? BackgroundColor => null;



    }
}
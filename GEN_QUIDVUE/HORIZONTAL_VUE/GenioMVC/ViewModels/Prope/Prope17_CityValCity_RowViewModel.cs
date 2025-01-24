
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Prope
{
    public class Prope17_CityValCity_RowViewModel : Models.City
    {
		#region constructors
		public Prope17_CityValCity_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public Prope17_CityValCity_RowViewModel(UserContext userContext, CSGenioAcity val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
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
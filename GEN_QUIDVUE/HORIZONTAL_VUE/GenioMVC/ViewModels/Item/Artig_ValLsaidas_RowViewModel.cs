
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Item
{
    public class Artig_ValLsaidas_RowViewModel : Models.Outpu
    {
		#region constructors
		public Artig_ValLsaidas_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public Artig_ValLsaidas_RowViewModel(UserContext userContext, CSGenioAoutpu val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
		#endregion

		[JsonPropertyName("btnPermission")]
		public TableRowCrudButtonPermissions BtnPermission { get; set; } = null;


		///// <summary>
		///// Foreground color formula 
		///// RGB(255,190,158)
		///// </summary> 
		//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		//public string? ForegroundColor => "RGB(255,190,158)";

		///// <summary>
		///// Background color formula 
		///// 
		///// </summary> 
		////[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		////public string? BackgroundColor => null;



    }
}
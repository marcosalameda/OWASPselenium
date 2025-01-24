
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Cmpki
{
    public class Cmpki_Tpeq1ValTipoequi_RowViewModel : Models.Tpeq1
    {
		#region constructors
		public Cmpki_Tpeq1ValTipoequi_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public Cmpki_Tpeq1ValTipoequi_RowViewModel(UserContext userContext, CSGenioAtpeq1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
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
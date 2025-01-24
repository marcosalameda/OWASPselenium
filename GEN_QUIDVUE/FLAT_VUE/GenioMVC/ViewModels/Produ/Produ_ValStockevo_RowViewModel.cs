
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Produ
{
    public class Produ_ValStockevo_RowViewModel : Models.Stock
    {
		#region constructors
		public Produ_ValStockevo_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public Produ_ValStockevo_RowViewModel(UserContext userContext, CSGenioAstock val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
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
		///// iif([STOCK->TYPE]=="Input",RGB(207,255,158),iif([STOCK->TYPE]=="Output",RGB(255,190,158),RGB(255,255,255)))
		///// </summary> 
		////[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		////public string? BackgroundColor => ((((string)this.ValType)=="Input")?("RGB(207,255,158)"):(((((string)this.ValType)=="Output")?("RGB(255,190,158)"):("RGB(255,255,255)"))));



    }
}
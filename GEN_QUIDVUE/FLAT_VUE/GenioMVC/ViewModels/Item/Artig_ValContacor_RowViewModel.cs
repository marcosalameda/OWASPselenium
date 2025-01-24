
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Item
{
    public class Artig_ValContacor_RowViewModel : Models.Ccorr
    {
		#region constructors
		public Artig_ValContacor_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public Artig_ValContacor_RowViewModel(UserContext userContext, CSGenioAccorr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
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
		///// iif([CCORR->TYPE]=="Entrada",RGB(207,255,158),iif([CCORR->TYPE]=="Saída",RGB(255,190,158),RGB(255,255,255)))
		///// </summary> 
		////[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		////public string? BackgroundColor => ((((string)this.ValType)=="Entrada")?("RGB(207,255,158)"):(((((string)this.ValType)=="Saída")?("RGB(255,190,158)"):("RGB(255,255,255)"))));



    }
}
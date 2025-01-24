
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Equip
{
    public class Groupbx_TpequValTipoequi_RowViewModel : Models.Tpequ
    {
		#region constructors
		public Groupbx_TpequValTipoequi_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public Groupbx_TpequValTipoequi_RowViewModel(UserContext userContext, CSGenioAtpequ val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
		#endregion

		[JsonPropertyName("btnPermission")]
		public TableRowCrudButtonPermissions BtnPermission { get; set; } = null;


		///// <summary>
		///// Foreground color formula 
		///// iif(emptyC([TPEQU->CORLETRA])==1,RGB(0,0,0),NCOLOUR([TPEQU->CORLETRA]))
		///// </summary> 
		//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		//public string? ForegroundColor => ((CSGenio.business.GlobalFunctions.emptyC(((string)this.ValCorletra))==1)?("RGB(0,0,0)"):(((string)this.ValCorletra)));

		///// <summary>
		///// Background color formula 
		///// iif(emptyC([TPEQU->BACKCOLO])==1,RGB(255,255,255),NCOLOUR([TPEQU->BACKCOLO]))
		///// </summary> 
		////[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		////public string? BackgroundColor => ((CSGenio.business.GlobalFunctions.emptyC(((string)this.ValBackcolo))==1)?("RGB(255,255,255)"):(((string)this.ValBackcolo)));



    }
}
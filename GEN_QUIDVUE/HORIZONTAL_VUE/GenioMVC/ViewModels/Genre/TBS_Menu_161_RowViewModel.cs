
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Genre
{
    public class TBS_Menu_161_RowViewModel : Models.Genre
    {
		#region constructors
		public TBS_Menu_161_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public TBS_Menu_161_RowViewModel(UserContext userContext, CSGenioAgenre val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
		#endregion

		[JsonPropertyName("btnPermission")]
		public TableRowCrudButtonPermissions BtnPermission { get; set; } = null;


		///// <summary>
		///// Foreground color formula 
		///// iif(emptyC([GENRE->TEXTCOLO])==1,RGB(0,0,0),NCOLOUR([GENRE->TEXTCOLO]))
		///// </summary> 
		//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		//public string? ForegroundColor => ((CSGenio.business.GlobalFunctions.emptyC(((string)this.ValTextcolo))==1)?("RGB(0,0,0)"):(((string)this.ValTextcolo)));

		///// <summary>
		///// Background color formula 
		///// iif(emptyC([GENRE->BACKCOLO])==1,RGB(255,255,255),NCOLOUR([GENRE->BACKCOLO]))
		///// </summary> 
		////[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		////public string? BackgroundColor => ((CSGenio.business.GlobalFunctions.emptyC(((string)this.ValBackcolo))==1)?("RGB(255,255,255)"):(((string)this.ValBackcolo)));



    }
}
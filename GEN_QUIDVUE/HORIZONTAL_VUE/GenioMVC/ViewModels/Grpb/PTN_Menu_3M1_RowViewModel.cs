
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Grpb
{
    public class PTN_Menu_3M1_RowViewModel : Models.Grpb
    {
		#region constructors
		public PTN_Menu_3M1_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize) { }
		public PTN_Menu_3M1_RowViewModel(UserContext userContext, CSGenioAgrpb val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize) { }
		#endregion

		[JsonPropertyName("btnPermission")]
		public TableRowCrudButtonPermissions BtnPermission { get; set; } = null;

		#region Columns from table below
		[ShouldSerialize("Tblb.ValBool")]
		public List<bool> TblbValBool { get; set; } = [];

		[ShouldSerialize("Tblb.ValCurdec")]
		public List<decimal?> TblbValCurdec { get; set; } = [];

		[ShouldSerialize("Tblb.ValCurint")]
		public List<decimal?> TblbValCurint { get; set; } = [];

		[ShouldSerialize("Tblb.ValDate")]
		public List<DateTime?> TblbValDate { get; set; } = [];

		[ShouldSerialize("Tblb.ValDatetm")]
		public List<DateTime?> TblbValDatetm { get; set; } = [];

		[ShouldSerialize("Tblb.ValDatets")]
		public List<DateTime?> TblbValDatets { get; set; } = [];

		[ShouldSerialize("Tblb.ValEnumn")]
		public List<decimal> TblbValEnumn { get; set; } = [];

		[ShouldSerialize("Tblb.ValEnumt")]
		public List<string> TblbValEnumt { get; set; } = [];

		[ShouldSerialize("Tblb.ValNumdec")]
		public List<decimal?> TblbValNumdec { get; set; } = [];

		[ShouldSerialize("Tblb.ValNumint")]
		public List<decimal?> TblbValNumint { get; set; } = [];

		[ShouldSerialize("Tblb.ValText")]
		public List<string> TblbValText { get; set; } = [];

		[ShouldSerialize("Tblb.ValTextml")]
		public List<string> TblbValTextml { get; set; } = [];

		[ShouldSerialize("Tblb.ValTimehm")]
		public List<string> TblbValTimehm { get; set; } = [];

		#endregion

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
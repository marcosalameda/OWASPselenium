
[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GrpbPseudTblbGrid(IWebDriver driver, By containerLocator, string css) : BaseGridControl(driver, containerLocator, By.CssSelector(css))
{
	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl TblbText => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_TEXT____", "#GRPB____PSEUDTBLB____TBLB_TEXT____");
	/// <summary>
	/// Multiline Text
	/// </summary>
	public BaseInputControl TblbTextml => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_TEXTML__", "#GRPB____PSEUDTBLB____TBLB_TEXTML__");
	/// <summary>
	/// Numeric (Integer)
	/// </summary>
	public BaseInputControl TblbNumint => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_NUMINT__", "#GRPB____PSEUDTBLB____TBLB_NUMINT__");
	/// <summary>
	/// Numeric (Decimal)
	/// </summary>
	public BaseInputControl TblbNumdec => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_NUMDEC__", "#GRPB____PSEUDTBLB____TBLB_NUMDEC__");
	/// <summary>
	/// Currency (Interger)
	/// </summary>
	public BaseInputControl TblbCurint => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_CURINT__", "#GRPB____PSEUDTBLB____TBLB_CURINT__");
	/// <summary>
	/// Currency (Decimal)
	/// </summary>
	public BaseInputControl TblbCurdec => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_CURDEC__", "#GRPB____PSEUDTBLB____TBLB_CURDEC__");
	/// <summary>
	/// Boolean
	/// </summary>
	public CheckboxInputControl TblbBool => new CheckboxInputControl(driver, lineLocator, "#container-GRPB____PSEUDTBLB____TBLB_BOOL____");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl TblbDate => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB____TBLB_DATE____");
	/// <summary>
	/// DateTime (Minutes)
	/// </summary>
	public DateInputControl TblbDatetm => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB____TBLB_DATETM__", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// DateTime (Seconds)
	/// </summary>
	public DateInputControl TblbDatets => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB____TBLB_DATETS__", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Time (Hours-Minutes)
	/// </summary>
	public BaseInputControl TblbTimehm => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_TIMEHM__", "#GRPB____PSEUDTBLB____TBLB_TIMEHM__");
	/// <summary>
	/// Enumeration (Text)
	/// </summary>
	public EnumControl TblbEnumt => new EnumControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_ENUMT___");
	/// <summary>
	/// Enumeration (Numeric)
	/// </summary>
	public EnumControl TblbEnumn => new EnumControl(driver, lineLocator, "container-GRPB____PSEUDTBLB____TBLB_ENUMN___");
}

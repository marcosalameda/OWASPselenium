
[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GrpbPseudTblbGrid(IWebDriver driver, By containerLocator, string css) : BaseGridControl(driver, containerLocator, By.CssSelector(css))
{
	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl TblbText => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__TEXT", "#GRPB____PSEUDTBLB______TBLB__TEXT");
	/// <summary>
	/// Multiline Text
	/// </summary>
	public BaseInputControl TblbTextml => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__TEXTML", "#GRPB____PSEUDTBLB______TBLB__TEXTML");
	/// <summary>
	/// Numeric (Integer)
	/// </summary>
	public BaseInputControl TblbNumint => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__NUMINT", "#GRPB____PSEUDTBLB______TBLB__NUMINT");
	/// <summary>
	/// Numeric (Decimal)
	/// </summary>
	public BaseInputControl TblbNumdec => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__NUMDEC", "#GRPB____PSEUDTBLB______TBLB__NUMDEC");
	/// <summary>
	/// Currency (Interger)
	/// </summary>
	public BaseInputControl TblbCurint => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__CURINT", "#GRPB____PSEUDTBLB______TBLB__CURINT");
	/// <summary>
	/// Currency (Decimal)
	/// </summary>
	public BaseInputControl TblbCurdec => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__CURDEC", "#GRPB____PSEUDTBLB______TBLB__CURDEC");
	/// <summary>
	/// Boolean
	/// </summary>
	public CheckboxInputControl TblbBool => new CheckboxInputControl(driver, lineLocator, "#container-GRPB____PSEUDTBLB______TBLB__BOOL");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl TblbDate => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB______TBLB__DATE");
	/// <summary>
	/// DateTime (Minutes)
	/// </summary>
	public DateInputControl TblbDatetm => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB______TBLB__DATETM", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// DateTime (Seconds)
	/// </summary>
	public DateInputControl TblbDatets => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB______TBLB__DATETS", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Time (Hours-Minutes)
	/// </summary>
	public BaseInputControl TblbTimehm => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__TIMEHM", "#GRPB____PSEUDTBLB______TBLB__TIMEHM");
	/// <summary>
	/// Enumeration (Text)
	/// </summary>
	public EnumControl TblbEnumt => new EnumControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__ENUMT");
	/// <summary>
	/// Enumeration (Numeric)
	/// </summary>
	public EnumControl TblbEnumn => new EnumControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__ENUMN");
}

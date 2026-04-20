
[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GrpbPseudTblbGrid(IWebDriver driver, By containerLocator, string css) : BaseGridControl(driver, containerLocator, By.CssSelector(css))
{
	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl TblbText => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__TEXT_" + currentRowPk, "#GRPB____PSEUDTBLB______TBLB__TEXT_" + currentRowPk);
	/// <summary>
	/// Multiline Text
	/// </summary>
	public BaseInputControl TblbTextml => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__TEXTML_" + currentRowPk, "#GRPB____PSEUDTBLB______TBLB__TEXTML_" + currentRowPk);
	/// <summary>
	/// Numeric (Integer)
	/// </summary>
	public BaseInputControl TblbNumint => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__NUMINT_" + currentRowPk, "#GRPB____PSEUDTBLB______TBLB__NUMINT_" + currentRowPk);
	/// <summary>
	/// Numeric (Decimal)
	/// </summary>
	public BaseInputControl TblbNumdec => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__NUMDEC_" + currentRowPk, "#GRPB____PSEUDTBLB______TBLB__NUMDEC_" + currentRowPk);
	/// <summary>
	/// Currency (Interger)
	/// </summary>
	public BaseInputControl TblbCurint => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__CURINT_" + currentRowPk, "#GRPB____PSEUDTBLB______TBLB__CURINT_" + currentRowPk);
	/// <summary>
	/// Currency (Decimal)
	/// </summary>
	public BaseInputControl TblbCurdec => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__CURDEC_" + currentRowPk, "#GRPB____PSEUDTBLB______TBLB__CURDEC_" + currentRowPk);
	/// <summary>
	/// Boolean
	/// </summary>
	public CheckboxInputControl TblbBool => new CheckboxInputControl(driver, lineLocator, "#container-GRPB____PSEUDTBLB______TBLB__BOOL_" + currentRowPk);
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl TblbDate => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB______TBLB__DATE_" + currentRowPk);
	/// <summary>
	/// DateTime (Minutes)
	/// </summary>
	public DateInputControl TblbDatetm => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB______TBLB__DATETM_" + currentRowPk, "dd/MM/yyyy HH:mm");
	/// <summary>
	/// DateTime (Seconds)
	/// </summary>
	public DateInputControl TblbDatets => new DateInputControl(driver, lineLocator, "#GRPB____PSEUDTBLB______TBLB__DATETS_" + currentRowPk, "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Time (Hours-Minutes)
	/// </summary>
	public BaseInputControl TblbTimehm => new BaseInputControl(driver, lineLocator, "container-GRPB____PSEUDTBLB______TBLB__TIMEHM_" + currentRowPk, "#GRPB____PSEUDTBLB______TBLB__TIMEHM_" + currentRowPk);
	/// <summary>
	/// Enumeration (Text)
	/// </summary>
	public EnumControl TblbEnumt => new EnumControl(driver, lineLocator, "container-$fieldIdentifier_" + currentRowPk);
	/// <summary>
	/// Enumeration (Numeric)
	/// </summary>
	public EnumControl TblbEnumn => new EnumControl(driver, lineLocator, "container-$fieldIdentifier_" + currentRowPk);
}

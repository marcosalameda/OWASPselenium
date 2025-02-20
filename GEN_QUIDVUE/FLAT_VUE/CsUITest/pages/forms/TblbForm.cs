using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TblbForm : Form
{
	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl TblbText => new BaseInputControl(driver, ContainerLocator, "container-TBLB____TBLB_TEXT____", "#TBLB____TBLB_TEXT____");

	/// <summary>
	/// Multiline Text
	/// </summary>
	public BaseInputControl TblbTextml => new BaseInputControl(driver, ContainerLocator, "container-TBLB____TBLB_TEXTML__", "#TBLB____TBLB_TEXTML__");

	/// <summary>
	/// Numeric (Integer)
	/// </summary>
	public BaseInputControl TblbNumint => new BaseInputControl(driver, ContainerLocator, "container-TBLB____TBLB_NUMINT__", "#TBLB____TBLB_NUMINT__");

	/// <summary>
	/// Numeric (Decimal)
	/// </summary>
	public BaseInputControl TblbNumdec => new BaseInputControl(driver, ContainerLocator, "container-TBLB____TBLB_NUMDEC__", "#TBLB____TBLB_NUMDEC__");

	/// <summary>
	/// Currency (Interger)
	/// </summary>
	public BaseInputControl TblbCurint => new BaseInputControl(driver, ContainerLocator, "container-TBLB____TBLB_CURINT__", "#TBLB____TBLB_CURINT__");

	/// <summary>
	/// Currency (Decimal)
	/// </summary>
	public BaseInputControl TblbCurdec => new BaseInputControl(driver, ContainerLocator, "container-TBLB____TBLB_CURDEC__", "#TBLB____TBLB_CURDEC__");

	/// <summary>
	/// Boolean
	/// </summary>
	public CheckboxInputControl TblbBool => new CheckboxInputControl(driver, ContainerLocator, "#container-TBLB____TBLB_BOOL____");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl TblbDate => new DateInputControl(driver, ContainerLocator, "#TBLB____TBLB_DATE____");

	/// <summary>
	/// DateTime (Minutes)
	/// </summary>
	public DateInputControl TblbDatetm => new DateInputControl(driver, ContainerLocator, "#TBLB____TBLB_DATETM__", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// DateTime (Seconds)
	/// </summary>
	public DateInputControl TblbDatets => new DateInputControl(driver, ContainerLocator, "#TBLB____TBLB_DATETS__", "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Time (Hours-Minutes)
	/// </summary>
	public BaseInputControl TblbTimehm => new BaseInputControl(driver, ContainerLocator, "container-TBLB____TBLB_TIMEHM__", "#TBLB____TBLB_TIMEHM__");

	/// <summary>
	/// Enumeration (Text)
	/// </summary>
	public EnumControl TblbEnumt => new EnumControl(driver, ContainerLocator, "container-TBLB____TBLB_ENUMT___");

	/// <summary>
	/// Enumeration (Numeric)
	/// </summary>
	public EnumControl TblbEnumn => new EnumControl(driver, ContainerLocator, "container-TBLB____TBLB_ENUMN___");

	public TblbForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TBLB", containerLocator: containerLocator) { }
}

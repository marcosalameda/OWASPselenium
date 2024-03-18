namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TblbForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl TblbText => new BaseInputControl(driver, formLocator, "#TBLB____TBLB_TEXT____");
	/// <summary>
	/// Multiline Text
	/// </summary>
	public BaseInputControl TblbTextml => new BaseInputControl(driver, formLocator, "#TBLB____TBLB_TEXTML__");
	/// <summary>
	/// Numeric (Integer)
	/// </summary>
	public BaseInputControl TblbNumint => new BaseInputControl(driver, formLocator, "#TBLB____TBLB_NUMINT__");
	/// <summary>
	/// Numeric (Decimal)
	/// </summary>
	public BaseInputControl TblbNumdec => new BaseInputControl(driver, formLocator, "#TBLB____TBLB_NUMDEC__");
	/// <summary>
	/// Currency (Interger)
	/// </summary>
	public BaseInputControl TblbCurint => new BaseInputControl(driver, formLocator, "#TBLB____TBLB_CURINT__");
	/// <summary>
	/// Currency (Decimal)
	/// </summary>
	public BaseInputControl TblbCurdec => new BaseInputControl(driver, formLocator, "#TBLB____TBLB_CURDEC__");
	/// <summary>
	/// Boolean
	/// </summary>
	public CheckboxInputControl TblbBool => new CheckboxInputControl(driver, formLocator, "#container-TBLB____TBLB_BOOL____");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl TblbDate => new DateInputControl(driver, formLocator, "#TBLB____TBLB_DATE____");
	/// <summary>
	/// DateTime (Minutes)
	/// </summary>
	public DateInputControl TblbDatetm => new DateInputControl(driver, formLocator, "#TBLB____TBLB_DATETM__", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// DateTime (Seconds)
	/// </summary>
	public DateInputControl TblbDatets => new DateInputControl(driver, formLocator, "#TBLB____TBLB_DATETS__", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Time (Hours-Minutes)
	/// </summary>
	public BaseInputControl TblbTimehm => new BaseInputControl(driver, formLocator, "#TBLB____TBLB_TIMEHM__");
	/// <summary>
	/// Enumeration (Text)
	/// </summary>
	public EnumControl TblbEnumt => new EnumControl(driver, formLocator, "container-TBLB____TBLB_ENUMT___");
	/// <summary>
	/// Enumeration (Numeric)
	/// </summary>
	public EnumControl TblbEnumn => new EnumControl(driver, formLocator, "container-TBLB____TBLB_ENUMN___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public TblbForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("TBLB")).GetAttribute("data-loading") != "true");
    }

	public void Save() {
		WaitForLoading();
		saveBtn.Click();
	}

	public void Cancel() {
		WaitForLoading();
		cancelBtn.Click();
	}

}

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamdateForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, formLocator, "#CAMDATE_FLDS_YEAR____");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, formLocator, "#CAMDATE_FLDS_DATE____");
	/// <summary>
	/// Date Time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, formLocator, "#CAMDATE_FLDS_DATETIME", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Date seconds
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, formLocator, "#CAMDATE_FLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, formLocator, "#CAMDATE_FLDS_TIME____");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public CamdateForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("CAMDATE")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ComodForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Lending
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, formLocator, "container-COMOD___PESS1NAME____");
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "COMOD", "PESS1.NAME");
	/// <summary>
	/// Borrower:
	/// </summary>
	public LookupControl Pess2Name => new LookupControl(driver, formLocator, "container-COMOD___PESS2NAME____");
	public SeeMorePage Pess2NameSeeMorePage => new SeeMorePage(driver, "COMOD", "PESS2.NAME");
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-COMOD___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "COMOD", "EQUIP.REGISTNR");
	/// <summary>
	/// Equipment
	/// </summary>
	public IWebElement EquipDesignat => throw new NotImplementedException();
	/// <summary>
	/// Loan Frequency
	/// </summary>
	public IWebElement EquipFrequenc => throw new NotImplementedException();
	/// <summary>
	/// Lending No
	/// </summary>
	public BaseInputControl LendiLendinnr => new BaseInputControl(driver, formLocator, "#COMOD___LENDILENDINNR");
	/// <summary>
	/// Start:
	/// </summary>
	public DateInputControl LendiStart => new DateInputControl(driver, formLocator, "#COMOD___LENDISTART___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Warning
	/// </summary>
	public DateInputControl LendiWarndt => new DateInputControl(driver, formLocator, "#COMOD___LENDIWARNDT__", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// End
	/// </summary>
	public DateInputControl LendiEnd => new DateInputControl(driver, formLocator, "#COMOD___LENDIEND_____", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Observation
	/// </summary>
	public BaseInputControl LendiObservat => new BaseInputControl(driver, formLocator, "#COMOD___LENDIOBSERVAT");
	/// <summary>
	/// Returned
	/// </summary>
	public DateInputControl LendiReturndt => new DateInputControl(driver, formLocator, "#COMOD___LENDIRETURNDT");
	/// <summary>
	/// Returned
	/// </summary>
	public CheckboxInputControl LendiReturned => new CheckboxInputControl(driver, formLocator, "#container-COMOD___LENDIRETURNED");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ComodForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("COMOD")).GetAttribute("data-loading") != "true");
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

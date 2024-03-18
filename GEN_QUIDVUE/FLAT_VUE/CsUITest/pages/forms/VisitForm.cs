namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class VisitForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-VISIT___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "VISIT", "EQUIP.REGISTNR");
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl VisitTitle => new BaseInputControl(driver, formLocator, "#VISIT___VISITTITLE___");
	/// <summary>
	/// Start:
	/// </summary>
	public DateInputControl VisitStartdt => new DateInputControl(driver, formLocator, "#VISIT___VISITSTARTDT_", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// End
	/// </summary>
	public DateInputControl VisitDtfim => new DateInputControl(driver, formLocator, "#VISIT___VISITDTFIM___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Description
	/// </summary>
	public IWebElement VisitDescript => throw new NotImplementedException();
	/// <summary>
	/// Day
	/// </summary>
	public CheckboxInputControl VisitTodoodia => new CheckboxInputControl(driver, formLocator, "#container-VISIT___VISITTODOODIA");
	/// <summary>
	/// Color
	/// </summary>
	public BaseInputControl VisitColor => new BaseInputControl(driver, formLocator, "#VISIT___VISITCOLOR___");
	/// <summary>
	/// Observations
	/// </summary>
	public BaseInputControl VisitObservat => new BaseInputControl(driver, formLocator, "#VISIT___VISITOBSERVAT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public VisitForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("VISIT")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Visit2Form: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-VISIT2");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-VISIT2__EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "VISIT2", "EQUIP.REGISTNR");
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl VisitTitle => new BaseInputControl(driver, formLocator, "#VISIT2__VISITTITLE___");
	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl VisitStartdt => new DateInputControl(driver, formLocator, "#VISIT2__VISITSTARTDT_", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// End
	/// </summary>
	public DateInputControl VisitDtfim => new DateInputControl(driver, formLocator, "#VISIT2__VISITDTFIM___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl VisitDescript => new BaseInputControl(driver, formLocator, "#VISIT2__VISITDESCRIPT");
	/// <summary>
	/// Day
	/// </summary>
	public CheckboxInputControl VisitTodoodia => new CheckboxInputControl(driver, formLocator, "#container-VISIT2__VISITTODOODIA");
	/// <summary>
	/// Color
	/// </summary>
	public BaseInputControl VisitColor => new BaseInputControl(driver, formLocator, "#VISIT2__VISITCOLOR___");
	/// <summary>
	/// Background
	/// </summary>
	public CheckboxInputControl VisitBack => new CheckboxInputControl(driver, formLocator, "#container-VISIT2__VISITBACK____");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Visit2Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("VISIT2")).GetAttribute("data-loading") != "true");
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

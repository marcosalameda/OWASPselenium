namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LcextForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Location extension
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#LCEXT___PSEUDNOVOGR01-container");
	/// <summary>
	/// Global Location Number
	/// </summary>
	public LookupControl LocatGln => new LookupControl(driver, formLocator, "container-LCEXT___LOCATGLN_____");
	public SeeMorePage LocatGlnSeeMorePage => new SeeMorePage(driver, "LCEXT", "LOCAT.GLN");
	/// <summary>
	/// GLN Extension Component
	/// </summary>
	public BaseInputControl LcextGlnext => new BaseInputControl(driver, formLocator, "#LCEXT___LCEXTGLNEXT__");
	/// <summary>
	/// Space type
	/// </summary>
	public EnumControl LcextSpacetyp => new EnumControl(driver, formLocator, "container-LCEXT___LCEXTSPACETYP");
	/// <summary>
	/// Space
	/// </summary>
	public BaseInputControl LcextSpaceobs => new BaseInputControl(driver, formLocator, "#LCEXT___LCEXTSPACEOBS");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LcextForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LCEXT")).GetAttribute("data-loading") != "true");
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

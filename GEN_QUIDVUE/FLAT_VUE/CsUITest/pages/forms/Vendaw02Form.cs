namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw02Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Qualification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#VENDAW02PSEUDNOVOGR02-container");
	/// <summary>
	/// Interested
	/// </summary>
	public CheckboxInputControl SaleInteress => new CheckboxInputControl(driver, formLocator, "#container-VENDAW02SALE_INTERESS");
	/// <summary>
	/// No financial resources
	/// </summary>
	public CheckboxInputControl SaleSemrfina => new CheckboxInputControl(driver, formLocator, "#container-VENDAW02SALE_SEMRFINA");
	/// <summary>
	/// No decision-making capacity
	/// </summary>
	public CheckboxInputControl SaleSemcapac => new CheckboxInputControl(driver, formLocator, "#container-VENDAW02SALE_SEMCAPAC");
	/// <summary>
	/// Qualification
	/// </summary>
	public DateInputControl SaleDtqualif => new DateInputControl(driver, formLocator, "#VENDAW02SALE_DTQUALIF", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Qualification carried out
	/// </summary>
	public CheckboxInputControl SaleQualific => new CheckboxInputControl(driver, formLocator, "#container-VENDAW02SALE_QUALIFIC");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Vendaw02Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("VENDAW02")).GetAttribute("data-loading") != "true");
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

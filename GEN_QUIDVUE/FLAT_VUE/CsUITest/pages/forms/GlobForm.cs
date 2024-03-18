namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GlobForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Home text
	/// </summary>
	public IWebElement GlobHome => throw new NotImplementedException();
	/// <summary>
	/// External API address
	/// </summary>
	public BaseInputControl GlobApiurl => new BaseInputControl(driver, formLocator, "#GLOB____GLOB_APIURL__");
	/// <summary>
	/// Legend
	/// </summary>
	public BaseInputControl GlobLegend => new BaseInputControl(driver, formLocator, "#GLOB____GLOB_LEGEND__");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public GlobForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("GLOB")).GetAttribute("data-loading") != "true");
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

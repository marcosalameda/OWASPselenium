namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Fami1Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Equipment family
	/// </summary>
	public BaseInputControl Fami1Family => new BaseInputControl(driver, formLocator, "#FAMI1___FAMI1FAMILY__");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public ListControl PseudTiposequ => new ListControl(driver, formLocator, "#FAMI1___PSEUDTIPOSEQU");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public IWebElement PseudTiposeq1 => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Fami1Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("FAMI1")).GetAttribute("data-loading") != "true");
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

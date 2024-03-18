namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TimequipForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Equipment Repairs
	/// </summary>
	public ListControl PseudReparaco => new ListControl(driver, formLocator, "#TIMEQUIPPSEUDREPARACO");
	/// <summary>
	/// Timeline Primary
	/// </summary>
	public IWebElement PseudPrimary => throw new NotImplementedException();
	/// <summary>
	/// Timeline Secundary
	/// </summary>
	public IWebElement PseudSecundar => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public TimequipForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("TIMEQUIP")).GetAttribute("data-loading") != "true");
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

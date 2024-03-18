namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw07Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Sale closing
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, formLocator, "#VENDAW07PSEUDNOVOGR07-container");
	/// <summary>
	/// Closing attempts
	/// </summary>
	public DateInputControl SaleTentfech => new DateInputControl(driver, formLocator, "#VENDAW07SALE_TENTFECH", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Sale closing
	/// </summary>
	public DateInputControl SaleDtvenda => new DateInputControl(driver, formLocator, "#VENDAW07SALE_DTVENDA_", "dd/MM/yyyy HH:mm");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Vendaw07Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("VENDAW07")).GetAttribute("data-loading") != "true");
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

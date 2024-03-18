namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Armaz03Form: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-ARMAZ03");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Support
	/// </summary>
	public ArtigextForm  PseudArtigapo => new ArtigextForm(driver, FORM_MODE.EDIT, By.Id("ARMAZ03_PSEUDARTIGAPO"));
	/// <summary>
	/// Catalog articles
	/// </summary>
	public ListControl PseudArtigos => new ListControl(driver, formLocator, "#ARMAZ03_PSEUDARTIGOS_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Armaz03Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARMAZ03")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtglForm: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-ARTGL");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Global Item
	/// </summary>
	public BaseInputControl GitemItemdes => new BaseInputControl(driver, formLocator, "#ARTGL___GITEMITEMDES_");
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl GitemItemgcod => new BaseInputControl(driver, formLocator, "#ARTGL___GITEMITEMGCOD");
	/// <summary>
	/// Catalog
	/// </summary>
	public BaseInputControl GitemDocument => new BaseInputControl(driver, formLocator, "#ARTGL___GITEMDOCUMENT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ArtglForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARTGL")).GetAttribute("data-loading") != "true");
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

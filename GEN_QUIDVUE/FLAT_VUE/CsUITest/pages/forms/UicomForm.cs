namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class UicomForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Miniature
	/// </summary>
	public BaseInputControl UicomThumbnai => new BaseInputControl(driver, formLocator, "#UICOM___UICOMTHUMBNAI");
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl UicomName => new BaseInputControl(driver, formLocator, "#UICOM___UICOMNAME____");
	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl UicomCategory => new BaseInputControl(driver, formLocator, "#UICOM___UICOMCATEGORY");
	/// <summary>
	/// Fixed menu name
	/// </summary>
	public BaseInputControl UicomMenuid => new BaseInputControl(driver, formLocator, "#UICOM___UICOMMENUID__");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public UicomForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("UICOM")).GetAttribute("data-loading") != "true");
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

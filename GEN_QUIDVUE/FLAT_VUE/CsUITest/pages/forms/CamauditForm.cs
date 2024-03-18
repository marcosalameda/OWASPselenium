namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamauditForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, formLocator, "#CAMAUDITFLDS_CREATUSE");
	/// <summary>
	/// Date of Creation
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, formLocator, "#CAMAUDITFLDS_CREATDAT");
	/// <summary>
	/// Creation hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, formLocator, "#CAMAUDITFLDS_CREATHOU");
	/// <summary>
	/// Complete Date of Creation
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, formLocator, "#CAMAUDITFLDS_CREATINS");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public CamauditForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("CAMAUDIT")).GetAttribute("data-loading") != "true");
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

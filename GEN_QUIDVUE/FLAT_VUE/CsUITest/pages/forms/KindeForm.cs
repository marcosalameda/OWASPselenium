namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class KindeForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Kind of equipment
	/// </summary>
	public BaseInputControl KindeDesignat => new BaseInputControl(driver, formLocator, "#KINDE___KINDEDESIGNAT");
	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl PseudParamete => new ListControl(driver, formLocator, "#KINDE___PSEUDPARAMETE");
	/// <summary>
	/// Manuals
	/// </summary>
	public ListControl PseudManuals => new ListControl(driver, formLocator, "#KINDE___PSEUDMANUALS_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public KindeForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("KINDE")).GetAttribute("data-loading") != "true");
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

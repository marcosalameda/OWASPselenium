namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GrpbForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl GrpbName => new BaseInputControl(driver, formLocator, "#GRPB____GRPB_NAME____");
	/// <summary>
	/// 
	/// </summary>

	public GrpbPseudTblbGrid PseudTblb => new GrpbPseudTblbGrid(driver, formLocator, "#GRPB____PSEUDTBLB____");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public GrpbForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("GRPB")).GetAttribute("data-loading") != "true");
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

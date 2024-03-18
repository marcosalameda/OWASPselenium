namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegraForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Condition type
	/// </summary>
	public EnumControl RulesTipocond => new EnumControl(driver, formLocator, "container-REGRA___RULESTIPOCOND");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl RulesDescript => new BaseInputControl(driver, formLocator, "#REGRA___RULESDESCRIPT");
	/// <summary>
	/// Local onde executa
	/// </summary>
	public EnumControl RulesLocal => new EnumControl(driver, formLocator, "container-REGRA___RULESLOCAL___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public RegraForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("REGRA")).GetAttribute("data-loading") != "true");
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

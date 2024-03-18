namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TraduForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Reference
	/// </summary>
	public BaseInputControl TraduReferenc => new BaseInputControl(driver, formLocator, "#TRADU___TRADUREFERENC");
	/// <summary>
	/// Language
	/// </summary>
	public LookupControl Lang1Langua => new LookupControl(driver, formLocator, "container-TRADU___LANG1LANGUA__");
	public SeeMorePage Lang1LanguaSeeMorePage => new SeeMorePage(driver, "TRADU", "LANG1.LANGUA");
	/// <summary>
	/// To translate
	/// </summary>
	public BaseInputControl TraduAtraduzi => new BaseInputControl(driver, formLocator, "#TRADU___TRADUATRADUZI");
	/// <summary>
	/// Language
	/// </summary>
	public LookupControl Lang2Langua => new LookupControl(driver, formLocator, "container-TRADU___LANG2LANGUA__");
	public SeeMorePage Lang2LanguaSeeMorePage => new SeeMorePage(driver, "TRADU", "LANG2.LANGUA");
	/// <summary>
	/// Translated
	/// </summary>
	public BaseInputControl TraduTraduzid => new BaseInputControl(driver, formLocator, "#TRADU___TRADUTRADUZID");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public TraduForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("TRADU")).GetAttribute("data-loading") != "true");
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

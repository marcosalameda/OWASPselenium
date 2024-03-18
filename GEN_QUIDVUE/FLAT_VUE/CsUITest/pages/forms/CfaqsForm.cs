namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CfaqsForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Icon
	/// </summary>
	public BaseInputControl CfaqsIcon => new BaseInputControl(driver, formLocator, "#CFAQS___CFAQSICON____");
	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl CfaqsCategory => new BaseInputControl(driver, formLocator, "#CFAQS___CFAQSCATEGORY");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CfaqsDescript => new BaseInputControl(driver, formLocator, "#CFAQS___CFAQSDESCRIPT");
	/// <summary>
	/// FAQS
	/// </summary>
	public ListControl PseudExpfaqs => new ListControl(driver, formLocator, "#CFAQS___PSEUDEXPFAQS_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public CfaqsForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("CFAQS")).GetAttribute("data-loading") != "true");
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

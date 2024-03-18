namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AbatereqForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudReqtext => throw new NotImplementedException();
	/// <summary>
	/// Number
	/// </summary>
	public BaseInputControl DecomDecomnr => new BaseInputControl(driver, formLocator, "#ABATEREQDECOMDECOMNR_");
	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl DecomNote => new BaseInputControl(driver, formLocator, "#ABATEREQDECOMNOTE____");
	/// <summary>
	/// Collapsible
	/// </summary>
	public IWebElement PseudCollapse => throw new NotImplementedException();
	/// <summary>
	/// Tab
	/// </summary>
	public TabControl PseudAbatetab => new TabControl(driver, formLocator, "#tab-container-ABATEREQPSEUDABATETAB");
	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl AbatetabDecomDtdeco => new DateInputControl(driver, formLocator, "#ABATETABDECOMDTDECO__", "dd/MM/yyyy HH:mm");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AbatereqForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ABATEREQ")).GetAttribute("data-loading") != "true");
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

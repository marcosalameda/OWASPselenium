namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpcatForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Category type
	/// </summary>
	public BaseInputControl CattpTpcatego => new BaseInputControl(driver, formLocator, "#TPCAT___CATTPTPCATEGO");
	/// <summary>
	/// Sub categoria
	/// </summary>
	public LookupControl SbcatSubcateg => new LookupControl(driver, formLocator, "container-TPCAT___SBCATSUBCATEG");
	public SeeMorePage SbcatSubcategSeeMorePage => new SeeMorePage(driver, "TPCAT", "SBCAT.SUBCATEG");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public TpcatForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("TPCAT")).GetAttribute("data-loading") != "true");
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

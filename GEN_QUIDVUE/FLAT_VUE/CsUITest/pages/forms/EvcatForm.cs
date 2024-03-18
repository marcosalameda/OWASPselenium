namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EvcatForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, formLocator, "container-EVCAT___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "EVCAT", "PESSO.NAME");
	/// <summary>
	/// Category
	/// </summary>
	public LookupControl Cate1Category => new LookupControl(driver, formLocator, "container-EVCAT___CATE1CATEGORY");
	public SeeMorePage Cate1CategorySeeMorePage => new SeeMorePage(driver, "EVCAT", "CATE1.CATEGORY");
	/// <summary>
	/// Since:
	/// </summary>
	public DateInputControl EvcatSince => new DateInputControl(driver, formLocator, "#EVCAT___EVCATSINCE___");
	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl EvcatUntil => new DateInputControl(driver, formLocator, "#EVCAT___EVCATUNTIL___");
	/// <summary>
	/// End
	/// </summary>
	public DateInputControl EvcatUntilman => new DateInputControl(driver, formLocator, "#EVCAT___EVCATUNTILMAN");
	/// <summary>
	/// End of period
	/// </summary>
	public DateInputControl EvcatFimperio => new DateInputControl(driver, formLocator, "#EVCAT___EVCATFIMPERIO");
	/// <summary>
	/// Observation
	/// </summary>
	public BaseInputControl EvcatObservat => new BaseInputControl(driver, formLocator, "#EVCAT___EVCATOBSERVAT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public EvcatForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("EVCAT")).GetAttribute("data-loading") != "true");
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

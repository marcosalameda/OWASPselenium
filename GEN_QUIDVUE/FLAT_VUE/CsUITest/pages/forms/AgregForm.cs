namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AgregForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Project
	/// </summary>
	public LookupControl ProjeProjecto => new LookupControl(driver, formLocator, "container-AGREG___PROJEPROJECTO");
	public SeeMorePage ProjeProjectoSeeMorePage => new SeeMorePage(driver, "AGREG", "PROJE.PROJECTO");
	/// <summary>
	/// Year
	/// </summary>
	public LookupControl YearYear => new LookupControl(driver, formLocator, "container-AGREG___YEAR_YEAR____");
	public SeeMorePage YearYearSeeMorePage => new SeeMorePage(driver, "AGREG", "YEAR.YEAR");
	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl AgregValue => new BaseInputControl(driver, formLocator, "#AGREG___AGREGVALUE___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AgregForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("AGREG")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DespeForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Project
	/// </summary>
	public LookupControl ProjeProjecto => new LookupControl(driver, formLocator, "container-DESPE___PROJEPROJECTO");
	public SeeMorePage ProjeProjectoSeeMorePage => new SeeMorePage(driver, "DESPE", "PROJE.PROJECTO");
	/// <summary>
	/// Year
	/// </summary>
	public LookupControl YearYear => new LookupControl(driver, formLocator, "container-DESPE___YEAR_YEAR____");
	public SeeMorePage YearYearSeeMorePage => new SeeMorePage(driver, "DESPE", "YEAR.YEAR");
	/// <summary>
	/// Value
	/// </summary>
	public LookupControl AgregValue => new LookupControl(driver, formLocator, "container-DESPE___AGREGVALUE___");
	public SeeMorePage AgregValueSeeMorePage => new SeeMorePage(driver, "DESPE", "AGREG.VALUE");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ExpenDescript => new BaseInputControl(driver, formLocator, "#DESPE___EXPENDESCRIPT");
	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl ExpenValue => new BaseInputControl(driver, formLocator, "#DESPE___EXPENVALUE___");
	/// <summary>
	/// Previous Value
	/// </summary>
	public BaseInputControl ExpenPrevval => new BaseInputControl(driver, formLocator, "#DESPE___EXPENPREVVAL_");
	/// <summary>
	/// Previous Year
	/// </summary>
	public BaseInputControl ExpenYearprev => new BaseInputControl(driver, formLocator, "#DESPE___EXPENYEARPREV");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public DespeForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("DESPE")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpconForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// CONTACT TYPE
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#TPCON___PSEUDNOVOGR01-container");
	/// <summary>
	/// Genre
	/// </summary>
	public LookupControl GenreGender => new LookupControl(driver, formLocator, "container-TPCON___GENREGENDER__");
	public SeeMorePage GenreGenderSeeMorePage => new SeeMorePage(driver, "TPCON", "GENRE.GENDER");
	/// <summary>
	/// Contact Type:
	/// </summary>
	public BaseInputControl TpconTipocont => new BaseInputControl(driver, formLocator, "#TPCON___TPCONTIPOCONT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public TpconForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("TPCON")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EsppeForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, formLocator, "container-ESPPE___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "ESPPE", "PESSO.NAME");
	/// <summary>
	/// Specialty
	/// </summary>
	public LookupControl SpeciEspecial => new LookupControl(driver, formLocator, "container-ESPPE___SPECIESPECIAL");
	public SeeMorePage SpeciEspecialSeeMorePage => new SeeMorePage(driver, "ESPPE", "SPECI.ESPECIAL");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public EsppeForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ESPPE")).GetAttribute("data-loading") != "true");
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

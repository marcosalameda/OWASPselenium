namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class UsersForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Login name
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, formLocator, "container-USERS___PSW__NOME____");
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "USERS", "PSW.NOME");
	/// <summary>
	/// Person name
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, formLocator, "container-USERS___PERSONAME____");
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "USERS", "PERSO.NAME");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public UsersForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("USERS")).GetAttribute("data-loading") != "true");
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

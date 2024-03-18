namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ContaForm: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-CONTA");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name:
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, formLocator, "container-CONTA___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "CONTA", "PESSO.NAME");
	/// <summary>
	/// Genre
	/// </summary>
	public LookupControl GenreGender => new LookupControl(driver, formLocator, "container-CONTA___GENREGENDER__");
	public SeeMorePage GenreGenderSeeMorePage => new SeeMorePage(driver, "CONTA", "GENRE.GENDER");
	/// <summary>
	/// Contact Type:
	/// </summary>
	public LookupControl TpconTipocont => new LookupControl(driver, formLocator, "container-CONTA___TPCONTIPOCONT");
	public SeeMorePage TpconTipocontSeeMorePage => new SeeMorePage(driver, "CONTA", "TPCON.TIPOCONT");
	/// <summary>
	/// Contact
	/// </summary>
	public BaseInputControl ContaContacto => new BaseInputControl(driver, formLocator, "#CONTA___CONTACONTACTO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ContaForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("CONTA")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pessos01Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();
	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#PESSOS01PSEUDNOVOGR03-container");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, formLocator, "#PESSOS01PESSOTELEPHON");
	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, formLocator, "#PESSOS01PESSOEMAIL___");
	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#PESSOS01PSEUDNOVOGR04-container");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, formLocator, "#PESSOS01PESSOPHOTOGRA");
	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#PESSOS01PSEUDNOVOGR05-container");
	/// <summary>
	/// Professional Category Evolution
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, formLocator, "#PESSOS01PSEUDEVOLUCAO");
	/// <summary>
	/// Career record
	/// </summary>
	public EvcatForm  PseudFichacar => new EvcatForm(driver, FORM_MODE.EDIT, By.Id("PESSOS01PSEUDFICHACAR"));
	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, formLocator, "#PESSOS01PSEUDNOVOGR07-container");
	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudContacto => new ListControl(driver, formLocator, "#PESSOS01PSEUDCONTACTO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Pessos01Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PESSOS01")).GetAttribute("data-loading") != "true");
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

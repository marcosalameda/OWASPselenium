namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessosepForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#PESSOSEPPSEUDNOVOGR02-container");
	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, formLocator, "#PESSOSEPPESSOIDFUNCIO");
	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, formLocator, "#PESSOSEPPESSONAME____");
	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl PessoDtnascim => new DateInputControl(driver, formLocator, "#PESSOSEPPESSODTNASCIM");
	/// <summary>
	/// Gender
	/// </summary>
	public RadiobuttonControl PessoGender => new RadiobuttonControl(driver, formLocator, "container-PESSOSEPPESSOGENDER__");
	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl PessoInterna => new CheckboxInputControl(driver, formLocator, "#container-PESSOSEPPESSOINTERNA_");
	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl PessoExterna => new CheckboxInputControl(driver, formLocator, "#container-PESSOSEPPESSOEXTERNA_");
	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategCategory => new LookupControl(driver, formLocator, "container-PESSOSEPCATEGCATEGORY");
	public SeeMorePage CategCategorySeeMorePage => new SeeMorePage(driver, "PESSOSEP", "CATEG.CATEGORY");
	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl PessoDtultcat => new DateInputControl(driver, formLocator, "#PESSOSEPPESSODTULTCAT");
	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();
	/// <summary>
	/// COMPANY
	/// </summary>
	public TabControl PseudPessos00 => new TabControl(driver, formLocator, "#tab-container-PESSOSEPPSEUDPESSOS00");
	/// <summary>
	/// EVERYTHING
	/// </summary>
	public TabControl PseudPessos01 => new TabControl(driver, formLocator, "#tab-container-PESSOSEPPSEUDPESSOS01");
	/// <summary>
	/// Designation
	/// </summary>
	public LookupControl Pessos00CmpnyDesignat => new LookupControl(driver, formLocator, "container-PESSOS00CMPNYDESIGNAT");
	public SeeMorePage Pessos00CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSOSEP", "CMPNY.DESIGNAT");
	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement Pessos01PseudNovogr06 => throw new NotImplementedException();
	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl Pessos01PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#PESSOS01PSEUDNOVOGR03-container");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl Pessos01PessoTelephon => new BaseInputControl(driver, formLocator, "#PESSOS01PESSOTELEPHON");
	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl Pessos01PessoEmail => new BaseInputControl(driver, formLocator, "#PESSOS01PESSOEMAIL___");
	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl Pessos01PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#PESSOS01PSEUDNOVOGR04-container");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl Pessos01PessoPhotogra => new BaseInputControl(driver, formLocator, "#PESSOS01PESSOPHOTOGRA");
	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl Pessos01PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#PESSOS01PSEUDNOVOGR05-container");
	/// <summary>
	/// Professional Category Evolution
	/// </summary>
	public ListControl Pessos01PseudEvolucao => new ListControl(driver, formLocator, "#PESSOS01PSEUDEVOLUCAO");
	/// <summary>
	/// Career record
	/// </summary>
	public EvcatForm  Pessos01PseudFichacar => new EvcatForm(driver, FORM_MODE.EDIT, By.Id("PESSOS01PSEUDFICHACAR"));
	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl Pessos01PseudNovogr07 => new CollapsibleZoneControl(driver, formLocator, "#PESSOS01PSEUDNOVOGR07-container");
	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl Pessos01PseudContacto => new ListControl(driver, formLocator, "#PESSOS01PSEUDCONTACTO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PessosepForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PESSOSEP")).GetAttribute("data-loading") != "true");
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

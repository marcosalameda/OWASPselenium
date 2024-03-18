namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pesso1Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR08-container");
	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR04-container");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, formLocator, "#PESSO1__PESSOPHOTOGRA");
	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR02-container");
	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, formLocator, "#PESSO1__PESSOIDFUNCIO");
	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, formLocator, "#PESSO1__PESSONAME____");
	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl PessoDtnascim => new DateInputControl(driver, formLocator, "#PESSO1__PESSODTNASCIM");
	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl PessoIdade => new BaseInputControl(driver, formLocator, "#PESSO1__PESSOIDADE___");
	/// <summary>
	/// Gender
	/// </summary>
	public IWebElement PessoGender => throw new NotImplementedException();
	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl PessoInterna => new CheckboxInputControl(driver, formLocator, "#container-PESSO1__PESSOINTERNA_");
	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl PessoExterna => new CheckboxInputControl(driver, formLocator, "#container-PESSO1__PESSOEXTERNA_");
	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategCategory => new LookupControl(driver, formLocator, "container-PESSO1__CATEGCATEGORY");
	public SeeMorePage CategCategorySeeMorePage => new SeeMorePage(driver, "PESSO1", "CATEG.CATEGORY");
	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl PessoDtultcat => new DateInputControl(driver, formLocator, "#PESSO1__PESSODTULTCAT");
	/// <summary>
	/// ACCORDION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR06-container");
	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR07-container");
	/// <summary>
	/// MAIN CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR03-container");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, formLocator, "#PESSO1__PESSOTELEPHON");
	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, formLocator, "#PESSO1__PESSOEMAIL___");
	/// <summary>
	/// ALL CONTACTS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr09 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR09-container");
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudContacto => new ListControl(driver, formLocator, "#PESSO1__PSEUDCONTACTO");
	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR05-container");
	/// <summary>
	/// COMPANY
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR01-container");
	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, formLocator, "container-PESSO1__CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSO1", "CMPNY.DESIGNAT");
	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CntryCountry => throw new NotImplementedException();
	/// <summary>
	/// EVOLUTION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr10 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR10-container");
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, formLocator, "#PESSO1__PSEUDEVOLUCAO");
	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();
	/// <summary>
	/// Place of Birth
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, formLocator, "#PESSO1__PSEUDNOVOGR11-container");
	/// <summary>
	/// Region
	/// </summary>
	public LookupControl Regi1Regiao => new LookupControl(driver, formLocator, "container-PESSO1__REGI1REGIAO__");
	public SeeMorePage Regi1RegiaoSeeMorePage => new SeeMorePage(driver, "PESSO1", "REGI1.REGIAO");
	/// <summary>
	/// Country
	/// </summary>
	public IWebElement Pais1Country => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Pesso1Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PESSO1")).GetAttribute("data-loading") != "true");
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

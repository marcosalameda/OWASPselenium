namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessoForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR08-container");
	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR04-container");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, formLocator, "#PESSO___PESSOPHOTOGRA");
	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR02-container");
	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, formLocator, "#PESSO___PESSOIDFUNCIO");
	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, formLocator, "#PESSO___PESSONAME____");
	/// <summary>
	/// Gender
	/// </summary>
	public RadiobuttonControl PessoGender => new RadiobuttonControl(driver, formLocator, "container-PESSO___PESSOGENDER__");
	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl PessoDtnascim => new DateInputControl(driver, formLocator, "#PESSO___PESSODTNASCIM");
	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl PessoIdade => new BaseInputControl(driver, formLocator, "#PESSO___PESSOIDADE___");
	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl PessoInterna => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOINTERNA_");
	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl PessoExterna => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOEXTERNA_");
	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategCategory => new LookupControl(driver, formLocator, "container-PESSO___CATEGCATEGORY");
	public SeeMorePage CategCategorySeeMorePage => new SeeMorePage(driver, "PESSO", "CATEG.CATEGORY");
	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl PessoDtultcat => new DateInputControl(driver, formLocator, "#PESSO___PESSODTULTCAT");
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, formLocator, "container-PESSO___PAIS1COUNTRY_");
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "PESSO", "PAIS1.COUNTRY");
	/// <summary>
	/// Specialties
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR11-container");
	/// <summary>
	/// Specialties
	/// </summary>
	public IWebElement PseudEspecial => throw new NotImplementedException();
	/// <summary>
	/// Specialties
	/// </summary>
	public ListControl PseudEspecitl => new ListControl(driver, formLocator, "#PESSO___PSEUDESPECITL");
	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR07-container");
	/// <summary>
	/// MAIN CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR03-container");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, formLocator, "#PESSO___PESSOTELEPHON");
	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, formLocator, "#PESSO___PESSOEMAIL___");
	/// <summary>
	/// ALL CONTACTS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr09 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR09-container");
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudContacto => new ListControl(driver, formLocator, "#PESSO___PSEUDCONTACTO");
	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR05-container");
	/// <summary>
	/// Company
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR01-container");
	/// <summary>
	/// C&D
	/// </summary>
	public CollapsibleZoneControl PseudNovogr13 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR13-container");
	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, formLocator, "container-PESSO___CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSO", "CMPNY.DESIGNAT");
	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CntryCountry => throw new NotImplementedException();
	/// <summary>
	/// Region of the person:
	/// </summary>
	public LookupControl Regi1Regiao => new LookupControl(driver, formLocator, "container-PESSO___REGI1REGIAO__");
	public SeeMorePage Regi1RegiaoSeeMorePage => new SeeMorePage(driver, "PESSO", "REGI1.REGIAO");
	/// <summary>
	/// EVOLUTION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr10 => new CollapsibleZoneControl(driver, formLocator, "#PESSO___PSEUDNOVOGR10-container");
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, formLocator, "#PESSO___PSEUDEVOLUCAO");
	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();
	/// <summary>
	/// Static Image
	/// </summary>
	public IWebElement PseudStaticim => throw new NotImplementedException();
	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();
	/// <summary>
	/// Alternative Email
	/// </summary>
	public BaseInputControl PessoEmail2 => new BaseInputControl(driver, formLocator, "#PESSO___PESSOEMAIL2__");
	/// <summary>
	/// Terrain
	/// </summary>
	public IWebElement PseudTerragrp => throw new NotImplementedException();
	/// <summary>
	/// Query for external API
	/// </summary>
	public BaseInputControl PessoExtquery => new BaseInputControl(driver, formLocator, "#PESSO___PESSOEXTQUERY");
	/// <summary>
	/// Zoom level
	/// </summary>
	public BaseInputControl PessoZoomlvl => new BaseInputControl(driver, formLocator, "#PESSO___PESSOZOOMLVL_");
	/// <summary>
	/// Minimum zoom to load features
	/// </summary>
	public BaseInputControl PessoExtminzm => new BaseInputControl(driver, formLocator, "#PESSO___PESSOEXTMINZM");
	/// <summary>
	/// Map height
	/// </summary>
	public BaseInputControl PessoMapheigh => new BaseInputControl(driver, formLocator, "#PESSO___PESSOMAPHEIGH");
	/// <summary>
	/// Outline weight
	/// </summary>
	public BaseInputControl PessoOutweigh => new BaseInputControl(driver, formLocator, "#PESSO___PESSOOUTWEIGH");
	/// <summary>
	/// Polyline color
	/// </summary>
	public BaseInputControl PessoLineclr => new BaseInputControl(driver, formLocator, "#PESSO___PESSOLINECLR_");
	/// <summary>
	/// Polygon color
	/// </summary>
	public BaseInputControl PessoPolyclr => new BaseInputControl(driver, formLocator, "#PESSO___PESSOPOLYCLR_");
	/// <summary>
	/// Allow drawing markers
	/// </summary>
	public CheckboxInputControl PessoDrawmrk => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSODRAWMRK_");
	/// <summary>
	/// Allow drawing polylines
	/// </summary>
	public CheckboxInputControl PessoAllowlin => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOALLOWLIN");
	/// <summary>
	/// Allow drawing polygons
	/// </summary>
	public CheckboxInputControl PessoAllowpol => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOALLOWPOL");
	/// <summary>
	/// Allow exporting map
	/// </summary>
	public CheckboxInputControl PessoCanexpor => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOCANEXPOR");
	/// <summary>
	/// Group markers in cluster
	/// </summary>
	public CheckboxInputControl PessoGroupmrk => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOGROUPMRK");
	/// <summary>
	/// Allow feature editing
	/// </summary>
	public CheckboxInputControl PessoCanedit => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOCANEDIT_");
	/// <summary>
	/// Allow feature cutting
	/// </summary>
	public CheckboxInputControl PessoCancut => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOCANCUT__");
	/// <summary>
	/// Allow feature dragging
	/// </summary>
	public CheckboxInputControl PessoCandrag => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOCANDRAG_");
	/// <summary>
	/// Allow feature rotation
	/// </summary>
	public CheckboxInputControl PessoCanrot => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOCANROT__");
	/// <summary>
	/// Allow feature removal
	/// </summary>
	public CheckboxInputControl PessoCanremov => new CheckboxInputControl(driver, formLocator, "#container-PESSO___PESSOCANREMOV");
	/// <summary>
	/// Terrain
	/// </summary>
	public BaseInputControl PessoTerrain => new BaseInputControl(driver, formLocator, "#PESSO___PESSOTERRAIN_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PessoForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PESSO")).GetAttribute("data-loading") != "true");
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

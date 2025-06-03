using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessoForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR08-container");

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR04-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOPHOTOGRA", "#PESSO___PESSOPHOTOGRA");

	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR02-container");

	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOIDFUNCIO", "#PESSO___PESSOIDFUNCIO");

	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSONAME____", "#PESSO___PESSONAME____");

	/// <summary>
	/// Gender
	/// </summary>
	public RadiobuttonControl PessoGender => new RadiobuttonControl(driver, ContainerLocator, "container-PESSO___PESSOGENDER__");

	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl PessoDtnascim => new DateInputControl(driver, ContainerLocator, "#PESSO___PESSODTNASCIM");

	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl PessoIdade => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOIDADE___", "#PESSO___PESSOIDADE___");

	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl PessoInterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOINTERNA_");

	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl PessoExterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOEXTERNA_");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategCategory => new LookupControl(driver, ContainerLocator, "container-PESSO___CATEGCATEGORY");
	public SeeMorePage CategCategorySeeMorePage => new SeeMorePage(driver, "PESSO", "PESSO___CATEGCATEGORY");

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl PessoDtultcat => new DateInputControl(driver, ContainerLocator, "#PESSO___PESSODTULTCAT");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, ContainerLocator, "container-PESSO___PAIS1COUNTRY_");
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "PESSO", "PESSO___PAIS1COUNTRY_");

	/// <summary>
	/// Specialties
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR11-container");

	/// <summary>
	/// Specialties
	/// </summary>
	public IWebElement PseudEspecial => throw new NotImplementedException();

	/// <summary>
	/// Specialties
	/// </summary>
	public ListControl PseudEspecitl => new ListControl(driver, ContainerLocator, "#PESSO___PSEUDESPECITL");

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR07-container");

	/// <summary>
	/// MAIN CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR03-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOTELEPHON", "#PESSO___PESSOTELEPHON");

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOEMAIL___", "#PESSO___PESSOEMAIL___");

	/// <summary>
	/// ALL CONTACTS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr09 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR09-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudContacto => new ListControl(driver, ContainerLocator, "#PESSO___PSEUDCONTACTO");

	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR05-container");

	/// <summary>
	/// Company
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR01-container");

	/// <summary>
	/// C&D
	/// </summary>
	public CollapsibleZoneControl PseudNovogr13 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR13-container");

	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-PESSO___CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSO", "PESSO___CMPNYDESIGNAT");

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CntryCountry => throw new NotImplementedException();

	/// <summary>
	/// Region of the person:
	/// </summary>
	public LookupControl Regi1Regiao => new LookupControl(driver, ContainerLocator, "container-PESSO___REGI1REGIAO__");
	public SeeMorePage Regi1RegiaoSeeMorePage => new SeeMorePage(driver, "PESSO", "PESSO___REGI1REGIAO__");

	/// <summary>
	/// EVOLUTION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr10 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR10-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, ContainerLocator, "#PESSO___PSEUDEVOLUCAO");

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
	public BaseInputControl PessoEmail2 => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOEMAIL2__", "#PESSO___PESSOEMAIL2__");

	/// <summary>
	/// Terrain
	/// </summary>
	public IWebElement PseudTerragrp => throw new NotImplementedException();

	/// <summary>
	/// Query for external API
	/// </summary>
	public BaseInputControl PessoExtquery => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOEXTQUERY", "#PESSO___PESSOEXTQUERY");

	/// <summary>
	/// Zoom level
	/// </summary>
	public BaseInputControl PessoZoomlvl => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOZOOMLVL_", "#PESSO___PESSOZOOMLVL_");

	/// <summary>
	/// Minimum zoom to load features
	/// </summary>
	public BaseInputControl PessoExtminzm => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOEXTMINZM", "#PESSO___PESSOEXTMINZM");

	/// <summary>
	/// Map height
	/// </summary>
	public BaseInputControl PessoMapheigh => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOMAPHEIGH", "#PESSO___PESSOMAPHEIGH");

	/// <summary>
	/// Outline weight
	/// </summary>
	public BaseInputControl PessoOutweigh => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOOUTWEIGH", "#PESSO___PESSOOUTWEIGH");

	/// <summary>
	/// Polyline color
	/// </summary>
	public BaseInputControl PessoLineclr => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOLINECLR_", "#PESSO___PESSOLINECLR_");

	/// <summary>
	/// Polygon color
	/// </summary>
	public BaseInputControl PessoPolyclr => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOPOLYCLR_", "#PESSO___PESSOPOLYCLR_");

	/// <summary>
	/// Allow drawing markers
	/// </summary>
	public CheckboxInputControl PessoDrawmrk => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSODRAWMRK_");

	/// <summary>
	/// Allow drawing polylines
	/// </summary>
	public CheckboxInputControl PessoAllowlin => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOALLOWLIN");

	/// <summary>
	/// Allow drawing polygons
	/// </summary>
	public CheckboxInputControl PessoAllowpol => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOALLOWPOL");

	/// <summary>
	/// Allow exporting map
	/// </summary>
	public CheckboxInputControl PessoCanexpor => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANEXPOR");

	/// <summary>
	/// Group markers in cluster
	/// </summary>
	public CheckboxInputControl PessoGroupmrk => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOGROUPMRK");

	/// <summary>
	/// Allow feature editing
	/// </summary>
	public CheckboxInputControl PessoCanedit => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANEDIT_");

	/// <summary>
	/// Allow feature cutting
	/// </summary>
	public CheckboxInputControl PessoCancut => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANCUT__");

	/// <summary>
	/// Allow feature dragging
	/// </summary>
	public CheckboxInputControl PessoCandrag => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANDRAG_");

	/// <summary>
	/// Allow feature rotation
	/// </summary>
	public CheckboxInputControl PessoCanrot => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANROT__");

	/// <summary>
	/// Allow feature removal
	/// </summary>
	public CheckboxInputControl PessoCanremov => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANREMOV");

	/// <summary>
	/// Terrain
	/// </summary>
	public BaseInputControl PessoTerrain => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOTERRAIN_", "#PESSO___PESSOTERRAIN_");

	public PessoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PESSO", containerLocator: containerLocator) { }
}

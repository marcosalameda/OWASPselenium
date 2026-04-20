using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessoForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR08" + IdSuffix + "-container");

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOPHOTOGRA" + IdSuffix, "#PESSO___PESSOPHOTOGRA" + IdSuffix);

	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOIDFUNCIO" + IdSuffix, "#PESSO___PESSOIDFUNCIO" + IdSuffix);

	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSONAME____" + IdSuffix, "#PESSO___PESSONAME____" + IdSuffix);

	/// <summary>
	/// Gender
	/// </summary>
	public RadiobuttonControl PessoGender => new RadiobuttonControl(driver, ContainerLocator, "container-PESSO___PESSOGENDER__" + IdSuffix);

	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl PessoDtnascim => new DateInputControl(driver, ContainerLocator, "#PESSO___PESSODTNASCIM" + IdSuffix);

	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl PessoIdade => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOIDADE___" + IdSuffix, "#PESSO___PESSOIDADE___" + IdSuffix);

	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl PessoInterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOINTERNA_" + IdSuffix);

	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl PessoExterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOEXTERNA_" + IdSuffix);

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategCategory => new LookupControl(driver, ContainerLocator, "container-PESSO___CATEGCATEGORY" + IdSuffix);
	public SeeMorePage CategCategorySeeMorePage => new SeeMorePage(driver, "PESSO", "PESSO___CATEGCATEGORY" + IdSuffix);

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl PessoDtultcat => new DateInputControl(driver, ContainerLocator, "#PESSO___PESSODTULTCAT" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl Pais1Country => new LookupControl(driver, ContainerLocator, "container-PESSO___PAIS1COUNTRY_" + IdSuffix);
	public SeeMorePage Pais1CountrySeeMorePage => new SeeMorePage(driver, "PESSO", "PESSO___PAIS1COUNTRY_" + IdSuffix);

	/// <summary>
	/// Specialties
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR11" + IdSuffix + "-container");

	/// <summary>
	/// Specialties
	/// </summary>
	public IWebElement PseudEspecial => throw new NotImplementedException();

	/// <summary>
	/// Specialties
	/// </summary>
	public ListControl PseudEspecitl => new ListControl(driver, ContainerLocator, "#PESSO___PSEUDESPECITL" + IdSuffix);

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR07" + IdSuffix + "-container");

	/// <summary>
	/// MAIN CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOTELEPHON" + IdSuffix, "#PESSO___PESSOTELEPHON" + IdSuffix);

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOEMAIL___" + IdSuffix, "#PESSO___PESSOEMAIL___" + IdSuffix);

	/// <summary>
	/// ALL CONTACTS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr09 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR09" + IdSuffix + "-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudContacto => new ListControl(driver, ContainerLocator, "#PESSO___PSEUDCONTACTO" + IdSuffix);

	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR05" + IdSuffix + "-container");

	/// <summary>
	/// Company
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// C&D
	/// </summary>
	public CollapsibleZoneControl PseudNovogr13 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR13" + IdSuffix + "-container");

	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-PESSO___CMPNYDESIGNAT" + IdSuffix);
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSO", "PESSO___CMPNYDESIGNAT" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CntryCountry => throw new NotImplementedException();

	/// <summary>
	/// Region of the person:
	/// </summary>
	public LookupControl Regi1Regiao => new LookupControl(driver, ContainerLocator, "container-PESSO___REGI1REGIAO__" + IdSuffix);
	public SeeMorePage Regi1RegiaoSeeMorePage => new SeeMorePage(driver, "PESSO", "PESSO___REGI1REGIAO__" + IdSuffix);

	/// <summary>
	/// EVOLUTION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr10 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDNOVOGR10" + IdSuffix + "-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, ContainerLocator, "#PESSO___PSEUDEVOLUCAO" + IdSuffix);

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
	public BaseInputControl PessoEmail2 => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOEMAIL2__" + IdSuffix, "#PESSO___PESSOEMAIL2__" + IdSuffix);

	/// <summary>
	/// Terrain
	/// </summary>
	public CollapsibleZoneControl PseudTerragrp => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO___PSEUDTERRAGRP" + IdSuffix + "-container");

	/// <summary>
	/// Query for external API
	/// </summary>
	public BaseInputControl PessoExtquery => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOEXTQUERY" + IdSuffix, "#PESSO___PESSOEXTQUERY" + IdSuffix);

	/// <summary>
	/// Zoom level
	/// </summary>
	public BaseInputControl PessoZoomlvl => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOZOOMLVL_" + IdSuffix, "#PESSO___PESSOZOOMLVL_" + IdSuffix);

	/// <summary>
	/// Minimum zoom to load features
	/// </summary>
	public BaseInputControl PessoExtminzm => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOEXTMINZM" + IdSuffix, "#PESSO___PESSOEXTMINZM" + IdSuffix);

	/// <summary>
	/// Map height
	/// </summary>
	public BaseInputControl PessoMapheigh => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOMAPHEIGH" + IdSuffix, "#PESSO___PESSOMAPHEIGH" + IdSuffix);

	/// <summary>
	/// Outline weight
	/// </summary>
	public BaseInputControl PessoOutweigh => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOOUTWEIGH" + IdSuffix, "#PESSO___PESSOOUTWEIGH" + IdSuffix);

	/// <summary>
	/// Polyline color
	/// </summary>
	public BaseInputControl PessoLineclr => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOLINECLR_" + IdSuffix, "#PESSO___PESSOLINECLR_" + IdSuffix);

	/// <summary>
	/// Polygon color
	/// </summary>
	public BaseInputControl PessoPolyclr => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOPOLYCLR_" + IdSuffix, "#PESSO___PESSOPOLYCLR_" + IdSuffix);

	/// <summary>
	/// Allow drawing markers
	/// </summary>
	public CheckboxInputControl PessoDrawmrk => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSODRAWMRK_" + IdSuffix);

	/// <summary>
	/// Allow drawing polylines
	/// </summary>
	public CheckboxInputControl PessoAllowlin => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOALLOWLIN" + IdSuffix);

	/// <summary>
	/// Allow drawing polygons
	/// </summary>
	public CheckboxInputControl PessoAllowpol => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOALLOWPOL" + IdSuffix);

	/// <summary>
	/// Allow exporting map
	/// </summary>
	public CheckboxInputControl PessoCanexpor => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANEXPOR" + IdSuffix);

	/// <summary>
	/// Group markers in cluster
	/// </summary>
	public CheckboxInputControl PessoGroupmrk => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOGROUPMRK" + IdSuffix);

	/// <summary>
	/// Allow feature editing
	/// </summary>
	public CheckboxInputControl PessoCanedit => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANEDIT_" + IdSuffix);

	/// <summary>
	/// Allow feature cutting
	/// </summary>
	public CheckboxInputControl PessoCancut => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANCUT__" + IdSuffix);

	/// <summary>
	/// Allow feature dragging
	/// </summary>
	public CheckboxInputControl PessoCandrag => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANDRAG_" + IdSuffix);

	/// <summary>
	/// Allow feature rotation
	/// </summary>
	public CheckboxInputControl PessoCanrot => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANROT__" + IdSuffix);

	/// <summary>
	/// Allow feature removal
	/// </summary>
	public CheckboxInputControl PessoCanremov => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO___PESSOCANREMOV" + IdSuffix);

	/// <summary>
	/// Terrain
	/// </summary>
	public BaseInputControl PessoTerrain => new BaseInputControl(driver, ContainerLocator, "container-PESSO___PESSOTERRAIN_" + IdSuffix, "#PESSO___PESSOTERRAIN_" + IdSuffix);

	public PessoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PESSO", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

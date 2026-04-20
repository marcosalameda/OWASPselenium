using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pesso1Form : Form
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR08" + IdSuffix + "-container");

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PESSO1__PESSOPHOTOGRA" + IdSuffix, "#PESSO1__PESSOPHOTOGRA" + IdSuffix);

	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, ContainerLocator, "container-PESSO1__PESSOIDFUNCIO" + IdSuffix, "#PESSO1__PESSOIDFUNCIO" + IdSuffix);

	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, ContainerLocator, "container-PESSO1__PESSONAME____" + IdSuffix, "#PESSO1__PESSONAME____" + IdSuffix);

	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl PessoDtnascim => new DateInputControl(driver, ContainerLocator, "#PESSO1__PESSODTNASCIM" + IdSuffix);

	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl PessoIdade => new BaseInputControl(driver, ContainerLocator, "container-PESSO1__PESSOIDADE___" + IdSuffix, "#PESSO1__PESSOIDADE___" + IdSuffix);

	/// <summary>
	/// Gender
	/// </summary>
	public IWebElement PessoGender => throw new NotImplementedException();

	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl PessoInterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO1__PESSOINTERNA_" + IdSuffix);

	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl PessoExterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO1__PESSOEXTERNA_" + IdSuffix);

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategCategory => new LookupControl(driver, ContainerLocator, "container-PESSO1__CATEGCATEGORY" + IdSuffix);
	public SeeMorePage CategCategorySeeMorePage => new SeeMorePage(driver, "PESSO1", "PESSO1__CATEGCATEGORY" + IdSuffix);

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl PessoDtultcat => new DateInputControl(driver, ContainerLocator, "#PESSO1__PESSODTULTCAT" + IdSuffix);

	/// <summary>
	/// ACCORDION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR06" + IdSuffix + "-container");

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR07" + IdSuffix + "-container");

	/// <summary>
	/// MAIN CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, ContainerLocator, "container-PESSO1__PESSOTELEPHON" + IdSuffix, "#PESSO1__PESSOTELEPHON" + IdSuffix);

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, ContainerLocator, "container-PESSO1__PESSOEMAIL___" + IdSuffix, "#PESSO1__PESSOEMAIL___" + IdSuffix);

	/// <summary>
	/// ALL CONTACTS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr09 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR09" + IdSuffix + "-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudContacto => new ListControl(driver, ContainerLocator, "#PESSO1__PSEUDCONTACTO" + IdSuffix);

	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR05" + IdSuffix + "-container");

	/// <summary>
	/// COMPANY
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-PESSO1__CMPNYDESIGNAT" + IdSuffix);
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSO1", "PESSO1__CMPNYDESIGNAT" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CntryCountry => throw new NotImplementedException();

	/// <summary>
	/// EVOLUTION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr10 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR10" + IdSuffix + "-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, ContainerLocator, "#PESSO1__PSEUDEVOLUCAO" + IdSuffix);

	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();

	/// <summary>
	/// Place of Birth
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR11" + IdSuffix + "-container");

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl Regi1Regiao => new LookupControl(driver, ContainerLocator, "container-PESSO1__REGI1REGIAO__" + IdSuffix);
	public SeeMorePage Regi1RegiaoSeeMorePage => new SeeMorePage(driver, "PESSO1", "PESSO1__REGI1REGIAO__" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement Pais1Country => throw new NotImplementedException();

	public Pesso1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PESSO1", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

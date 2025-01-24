using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pesso1Form : Form
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR08-container");

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR04-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, ContainerLocator, "#PESSO1__PESSOPHOTOGRA");

	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR02-container");

	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, ContainerLocator, "#PESSO1__PESSOIDFUNCIO");

	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, ContainerLocator, "#PESSO1__PESSONAME____");

	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl PessoDtnascim => new DateInputControl(driver, ContainerLocator, "#PESSO1__PESSODTNASCIM");

	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl PessoIdade => new BaseInputControl(driver, ContainerLocator, "#PESSO1__PESSOIDADE___");

	/// <summary>
	/// Gender
	/// </summary>
	public IWebElement PessoGender => throw new NotImplementedException();

	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl PessoInterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO1__PESSOINTERNA_");

	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl PessoExterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSO1__PESSOEXTERNA_");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategCategory => new LookupControl(driver, ContainerLocator, "container-PESSO1__CATEGCATEGORY");
	public SeeMorePage CategCategorySeeMorePage => new SeeMorePage(driver, "PESSO1", "PESSO1__CATEGCATEGORY");

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl PessoDtultcat => new DateInputControl(driver, ContainerLocator, "#PESSO1__PESSODTULTCAT");

	/// <summary>
	/// ACCORDION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR06-container");

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR07-container");

	/// <summary>
	/// MAIN CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR03-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, ContainerLocator, "#PESSO1__PESSOTELEPHON");

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, ContainerLocator, "#PESSO1__PESSOEMAIL___");

	/// <summary>
	/// ALL CONTACTS
	/// </summary>
	public CollapsibleZoneControl PseudNovogr09 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR09-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudContacto => new ListControl(driver, ContainerLocator, "#PESSO1__PSEUDCONTACTO");

	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR05-container");

	/// <summary>
	/// COMPANY
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR01-container");

	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-PESSO1__CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSO1", "PESSO1__CMPNYDESIGNAT");

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CntryCountry => throw new NotImplementedException();

	/// <summary>
	/// EVOLUTION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr10 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR10-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, ContainerLocator, "#PESSO1__PSEUDEVOLUCAO");

	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();

	/// <summary>
	/// Place of Birth
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSO1__PSEUDNOVOGR11-container");

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl Regi1Regiao => new LookupControl(driver, ContainerLocator, "container-PESSO1__REGI1REGIAO__");
	public SeeMorePage Regi1RegiaoSeeMorePage => new SeeMorePage(driver, "PESSO1", "PESSO1__REGI1REGIAO__");

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement Pais1Country => throw new NotImplementedException();

	public Pesso1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PESSO1", containerLocator: containerLocator) { }
}

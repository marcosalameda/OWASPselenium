using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessosepForm : Form
{
	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOSEPPSEUDNOVOGR02-container");

	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl PessoIdfuncio => new BaseInputControl(driver, ContainerLocator, "container-PESSOSEPPESSOIDFUNCIO", "#PESSOSEPPESSOIDFUNCIO");

	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, ContainerLocator, "container-PESSOSEPPESSONAME____", "#PESSOSEPPESSONAME____");

	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl PessoDtnascim => new DateInputControl(driver, ContainerLocator, "#PESSOSEPPESSODTNASCIM");

	/// <summary>
	/// Gender
	/// </summary>
	public RadiobuttonControl PessoGender => new RadiobuttonControl(driver, ContainerLocator, "container-PESSOSEPPESSOGENDER__");

	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl PessoInterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSOSEPPESSOINTERNA_");

	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl PessoExterna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESSOSEPPESSOEXTERNA_");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategCategory => new LookupControl(driver, ContainerLocator, "container-PESSOSEPCATEGCATEGORY");
	public SeeMorePage CategCategorySeeMorePage => new SeeMorePage(driver, "PESSOSEP", "PESSOSEPCATEGCATEGORY");

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl PessoDtultcat => new DateInputControl(driver, ContainerLocator, "#PESSOSEPPESSODTULTCAT");

	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();

	/// <summary>
	/// COMPANY
	/// </summary>
	public TabControl PseudPessos00 => new TabControl(driver, ContainerLocator, "#tab-container-PESSOSEPPSEUDPESSOS00");

	/// <summary>
	/// EVERYTHING
	/// </summary>
	public TabControl PseudPessos01 => new TabControl(driver, ContainerLocator, "#tab-container-PESSOSEPPSEUDPESSOS01");

	/// <summary>
	/// Designation
	/// </summary>
	public LookupControl Pessos00CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-PESSOS00CMPNYDESIGNAT");
	public SeeMorePage Pessos00CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSOS00", "PESSOS00CMPNYDESIGNAT");

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement Pessos01PseudNovogr06 => throw new NotImplementedException();

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl Pessos01PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOS01PSEUDNOVOGR03-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl Pessos01PessoTelephon => new BaseInputControl(driver, ContainerLocator, "container-PESSOS01PESSOTELEPHON", "#PESSOS01PESSOTELEPHON");

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl Pessos01PessoEmail => new BaseInputControl(driver, ContainerLocator, "container-PESSOS01PESSOEMAIL___", "#PESSOS01PESSOEMAIL___");

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl Pessos01PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOS01PSEUDNOVOGR04-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl Pessos01PessoPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PESSOS01PESSOPHOTOGRA", "#PESSOS01PESSOPHOTOGRA");

	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl Pessos01PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOS01PSEUDNOVOGR05-container");

	/// <summary>
	/// Professional Category Evolution
	/// </summary>
	public ListControl Pessos01PseudEvolucao => new ListControl(driver, ContainerLocator, "#PESSOS01PSEUDEVOLUCAO");

	/// <summary>
	/// Career record
	/// </summary>
	public EvcatForm  Pessos01PseudFichacar => new EvcatForm(driver, FORM_MODE.EDIT, By.Id("PESSOS01PSEUDFICHACAR"));

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl Pessos01PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOS01PSEUDNOVOGR07-container");

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl Pessos01PseudContacto => new ListControl(driver, ContainerLocator, "#PESSOS01PSEUDCONTACTO");

	public PessosepForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PESSOSEP", containerLocator: containerLocator) { }
}

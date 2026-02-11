using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pess1Form : Form
{
	/// <summary>
	/// Create Mock Person
	/// </summary>
 	public ButtonControl PseudField001 => new ButtonControl(driver, ContainerLocator, "#PESS1___PSEUDFIELD001");

	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-PESS1___CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESS1", "PESS1___CMPNYDESIGNAT");

	/// <summary>
	/// Interested
	/// </summary>
	public LookupControl StakeDesignat => new LookupControl(driver, ContainerLocator, "container-PESS1___STAKEDESIGNAT");
	public SeeMorePage StakeDesignatSeeMorePage => new SeeMorePage(driver, "PESS1", "PESS1___STAKEDESIGNAT");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl Pess1Name => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1NAME____", "#PESS1___PESS1NAME____");

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl Pess1Gender => new EnumControl(driver, ContainerLocator, "container-PESS1___PESS1GENDER__");

	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl Pess1Dtnascim => new DateInputControl(driver, ContainerLocator, "#PESS1___PESS1DTNASCIM");

	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl Pess1Idfuncio => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1IDFUNCIO", "#PESS1___PESS1IDFUNCIO");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl Pess1Telephon => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1TELEPHON", "#PESS1___PESS1TELEPHON");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl Pess1Email => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1EMAIL___", "#PESS1___PESS1EMAIL___");

	/// <summary>
	/// Email (confirm)
	/// </summary>
	public BaseInputControl Pess1Email2 => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1EMAIL2__", "#PESS1___PESS1EMAIL2__");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl Pess1Photogra => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1PHOTOGRA", "#PESS1___PESS1PHOTOGRA");

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl Pess1Dtultcat => new DateInputControl(driver, ContainerLocator, "#PESS1___PESS1DTULTCAT");

	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl Pess1Externa => new CheckboxInputControl(driver, ContainerLocator, "#container-PESS1___PESS1EXTERNA_");

	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl Pess1Interna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESS1___PESS1INTERNA_");

	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl Pess1Idade => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1IDADE___", "#PESS1___PESS1IDADE___");

	public Pess1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PESS1", containerLocator: containerLocator) { }
}

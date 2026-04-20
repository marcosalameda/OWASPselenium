using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pess1Form : Form
{
	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-PESS1___CMPNYDESIGNAT" + IdSuffix);
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESS1", "PESS1___CMPNYDESIGNAT" + IdSuffix);

	/// <summary>
	/// Interested
	/// </summary>
	public LookupControl StakeDesignat => new LookupControl(driver, ContainerLocator, "container-PESS1___STAKEDESIGNAT" + IdSuffix);
	public SeeMorePage StakeDesignatSeeMorePage => new SeeMorePage(driver, "PESS1", "PESS1___STAKEDESIGNAT" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl Pess1Name => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1NAME____" + IdSuffix, "#PESS1___PESS1NAME____" + IdSuffix);

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl Pess1Gender => new EnumControl(driver, ContainerLocator, "container-PESS1___PESS1GENDER__" + IdSuffix);

	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl Pess1Dtnascim => new DateInputControl(driver, ContainerLocator, "#PESS1___PESS1DTNASCIM" + IdSuffix);

	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl Pess1Idfuncio => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1IDFUNCIO" + IdSuffix, "#PESS1___PESS1IDFUNCIO" + IdSuffix);

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl Pess1Telephon => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1TELEPHON" + IdSuffix, "#PESS1___PESS1TELEPHON" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl Pess1Email => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1EMAIL___" + IdSuffix, "#PESS1___PESS1EMAIL___" + IdSuffix);

	/// <summary>
	/// Email (confirm)
	/// </summary>
	public BaseInputControl Pess1Email2 => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1EMAIL2__" + IdSuffix, "#PESS1___PESS1EMAIL2__" + IdSuffix);

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl Pess1Photogra => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1PHOTOGRA" + IdSuffix, "#PESS1___PESS1PHOTOGRA" + IdSuffix);

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl Pess1Dtultcat => new DateInputControl(driver, ContainerLocator, "#PESS1___PESS1DTULTCAT" + IdSuffix);

	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl Pess1Externa => new CheckboxInputControl(driver, ContainerLocator, "#container-PESS1___PESS1EXTERNA_" + IdSuffix);

	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl Pess1Interna => new CheckboxInputControl(driver, ContainerLocator, "#container-PESS1___PESS1INTERNA_" + IdSuffix);

	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl Pess1Idade => new BaseInputControl(driver, ContainerLocator, "container-PESS1___PESS1IDADE___" + IdSuffix, "#PESS1___PESS1IDADE___" + IdSuffix);

	public Pess1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PESS1", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

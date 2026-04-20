using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Contac03Form : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl ProcnName => new BaseInputControl(driver, ContainerLocator, "container-CONTAC03PROCNNAME____" + IdSuffix, "#CONTAC03PROCNNAME____" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl ProcnEmail => new BaseInputControl(driver, ContainerLocator, "container-CONTAC03PROCNEMAIL___" + IdSuffix, "#CONTAC03PROCNEMAIL___" + IdSuffix);

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl ProcnTelephon => new BaseInputControl(driver, ContainerLocator, "container-CONTAC03PROCNTELEPHON" + IdSuffix, "#CONTAC03PROCNTELEPHON" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProcnDescript => new BaseInputControl(driver, ContainerLocator, "container-CONTAC03PROCNDESCRIPT" + IdSuffix, "#CONTAC03PROCNDESCRIPT" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ProcnDate => new DateInputControl(driver, ContainerLocator, "#CONTAC03PROCNDATE____" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl PropeTitle => new LookupControl(driver, ContainerLocator, "container-CONTAC03PROPETITLE___" + IdSuffix);
	public SeeMorePage PropeTitleSeeMorePage => new SeeMorePage(driver, "CONTAC03", "CONTAC03PROPETITLE___" + IdSuffix);

	public Contac03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CONTAC03", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

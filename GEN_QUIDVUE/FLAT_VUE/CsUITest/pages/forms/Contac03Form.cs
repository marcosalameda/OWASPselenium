using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Contac03Form : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl ProcnName => new BaseInputControl(driver, ContainerLocator, "#CONTAC03PROCNNAME____");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl ProcnEmail => new BaseInputControl(driver, ContainerLocator, "#CONTAC03PROCNEMAIL___");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl ProcnTelephon => new BaseInputControl(driver, ContainerLocator, "#CONTAC03PROCNTELEPHON");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProcnDescript => new BaseInputControl(driver, ContainerLocator, "#CONTAC03PROCNDESCRIPT");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ProcnDate => new DateInputControl(driver, ContainerLocator, "#CONTAC03PROCNDATE____");

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl PropeTitle => new LookupControl(driver, ContainerLocator, "container-CONTAC03PROPETITLE___");
	public SeeMorePage PropeTitleSeeMorePage => new SeeMorePage(driver, "CONTAC03", "CONTAC03PROPETITLE___");

	public Contac03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONTAC03", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Contac19Form : PopupForm
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl ProcnName => new BaseInputControl(driver, ContainerLocator, "#CONTAC19PROCNNAME____");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl ProcnEmail => new BaseInputControl(driver, ContainerLocator, "#CONTAC19PROCNEMAIL___");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl ProcnTelephon => new BaseInputControl(driver, ContainerLocator, "#CONTAC19PROCNTELEPHON");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProcnDescript => new BaseInputControl(driver, ContainerLocator, "#CONTAC19PROCNDESCRIPT");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ProcnDate => new DateInputControl(driver, ContainerLocator, "#CONTAC19PROCNDATE____");

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl PropeTitle => new LookupControl(driver, ContainerLocator, "container-CONTAC19PROPETITLE___");
	public SeeMorePage PropeTitleSeeMorePage => new SeeMorePage(driver, "CONTAC19", "CONTAC19PROPETITLE___");

	public Contac19Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONTAC19") { }
}

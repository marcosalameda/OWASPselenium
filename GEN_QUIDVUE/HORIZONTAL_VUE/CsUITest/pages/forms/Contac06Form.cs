using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Contac06Form : PopupForm
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl ProcnName => new BaseInputControl(driver, ContainerLocator, "#CONTAC06PROCNNAME____");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl ProcnEmail => new BaseInputControl(driver, ContainerLocator, "#CONTAC06PROCNEMAIL___");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl ProcnTelephon => new BaseInputControl(driver, ContainerLocator, "#CONTAC06PROCNTELEPHON");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProcnDescript => new BaseInputControl(driver, ContainerLocator, "#CONTAC06PROCNDESCRIPT");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ProcnDate => new DateInputControl(driver, ContainerLocator, "#CONTAC06PROCNDATE____");

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl PropeTitle => new LookupControl(driver, ContainerLocator, "container-CONTAC06PROPETITLE___");
	public SeeMorePage PropeTitleSeeMorePage => new SeeMorePage(driver, "CONTAC06", "CONTAC06PROPETITLE___");

	public Contac06Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONTAC06") { }
}

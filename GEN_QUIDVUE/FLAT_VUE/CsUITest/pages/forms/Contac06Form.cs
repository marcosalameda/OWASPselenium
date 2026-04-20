using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Contac06Form : PopupForm
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl ProcnName => new BaseInputControl(driver, ContainerLocator, "container-CONTAC06PROCNNAME____" + IdSuffix, "#CONTAC06PROCNNAME____" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl ProcnEmail => new BaseInputControl(driver, ContainerLocator, "container-CONTAC06PROCNEMAIL___" + IdSuffix, "#CONTAC06PROCNEMAIL___" + IdSuffix);

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl ProcnTelephon => new BaseInputControl(driver, ContainerLocator, "container-CONTAC06PROCNTELEPHON" + IdSuffix, "#CONTAC06PROCNTELEPHON" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProcnDescript => new BaseInputControl(driver, ContainerLocator, "container-CONTAC06PROCNDESCRIPT" + IdSuffix, "#CONTAC06PROCNDESCRIPT" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ProcnDate => new DateInputControl(driver, ContainerLocator, "#CONTAC06PROCNDATE____" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl PropeTitle => new LookupControl(driver, ContainerLocator, "container-CONTAC06PROPETITLE___" + IdSuffix);
	public SeeMorePage PropeTitleSeeMorePage => new SeeMorePage(driver, "CONTAC06", "CONTAC06PROPETITLE___" + IdSuffix);

	public Contac06Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CONTAC06", usePkInId: usePkInId) { }
}

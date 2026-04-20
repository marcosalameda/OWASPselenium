using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Contac19Form : PopupForm
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl ProcnName => new BaseInputControl(driver, ContainerLocator, "container-CONTAC19PROCNNAME____" + IdSuffix, "#CONTAC19PROCNNAME____" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl ProcnEmail => new BaseInputControl(driver, ContainerLocator, "container-CONTAC19PROCNEMAIL___" + IdSuffix, "#CONTAC19PROCNEMAIL___" + IdSuffix);

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl ProcnTelephon => new BaseInputControl(driver, ContainerLocator, "container-CONTAC19PROCNTELEPHON" + IdSuffix, "#CONTAC19PROCNTELEPHON" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProcnDescript => new BaseInputControl(driver, ContainerLocator, "container-CONTAC19PROCNDESCRIPT" + IdSuffix, "#CONTAC19PROCNDESCRIPT" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ProcnDate => new DateInputControl(driver, ContainerLocator, "#CONTAC19PROCNDATE____" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl PropeTitle => new LookupControl(driver, ContainerLocator, "container-CONTAC19PROPETITLE___" + IdSuffix);
	public SeeMorePage PropeTitleSeeMorePage => new SeeMorePage(driver, "CONTAC19", "CONTAC19PROPETITLE___" + IdSuffix);

	public Contac19Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CONTAC19", usePkInId: usePkInId) { }
}

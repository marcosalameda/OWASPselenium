using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LcextForm : Form
{
	/// <summary>
	/// Location extension
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#LCEXT___PSEUDNOVOGR01-container");

	/// <summary>
	/// Global Location Number
	/// </summary>
	public LookupControl LocatGln => new LookupControl(driver, ContainerLocator, "container-LCEXT___LOCATGLN_____");
	public SeeMorePage LocatGlnSeeMorePage => new SeeMorePage(driver, "LCEXT", "LCEXT___LOCATGLN_____");

	/// <summary>
	/// GLN Extension Component
	/// </summary>
	public BaseInputControl LcextGlnext => new BaseInputControl(driver, ContainerLocator, "#LCEXT___LCEXTGLNEXT__");

	/// <summary>
	/// Space type
	/// </summary>
	public EnumControl LcextSpacetyp => new EnumControl(driver, ContainerLocator, "container-LCEXT___LCEXTSPACETYP");

	/// <summary>
	/// Space
	/// </summary>
	public BaseInputControl LcextSpaceobs => new BaseInputControl(driver, ContainerLocator, "#LCEXT___LCEXTSPACEOBS");

	public LcextForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LCEXT", containerLocator: containerLocator) { }
}

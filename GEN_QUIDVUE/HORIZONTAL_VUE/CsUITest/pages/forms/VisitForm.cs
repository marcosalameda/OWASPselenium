using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class VisitForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-VISIT___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "VISIT", "VISIT___EQUIPREGISTNR");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl VisitTitle => new BaseInputControl(driver, ContainerLocator, "container-VISIT___VISITTITLE___", "#VISIT___VISITTITLE___");

	/// <summary>
	/// Start:
	/// </summary>
	public DateInputControl VisitStartdt => new DateInputControl(driver, ContainerLocator, "#VISIT___VISITSTARTDT_", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl VisitDtfim => new DateInputControl(driver, ContainerLocator, "#VISIT___VISITDTFIM___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Description
	/// </summary>
	public IWebElement VisitDescript => throw new NotImplementedException();

	/// <summary>
	/// Day
	/// </summary>
	public CheckboxInputControl VisitTodoodia => new CheckboxInputControl(driver, ContainerLocator, "#container-VISIT___VISITTODOODIA");

	/// <summary>
	/// Color
	/// </summary>
	public BaseInputControl VisitColor => new BaseInputControl(driver, ContainerLocator, "container-VISIT___VISITCOLOR___", "#VISIT___VISITCOLOR___");

	/// <summary>
	/// Observations
	/// </summary>
	public BaseInputControl VisitObservat => new BaseInputControl(driver, ContainerLocator, "container-VISIT___VISITOBSERVAT", "#VISIT___VISITOBSERVAT");

	public VisitForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "VISIT", containerLocator: containerLocator) { }
}

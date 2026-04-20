using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class VisitForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-VISIT___EQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "VISIT", "VISIT___EQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl VisitTitle => new BaseInputControl(driver, ContainerLocator, "container-VISIT___VISITTITLE___" + IdSuffix, "#VISIT___VISITTITLE___" + IdSuffix);

	/// <summary>
	/// Start:
	/// </summary>
	public DateInputControl VisitStartdt => new DateInputControl(driver, ContainerLocator, "#VISIT___VISITSTARTDT_" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl VisitDtfim => new DateInputControl(driver, ContainerLocator, "#VISIT___VISITDTFIM___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Description
	/// </summary>
	public IWebElement VisitDescript => throw new NotImplementedException();

	/// <summary>
	/// Day
	/// </summary>
	public CheckboxInputControl VisitTodoodia => new CheckboxInputControl(driver, ContainerLocator, "#container-VISIT___VISITTODOODIA" + IdSuffix);

	/// <summary>
	/// Color
	/// </summary>
	public BaseInputControl VisitColor => new BaseInputControl(driver, ContainerLocator, "container-VISIT___VISITCOLOR___" + IdSuffix, "#VISIT___VISITCOLOR___" + IdSuffix);

	/// <summary>
	/// Observations
	/// </summary>
	public BaseInputControl VisitObservat => new BaseInputControl(driver, ContainerLocator, "container-VISIT___VISITOBSERVAT" + IdSuffix, "#VISIT___VISITOBSERVAT" + IdSuffix);

	public VisitForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "VISIT", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

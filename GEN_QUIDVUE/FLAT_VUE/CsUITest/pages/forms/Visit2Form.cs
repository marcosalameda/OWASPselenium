using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Visit2Form : PopupForm
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-VISIT2__EQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "VISIT2", "VISIT2__EQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl VisitTitle => new BaseInputControl(driver, ContainerLocator, "container-VISIT2__VISITTITLE___" + IdSuffix, "#VISIT2__VISITTITLE___" + IdSuffix);

	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl VisitStartdt => new DateInputControl(driver, ContainerLocator, "#VISIT2__VISITSTARTDT_" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl VisitDtfim => new DateInputControl(driver, ContainerLocator, "#VISIT2__VISITDTFIM___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl VisitDescript => new BaseInputControl(driver, ContainerLocator, "container-VISIT2__VISITDESCRIPT" + IdSuffix, "#VISIT2__VISITDESCRIPT" + IdSuffix);

	/// <summary>
	/// Day
	/// </summary>
	public CheckboxInputControl VisitTodoodia => new CheckboxInputControl(driver, ContainerLocator, "#container-VISIT2__VISITTODOODIA" + IdSuffix);

	/// <summary>
	/// Color
	/// </summary>
	public BaseInputControl VisitColor => new BaseInputControl(driver, ContainerLocator, "container-VISIT2__VISITCOLOR___" + IdSuffix, "#VISIT2__VISITCOLOR___" + IdSuffix);

	/// <summary>
	/// Background
	/// </summary>
	public CheckboxInputControl VisitBack => new CheckboxInputControl(driver, ContainerLocator, "#container-VISIT2__VISITBACK____" + IdSuffix);

	public Visit2Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "VISIT2", usePkInId: usePkInId) { }
}

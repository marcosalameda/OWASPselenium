using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ComodForm : Form
{
	/// <summary>
	/// Lending
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, ContainerLocator, "container-COMOD___PESS1NAME____" + IdSuffix);
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "COMOD", "COMOD___PESS1NAME____" + IdSuffix);

	/// <summary>
	/// Borrower:
	/// </summary>
	public LookupControl Pess2Name => new LookupControl(driver, ContainerLocator, "container-COMOD___PESS2NAME____" + IdSuffix);
	public SeeMorePage Pess2NameSeeMorePage => new SeeMorePage(driver, "COMOD", "COMOD___PESS2NAME____" + IdSuffix);

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-COMOD___EQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "COMOD", "COMOD___EQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Equipment
	/// </summary>
	public IWebElement EquipDesignat => throw new NotImplementedException();

	/// <summary>
	/// Loan Frequency
	/// </summary>
	public IWebElement EquipFrequenc => throw new NotImplementedException();

	/// <summary>
	/// Lending No
	/// </summary>
	public BaseInputControl LendiLendinnr => new BaseInputControl(driver, ContainerLocator, "container-COMOD___LENDILENDINNR" + IdSuffix, "#COMOD___LENDILENDINNR" + IdSuffix);

	/// <summary>
	/// Start:
	/// </summary>
	public DateInputControl LendiStart => new DateInputControl(driver, ContainerLocator, "#COMOD___LENDISTART___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Warning
	/// </summary>
	public DateInputControl LendiWarndt => new DateInputControl(driver, ContainerLocator, "#COMOD___LENDIWARNDT__" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl LendiEnd => new DateInputControl(driver, ContainerLocator, "#COMOD___LENDIEND_____" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Observation
	/// </summary>
	public BaseInputControl LendiObservat => new BaseInputControl(driver, ContainerLocator, "container-COMOD___LENDIOBSERVAT" + IdSuffix, "#COMOD___LENDIOBSERVAT" + IdSuffix);

	/// <summary>
	/// Returned
	/// </summary>
	public DateInputControl LendiReturndt => new DateInputControl(driver, ContainerLocator, "#COMOD___LENDIRETURNDT" + IdSuffix);

	/// <summary>
	/// Returned
	/// </summary>
	public CheckboxInputControl LendiReturned => new CheckboxInputControl(driver, ContainerLocator, "#container-COMOD___LENDIRETURNED" + IdSuffix);

	public ComodForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "COMOD", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ComodForm : Form
{
	/// <summary>
	/// Lending
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, ContainerLocator, "container-COMOD___PESS1NAME____");
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "COMOD", "COMOD___PESS1NAME____");

	/// <summary>
	/// Borrower:
	/// </summary>
	public LookupControl Pess2Name => new LookupControl(driver, ContainerLocator, "container-COMOD___PESS2NAME____");
	public SeeMorePage Pess2NameSeeMorePage => new SeeMorePage(driver, "COMOD", "COMOD___PESS2NAME____");

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-COMOD___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "COMOD", "COMOD___EQUIPREGISTNR");

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
	public BaseInputControl LendiLendinnr => new BaseInputControl(driver, ContainerLocator, "container-COMOD___LENDILENDINNR", "#COMOD___LENDILENDINNR");

	/// <summary>
	/// Start:
	/// </summary>
	public DateInputControl LendiStart => new DateInputControl(driver, ContainerLocator, "#COMOD___LENDISTART___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Warning
	/// </summary>
	public DateInputControl LendiWarndt => new DateInputControl(driver, ContainerLocator, "#COMOD___LENDIWARNDT__", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl LendiEnd => new DateInputControl(driver, ContainerLocator, "#COMOD___LENDIEND_____", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Observation
	/// </summary>
	public IWebElement LendiObservat => throw new NotImplementedException();

	/// <summary>
	/// Returned
	/// </summary>
	public DateInputControl LendiReturndt => new DateInputControl(driver, ContainerLocator, "#COMOD___LENDIRETURNDT");

	/// <summary>
	/// Returned
	/// </summary>
	public CheckboxInputControl LendiReturned => new CheckboxInputControl(driver, ContainerLocator, "#container-COMOD___LENDIRETURNED");

	public ComodForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "COMOD", containerLocator: containerLocator) { }
}

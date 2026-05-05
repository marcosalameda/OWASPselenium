using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MovimForm : Form
{
	/// <summary>
	/// Change
	/// </summary>
	public DateInputControl MovimDhmudanc => new DateInputControl(driver, ContainerLocator, "#MOVIM___MOVIMDHMUDANC", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-MOVIM___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "MOVIM", "MOVIM___EQUIPREGISTNR");

	/// <summary>
	/// Room No.
	/// </summary>
	public LookupControl RoomsRoomnr => new LookupControl(driver, ContainerLocator, "container-MOVIM___ROOMSROOMNR__");
	public SeeMorePage RoomsRoomnrSeeMorePage => new SeeMorePage(driver, "MOVIM", "MOVIM___ROOMSROOMNR__");

	/// <summary>
	/// Observation
	/// </summary>
	public BaseInputControl MovimObservat => new BaseInputControl(driver, ContainerLocator, "container-MOVIM___MOVIMOBSERVAT", "#MOVIM___MOVIMOBSERVAT");

	public MovimForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "MOVIM", containerLocator: containerLocator) { }
}

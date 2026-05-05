using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class SalasForm : Form
{
	/// <summary>
	/// Room No.
	/// </summary>
	public BaseInputControl RoomsRoomnr => new BaseInputControl(driver, ContainerLocator, "container-SALAS___ROOMSROOMNR__", "#SALAS___ROOMSROOMNR__");

	/// <summary>
	/// Room Designation
	/// </summary>
	public BaseInputControl RoomsDesignat => new BaseInputControl(driver, ContainerLocator, "container-SALAS___ROOMSDESIGNAT", "#SALAS___ROOMSDESIGNAT");

	public SalasForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "SALAS", containerLocator: containerLocator) { }
}

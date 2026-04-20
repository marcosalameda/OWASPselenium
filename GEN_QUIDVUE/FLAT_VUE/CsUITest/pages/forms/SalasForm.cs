using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class SalasForm : Form
{
	/// <summary>
	/// Room No.
	/// </summary>
	public BaseInputControl RoomsRoomnr => new BaseInputControl(driver, ContainerLocator, "container-SALAS___ROOMSROOMNR__" + IdSuffix, "#SALAS___ROOMSROOMNR__" + IdSuffix);

	/// <summary>
	/// Room Designation
	/// </summary>
	public BaseInputControl RoomsDesignat => new BaseInputControl(driver, ContainerLocator, "container-SALAS___ROOMSDESIGNAT" + IdSuffix, "#SALAS___ROOMSDESIGNAT" + IdSuffix);

	public SalasForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "SALAS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

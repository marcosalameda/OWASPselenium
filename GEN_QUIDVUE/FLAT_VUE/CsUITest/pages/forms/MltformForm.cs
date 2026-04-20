using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MltformForm : Form
{
	/// <summary>
	/// Warehouse
	/// </summary>
	public BaseInputControl WarehWarehdes => new BaseInputControl(driver, ContainerLocator, "container-MLTFORM_WAREHWAREHDES" + IdSuffix, "#MLTFORM_WAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl WarehWarehcod => new BaseInputControl(driver, ContainerLocator, "container-MLTFORM_WAREHWAREHCOD" + IdSuffix, "#MLTFORM_WAREHWAREHCOD" + IdSuffix);

	/// <summary>
	/// Warehouse employees
	/// </summary>
	public IWebElement PseudMltform1 => throw new NotImplementedException();

	public MltformForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "MLTFORM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

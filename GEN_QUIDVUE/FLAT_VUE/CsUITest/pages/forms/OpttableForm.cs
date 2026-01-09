using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class OpttableForm : PopupForm
{
	/// <summary>
	/// Variant
	/// </summary>
	public BaseInputControl CompvCompvar => new BaseInputControl(driver, ContainerLocator, "container-OPTTABLECOMPVCOMPVAR_", "#OPTTABLECOMPVCOMPVAR_");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CompvVaridesc => new BaseInputControl(driver, ContainerLocator, "container-OPTTABLECOMPVVARIDESC", "#OPTTABLECOMPVVARIDESC");

	public OpttableForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "OPTTABLE") { }
}

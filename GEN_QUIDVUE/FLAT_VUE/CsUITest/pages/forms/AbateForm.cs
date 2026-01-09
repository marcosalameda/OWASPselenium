using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AbateForm : Form
{
	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl DecomDtdeco => new DateInputControl(driver, ContainerLocator, "#ABATE___DECOMDTDECO__", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// No bate
	/// </summary>
	public BaseInputControl DecomDecomnr => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMDECOMNR_", "#ABATE___DECOMDECOMNR_");

	public AbateForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ABATE", containerLocator: containerLocator) { }
}

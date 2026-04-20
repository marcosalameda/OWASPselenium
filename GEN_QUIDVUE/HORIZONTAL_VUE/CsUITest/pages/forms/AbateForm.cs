using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AbateForm : Form
{
	/// <summary>
	/// No decomission
	/// </summary>
	public BaseInputControl DecomDecomnr => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMDECOMNR_" + IdSuffix, "#ABATE___DECOMDECOMNR_" + IdSuffix);

	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl DecomDtdeco => new DateInputControl(driver, ContainerLocator, "#ABATE___DECOMDTDECO__" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl DecomNote => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMNOTE____" + IdSuffix, "#ABATE___DECOMNOTE____" + IdSuffix);

	public AbateForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ABATE", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

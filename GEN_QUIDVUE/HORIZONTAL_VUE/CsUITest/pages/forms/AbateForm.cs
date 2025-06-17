using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AbateForm : Form
{
	/// <summary>
	/// No decomission
	/// </summary>
	public BaseInputControl DecomDecomnr => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMDECOMNR_", "#ABATE___DECOMDECOMNR_");

	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl DecomDtdeco => new DateInputControl(driver, ContainerLocator, "#ABATE___DECOMDTDECO__", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl DecomNote => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMNOTE____", "#ABATE___DECOMNOTE____");

	/// <summary>
	/// Creation date
	/// </summary>
	public BaseInputControl DecomCreatdat => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMCREATDAT", "#ABATE___DECOMCREATDAT");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl DecomCreatope => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMCREATOPE", "#ABATE___DECOMCREATOPE");

	/// <summary>
	/// Changed on
	/// </summary>
	public BaseInputControl DecomChngdate => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMCHNGDATE", "#ABATE___DECOMCHNGDATE");

	/// <summary>
	/// Changed by
	/// </summary>
	public BaseInputControl DecomOperchng => new BaseInputControl(driver, ContainerLocator, "container-ABATE___DECOMOPERCHNG", "#ABATE___DECOMOPERCHNG");

	public AbateForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ABATE", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AbatereqForm : Form
{
	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudReqtext => throw new NotImplementedException();

	/// <summary>
	/// Number
	/// </summary>
	public BaseInputControl DecomDecomnr => new BaseInputControl(driver, ContainerLocator, "container-ABATEREQDECOMDECOMNR_", "#ABATEREQDECOMDECOMNR_");

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl DecomNote => new BaseInputControl(driver, ContainerLocator, "container-ABATEREQDECOMNOTE____", "#ABATEREQDECOMNOTE____");

	/// <summary>
	/// Collapsible
	/// </summary>
	public IWebElement PseudCollapse => throw new NotImplementedException();

	/// <summary>
	/// Tab
	/// </summary>
	public TabControl PseudAbatetab => new TabControl(driver, ContainerLocator, "#tab-container-ABATEREQPSEUDABATETAB");

	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl DecomDtdeco => new DateInputControl(driver, ContainerLocator, "#ABATEREQDECOMDTDECO__", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Creation date
	/// </summary>
	public BaseInputControl DecomCreatdat => new BaseInputControl(driver, ContainerLocator, "container-ABATEREQDECOMCREATDAT", "#ABATEREQDECOMCREATDAT");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl DecomCreatope => new BaseInputControl(driver, ContainerLocator, "container-ABATEREQDECOMCREATOPE", "#ABATEREQDECOMCREATOPE");

	/// <summary>
	/// Changed on
	/// </summary>
	public BaseInputControl DecomChngdate => new BaseInputControl(driver, ContainerLocator, "container-ABATEREQDECOMCHNGDATE", "#ABATEREQDECOMCHNGDATE");

	/// <summary>
	/// Changed by
	/// </summary>
	public BaseInputControl DecomOperchng => new BaseInputControl(driver, ContainerLocator, "container-ABATEREQDECOMOPERCHNG", "#ABATEREQDECOMOPERCHNG");

	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl AbatetabDecomDtdeco => new DateInputControl(driver, ContainerLocator, "#ABATETABDECOMDTDECO__", "dd/MM/yyyy HH:mm");

	public AbatereqForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ABATEREQ", containerLocator: containerLocator) { }
}

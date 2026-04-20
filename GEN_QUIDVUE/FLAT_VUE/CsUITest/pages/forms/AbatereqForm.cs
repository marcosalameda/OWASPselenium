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
	public BaseInputControl DecomDecomnr => new BaseInputControl(driver, ContainerLocator, "container-ABATEREQDECOMDECOMNR_" + IdSuffix, "#ABATEREQDECOMDECOMNR_" + IdSuffix);

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl DecomNote => new BaseInputControl(driver, ContainerLocator, "container-ABATEREQDECOMNOTE____" + IdSuffix, "#ABATEREQDECOMNOTE____" + IdSuffix);

	/// <summary>
	/// Collapsible
	/// </summary>
	public CollapsibleZoneControl PseudCollapse => new CollapsibleZoneControl(driver, ContainerLocator, "#ABATEREQPSEUDCOLLAPSE" + IdSuffix + "-container");

	/// <summary>
	/// Tab
	/// </summary>
	public TabControl PseudAbatetab => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-ABATEREQPSEUDABATETAB']");

	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl AbatetabDecomDtdeco => new DateInputControl(driver, ContainerLocator, "#ABATETABDECOMDTDECO__" + IdSuffix, "dd/MM/yyyy HH:mm");

	public AbatereqForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ABATEREQ", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

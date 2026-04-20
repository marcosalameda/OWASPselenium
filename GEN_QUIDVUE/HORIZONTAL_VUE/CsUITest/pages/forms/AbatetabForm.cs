using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AbatetabForm : Subform
{
	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl DecomDtdeco => new DateInputControl(driver, ContainerLocator, "#ABATETABDECOMDTDECO__" + IdSuffix, "dd/MM/yyyy HH:mm");

	public AbatetabForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ABATETAB", "ABATEREQ", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

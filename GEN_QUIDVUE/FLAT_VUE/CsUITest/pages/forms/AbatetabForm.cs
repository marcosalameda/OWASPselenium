using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AbatetabForm : Subform
{
	/// <summary>
	/// Decomission
	/// </summary>
	public DateInputControl DecomDtdeco => new DateInputControl(driver, ContainerLocator, "#ABATETABDECOMDTDECO__", "dd/MM/yyyy HH:mm");

	public AbatetabForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ABATETAB", "ABATEREQ", containerLocator: containerLocator) { }
}

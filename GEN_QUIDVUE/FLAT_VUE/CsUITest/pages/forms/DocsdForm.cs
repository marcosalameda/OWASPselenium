using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DocsdForm : Form
{
	/// <summary>
	/// Number:
	/// </summary>
	public BaseInputControl OudocNrdocsda => new BaseInputControl(driver, ContainerLocator, "#DOCSD___OUDOCNRDOCSDA");

	/// <summary>
	/// Date:
	/// </summary>
	public DateInputControl OudocDtdocsda => new DateInputControl(driver, ContainerLocator, "#DOCSD___OUDOCDTDOCSDA", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl OudocTitle => new BaseInputControl(driver, ContainerLocator, "#DOCSD___OUDOCTITLE___");

	public DocsdForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DOCSD", containerLocator: containerLocator) { }
}

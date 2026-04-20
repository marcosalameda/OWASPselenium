using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DocsdForm : Form
{
	/// <summary>
	/// Number:
	/// </summary>
	public BaseInputControl OudocNrdocsda => new BaseInputControl(driver, ContainerLocator, "container-DOCSD___OUDOCNRDOCSDA" + IdSuffix, "#DOCSD___OUDOCNRDOCSDA" + IdSuffix);

	/// <summary>
	/// Date:
	/// </summary>
	public DateInputControl OudocDtdocsda => new DateInputControl(driver, ContainerLocator, "#DOCSD___OUDOCDTDOCSDA" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl OudocTitle => new BaseInputControl(driver, ContainerLocator, "container-DOCSD___OUDOCTITLE___" + IdSuffix, "#DOCSD___OUDOCTITLE___" + IdSuffix);

	public DocsdForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "DOCSD", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RordfForm : Form
{
	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl RordfOrder => new BaseInputControl(driver, ContainerLocator, "container-RORDF___RORDFORDER___" + IdSuffix, "#RORDF___RORDFORDER___" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl RordfTitle => new BaseInputControl(driver, ContainerLocator, "container-RORDF___RORDFTITLE___" + IdSuffix, "#RORDF___RORDFTITLE___" + IdSuffix);

	public RordfForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "RORDF", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

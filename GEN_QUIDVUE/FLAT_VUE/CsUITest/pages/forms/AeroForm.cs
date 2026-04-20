using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AeroForm : Form
{
	/// <summary>
	/// Airline
	/// </summary>
	public BaseInputControl AeroName => new BaseInputControl(driver, ContainerLocator, "container-AERO____AERO_NAME____" + IdSuffix, "#AERO____AERO_NAME____" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl AeroCodcmaer => new BaseInputControl(driver, ContainerLocator, "container-AERO____AERO_CODCMAER" + IdSuffix, "#AERO____AERO_CODCMAER" + IdSuffix);

	public AeroForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "AERO", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

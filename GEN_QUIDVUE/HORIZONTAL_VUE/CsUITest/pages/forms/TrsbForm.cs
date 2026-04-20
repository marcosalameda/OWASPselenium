using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TrsbForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl TrsbName => new BaseInputControl(driver, ContainerLocator, "container-TRSB____TRSB_NAME____" + IdSuffix, "#TRSB____TRSB_NAME____" + IdSuffix);

	public TrsbForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "TRSB", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

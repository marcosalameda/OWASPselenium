using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ImgmagnForm : Form
{
	/// <summary>
	/// Image Background
	/// </summary>
	public BaseInputControl WpessFtbackgr => new BaseInputControl(driver, ContainerLocator, "container-IMGMAGN_WPESSFTBACKGR" + IdSuffix, "#IMGMAGN_WPESSFTBACKGR" + IdSuffix);

	public ImgmagnForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "IMGMAGN", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

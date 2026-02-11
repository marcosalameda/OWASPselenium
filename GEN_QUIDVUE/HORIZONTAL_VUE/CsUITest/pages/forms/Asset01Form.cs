using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Asset01Form : Subform
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AssetPhoto => new BaseInputControl(driver, ContainerLocator, "container-ASSET01_ASSETPHOTO___", "#ASSET01_ASSETPHOTO___");

	public Asset01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ASSET01", "ASSET", containerLocator: containerLocator) { }
}

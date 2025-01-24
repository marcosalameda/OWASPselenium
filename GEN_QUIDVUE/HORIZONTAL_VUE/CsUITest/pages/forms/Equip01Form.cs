using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip01Form : Subform
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AssetPhoto => new BaseInputControl(driver, ContainerLocator, "#EQUIP01_ASSETPHOTO___");

	public Equip01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EQUIP01", "EQUIPM", containerLocator: containerLocator) { }
}

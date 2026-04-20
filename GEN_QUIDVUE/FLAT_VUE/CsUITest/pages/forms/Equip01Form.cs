using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip01Form : Subform
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AssetPhoto => new BaseInputControl(driver, ContainerLocator, "container-EQUIP01_ASSETPHOTO___" + IdSuffix, "#EQUIP01_ASSETPHOTO___" + IdSuffix);

	public Equip01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "EQUIP01", "EQUIPM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

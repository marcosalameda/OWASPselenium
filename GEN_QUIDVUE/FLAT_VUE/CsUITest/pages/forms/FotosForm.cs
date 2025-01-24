using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FotosForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-FOTOS___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "FOTOS", "FOTOS___EQUIPREGISTNR");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PhotoPhotogra => new BaseInputControl(driver, ContainerLocator, "#FOTOS___PHOTOPHOTOGRA");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PhotoTitle => new BaseInputControl(driver, ContainerLocator, "#FOTOS___PHOTOTITLE___");

	/// <summary>
	/// Attached:
	/// </summary>
	public DateInputControl PhotoAnexed => new DateInputControl(driver, ContainerLocator, "#FOTOS___PHOTOANEXED__", "dd/MM/yyyy HH:mm");

	public FotosForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FOTOS", containerLocator: containerLocator) { }
}

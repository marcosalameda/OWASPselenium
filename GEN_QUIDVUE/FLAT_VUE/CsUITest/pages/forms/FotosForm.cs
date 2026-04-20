using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FotosForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-FOTOS___EQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "FOTOS", "FOTOS___EQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PhotoPhotogra => new BaseInputControl(driver, ContainerLocator, "container-FOTOS___PHOTOPHOTOGRA" + IdSuffix, "#FOTOS___PHOTOPHOTOGRA" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PhotoTitle => new BaseInputControl(driver, ContainerLocator, "container-FOTOS___PHOTOTITLE___" + IdSuffix, "#FOTOS___PHOTOTITLE___" + IdSuffix);

	/// <summary>
	/// Attached:
	/// </summary>
	public DateInputControl PhotoAnexed => new DateInputControl(driver, ContainerLocator, "#FOTOS___PHOTOANEXED__" + IdSuffix, "dd/MM/yyyy HH:mm");

	public FotosForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "FOTOS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

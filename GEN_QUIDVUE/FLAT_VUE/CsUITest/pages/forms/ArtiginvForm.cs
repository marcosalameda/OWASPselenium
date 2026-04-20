using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtiginvForm : PopupForm
{
	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, ContainerLocator, "container-ARTIGINVITEM_IMAGE___" + IdSuffix, "#ARTIGINVITEM_IMAGE___" + IdSuffix);

	/// <summary>
	/// Global Item
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, ContainerLocator, "container-ARTIGINVGITEMITEMDES_" + IdSuffix);
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIGINV", "ARTIGINVGITEMITEMDES_" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARTIGINVWAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIGINV", "ARTIGINVWAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Tipo
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, ContainerLocator, "container-ARTIGINVITEM_ITEMTYPE" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, ContainerLocator, "container-ARTIGINVITEM_ITEMCOD_" + IdSuffix, "#ARTIGINVITEM_ITEMCOD_" + IdSuffix);

	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "container-ARTIGINVITEM_ITEMDES_" + IdSuffix, "#ARTIGINVITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// In use
	/// </summary>
	public CheckboxInputControl ItemValid => new CheckboxInputControl(driver, ContainerLocator, "#container-ARTIGINVITEM_VALID___" + IdSuffix);

	public ArtiginvForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARTIGINV", usePkInId: usePkInId) { }
}

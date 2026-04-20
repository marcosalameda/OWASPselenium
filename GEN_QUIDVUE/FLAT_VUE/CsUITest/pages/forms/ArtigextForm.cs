using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigextForm : Form
{
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-ARTIGEXTWAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIGEXT", "ARTIGEXTWAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Global Item
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, ContainerLocator, "container-ARTIGEXTGITEMITEMDES_" + IdSuffix);
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIGEXT", "ARTIGEXTGITEMITEMDES_" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public IWebElement GitemItemgcod => throw new NotImplementedException();

	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, ContainerLocator, "container-ARTIGEXTITEM_ITEMDES_" + IdSuffix, "#ARTIGEXTITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, ContainerLocator, "container-ARTIGEXTITEM_ITEMCOD_" + IdSuffix, "#ARTIGEXTITEM_ITEMCOD_" + IdSuffix);

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, ContainerLocator, "container-ARTIGEXTITEM_IMAGE___" + IdSuffix, "#ARTIGEXTITEM_IMAGE___" + IdSuffix);

	public ArtigextForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARTIGEXT", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

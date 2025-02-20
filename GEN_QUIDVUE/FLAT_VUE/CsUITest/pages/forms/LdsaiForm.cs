using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdsaiForm : Form
{
	/// <summary>
	/// Document No.
	/// </summary>
	public LookupControl OutptDocumenr => new LookupControl(driver, ContainerLocator, "container-LDSAI___OUTPTDOCUMENR");
	public SeeMorePage OutptDocumenrSeeMorePage => new SeeMorePage(driver, "LDSAI", "LDSAI___OUTPTDOCUMENR");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement OutptCodwareh => throw new NotImplementedException();

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#LDSAI___PSEUDNOVOGR01-container");

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl OutpuLine => new BaseInputControl(driver, ContainerLocator, "container-LDSAI___OUTPULINE____", "#LDSAI___OUTPULINE____");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-LDSAI___WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDSAI", "LDSAI___WAREHWAREHDES");

	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-LDSAI___ITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDSAI", "LDSAI___ITEM_ITEMDES_");

	/// <summary>
	/// Output quantity:
	/// </summary>
	public BaseInputControl OutpuExitqnty => new BaseInputControl(driver, ContainerLocator, "container-LDSAI___OUTPUEXITQNTY", "#LDSAI___OUTPUEXITQNTY");

	/// <summary>
	/// Output No
	/// </summary>
	public LookupControl OudocNrdocsda => new LookupControl(driver, ContainerLocator, "container-LDSAI___OUDOCNRDOCSDA");
	public SeeMorePage OudocNrdocsdaSeeMorePage => new SeeMorePage(driver, "LDSAI", "LDSAI___OUDOCNRDOCSDA");

	public LdsaiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LDSAI", containerLocator: containerLocator) { }
}

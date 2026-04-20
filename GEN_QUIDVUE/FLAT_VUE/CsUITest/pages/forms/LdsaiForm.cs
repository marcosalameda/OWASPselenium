using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdsaiForm : Form
{
	/// <summary>
	/// Document No.
	/// </summary>
	public LookupControl OutptDocumenr => new LookupControl(driver, ContainerLocator, "container-LDSAI___OUTPTDOCUMENR" + IdSuffix);
	public SeeMorePage OutptDocumenrSeeMorePage => new SeeMorePage(driver, "LDSAI", "LDSAI___OUTPTDOCUMENR" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public IWebElement OutptCodwareh => throw new NotImplementedException();

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#LDSAI___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl OutpuLine => new BaseInputControl(driver, ContainerLocator, "container-LDSAI___OUTPULINE____" + IdSuffix, "#LDSAI___OUTPULINE____" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, ContainerLocator, "container-LDSAI___WAREHWAREHDES" + IdSuffix);
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "LDSAI", "LDSAI___WAREHWAREHDES" + IdSuffix);

	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-LDSAI___ITEM_ITEMDES_" + IdSuffix);
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "LDSAI", "LDSAI___ITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// Output quantity:
	/// </summary>
	public BaseInputControl OutpuExitqnty => new BaseInputControl(driver, ContainerLocator, "container-LDSAI___OUTPUEXITQNTY" + IdSuffix, "#LDSAI___OUTPUEXITQNTY" + IdSuffix);

	/// <summary>
	/// Output No
	/// </summary>
	public LookupControl OudocNrdocsda => new LookupControl(driver, ContainerLocator, "container-LDSAI___OUDOCNRDOCSDA" + IdSuffix);
	public SeeMorePage OudocNrdocsdaSeeMorePage => new SeeMorePage(driver, "LDSAI", "LDSAI___OUDOCNRDOCSDA" + IdSuffix);

	public LdsaiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LDSAI", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

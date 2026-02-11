using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Asset_global_filterForm : Form
{
	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, ContainerLocator, "container-ASSET_GLOBAL_FILTER__KINDE__DESIGNAT");
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "ASSET_GLOBAL_FILTER", "ASSET_GLOBAL_FILTER__KINDE__DESIGNAT");

	/// <summary>
	/// Asset number
	/// </summary>
	public BaseInputControl AssetAssetnum => new BaseInputControl(driver, ContainerLocator, "container-ASSET_GLOBAL_FILTER__ASSET__ASSETNUM", "#ASSET_GLOBAL_FILTER__ASSET__ASSETNUM");

	/// <summary>
	/// Asset type
	/// </summary>
	public EnumControl AssetAssettyp => new EnumControl(driver, ContainerLocator, "container-ASSET_GLOBAL_FILTER__ASSET__ASSETTYP");

	/// <summary>
	/// Parameter
	/// </summary>
    public LookupControl ParamParamete_FG => new LookupControl(driver, ContainerLocator, "container-ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG");

	/// <summary>
	/// Asset parameters
	/// </summary>
	public ListControl PseudAsspa_filtred_by_param => new ListControl(driver, ContainerLocator, "#ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement PseudRelation => throw new NotImplementedException();

	public Asset_global_filterForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ASSET_GLOBAL_FILTER", containerLocator: containerLocator) { }
}

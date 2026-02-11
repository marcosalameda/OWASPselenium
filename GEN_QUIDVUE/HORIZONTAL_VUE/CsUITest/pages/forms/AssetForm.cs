using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AssetForm : Form
{
	/// <summary>
	/// Asset identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#ASSET___PSEUDNOVOGR01-container");

	/// <summary>
	/// Identification name
	/// </summary>
	public BaseInputControl AssetName => new BaseInputControl(driver, ContainerLocator, "container-ASSET___ASSETNAME____", "#ASSET___ASSETNAME____");

	/// <summary>
	/// Asset type
	/// </summary>
	public EnumControl AssetAssettyp => new EnumControl(driver, ContainerLocator, "container-ASSET___ASSETASSETTYP");

	/// <summary>
	/// Asset number
	/// </summary>
	public BaseInputControl AssetAssetnum => new BaseInputControl(driver, ContainerLocator, "container-ASSET___ASSETASSETNUM", "#ASSET___ASSETASSETNUM");

	/// <summary>
	/// Identifier type
	/// </summary>
	public EnumControl AssetIdenttyp => new EnumControl(driver, ContainerLocator, "container-ASSET___ASSETIDENTTYP");

	/// <summary>
	/// GRAI – Global Returnable Asset Identifier
	/// </summary>
	public BaseInputControl AssetGrai => new BaseInputControl(driver, ContainerLocator, "container-ASSET___ASSETGRAI____", "#ASSET___ASSETGRAI____");

	/// <summary>
	/// GIAI – Global Individual Asset Identifier
	/// </summary>
	public BaseInputControl AssetGiai => new BaseInputControl(driver, ContainerLocator, "container-ASSET___ASSETGIAI____", "#ASSET___ASSETGIAI____");

	/// <summary>
	/// Legal name
	/// </summary>
	public LookupControl ManufName => new LookupControl(driver, ContainerLocator, "container-ASSET___MANUFNAME____");
	public SeeMorePage ManufNameSeeMorePage => new SeeMorePage(driver, "ASSET", "ASSET___MANUFNAME____");

	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, ContainerLocator, "container-ASSET___KINDEDESIGNAT");
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "ASSET", "ASSET___KINDEDESIGNAT");

	/// <summary>
	/// Photo
	/// </summary>
	public TabControl PseudAsset01 => new TabControl(driver, ContainerLocator, "#tab-container-ASSET___PSEUDASSET01_");

	/// <summary>
	/// Attachments
	/// </summary>
	public TabControl PseudAsset02 => new TabControl(driver, ContainerLocator, "#tab-container-ASSET___PSEUDASSET02_");

	/// <summary>
	/// Documents
	/// </summary>
	public TabControl PseudAsset03 => new TabControl(driver, ContainerLocator, "#tab-container-ASSET___PSEUDASSET03_");

	/// <summary>
	/// Parameters
	/// </summary>
	public TabControl PseudAsset04 => new TabControl(driver, ContainerLocator, "#tab-container-ASSET___PSEUDASSET04_");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl AssetDescript => new BaseInputControl(driver, ContainerLocator, "container-ASSET___ASSETDESCRIPT", "#ASSET___ASSETDESCRIPT");

	/// <summary>
	/// Detailed description
	/// </summary>
	public IWebElement AssetLongdesc => throw new NotImplementedException();

	/// <summary>
	/// Category
	/// </summary>
	public EnumControl AssetCategory => new EnumControl(driver, ContainerLocator, "container-ASSET___ASSETCATEGORY");

	/// <summary>
	/// Background color for category
	/// </summary>
	public BaseInputControl AssetBg_color => new BaseInputControl(driver, ContainerLocator, "container-ASSET___ASSETBG_COLOR", "#ASSET___ASSETBG_COLOR");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl Asset01AssetPhoto => new BaseInputControl(driver, ContainerLocator, "container-ASSET01_ASSETPHOTO___", "#ASSET01_ASSETPHOTO___");

	/// <summary>
	/// Attachments
	/// </summary>
	public ListControl Asset02PseudAttachme => new ListControl(driver, ContainerLocator, "#ASSET02_PSEUDATTACHME");

	/// <summary>
	/// Documents
	/// </summary>
	public ListControl Asset03PseudDocument => new ListControl(driver, ContainerLocator, "#ASSET03_PSEUDDOCUMENT");

	/// <summary>
	/// Parameters
	/// </summary>
	public CollapsibleZoneControl Asset04PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#ASSET04_PSEUDNOVOGR01-container");

	/// <summary>
	/// Parameters load
	/// </summary>
	public ButtonControl Asset04PseudParamloa => new ButtonControl(driver, ContainerLocator, "#ASSET04_PSEUDPARAMLOA");

	/// <summary>
	/// Manuals load
	/// </summary>
	public ButtonControl Asset04PseudManuals => new ButtonControl(driver, ContainerLocator, "#ASSET04_PSEUDMANUALS_");

	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl Asset04PseudParamete => new ListControl(driver, ContainerLocator, "#ASSET04_PSEUDPARAMETE");

	public AssetForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ASSET", containerLocator: containerLocator) { }
}

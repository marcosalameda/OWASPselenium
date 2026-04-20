using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquipmForm : Form
{
	/// <summary>
	/// Asset identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIPM__PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Identification name
	/// </summary>
	public BaseInputControl AssetName => new BaseInputControl(driver, ContainerLocator, "container-EQUIPM__ASSETNAME____" + IdSuffix, "#EQUIPM__ASSETNAME____" + IdSuffix);

	/// <summary>
	/// Asset type
	/// </summary>
	public EnumControl AssetAssettyp => new EnumControl(driver, ContainerLocator, "container-EQUIPM__ASSETASSETTYP" + IdSuffix);

	/// <summary>
	/// Asset number
	/// </summary>
	public BaseInputControl AssetAssetnum => new BaseInputControl(driver, ContainerLocator, "container-EQUIPM__ASSETASSETNUM" + IdSuffix, "#EQUIPM__ASSETASSETNUM" + IdSuffix);

	/// <summary>
	/// Identifier type
	/// </summary>
	public EnumControl AssetIdenttyp => new EnumControl(driver, ContainerLocator, "container-EQUIPM__ASSETIDENTTYP" + IdSuffix);

	/// <summary>
	/// GRAI – Global Returnable Asset Identifier
	/// </summary>
	public BaseInputControl AssetGrai => new BaseInputControl(driver, ContainerLocator, "container-EQUIPM__ASSETGRAI____" + IdSuffix, "#EQUIPM__ASSETGRAI____" + IdSuffix);

	/// <summary>
	/// GIAI – Global Individual Asset Identifier
	/// </summary>
	public BaseInputControl AssetGiai => new BaseInputControl(driver, ContainerLocator, "container-EQUIPM__ASSETGIAI____" + IdSuffix, "#EQUIPM__ASSETGIAI____" + IdSuffix);

	/// <summary>
	/// Manufacturer
	/// </summary>
	public LookupControl ManufName => new LookupControl(driver, ContainerLocator, "container-EQUIPM__MANUFNAME____" + IdSuffix);
	public SeeMorePage ManufNameSeeMorePage => new SeeMorePage(driver, "EQUIPM", "EQUIPM__MANUFNAME____" + IdSuffix);

	/// <summary>
	/// Photo
	/// </summary>
	public TabControl PseudEquip01 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-EQUIPM__PSEUDEQUIP01_']");

	/// <summary>
	/// Attachments
	/// </summary>
	public TabControl PseudEquip02 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-EQUIPM__PSEUDEQUIP02_']");

	/// <summary>
	/// Documents
	/// </summary>
	public TabControl PseudEquip03 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-EQUIPM__PSEUDEQUIP03_']");

	/// <summary>
	/// Parameters
	/// </summary>
	public TabControl PseudEquip04 => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-EQUIPM__PSEUDEQUIP04_']");

	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, ContainerLocator, "container-EQUIPM__KINDEDESIGNAT" + IdSuffix);
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "EQUIPM", "EQUIPM__KINDEDESIGNAT" + IdSuffix);

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl Equip01AssetPhoto => new BaseInputControl(driver, ContainerLocator, "container-EQUIP01_ASSETPHOTO___" + IdSuffix, "#EQUIP01_ASSETPHOTO___" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl Equip02PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP02_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Attachments
	/// </summary>
	public ListControl Equip02PseudAttachme => new ListControl(driver, ContainerLocator, "#EQUIP02_PSEUDATTACHME" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl Equip03PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP03_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Documents
	/// </summary>
	public ListControl Equip03PseudDocument => new ListControl(driver, ContainerLocator, "#EQUIP03_PSEUDDOCUMENT" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl Equip04PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIP04_PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Parameters load
	/// </summary>
	public ButtonControl Equip04PseudParamloa => new ButtonControl(driver, ContainerLocator, "#EQUIP04_PSEUDPARAMLOA" + IdSuffix);

	/// <summary>
	/// Manuals load
	/// </summary>
	public ButtonControl Equip04PseudManuals => new ButtonControl(driver, ContainerLocator, "#EQUIP04_PSEUDMANUALS_" + IdSuffix);

	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl Equip04PseudParamete => new ListControl(driver, ContainerLocator, "#EQUIP04_PSEUDPARAMETE" + IdSuffix);

	public EquipmForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "EQUIPM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

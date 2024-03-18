namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquipmForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Asset identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#EQUIPM__PSEUDNOVOGR01-container");
	/// <summary>
	/// Identification name
	/// </summary>
	public BaseInputControl AssetName => new BaseInputControl(driver, formLocator, "#EQUIPM__ASSETNAME____");
	/// <summary>
	/// Asset type
	/// </summary>
	public EnumControl AssetAssettyp => new EnumControl(driver, formLocator, "container-EQUIPM__ASSETASSETTYP");
	/// <summary>
	/// Asset number
	/// </summary>
	public BaseInputControl AssetAssetnum => new BaseInputControl(driver, formLocator, "#EQUIPM__ASSETASSETNUM");
	/// <summary>
	/// Identifier type
	/// </summary>
	public EnumControl AssetIdenttyp => new EnumControl(driver, formLocator, "container-EQUIPM__ASSETIDENTTYP");
	/// <summary>
	/// GRAI – Global Returnable Asset Identifier
	/// </summary>
	public BaseInputControl AssetGrai => new BaseInputControl(driver, formLocator, "#EQUIPM__ASSETGRAI____");
	/// <summary>
	/// GIAI – Global Individual Asset Identifier
	/// </summary>
	public BaseInputControl AssetGiai => new BaseInputControl(driver, formLocator, "#EQUIPM__ASSETGIAI____");
	/// <summary>
	/// Manufacturer
	/// </summary>
	public LookupControl ManufName => new LookupControl(driver, formLocator, "container-EQUIPM__MANUFNAME____");
	public SeeMorePage ManufNameSeeMorePage => new SeeMorePage(driver, "EQUIPM", "MANUF.NAME");
	/// <summary>
	/// Photo
	/// </summary>
	public TabControl PseudEquip01 => new TabControl(driver, formLocator, "#tab-container-EQUIPM__PSEUDEQUIP01_");
	/// <summary>
	/// Attachments
	/// </summary>
	public TabControl PseudEquip02 => new TabControl(driver, formLocator, "#tab-container-EQUIPM__PSEUDEQUIP02_");
	/// <summary>
	/// Documents
	/// </summary>
	public TabControl PseudEquip03 => new TabControl(driver, formLocator, "#tab-container-EQUIPM__PSEUDEQUIP03_");
	/// <summary>
	/// Parameters
	/// </summary>
	public TabControl PseudEquip04 => new TabControl(driver, formLocator, "#tab-container-EQUIPM__PSEUDEQUIP04_");
	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, formLocator, "container-EQUIPM__KINDEDESIGNAT");
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "EQUIPM", "KINDE.DESIGNAT");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl Equip01AssetPhoto => new BaseInputControl(driver, formLocator, "#EQUIP01_ASSETPHOTO___");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl Equip02PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#EQUIP02_PSEUDNOVOGR01-container");
	/// <summary>
	/// Attachments
	/// </summary>
	public ListControl Equip02PseudAttachme => new ListControl(driver, formLocator, "#EQUIP02_PSEUDATTACHME");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl Equip03PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#EQUIP03_PSEUDNOVOGR01-container");
	/// <summary>
	/// Documents
	/// </summary>
	public ListControl Equip03PseudDocument => new ListControl(driver, formLocator, "#EQUIP03_PSEUDDOCUMENT");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl Equip04PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#EQUIP04_PSEUDNOVOGR01-container");
	/// <summary>
	/// Parameters load
	/// </summary>
	public ButtonControl Equip04PseudParamloa => new ButtonControl(driver, formLocator, "#EQUIP04_PSEUDPARAMLOA");
	/// <summary>
	/// Manuals load
	/// </summary>
	public ButtonControl Equip04PseudManuals => new ButtonControl(driver, formLocator, "#EQUIP04_PSEUDMANUALS_");
	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl Equip04PseudParamete => new ListControl(driver, formLocator, "#EQUIP04_PSEUDPARAMETE");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public EquipmForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("EQUIPM")).GetAttribute("data-loading") != "true");
    }

	public void Save() {
		WaitForLoading();
		saveBtn.Click();
	}

	public void Cancel() {
		WaitForLoading();
		cancelBtn.Click();
	}

}

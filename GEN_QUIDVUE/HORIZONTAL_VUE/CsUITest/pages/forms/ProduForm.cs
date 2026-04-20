using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProduForm : Form
{
	/// <summary>
	/// Product identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Product
	/// </summary>
	public BaseInputControl ProduProduct => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUPRODUCT_" + IdSuffix, "#PRODU___PRODUPRODUCT_" + IdSuffix);

	/// <summary>
	/// In use
	/// </summary>
	public EnumControl ProduIn_use => new EnumControl(driver, ContainerLocator, "container-PRODU___PRODUIN_USE__" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProduDescript => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUDESCRIPT" + IdSuffix, "#PRODU___PRODUDESCRIPT" + IdSuffix);

	/// <summary>
	/// SKU
	/// </summary>
	public BaseInputControl ProduSku => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUSKU_____" + IdSuffix, "#PRODU___PRODUSKU_____" + IdSuffix);

	/// <summary>
	/// GTIN
	/// </summary>
	public BaseInputControl ProduGtin => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUGTIN____" + IdSuffix, "#PRODU___PRODUGTIN____" + IdSuffix);

	/// <summary>
	/// Size
	/// </summary>
	public BaseInputControl ProduSize => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUSIZE____" + IdSuffix, "#PRODU___PRODUSIZE____" + IdSuffix);

	/// <summary>
	/// Weight
	/// </summary>
	public BaseInputControl ProduWeight => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUWEIGHT__" + IdSuffix, "#PRODU___PRODUWEIGHT__" + IdSuffix);

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl ProduPrice => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUPRICE___" + IdSuffix, "#PRODU___PRODUPRICE___" + IdSuffix);

	/// <summary>
	/// Inputs
	/// </summary>
	public BaseInputControl ProduInputs => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUINPUTS__" + IdSuffix, "#PRODU___PRODUINPUTS__" + IdSuffix);

	/// <summary>
	/// Outputs
	/// </summary>
	public BaseInputControl ProduOutputs => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUOUTPUTS_" + IdSuffix, "#PRODU___PRODUOUTPUTS_" + IdSuffix);

	/// <summary>
	/// Stock
	/// </summary>
	public BaseInputControl ProduStock => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUSTOCK___" + IdSuffix, "#PRODU___PRODUSTOCK___" + IdSuffix);

	/// <summary>
	/// Image
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ProduImage => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUIMAGE___" + IdSuffix, "#PRODU___PRODUIMAGE___" + IdSuffix);

	/// <summary>
	/// ACCORDEON
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();

	/// <summary>
	/// Stock
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Global Location Number
	/// </summary>
	public LookupControl LocatGln => new LookupControl(driver, ContainerLocator, "container-PRODU___LOCATGLN_____" + IdSuffix);
	public SeeMorePage LocatGlnSeeMorePage => new SeeMorePage(driver, "PRODU", "PRODU___LOCATGLN_____" + IdSuffix);

	/// <summary>
	/// GLN Extension Component
	/// </summary>
	public LookupControl LcextGlnext => new LookupControl(driver, ContainerLocator, "container-PRODU___LCEXTGLNEXT__" + IdSuffix);
	public SeeMorePage LcextGlnextSeeMorePage => new SeeMorePage(driver, "PRODU", "PRODU___LCEXTGLNEXT__" + IdSuffix);

	/// <summary>
	/// Stock evolution
	/// </summary>
	public ListControl PseudStockevo => new ListControl(driver, ContainerLocator, "#PRODU___PSEUDSTOCKEVO" + IdSuffix);

	/// <summary>
	/// Details
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR05" + IdSuffix + "-container");

	/// <summary>
	/// Inputs
	/// </summary>
	public ListControl PseudInputsre => new ListControl(driver, ContainerLocator, "#PRODU___PSEUDINPUTSRE" + IdSuffix);

	/// <summary>
	/// Outputs
	/// </summary>
	public ListControl PseudOutputsd => new ListControl(driver, ContainerLocator, "#PRODU___PSEUDOUTPUTSD" + IdSuffix);

	public ProduForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PRODU", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

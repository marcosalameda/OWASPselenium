using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProduForm : Form
{
	/// <summary>
	/// Product identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR01-container");

	/// <summary>
	/// Product
	/// </summary>
	public BaseInputControl ProduProduct => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUPRODUCT_", "#PRODU___PRODUPRODUCT_");

	/// <summary>
	/// In use
	/// </summary>
	public EnumControl ProduIn_use => new EnumControl(driver, ContainerLocator, "container-PRODU___PRODUIN_USE__");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProduDescript => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUDESCRIPT", "#PRODU___PRODUDESCRIPT");

	/// <summary>
	/// SKU
	/// </summary>
	public BaseInputControl ProduSku => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUSKU_____", "#PRODU___PRODUSKU_____");

	/// <summary>
	/// GTIN
	/// </summary>
	public BaseInputControl ProduGtin => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUGTIN____", "#PRODU___PRODUGTIN____");

	/// <summary>
	/// Size
	/// </summary>
	public BaseInputControl ProduSize => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUSIZE____", "#PRODU___PRODUSIZE____");

	/// <summary>
	/// Weight
	/// </summary>
	public BaseInputControl ProduWeight => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUWEIGHT__", "#PRODU___PRODUWEIGHT__");

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl ProduPrice => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUPRICE___", "#PRODU___PRODUPRICE___");

	/// <summary>
	/// Inputs
	/// </summary>
	public BaseInputControl ProduInputs => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUINPUTS__", "#PRODU___PRODUINPUTS__");

	/// <summary>
	/// Outputs
	/// </summary>
	public BaseInputControl ProduOutputs => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUOUTPUTS_", "#PRODU___PRODUOUTPUTS_");

	/// <summary>
	/// Stock
	/// </summary>
	public BaseInputControl ProduStock => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUSTOCK___", "#PRODU___PRODUSTOCK___");

	/// <summary>
	/// Image
	/// </summary>
	public IWebElement PseudNovogr02 => throw new NotImplementedException();

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ProduImage => new BaseInputControl(driver, ContainerLocator, "container-PRODU___PRODUIMAGE___", "#PRODU___PRODUIMAGE___");

	/// <summary>
	/// ACCORDEON
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();

	/// <summary>
	/// Stock
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR04-container");

	/// <summary>
	/// Location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR03-container");

	/// <summary>
	/// Global Location Number
	/// </summary>
	public LookupControl LocatGln => new LookupControl(driver, ContainerLocator, "container-PRODU___LOCATGLN_____");
	public SeeMorePage LocatGlnSeeMorePage => new SeeMorePage(driver, "PRODU", "PRODU___LOCATGLN_____");

	/// <summary>
	/// GLN Extension Component
	/// </summary>
	public LookupControl LcextGlnext => new LookupControl(driver, ContainerLocator, "container-PRODU___LCEXTGLNEXT__");
	public SeeMorePage LcextGlnextSeeMorePage => new SeeMorePage(driver, "PRODU", "PRODU___LCEXTGLNEXT__");

	/// <summary>
	/// Stock evolution
	/// </summary>
	public ListControl PseudStockevo => new ListControl(driver, ContainerLocator, "#PRODU___PSEUDSTOCKEVO");

	/// <summary>
	/// Details
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODU___PSEUDNOVOGR05-container");

	/// <summary>
	/// Inputs
	/// </summary>
	public ListControl PseudInputsre => new ListControl(driver, ContainerLocator, "#PRODU___PSEUDINPUTSRE");

	/// <summary>
	/// Outputs
	/// </summary>
	public ListControl PseudOutputsd => new ListControl(driver, ContainerLocator, "#PRODU___PSEUDOUTPUTSD");

	public ProduForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PRODU", containerLocator: containerLocator) { }
}

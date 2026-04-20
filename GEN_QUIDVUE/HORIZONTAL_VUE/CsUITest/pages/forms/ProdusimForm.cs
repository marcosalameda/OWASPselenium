using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProdusimForm : Form
{
	/// <summary>
	/// Product identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODUSIMPSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Product
	/// </summary>
	public BaseInputControl ProduProduct => new BaseInputControl(driver, ContainerLocator, "container-PRODUSIMPRODUPRODUCT_" + IdSuffix, "#PRODUSIMPRODUPRODUCT_" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProduDescript => new BaseInputControl(driver, ContainerLocator, "container-PRODUSIMPRODUDESCRIPT" + IdSuffix, "#PRODUSIMPRODUDESCRIPT" + IdSuffix);

	/// <summary>
	/// SKU
	/// </summary>
	public BaseInputControl ProduSku => new BaseInputControl(driver, ContainerLocator, "container-PRODUSIMPRODUSKU_____" + IdSuffix, "#PRODUSIMPRODUSKU_____" + IdSuffix);

	/// <summary>
	/// GTIN
	/// </summary>
	public BaseInputControl ProduGtin => new BaseInputControl(driver, ContainerLocator, "container-PRODUSIMPRODUGTIN____" + IdSuffix, "#PRODUSIMPRODUGTIN____" + IdSuffix);

	/// <summary>
	/// Size
	/// </summary>
	public BaseInputControl ProduSize => new BaseInputControl(driver, ContainerLocator, "container-PRODUSIMPRODUSIZE____" + IdSuffix, "#PRODUSIMPRODUSIZE____" + IdSuffix);

	/// <summary>
	/// Weight
	/// </summary>
	public BaseInputControl ProduWeight => new BaseInputControl(driver, ContainerLocator, "container-PRODUSIMPRODUWEIGHT__" + IdSuffix, "#PRODUSIMPRODUWEIGHT__" + IdSuffix);

	/// <summary>
	/// Location
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODUSIMPSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Global Location Number
	/// </summary>
	public LookupControl LocatGln => new LookupControl(driver, ContainerLocator, "container-PRODUSIMLOCATGLN_____" + IdSuffix);
	public SeeMorePage LocatGlnSeeMorePage => new SeeMorePage(driver, "PRODUSIM", "PRODUSIMLOCATGLN_____" + IdSuffix);

	/// <summary>
	/// GLN Extension Component
	/// </summary>
	public LookupControl LcextGlnext => new LookupControl(driver, ContainerLocator, "container-PRODUSIMLCEXTGLNEXT__" + IdSuffix);
	public SeeMorePage LcextGlnextSeeMorePage => new SeeMorePage(driver, "PRODUSIM", "PRODUSIMLCEXTGLNEXT__" + IdSuffix);

	public ProdusimForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PRODUSIM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

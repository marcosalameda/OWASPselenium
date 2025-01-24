using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProdusimForm : Form
{
	/// <summary>
	/// Product identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PRODUSIMPSEUDNOVOGR01-container");

	/// <summary>
	/// Product
	/// </summary>
	public BaseInputControl ProduProduct => new BaseInputControl(driver, ContainerLocator, "#PRODUSIMPRODUPRODUCT_");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ProduDescript => new BaseInputControl(driver, ContainerLocator, "#PRODUSIMPRODUDESCRIPT");

	/// <summary>
	/// SKU
	/// </summary>
	public BaseInputControl ProduSku => new BaseInputControl(driver, ContainerLocator, "#PRODUSIMPRODUSKU_____");

	/// <summary>
	/// GTIN
	/// </summary>
	public BaseInputControl ProduGtin => new BaseInputControl(driver, ContainerLocator, "#PRODUSIMPRODUGTIN____");

	/// <summary>
	/// Size
	/// </summary>
	public BaseInputControl ProduSize => new BaseInputControl(driver, ContainerLocator, "#PRODUSIMPRODUSIZE____");

	/// <summary>
	/// Weight
	/// </summary>
	public BaseInputControl ProduWeight => new BaseInputControl(driver, ContainerLocator, "#PRODUSIMPRODUWEIGHT__");

	/// <summary>
	/// Location
	/// </summary>
	public IWebElement PseudNovogr02 => throw new NotImplementedException();

	/// <summary>
	/// Global Location Number
	/// </summary>
	public LookupControl LocatGln => new LookupControl(driver, ContainerLocator, "container-PRODUSIMLOCATGLN_____");
	public SeeMorePage LocatGlnSeeMorePage => new SeeMorePage(driver, "PRODUSIM", "PRODUSIMLOCATGLN_____");

	/// <summary>
	/// GLN Extension Component
	/// </summary>
	public LookupControl LcextGlnext => new LookupControl(driver, ContainerLocator, "container-PRODUSIMLCEXTGLNEXT__");
	public SeeMorePage LcextGlnextSeeMorePage => new SeeMorePage(driver, "PRODUSIM", "PRODUSIMLCEXTGLNEXT__");

	public ProdusimForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PRODUSIM", containerLocator: containerLocator) { }
}

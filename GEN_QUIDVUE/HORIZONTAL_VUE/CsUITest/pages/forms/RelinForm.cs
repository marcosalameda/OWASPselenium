using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RelinForm : Form
{
	/// <summary>
	/// Receipt
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#RELIN___PSEUDNOVOGR01-container");

	/// <summary>
	/// Receipt number
	/// </summary>
	public LookupControl ReceiNumber => new LookupControl(driver, ContainerLocator, "container-RELIN___RECEINUMBER__");
	public SeeMorePage ReceiNumberSeeMorePage => new SeeMorePage(driver, "RELIN", "RELIN___RECEINUMBER__");

	/// <summary>
	/// Legal name
	/// </summary>
	public IWebElement EntitName => throw new NotImplementedException();

	/// <summary>
	/// Receipt line
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#RELIN___PSEUDNOVOGR02-container");

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl RelinLinenumb => new BaseInputControl(driver, ContainerLocator, "#RELIN___RELINLINENUMB");

	/// <summary>
	/// Product
	/// </summary>
	public LookupControl ProduProduct => new LookupControl(driver, ContainerLocator, "container-RELIN___PRODUPRODUCT_");
	public SeeMorePage ProduProductSeeMorePage => new SeeMorePage(driver, "RELIN", "RELIN___PRODUPRODUCT_");

	/// <summary>
	/// Ordered
	/// </summary>
	public BaseInputControl RelinOrdered => new BaseInputControl(driver, ContainerLocator, "#RELIN___RELINORDERED_");

	/// <summary>
	/// Received
	/// </summary>
	public BaseInputControl RelinReceived => new BaseInputControl(driver, ContainerLocator, "#RELIN___RELINRECEIVED");

	/// <summary>
	/// Outstanding
	/// </summary>
	public BaseInputControl RelinOutstand => new BaseInputControl(driver, ContainerLocator, "#RELIN___RELINOUTSTAND");

	public RelinForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "RELIN", containerLocator: containerLocator) { }
}

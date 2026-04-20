using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RelinForm : Form
{
	/// <summary>
	/// Receipt
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#RELIN___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Receipt number
	/// </summary>
	public LookupControl ReceiNumber => new LookupControl(driver, ContainerLocator, "container-RELIN___RECEINUMBER__" + IdSuffix);
	public SeeMorePage ReceiNumberSeeMorePage => new SeeMorePage(driver, "RELIN", "RELIN___RECEINUMBER__" + IdSuffix);

	/// <summary>
	/// Legal name
	/// </summary>
	public IWebElement EntitName => throw new NotImplementedException();

	/// <summary>
	/// Receipt line
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#RELIN___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl RelinLinenumb => new BaseInputControl(driver, ContainerLocator, "container-RELIN___RELINLINENUMB" + IdSuffix, "#RELIN___RELINLINENUMB" + IdSuffix);

	/// <summary>
	/// Product
	/// </summary>
	public LookupControl ProduProduct => new LookupControl(driver, ContainerLocator, "container-RELIN___PRODUPRODUCT_" + IdSuffix);
	public SeeMorePage ProduProductSeeMorePage => new SeeMorePage(driver, "RELIN", "RELIN___PRODUPRODUCT_" + IdSuffix);

	/// <summary>
	/// Ordered
	/// </summary>
	public BaseInputControl RelinOrdered => new BaseInputControl(driver, ContainerLocator, "container-RELIN___RELINORDERED_" + IdSuffix, "#RELIN___RELINORDERED_" + IdSuffix);

	/// <summary>
	/// Received
	/// </summary>
	public BaseInputControl RelinReceived => new BaseInputControl(driver, ContainerLocator, "container-RELIN___RELINRECEIVED" + IdSuffix, "#RELIN___RELINRECEIVED" + IdSuffix);

	/// <summary>
	/// Outstanding
	/// </summary>
	public BaseInputControl RelinOutstand => new BaseInputControl(driver, ContainerLocator, "container-RELIN___RELINOUTSTAND" + IdSuffix, "#RELIN___RELINOUTSTAND" + IdSuffix);

	public RelinForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "RELIN", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

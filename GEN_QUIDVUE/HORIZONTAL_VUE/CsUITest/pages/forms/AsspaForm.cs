using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AsspaForm : Form
{
	/// <summary>
	/// Identification name
	/// </summary>
	public LookupControl AssetName => new LookupControl(driver, ContainerLocator, "container-ASSPA___ASSETNAME____");
	public SeeMorePage AssetNameSeeMorePage => new SeeMorePage(driver, "ASSPA", "ASSPA___ASSETNAME____");

	/// <summary>
	/// Data type
	/// </summary>
	public EnumControl AsspaDatatype => new EnumControl(driver, ContainerLocator, "container-ASSPA___ASSPADATATYPE");

	/// <summary>
	/// Decimal places
	/// </summary>
	public BaseInputControl AsspaDecplace => new BaseInputControl(driver, ContainerLocator, "#ASSPA___ASSPADECPLACE");

	/// <summary>
	/// Parameter
	/// </summary>
	public LookupControl ParamParamete => new LookupControl(driver, ContainerLocator, "container-ASSPA___PARAMPARAMETE");
	public SeeMorePage ParamParameteSeeMorePage => new SeeMorePage(driver, "ASSPA", "ASSPA___PARAMPARAMETE");

	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl AsspaText => new BaseInputControl(driver, ContainerLocator, "#ASSPA___ASSPATEXT____");

	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl AsspaQuantity => new BaseInputControl(driver, ContainerLocator, "#ASSPA___ASSPAQUANTITY");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl AsspaDate => new DateInputControl(driver, ContainerLocator, "#ASSPA___ASSPADATE____");

	/// <summary>
	/// To show
	/// </summary>
	public BaseInputControl AsspaToshow => new BaseInputControl(driver, ContainerLocator, "#ASSPA___ASSPATOSHOW__");

	public AsspaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ASSPA", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AsspaForm : Form
{
	/// <summary>
	/// Identification name
	/// </summary>
	public LookupControl AssetName => new LookupControl(driver, ContainerLocator, "container-ASSPA___ASSETNAME____" + IdSuffix);
	public SeeMorePage AssetNameSeeMorePage => new SeeMorePage(driver, "ASSPA", "ASSPA___ASSETNAME____" + IdSuffix);

	/// <summary>
	/// Data type
	/// </summary>
	public EnumControl AsspaDatatype => new EnumControl(driver, ContainerLocator, "container-ASSPA___ASSPADATATYPE" + IdSuffix);

	/// <summary>
	/// Decimal places
	/// </summary>
	public BaseInputControl AsspaDecplace => new BaseInputControl(driver, ContainerLocator, "container-ASSPA___ASSPADECPLACE" + IdSuffix, "#ASSPA___ASSPADECPLACE" + IdSuffix);

	/// <summary>
	/// Parameter
	/// </summary>
	public LookupControl ParamParamete => new LookupControl(driver, ContainerLocator, "container-ASSPA___PARAMPARAMETE" + IdSuffix);
	public SeeMorePage ParamParameteSeeMorePage => new SeeMorePage(driver, "ASSPA", "ASSPA___PARAMPARAMETE" + IdSuffix);

	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl AsspaText => new BaseInputControl(driver, ContainerLocator, "container-ASSPA___ASSPATEXT____" + IdSuffix, "#ASSPA___ASSPATEXT____" + IdSuffix);

	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl AsspaQuantity => new BaseInputControl(driver, ContainerLocator, "container-ASSPA___ASSPAQUANTITY" + IdSuffix, "#ASSPA___ASSPAQUANTITY" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl AsspaDate => new DateInputControl(driver, ContainerLocator, "#ASSPA___ASSPADATE____" + IdSuffix);

	/// <summary>
	/// To show
	/// </summary>
	public BaseInputControl AsspaToshow => new BaseInputControl(driver, ContainerLocator, "container-ASSPA___ASSPATOSHOW__" + IdSuffix, "#ASSPA___ASSPATOSHOW__" + IdSuffix);

	public AsspaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ASSPA", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

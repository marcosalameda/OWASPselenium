using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RoigiForm : Form
{
	/// <summary>
	/// Title
	/// </summary>
	public LookupControl Rogl1Title => new LookupControl(driver, ContainerLocator, "container-ROIGI___ROGL1TITLE___");
	public SeeMorePage Rogl1TitleSeeMorePage => new SeeMorePage(driver, "ROIGI", "ROIGI___ROGL1TITLE___");

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl RoigiOrder => new BaseInputControl(driver, ContainerLocator, "container-ROIGI___ROIGIORDER___", "#ROIGI___ROIGIORDER___");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl RoigiTitle => new BaseInputControl(driver, ContainerLocator, "container-ROIGI___ROIGITITLE___", "#ROIGI___ROIGITITLE___");

	public RoigiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ROIGI", containerLocator: containerLocator) { }
}

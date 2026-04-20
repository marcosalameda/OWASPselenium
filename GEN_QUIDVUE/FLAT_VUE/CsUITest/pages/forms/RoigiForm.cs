using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RoigiForm : Form
{
	/// <summary>
	/// Title
	/// </summary>
	public LookupControl Rogl1Title => new LookupControl(driver, ContainerLocator, "container-ROIGI___ROGL1TITLE___" + IdSuffix);
	public SeeMorePage Rogl1TitleSeeMorePage => new SeeMorePage(driver, "ROIGI", "ROIGI___ROGL1TITLE___" + IdSuffix);

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl RoigiOrder => new BaseInputControl(driver, ContainerLocator, "container-ROIGI___ROIGIORDER___" + IdSuffix, "#ROIGI___ROIGIORDER___" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl RoigiTitle => new BaseInputControl(driver, ContainerLocator, "container-ROIGI___ROIGITITLE___" + IdSuffix, "#ROIGI___ROIGITITLE___" + IdSuffix);

	public RoigiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ROIGI", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

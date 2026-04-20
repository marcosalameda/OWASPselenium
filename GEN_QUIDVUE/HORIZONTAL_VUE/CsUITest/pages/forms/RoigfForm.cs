using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RoigfForm : Form
{
	/// <summary>
	/// Title
	/// </summary>
	public LookupControl Rogl1Title => new LookupControl(driver, ContainerLocator, "container-ROIGF___ROGL1TITLE___" + IdSuffix);
	public SeeMorePage Rogl1TitleSeeMorePage => new SeeMorePage(driver, "ROIGF", "ROIGF___ROGL1TITLE___" + IdSuffix);

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl RoigfOrder => new BaseInputControl(driver, ContainerLocator, "container-ROIGF___ROIGFORDER___" + IdSuffix, "#ROIGF___ROIGFORDER___" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl RoigfTitle => new BaseInputControl(driver, ContainerLocator, "container-ROIGF___ROIGFTITLE___" + IdSuffix, "#ROIGF___ROIGFTITLE___" + IdSuffix);

	public RoigfForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ROIGF", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

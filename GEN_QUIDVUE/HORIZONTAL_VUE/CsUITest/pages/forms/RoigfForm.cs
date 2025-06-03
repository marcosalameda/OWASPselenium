using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RoigfForm : Form
{
	/// <summary>
	/// Title
	/// </summary>
	public LookupControl Rogl1Title => new LookupControl(driver, ContainerLocator, "container-ROIGF___ROGL1TITLE___");
	public SeeMorePage Rogl1TitleSeeMorePage => new SeeMorePage(driver, "ROIGF", "ROIGF___ROGL1TITLE___");

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl RoigfOrder => new BaseInputControl(driver, ContainerLocator, "container-ROIGF___ROIGFORDER___", "#ROIGF___ROIGFORDER___");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl RoigfTitle => new BaseInputControl(driver, ContainerLocator, "container-ROIGF___ROIGFTITLE___", "#ROIGF___ROIGFTITLE___");

	public RoigfForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ROIGF", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Photo03Form : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl ProphPhoto => new BaseInputControl(driver, ContainerLocator, "container-PHOTO03_PROPHPHOTO___", "#PHOTO03_PROPHPHOTO___");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl ProphTitle => new BaseInputControl(driver, ContainerLocator, "container-PHOTO03_PROPHTITLE___", "#PHOTO03_PROPHTITLE___");

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl PropeTitle => new LookupControl(driver, ContainerLocator, "container-PHOTO03_PROPETITLE___");
	public SeeMorePage PropeTitleSeeMorePage => new SeeMorePage(driver, "PHOTO03", "PHOTO03_PROPETITLE___");

	public Photo03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PHOTO03", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ConfigcompForm : Subform
{
	/// <summary>
	/// Show Release Field
	/// </summary>
	public CheckboxInputControl CompoReleaselogic => new CheckboxInputControl(driver, ContainerLocator, "#container-CONFIGCOMP__COMPO__RELEASELOGIC");

	/// <summary>
	/// Storybook Link
	/// </summary>
	public BaseInputControl CompoWeblink => new BaseInputControl(driver, ContainerLocator, "container-CONFIGCOMP__COMPO__WEBLINK", "#CONFIGCOMP__COMPO__WEBLINK");

	public ConfigcompForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONFIGCOMP", "COMPTYPE", containerLocator: containerLocator) { }
}

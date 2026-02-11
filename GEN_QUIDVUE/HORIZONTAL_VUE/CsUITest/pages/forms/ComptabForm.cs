using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ComptabForm : Subform
{
	/// <summary>
	/// Components Class
	/// </summary>
	public LookupControl CompcCompclas => new LookupControl(driver, ContainerLocator, "container-COMPTAB_COMPCCOMPCLAS");
	public SeeMorePage CompcCompclasSeeMorePage => new SeeMorePage(driver, "COMPTAB", "COMPTAB_COMPCCOMPCLAS");

	/// <summary>
	/// Component type
	/// </summary>
	public BaseInputControl CompoComptype => new BaseInputControl(driver, ContainerLocator, "container-COMPTAB_COMPOCOMPTYPE", "#COMPTAB_COMPOCOMPTYPE");

	/// <summary>
	/// Data type
	/// </summary>
	public BaseInputControl CompoCdatatyp => new BaseInputControl(driver, ContainerLocator, "container-COMPTAB_COMPOCDATATYP", "#COMPTAB_COMPOCDATATYP");

	/// <summary>
	/// Release
	/// </summary>
	public BaseInputControl CompoRelease => new BaseInputControl(driver, ContainerLocator, "container-COMPTAB_COMPORELEASE_", "#COMPTAB_COMPORELEASE_");

	/// <summary>
	/// MVC
	/// </summary>
	public CheckboxInputControl CompoMvc => new CheckboxInputControl(driver, ContainerLocator, "#container-COMPTAB_COMPOMVC_____");

	/// <summary>
	/// VUE
	/// </summary>
	public CheckboxInputControl CompoVuemvc => new CheckboxInputControl(driver, ContainerLocator, "#container-COMPTAB_COMPOVUEMVC__");

	/// <summary>
	/// Preview
	/// </summary>
	public BaseInputControl CompoPreview => new BaseInputControl(driver, ContainerLocator, "container-COMPTAB_COMPOPREVIEW_", "#COMPTAB_COMPOPREVIEW_");

	/// <summary>
	/// Storybook
	/// </summary>
	public ButtonControl PseudStorybook => new ButtonControl(driver, ContainerLocator, "#COMPTAB__PSEUD__STORYBOOK");

	/// <summary>
	/// Component Behaviour
	/// </summary>
	public ListControl PseudBehavior => new ListControl(driver, ContainerLocator, "#COMPTAB_PSEUDBEHAVIOR");

	public ComptabForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "COMPTAB", "COMPTYPE", containerLocator: containerLocator) { }
}

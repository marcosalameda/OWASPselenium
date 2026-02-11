using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ComptypeForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#COMPTYPEPSEUDNEWGRP01-container");

	/// <summary>
	/// Component type
	/// </summary>
	public BaseInputControl CompoComptype => new BaseInputControl(driver, ContainerLocator, "container-COMPTYPECOMPOCOMPTYPE", "#COMPTYPECOMPOCOMPTYPE");

	/// <summary>
	/// Component class
	/// </summary>
	public BaseInputControl CompoCompicon => new BaseInputControl(driver, ContainerLocator, "container-COMPTYPECOMPOCOMPICON", "#COMPTYPECOMPOCOMPICON");

	/// <summary>
	/// Component description
	/// </summary>
	public BaseInputControl CompoCompdesc => new BaseInputControl(driver, ContainerLocator, "container-COMPTYPECOMPOCOMPDESC", "#COMPTYPECOMPOCOMPDESC");

	/// <summary>
	/// Overview
	/// </summary>
	public TabControl PseudComptab => new TabControl(driver, ContainerLocator, "#tab-container-COMPTYPEPSEUDCOMPTAB_");

	/// <summary>
	/// Options
	/// </summary>
	public TabControl PseudTab => new TabControl(driver, ContainerLocator, "#tab-container-COMPTYPEPSEUDTAB_____");

	/// <summary>
	/// Usage
	/// </summary>
	public TabControl PseudC_usage => new TabControl(driver, ContainerLocator, "#tab-container-COMPTYPEPSEUDC_USAGE_");

	/// <summary>
	/// Accessibility
	/// </summary>
	public TabControl PseudCacessi => new TabControl(driver, ContainerLocator, "#tab-container-COMPTYPEPSEUDCACESSI_");

	/// <summary>
	/// Components Class
	/// </summary>
	public LookupControl ComptabCompcCompclas => new LookupControl(driver, ContainerLocator, "container-COMPTAB_COMPCCOMPCLAS");
	public SeeMorePage ComptabCompcCompclasSeeMorePage => new SeeMorePage(driver, "COMPTAB", "COMPTAB_COMPCCOMPCLAS");

	/// <summary>
	/// Component type
	/// </summary>
	public BaseInputControl ComptabCompoComptype => new BaseInputControl(driver, ContainerLocator, "container-COMPTAB_COMPOCOMPTYPE", "#COMPTAB_COMPOCOMPTYPE");

	/// <summary>
	/// Data type
	/// </summary>
	public BaseInputControl ComptabCompoCdatatyp => new BaseInputControl(driver, ContainerLocator, "container-COMPTAB_COMPOCDATATYP", "#COMPTAB_COMPOCDATATYP");

	/// <summary>
	/// Release
	/// </summary>
	public BaseInputControl ComptabCompoRelease => new BaseInputControl(driver, ContainerLocator, "container-COMPTAB_COMPORELEASE_", "#COMPTAB_COMPORELEASE_");

	/// <summary>
	/// MVC
	/// </summary>
	public CheckboxInputControl ComptabCompoMvc => new CheckboxInputControl(driver, ContainerLocator, "#container-COMPTAB_COMPOMVC_____");

	/// <summary>
	/// VUE
	/// </summary>
	public CheckboxInputControl ComptabCompoVuemvc => new CheckboxInputControl(driver, ContainerLocator, "#container-COMPTAB_COMPOVUEMVC__");

	/// <summary>
	/// Preview
	/// </summary>
	public BaseInputControl ComptabCompoPreview => new BaseInputControl(driver, ContainerLocator, "container-COMPTAB_COMPOPREVIEW_", "#COMPTAB_COMPOPREVIEW_");

	/// <summary>
	/// Storybook
	/// </summary>
	public ButtonControl ComptabPseudStorybook => new ButtonControl(driver, ContainerLocator, "#COMPTAB__PSEUD__STORYBOOK");

	/// <summary>
	/// Component Behaviour
	/// </summary>
	public ListControl ComptabPseudBehavior => new ListControl(driver, ContainerLocator, "#COMPTAB_PSEUDBEHAVIOR");

	/// <summary>
	/// VARIANTS/OPTIONS
	/// </summary>
	public ListControl TabPseudVariants => new ListControl(driver, ContainerLocator, "#TAB_____PSEUDVARIANTS");

	/// <summary>
	/// When to use
	/// </summary>
	public BaseInputControl C_usageCompoWuse => new BaseInputControl(driver, ContainerLocator, "container-C_USAGE_COMPOWUSE____", "#C_USAGE_COMPOWUSE____");

	/// <summary>
	/// When not to use
	/// </summary>
	public BaseInputControl C_usageCompoWnuse => new BaseInputControl(driver, ContainerLocator, "container-C_USAGE_COMPOWNUSE___", "#C_USAGE_COMPOWNUSE___");

	/// <summary>
	/// examples
	/// </summary>
	public CollapsibleZoneControl C_usagePseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#C_USAGE_PSEUDNEWGRP01-container");

	/// <summary>
	/// Storybook
	/// </summary>
	public ButtonControl C_usagePseudStorybookusa => new ButtonControl(driver, ContainerLocator, "#C_USAGE__PSEUD__STORYBOOKUSA");

	/// <summary>
	/// Demo 1
	/// </summary>
	public ButtonControl C_usagePseudDemocomp => new ButtonControl(driver, ContainerLocator, "#C_USAGE_PSEUDDEMOCOMP");

	/// <summary>
	/// Accessibilty Compliance & Best Practices
	/// </summary>
	public BaseInputControl CacessiCompoAccessib => new BaseInputControl(driver, ContainerLocator, "container-CACESSI_COMPOACCESSIB", "#CACESSI_COMPOACCESSIB");

	public ComptypeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "COMPTYPE", containerLocator: containerLocator) { }
}

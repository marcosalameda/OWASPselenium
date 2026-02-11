using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class C_usageForm : Subform
{
	/// <summary>
	/// When to use
	/// </summary>
	public BaseInputControl CompoWuse => new BaseInputControl(driver, ContainerLocator, "container-C_USAGE_COMPOWUSE____", "#C_USAGE_COMPOWUSE____");

	/// <summary>
	/// When not to use
	/// </summary>
	public BaseInputControl CompoWnuse => new BaseInputControl(driver, ContainerLocator, "container-C_USAGE_COMPOWNUSE___", "#C_USAGE_COMPOWNUSE___");

	/// <summary>
	/// examples
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#C_USAGE_PSEUDNEWGRP01-container");

	/// <summary>
	/// Storybook
	/// </summary>
	public ButtonControl PseudStorybookusa => new ButtonControl(driver, ContainerLocator, "#C_USAGE__PSEUD__STORYBOOKUSA");

	/// <summary>
	/// Demo 1
	/// </summary>
	public ButtonControl PseudDemocomp => new ButtonControl(driver, ContainerLocator, "#C_USAGE_PSEUDDEMOCOMP");

	public C_usageForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "C_USAGE", "COMPTYPE", containerLocator: containerLocator) { }
}

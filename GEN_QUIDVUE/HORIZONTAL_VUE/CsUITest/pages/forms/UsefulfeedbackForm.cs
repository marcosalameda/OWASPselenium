using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class UsefulfeedbackForm : PopupForm
{
	/// <summary>
	/// <h2><strong>Was the content of this page useful?</strong></h2>
	/// </summary>
	public IWebElement PseudUsefultext => throw new NotImplementedException();

	/// <summary>
	/// Yes
	/// </summary>
	public ButtonControl PseudField003 => new ButtonControl(driver, ContainerLocator, "#USEFULFEEDBACK__PSEUD__FIELD003");

	/// <summary>
	/// No
	/// </summary>
	public ButtonControl PseudField002 => new ButtonControl(driver, ContainerLocator, "#USEFULFEEDBACK__PSEUD__FIELD002");

	/// <summary>
	/// Evaluate your experience and leave us a comment
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#USEFULFEEDBACK__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Did you find what you were looking for?
	/// </summary>
	public RadiobuttonControl UfeedbackUsefulfeedb => new RadiobuttonControl(driver, ContainerLocator, "container-USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB");

	/// <summary>
	/// Classify your experience on this page
	/// </summary>
	public EnumControl UfeedbackSfeedback => new EnumControl(driver, ContainerLocator, "container-USEFULFEEDBACK__UFEEDBACK__SFEEDBACK");

	/// <summary>
	/// Comments
	/// </summary>
	public BaseInputControl UfeedbackFeedbcoment => new BaseInputControl(driver, ContainerLocator, "container-USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT", "#USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT");

	public UsefulfeedbackForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "USEFULFEEDBACK") { }
}

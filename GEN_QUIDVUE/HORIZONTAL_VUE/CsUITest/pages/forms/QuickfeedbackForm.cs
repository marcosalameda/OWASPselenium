using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class QuickfeedbackForm : PopupForm
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#QUICKFEEDBACK__PSEUD__NEWGRP01-container");

	/// <summary>
	/// <h2><strong>Thank you!</strong></h2>
	/// </summary>
	public IWebElement PseudField004 => throw new NotImplementedException();

	/// <summary>
	/// Your feedback helps us to create a better experience.
	/// </summary>
	public IWebElement PseudField005 => throw new NotImplementedException();

	/// <summary>
	/// <strong>Please tell us how we can improve</strong>
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// Check all that apply
	/// </summary>
	public IWebElement PseudField002 => throw new NotImplementedException();

	/// <summary>
	/// The information is hard to understand
	/// </summary>
	public CheckboxInputControl UfeedbackLogicalfeedb => new CheckboxInputControl(driver, ContainerLocator, "#container-QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB");

	/// <summary>
	/// I'd like to have more information in my language
	/// </summary>
	public CheckboxInputControl UfeedbackLanguagelogic => new CheckboxInputControl(driver, ContainerLocator, "#container-QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC");

	/// <summary>
	/// I can't find what I'm looking for
	/// </summary>
	public CheckboxInputControl UfeedbackLogicfeed => new CheckboxInputControl(driver, ContainerLocator, "#container-QUICKFEEDBACK__UFEEDBACK__LOGICFEED");

	/// <summary>
	/// Need more details
	/// </summary>
	public CheckboxInputControl UfeedbackMoredetlogic => new CheckboxInputControl(driver, ContainerLocator, "#container-QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC");

	/// <summary>
	/// Send Feedback
	/// </summary>
	public ButtonControl PseudField003 => new ButtonControl(driver, ContainerLocator, "#QUICKFEEDBACK__PSEUD__FIELD003");

	public QuickfeedbackForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "QUICKFEEDBACK") { }
}

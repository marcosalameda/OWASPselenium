using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DetailedfeedbackForm : PopupForm
{
	/// <summary>
	/// Form to retrieve anonymous feedback to improve the platform
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// Identify wich service you want to evaluate
	/// </summary>
	public EnumControl UfeedbackServicefeedback => new EnumControl(driver, ContainerLocator, "container-DETAILEDFEEDBACK__UFEEDBACK__SERVICEFEEDBACK");

	/// <summary>
	/// Identify what's the subject you intend to give feedback on
	/// </summary>
	public EnumControl UfeedbackServicetype => new EnumControl(driver, ContainerLocator, "container-DETAILEDFEEDBACK__UFEEDBACK__SERVICETYPE");

	/// <summary>
	/// Comments
	/// </summary>
	public BaseInputControl UfeedbackFeedbcoment => new BaseInputControl(driver, ContainerLocator, "container-DETAILEDFEEDBACK__UFEEDBACK__FEEDBCOMENT", "#DETAILEDFEEDBACK__UFEEDBACK__FEEDBCOMENT");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl UfeedbackFeedbackdate => new DateInputControl(driver, ContainerLocator, "#DETAILEDFEEDBACK__UFEEDBACK__FEEDBACKDATE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Files
	/// </summary>
	public DocumentControl UfeedbackFeedbfile => new DocumentControl(driver, ContainerLocator, "DETAILEDFEEDBACK__UFEEDBACK__FEEDBFILE");

	public DetailedfeedbackForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DETAILEDFEEDBACK") { }
}

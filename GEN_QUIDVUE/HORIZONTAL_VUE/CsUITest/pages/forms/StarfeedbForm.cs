using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class StarfeedbForm : PopupForm
{
	/// <summary>
	/// We are constantly trying to improve our website to make sure it responds to your needs.
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// Could you please dedicate your time to answer a small feedback form.
	/// </summary>
	public IWebElement PseudField002 => throw new NotImplementedException();

	/// <summary>
	/// Rating
	/// </summary>
	public EnumControl UfeedbackSfeedback => new EnumControl(driver, ContainerLocator, "container-STARFEEDB__UFEEDBACK__SFEEDBACK");

	/// <summary>
	/// Comments
	/// </summary>
	public BaseInputControl UfeedbackFeedbcoment => new BaseInputControl(driver, ContainerLocator, "container-STARFEEDB__UFEEDBACK__FEEDBCOMENT", "#STARFEEDB__UFEEDBACK__FEEDBCOMENT");

	public StarfeedbForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "STARFEEDB") { }
}

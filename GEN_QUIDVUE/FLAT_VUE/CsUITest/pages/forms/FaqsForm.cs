using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FaqsForm : Form
{
	/// <summary>
	/// Question
	/// </summary>
	public BaseInputControl FaqsQuestion => new BaseInputControl(driver, ContainerLocator, "#FAQS____FAQS_QUESTION");

	/// <summary>
	/// Answer
	/// </summary>
	public IWebElement FaqsAnswer => throw new NotImplementedException();

	public FaqsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FAQS", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CfaqsForm : Form
{
	/// <summary>
	/// Icon
	/// </summary>
	public BaseInputControl CfaqsIcon => new BaseInputControl(driver, ContainerLocator, "#CFAQS___CFAQSICON____");

	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl CfaqsCategory => new BaseInputControl(driver, ContainerLocator, "#CFAQS___CFAQSCATEGORY");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CfaqsDescript => new BaseInputControl(driver, ContainerLocator, "#CFAQS___CFAQSDESCRIPT");

	/// <summary>
	/// FAQS
	/// </summary>
	public ListControl PseudExpfaqs => new ListControl(driver, ContainerLocator, "#CFAQS___PSEUDEXPFAQS_");

	public CfaqsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CFAQS", containerLocator: containerLocator) { }
}

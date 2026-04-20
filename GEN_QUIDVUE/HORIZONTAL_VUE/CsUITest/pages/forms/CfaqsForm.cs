using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CfaqsForm : Form
{
	/// <summary>
	/// Icon
	/// </summary>
	public BaseInputControl CfaqsIcon => new BaseInputControl(driver, ContainerLocator, "container-CFAQS___CFAQSICON____" + IdSuffix, "#CFAQS___CFAQSICON____" + IdSuffix);

	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl CfaqsCategory => new BaseInputControl(driver, ContainerLocator, "container-CFAQS___CFAQSCATEGORY" + IdSuffix, "#CFAQS___CFAQSCATEGORY" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CfaqsDescript => new BaseInputControl(driver, ContainerLocator, "container-CFAQS___CFAQSDESCRIPT" + IdSuffix, "#CFAQS___CFAQSDESCRIPT" + IdSuffix);

	/// <summary>
	/// FAQS
	/// </summary>
	public ListControl PseudExpfaqs => new ListControl(driver, ContainerLocator, "#CFAQS___PSEUDEXPFAQS_" + IdSuffix);

	public CfaqsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CFAQS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TraduForm : Form
{
	/// <summary>
	/// Reference
	/// </summary>
	public BaseInputControl TraduReferenc => new BaseInputControl(driver, ContainerLocator, "container-TRADU___TRADUREFERENC", "#TRADU___TRADUREFERENC");

	/// <summary>
	/// Language
	/// </summary>
	public LookupControl Lang1Langua => new LookupControl(driver, ContainerLocator, "container-TRADU___LANG1LANGUA__");
	public SeeMorePage Lang1LanguaSeeMorePage => new SeeMorePage(driver, "TRADU", "TRADU___LANG1LANGUA__");

	/// <summary>
	/// To translate
	/// </summary>
	public BaseInputControl TraduAtraduzi => new BaseInputControl(driver, ContainerLocator, "container-TRADU___TRADUATRADUZI", "#TRADU___TRADUATRADUZI");

	/// <summary>
	/// Language
	/// </summary>
	public LookupControl Lang2Langua => new LookupControl(driver, ContainerLocator, "container-TRADU___LANG2LANGUA__");
	public SeeMorePage Lang2LanguaSeeMorePage => new SeeMorePage(driver, "TRADU", "TRADU___LANG2LANGUA__");

	/// <summary>
	/// Translated
	/// </summary>
	public BaseInputControl TraduTraduzid => new BaseInputControl(driver, ContainerLocator, "container-TRADU___TRADUTRADUZID", "#TRADU___TRADUTRADUZID");

	public TraduForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TRADU", containerLocator: containerLocator) { }
}

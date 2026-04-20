using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TraduForm : Form
{
	/// <summary>
	/// Reference
	/// </summary>
	public BaseInputControl TraduReferenc => new BaseInputControl(driver, ContainerLocator, "container-TRADU___TRADUREFERENC" + IdSuffix, "#TRADU___TRADUREFERENC" + IdSuffix);

	/// <summary>
	/// Language
	/// </summary>
	public LookupControl Lang1Langua => new LookupControl(driver, ContainerLocator, "container-TRADU___LANG1LANGUA__" + IdSuffix);
	public SeeMorePage Lang1LanguaSeeMorePage => new SeeMorePage(driver, "TRADU", "TRADU___LANG1LANGUA__" + IdSuffix);

	/// <summary>
	/// To translate
	/// </summary>
	public BaseInputControl TraduAtraduzi => new BaseInputControl(driver, ContainerLocator, "container-TRADU___TRADUATRADUZI" + IdSuffix, "#TRADU___TRADUATRADUZI" + IdSuffix);

	/// <summary>
	/// Language
	/// </summary>
	public LookupControl Lang2Langua => new LookupControl(driver, ContainerLocator, "container-TRADU___LANG2LANGUA__" + IdSuffix);
	public SeeMorePage Lang2LanguaSeeMorePage => new SeeMorePage(driver, "TRADU", "TRADU___LANG2LANGUA__" + IdSuffix);

	/// <summary>
	/// Translated
	/// </summary>
	public BaseInputControl TraduTraduzid => new BaseInputControl(driver, ContainerLocator, "container-TRADU___TRADUTRADUZID" + IdSuffix, "#TRADU___TRADUTRADUZID" + IdSuffix);

	public TraduForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "TRADU", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

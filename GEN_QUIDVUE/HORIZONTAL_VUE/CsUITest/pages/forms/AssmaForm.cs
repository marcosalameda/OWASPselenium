using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AssmaForm : Form
{
	/// <summary>
	/// Identification name
	/// </summary>
	public LookupControl AssetName => new LookupControl(driver, ContainerLocator, "container-ASSMA___ASSETNAME____" + IdSuffix);
	public SeeMorePage AssetNameSeeMorePage => new SeeMorePage(driver, "ASSMA", "ASSMA___ASSETNAME____" + IdSuffix);

	/// <summary>
	/// Manual name
	/// </summary>
	public BaseInputControl AssmaName => new BaseInputControl(driver, ContainerLocator, "container-ASSMA___ASSMANAME____" + IdSuffix, "#ASSMA___ASSMANAME____" + IdSuffix);

	/// <summary>
	/// Digital document
	/// </summary>
	public DocumentControl AssmaDigdocum => new DocumentControl(driver, ContainerLocator, "ASSMA___ASSMADIGDOCUM-container" + IdSuffix);

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl AssmaNotes => new BaseInputControl(driver, ContainerLocator, "container-ASSMA___ASSMANOTES___" + IdSuffix, "#ASSMA___ASSMANOTES___" + IdSuffix);

	public AssmaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ASSMA", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AssmaForm : Form
{
	/// <summary>
	/// Identification name
	/// </summary>
	public LookupControl AssetName => new LookupControl(driver, ContainerLocator, "container-ASSMA___ASSETNAME____");
	public SeeMorePage AssetNameSeeMorePage => new SeeMorePage(driver, "ASSMA", "ASSMA___ASSETNAME____");

	/// <summary>
	/// Manual name
	/// </summary>
	public BaseInputControl AssmaName => new BaseInputControl(driver, ContainerLocator, "container-ASSMA___ASSMANAME____", "#ASSMA___ASSMANAME____");

	/// <summary>
	/// Digital document
	/// </summary>
	public DocumentControl AssmaDigdocum => new DocumentControl(driver, ContainerLocator, "ASSMA___ASSMADIGDOCUM");

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl AssmaNotes => new BaseInputControl(driver, ContainerLocator, "container-ASSMA___ASSMANOTES___", "#ASSMA___ASSMANOTES___");

	public AssmaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ASSMA", containerLocator: containerLocator) { }
}

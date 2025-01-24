using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AttacForm : Form
{
	/// <summary>
	/// Identification name
	/// </summary>
	public LookupControl AssetName => new LookupControl(driver, ContainerLocator, "container-ATTAC___ASSETNAME____");
	public SeeMorePage AssetNameSeeMorePage => new SeeMorePage(driver, "ATTAC", "ATTAC___ASSETNAME____");

	/// <summary>
	/// Attached
	/// </summary>
	public DateInputControl AttacAttached => new DateInputControl(driver, ContainerLocator, "#ATTAC___ATTACATTACHED", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Note
	/// </summary>
	public BaseInputControl AttacNote => new BaseInputControl(driver, ContainerLocator, "#ATTAC___ATTACNOTE____");

	/// <summary>
	/// Document
	/// </summary>
	public DocumentControl AttacDocument => new DocumentControl(driver, ContainerLocator, "container-ATTAC___ATTACDOCUMENT");

	public AttacForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ATTAC", containerLocator: containerLocator) { }
}

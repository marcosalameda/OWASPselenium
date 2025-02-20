using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtglForm : PopupForm
{
	/// <summary>
	/// Global Item
	/// </summary>
	public BaseInputControl GitemItemdes => new BaseInputControl(driver, ContainerLocator, "container-ARTGL___GITEMITEMDES_", "#ARTGL___GITEMITEMDES_");

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl GitemItemgcod => new BaseInputControl(driver, ContainerLocator, "container-ARTGL___GITEMITEMGCOD", "#ARTGL___GITEMITEMGCOD");

	/// <summary>
	/// Catalog
	/// </summary>
	public DocumentControl GitemDocument => new DocumentControl(driver, ContainerLocator, "ARTGL___GITEMDOCUMENT");

	public ArtglForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARTGL") { }
}

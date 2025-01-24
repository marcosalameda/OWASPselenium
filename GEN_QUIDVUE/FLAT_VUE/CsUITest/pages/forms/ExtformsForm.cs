using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ExtformsForm : Form
{
	/// <summary>
	/// Support
	/// </summary>
	public ArtigextForm  PseudArtigapo => new ArtigextForm(driver, FORM_MODE.EDIT, By.Id("EXTFORMSPSEUDARTIGAPO"));

	/// <summary>
	/// Catalog Items
	/// </summary>
	public ListControl PseudArtigos => new ListControl(driver, ContainerLocator, "#EXTFORMSPSEUDARTIGOS_");

	public ExtformsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EXTFORMS", containerLocator: containerLocator) { }
}

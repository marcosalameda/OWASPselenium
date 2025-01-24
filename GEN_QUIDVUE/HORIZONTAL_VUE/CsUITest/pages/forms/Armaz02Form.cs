using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Armaz02Form : Subform
{
	/// <summary>
	/// Support
	/// </summary>
	public ArtigextForm  PseudArtigapo => new ArtigextForm(driver, FORM_MODE.EDIT, By.Id("ARMAZ02_PSEUDARTIGAPO"));

	/// <summary>
	/// Catalog articles
	/// </summary>
	public ListControl PseudArtigos => new ListControl(driver, ContainerLocator, "#ARMAZ02_PSEUDARTIGOS_");

	public Armaz02Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ARMAZ02", "ARMAZPOP", containerLocator: containerLocator) { }
}

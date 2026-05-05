using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CatarForm : Form
{
	/// <summary>
	/// Item:
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-CATAR___ITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "CATAR", "CATAR___ITEM_ITEMDES_");

	/// <summary>
	/// Category type
	/// </summary>
	public LookupControl CattpTpcatego => new LookupControl(driver, ContainerLocator, "container-CATAR___CATTPTPCATEGO");
	public SeeMorePage CattpTpcategoSeeMorePage => new SeeMorePage(driver, "CATAR", "CATAR___CATTPTPCATEGO");

	public CatarForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CATAR", containerLocator: containerLocator) { }
}

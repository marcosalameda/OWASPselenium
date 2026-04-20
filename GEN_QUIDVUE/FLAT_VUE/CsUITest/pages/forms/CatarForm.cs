using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CatarForm : Form
{
	/// <summary>
	/// Item:
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, ContainerLocator, "container-CATAR___ITEM_ITEMDES_" + IdSuffix);
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "CATAR", "CATAR___ITEM_ITEMDES_" + IdSuffix);

	/// <summary>
	/// Category type
	/// </summary>
	public LookupControl CattpTpcatego => new LookupControl(driver, ContainerLocator, "container-CATAR___CATTPTPCATEGO" + IdSuffix);
	public SeeMorePage CattpTpcategoSeeMorePage => new SeeMorePage(driver, "CATAR", "CATAR___CATTPTPCATEGO" + IdSuffix);

	public CatarForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CATAR", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

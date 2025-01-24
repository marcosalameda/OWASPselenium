using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GlobfactForm : Form
{
	/// <summary>
	/// Facility type
	/// </summary>
	public LookupControl FactyType => new LookupControl(driver, ContainerLocator, "container-GLOBFACTFACTYTYPE____");
	public SeeMorePage FactyTypeSeeMorePage => new SeeMorePage(driver, "GLOBFACT", "GLOBFACTFACTYTYPE____");

	public GlobfactForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "GLOBFACT", containerLocator: containerLocator) { }
}

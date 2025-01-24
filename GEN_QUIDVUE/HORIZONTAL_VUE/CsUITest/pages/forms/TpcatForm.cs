using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpcatForm : Form
{
	/// <summary>
	/// Category type
	/// </summary>
	public BaseInputControl CattpTpcatego => new BaseInputControl(driver, ContainerLocator, "#TPCAT___CATTPTPCATEGO");

	/// <summary>
	/// Sub categoria
	/// </summary>
	public LookupControl SbcatSubcateg => new LookupControl(driver, ContainerLocator, "container-TPCAT___SBCATSUBCATEG");
	public SeeMorePage SbcatSubcategSeeMorePage => new SeeMorePage(driver, "TPCAT", "TPCAT___SBCATSUBCATEG");

	public TpcatForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TPCAT", containerLocator: containerLocator) { }
}

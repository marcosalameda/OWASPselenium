using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpcatForm : Form
{
	/// <summary>
	/// Category type
	/// </summary>
	public BaseInputControl CattpTpcatego => new BaseInputControl(driver, ContainerLocator, "container-TPCAT___CATTPTPCATEGO" + IdSuffix, "#TPCAT___CATTPTPCATEGO" + IdSuffix);

	/// <summary>
	/// Sub categoria
	/// </summary>
	public LookupControl SbcatSubcateg => new LookupControl(driver, ContainerLocator, "container-TPCAT___SBCATSUBCATEG" + IdSuffix);
	public SeeMorePage SbcatSubcategSeeMorePage => new SeeMorePage(driver, "TPCAT", "TPCAT___SBCATSUBCATEG" + IdSuffix);

	public TpcatForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "TPCAT", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

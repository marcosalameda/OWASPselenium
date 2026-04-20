using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pessos00Form : Subform
{
	/// <summary>
	/// Designation
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-PESSOS00CMPNYDESIGNAT" + IdSuffix);
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESSOS00", "PESSOS00CMPNYDESIGNAT" + IdSuffix);

	public Pessos00Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PESSOS00", "PESSOSEP", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

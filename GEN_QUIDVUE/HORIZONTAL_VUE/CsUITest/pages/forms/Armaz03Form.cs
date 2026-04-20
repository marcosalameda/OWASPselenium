using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Armaz03Form : PopupForm
{
	/// <summary>
	/// Support
	/// </summary>
	public ArtigextForm  PseudArtigapo => new ArtigextForm(driver, FORM_MODE.EDIT, By.Id("ARMAZ03_PSEUDARTIGAPO"), usePkInId: true);

	/// <summary>
	/// Catalog articles
	/// </summary>
	public ListControl PseudArtigos => new ListControl(driver, ContainerLocator, "#ARMAZ03_PSEUDARTIGOS_" + IdSuffix);

	public Armaz03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ARMAZ03", usePkInId: usePkInId) { }
}

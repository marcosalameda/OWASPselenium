using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GmapsForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, ContainerLocator, "#GMAPS___PSEUDINSTALAC" + IdSuffix);

	public GmapsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "GMAPS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

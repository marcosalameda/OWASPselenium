using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wid_colaForm : Form
{
	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl CmpnyLogo => new BaseInputControl(driver, ContainerLocator, "container-WID_COLACMPNYLOGO____" + IdSuffix, "#WID_COLACMPNYLOGO____" + IdSuffix);

	/// <summary>
	/// Designation
	/// </summary>
	public BaseInputControl CmpnyDesignat => new BaseInputControl(driver, ContainerLocator, "container-WID_COLACMPNYDESIGNAT" + IdSuffix, "#WID_COLACMPNYDESIGNAT" + IdSuffix);

	/// <summary>
	/// People
	/// </summary>
	public ListControl PseudPesslist => new ListControl(driver, ContainerLocator, "#WID_COLAPSEUDPESSLIST" + IdSuffix);

	public Wid_colaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "WID_COLA", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

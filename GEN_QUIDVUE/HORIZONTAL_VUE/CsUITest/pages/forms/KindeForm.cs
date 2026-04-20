using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class KindeForm : Form
{
	/// <summary>
	/// Kind of equipment
	/// </summary>
	public BaseInputControl KindeDesignat => new BaseInputControl(driver, ContainerLocator, "container-KINDE___KINDEDESIGNAT" + IdSuffix, "#KINDE___KINDEDESIGNAT" + IdSuffix);

	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl PseudParamete => new ListControl(driver, ContainerLocator, "#KINDE___PSEUDPARAMETE" + IdSuffix);

	/// <summary>
	/// Manuals
	/// </summary>
	public ListControl PseudManuals => new ListControl(driver, ContainerLocator, "#KINDE___PSEUDMANUALS_" + IdSuffix);

	public KindeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "KINDE", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

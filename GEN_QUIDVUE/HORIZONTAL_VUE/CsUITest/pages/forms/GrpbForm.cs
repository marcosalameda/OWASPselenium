using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GrpbForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl GrpbName => new BaseInputControl(driver, ContainerLocator, "container-GRPB____GRPB_NAME____", "#GRPB____GRPB_NAME____");

	/// <summary>
	/// 
	/// </summary>
	public GrpbPseudTblbGrid PseudTblb => new GrpbPseudTblbGrid(driver, ContainerLocator, "#GRPB____PSEUDTBLB____");

	public GrpbForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "GRPB", containerLocator: containerLocator) { }
}

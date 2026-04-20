using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GrpbForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl GrpbName => new BaseInputControl(driver, ContainerLocator, "container-GRPB____GRPB_NAME____" + IdSuffix, "#GRPB____GRPB_NAME____" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public GrpbPseudTblbGrid PseudTblb => new GrpbPseudTblbGrid(driver, ContainerLocator, "#GRPB____PSEUDTBLB____" + IdSuffix);

	public GrpbForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "GRPB", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

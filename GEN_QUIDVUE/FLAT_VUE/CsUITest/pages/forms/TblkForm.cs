using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TblkForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl TblkName => new BaseInputControl(driver, ContainerLocator, "container-TBLK____TBLK_NAME____", "#TBLK____TBLK_NAME____");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl GrpbName => new LookupControl(driver, ContainerLocator, "container-TBLK____GRPB_NAME____");
	public SeeMorePage GrpbNameSeeMorePage => new SeeMorePage(driver, "TBLK", "TBLK____GRPB_NAME____");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl TrsbName => new LookupControl(driver, ContainerLocator, "container-TBLK____TRSB_NAME____");
	public SeeMorePage TrsbNameSeeMorePage => new SeeMorePage(driver, "TBLK", "TBLK____TRSB_NAME____");

	public TblkForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TBLK", containerLocator: containerLocator) { }
}

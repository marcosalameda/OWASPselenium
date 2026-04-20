using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EqudocumForm : Form
{
	/// <summary>
	/// Designation
	/// </summary>
	public BaseInputControl EquipDesignat => new BaseInputControl(driver, ContainerLocator, "container-EQUDOCUMEQUIPDESIGNAT" + IdSuffix, "#EQUDOCUMEQUIPDESIGNAT" + IdSuffix);

	/// <summary>
	/// Add ANEXD
	/// </summary>
	public ButtonControl PseudBtn_anex => new ButtonControl(driver, ContainerLocator, "#EQUDOCUMPSEUDBTN_ANEX" + IdSuffix);

	/// <summary>
	/// Digital Attachements
	/// </summary>
	public ListControl PseudLisanex => new ListControl(driver, ContainerLocator, "#EQUDOCUMPSEUDLISANEX_" + IdSuffix);

	public EqudocumForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "EQUDOCUM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

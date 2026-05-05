using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamenumForm : Subform
{
	/// <summary>
	/// Numeric enumeration
	/// </summary>
	public RadiobuttonControl FldsClassnum => new RadiobuttonControl(driver, ContainerLocator, "container-CAMENUM_FLDS_CLASSNUM");

	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl FldsClass => new EnumControl(driver, ContainerLocator, "container-CAMENUM_FLDS_CLASS___");

	/// <summary>
	/// Logical Enumeration
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, ContainerLocator, "container-CAMENUM_FLDS_LOGICENU");

	public CamenumForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CAMENUM", "LISTACAM", containerLocator: containerLocator) { }
}

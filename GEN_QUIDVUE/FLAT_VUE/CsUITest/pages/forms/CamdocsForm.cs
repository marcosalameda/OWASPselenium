using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamdocsForm : Subform
{
	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl FldsLogo => new BaseInputControl(driver, ContainerLocator, "container-CAMDOCS_FLDS_LOGO____" + IdSuffix, "#CAMDOCS_FLDS_LOGO____" + IdSuffix);

	/// <summary>
	/// Attachments
	/// </summary>
	public DocumentControl FldsAttach => new DocumentControl(driver, ContainerLocator, "CAMDOCS_FLDS_ATTACH__-container" + IdSuffix);

	public CamdocsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CAMDOCS", "LISTACAM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

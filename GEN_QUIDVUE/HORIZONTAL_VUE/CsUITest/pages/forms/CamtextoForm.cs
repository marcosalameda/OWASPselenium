using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamtextoForm : Subform
{
	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl FldsTxtfield => new BaseInputControl(driver, ContainerLocator, "container-CAMTEXTOFLDS_TXTFIELD" + IdSuffix, "#CAMTEXTOFLDS_TXTFIELD" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, ContainerLocator, "container-CAMTEXTOFLDS_DESCRIP_" + IdSuffix, "#CAMTEXTOFLDS_DESCRIP_" + IdSuffix);

	public CamtextoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CAMTEXTO", "LISTACAM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

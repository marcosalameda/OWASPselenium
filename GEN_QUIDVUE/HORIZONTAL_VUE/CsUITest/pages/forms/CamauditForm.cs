using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamauditForm : Subform
{
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATUSE" + IdSuffix, "#CAMAUDITFLDS_CREATUSE" + IdSuffix);

	/// <summary>
	/// Date of Creation
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATDAT" + IdSuffix, "#CAMAUDITFLDS_CREATDAT" + IdSuffix);

	/// <summary>
	/// Creation hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATHOU" + IdSuffix, "#CAMAUDITFLDS_CREATHOU" + IdSuffix);

	/// <summary>
	/// Complete Date of Creation
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATINS" + IdSuffix, "#CAMAUDITFLDS_CREATINS" + IdSuffix);

	public CamauditForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CAMAUDIT", "LISTACAM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

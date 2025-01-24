using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamauditForm : Subform
{
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, ContainerLocator, "#CAMAUDITFLDS_CREATUSE");

	/// <summary>
	/// Date of Creation
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, ContainerLocator, "#CAMAUDITFLDS_CREATDAT");

	/// <summary>
	/// Creation hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, ContainerLocator, "#CAMAUDITFLDS_CREATHOU");

	/// <summary>
	/// Complete Date of Creation
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, ContainerLocator, "#CAMAUDITFLDS_CREATINS");

	public CamauditForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CAMAUDIT", "LISTACAM", containerLocator: containerLocator) { }
}

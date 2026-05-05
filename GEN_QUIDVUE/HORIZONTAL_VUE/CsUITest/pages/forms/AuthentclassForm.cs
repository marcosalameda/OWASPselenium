using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AuthentclassForm : Form
{
	/// <summary>
	/// Preview
	/// </summary>
	public BaseInputControl AuthenticatoptAuthpreview => new BaseInputControl(driver, ContainerLocator, "container-AUTHENTCLASS__AUTHENTICATOPT__AUTHPREVIEW", "#AUTHENTCLASS__AUTHENTICATOPT__AUTHPREVIEW");

	/// <summary>
	/// Option
	/// </summary>
	public EnumControl AuthenticatoptAuthoptions => new EnumControl(driver, ContainerLocator, "container-AUTHENTCLASS__AUTHENTICATOPT__AUTHOPTIONS");

	public AuthentclassForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "AUTHENTCLASS", containerLocator: containerLocator) { }
}

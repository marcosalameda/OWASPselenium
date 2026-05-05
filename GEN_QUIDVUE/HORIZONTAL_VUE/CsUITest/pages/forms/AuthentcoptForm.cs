using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AuthentcoptForm : Form
{
	/// <summary>
	/// Variable type
	/// </summary>
	public BaseInputControl AuthenticatoptAuthvariablet => new BaseInputControl(driver, ContainerLocator, "container-AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET", "#AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET");

	/// <summary>
	/// Variable name
	/// </summary>
	public BaseInputControl AuthenticatoptAuthvarname => new BaseInputControl(driver, ContainerLocator, "container-AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME", "#AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME");

	/// <summary>
	/// Option
	/// </summary>
	public EnumControl AuthenticatoptAuthoptions => new EnumControl(driver, ContainerLocator, "container-AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS");

	/// <summary>
	/// MVC
	/// </summary>
	public CheckboxInputControl AuthenticatoptAuthmvc => new CheckboxInputControl(driver, ContainerLocator, "#container-AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC");

	/// <summary>
	/// VUE
	/// </summary>
	public CheckboxInputControl AuthenticatoptAuthvue => new CheckboxInputControl(driver, ContainerLocator, "#container-AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE");

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl AuthenticatoptAuthnotes => new BaseInputControl(driver, ContainerLocator, "container-AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES", "#AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES");

	/// <summary>
	/// Preview
	/// </summary>
	public BaseInputControl AuthenticatoptAuthpreview => new BaseInputControl(driver, ContainerLocator, "container-AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW", "#AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW");

	public AuthentcoptForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "AUTHENTCOPT", containerLocator: containerLocator) { }
}

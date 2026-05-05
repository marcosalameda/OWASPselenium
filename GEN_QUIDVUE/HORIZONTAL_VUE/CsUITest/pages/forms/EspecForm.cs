using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EspecForm : Form
{
	/// <summary>
	/// Specialty
	/// </summary>
	public BaseInputControl SpeciEspecial => new BaseInputControl(driver, ContainerLocator, "container-ESPEC___SPECIESPECIAL", "#ESPEC___SPECIESPECIAL");

	/// <summary>
	/// Technical  area
	/// </summary>
	public RadiobuttonControl SpeciAreatecn => new RadiobuttonControl(driver, ContainerLocator, "container-ESPEC___SPECIAREATECN");

	public EspecForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ESPEC", containerLocator: containerLocator) { }
}

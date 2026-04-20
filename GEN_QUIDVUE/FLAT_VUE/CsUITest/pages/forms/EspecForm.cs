using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EspecForm : Form
{
	/// <summary>
	/// Specialty
	/// </summary>
	public BaseInputControl SpeciEspecial => new BaseInputControl(driver, ContainerLocator, "container-ESPEC___SPECIESPECIAL" + IdSuffix, "#ESPEC___SPECIESPECIAL" + IdSuffix);

	/// <summary>
	/// Technical  area
	/// </summary>
	public RadiobuttonControl SpeciAreatecn => new RadiobuttonControl(driver, ContainerLocator, "container-ESPEC___SPECIAREATECN" + IdSuffix);

	public EspecForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ESPEC", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

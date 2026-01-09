using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CompclasForm : Form
{
	/// <summary>
	/// Components Class
	/// </summary>
	public BaseInputControl CompcCompclas => new BaseInputControl(driver, ContainerLocator, "container-COMPCLASCOMPCCOMPCLAS", "#COMPCLASCOMPCCOMPCLAS");

	/// <summary>
	/// 
	/// </summary>
	public BaseInputControl CompcClassico => new BaseInputControl(driver, ContainerLocator, "container-COMPCLASCOMPCCLASSICO", "#COMPCLASCOMPCCLASSICO");

	/// <summary>
	/// Class Description
	/// </summary>
	public BaseInputControl CompcClassdes => new BaseInputControl(driver, ContainerLocator, "container-COMPCLASCOMPCCLASSDES", "#COMPCLASCOMPCCLASSDES");

	public CompclasForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "COMPCLAS", containerLocator: containerLocator) { }
}

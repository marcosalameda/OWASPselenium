using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class SbcatForm : Form
{
	/// <summary>
	/// Sub categoria
	/// </summary>
	public BaseInputControl SbcatSubcateg => new BaseInputControl(driver, ContainerLocator, "container-SBCAT___SBCATSUBCATEG" + IdSuffix, "#SBCAT___SBCATSUBCATEG" + IdSuffix);

	public SbcatForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "SBCAT", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

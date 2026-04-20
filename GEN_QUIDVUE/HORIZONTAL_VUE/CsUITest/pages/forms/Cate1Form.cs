using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Cate1Form : Form
{
	/// <summary>
	/// Abbreviation
	/// </summary>
	public BaseInputControl Cate1Abbrevia => new BaseInputControl(driver, ContainerLocator, "container-CATE1___CATE1ABBREVIA" + IdSuffix, "#CATE1___CATE1ABBREVIA" + IdSuffix);

	/// <summary>
	/// Category
	/// </summary>
	public BaseInputControl Cate1Category => new BaseInputControl(driver, ContainerLocator, "container-CATE1___CATE1CATEGORY" + IdSuffix, "#CATE1___CATE1CATEGORY" + IdSuffix);

	public Cate1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CATE1", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

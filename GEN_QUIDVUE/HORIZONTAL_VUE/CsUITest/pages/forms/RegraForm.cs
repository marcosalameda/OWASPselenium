using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegraForm : Form
{
	/// <summary>
	/// Condition type
	/// </summary>
	public EnumControl RulesTipocond => new EnumControl(driver, ContainerLocator, "container-REGRA___RULESTIPOCOND");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl RulesDescript => new BaseInputControl(driver, ContainerLocator, "#REGRA___RULESDESCRIPT");

	/// <summary>
	/// Local onde executa
	/// </summary>
	public EnumControl RulesLocal => new EnumControl(driver, ContainerLocator, "container-REGRA___RULESLOCAL___");

	public RegraForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "REGRA", containerLocator: containerLocator) { }
}

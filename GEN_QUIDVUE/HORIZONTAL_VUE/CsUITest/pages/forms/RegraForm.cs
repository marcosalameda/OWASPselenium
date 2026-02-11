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
	public BaseInputControl RulesDescript => new BaseInputControl(driver, ContainerLocator, "container-REGRA___RULESDESCRIPT", "#REGRA___RULESDESCRIPT");

	/// <summary>
	/// Local onde executa
	/// </summary>
	public EnumControl RulesLocal => new EnumControl(driver, ContainerLocator, "container-REGRA___RULESLOCAL___");

	/// <summary>
	/// Description
	/// </summary>
	public LookupControl Up_rulesDescript => new LookupControl(driver, ContainerLocator, "container-REGRA__UP_RULES__DESCRIPT");
	public SeeMorePage Up_rulesDescriptSeeMorePage => new SeeMorePage(driver, "REGRA", "REGRA__UP_RULES__DESCRIPT");

	public RegraForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "REGRA", containerLocator: containerLocator) { }
}

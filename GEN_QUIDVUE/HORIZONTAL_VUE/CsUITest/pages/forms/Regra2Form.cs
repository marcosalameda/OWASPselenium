using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Regra2Form : Form
{
	/// <summary>
	/// Description
	/// </summary>
	public LookupControl Up_rulesDescript => new LookupControl(driver, ContainerLocator, "container-REGRA2__UP_RULES__DESCRIPT");
	public SeeMorePage Up_rulesDescriptSeeMorePage => new SeeMorePage(driver, "REGRA2", "REGRA2__UP_RULES__DESCRIPT");

	/// <summary>
	/// Condition type
	/// </summary>
	public EnumControl RulesTipocond => new EnumControl(driver, ContainerLocator, "container-REGRA2__RULESTIPOCOND");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl RulesDescript => new BaseInputControl(driver, ContainerLocator, "container-REGRA2__RULESDESCRIPT", "#REGRA2__RULESDESCRIPT");

	/// <summary>
	/// Local onde executa
	/// </summary>
	public EnumControl RulesLocal => new EnumControl(driver, ContainerLocator, "container-REGRA2__RULESLOCAL___");

	public Regra2Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "REGRA2", containerLocator: containerLocator) { }
}

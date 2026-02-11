using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Up_rulesForm : Form
{
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl Up_rulesDescript => new BaseInputControl(driver, ContainerLocator, "container-UP_RULES__UP_RULES__DESCRIPT", "#UP_RULES__UP_RULES__DESCRIPT");

	/// <summary>
	/// Place where you run
	/// </summary>
	public EnumControl Up_rulesLocal => new EnumControl(driver, ContainerLocator, "container-UP_RULES__UP_RULES__LOCAL");

	/// <summary>
	/// Allow all
	/// </summary>
	public CheckboxInputControl Up_rulesAllow_all => new CheckboxInputControl(driver, ContainerLocator, "#container-UP_RULES__UP_RULES__ALLOW_ALL");

	/// <summary>
	/// Receipts of goods
	/// </summary>
	public ListControl PseudRegras => new ListControl(driver, ContainerLocator, "#UP_RULESPSEUDREGRAS__");

	public Up_rulesForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "UP_RULES", containerLocator: containerLocator) { }
}

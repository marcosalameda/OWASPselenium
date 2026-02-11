using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class OperacoesForm : Form
{
	/// <summary>
	/// Entidade
	/// </summary>
	public LookupControl EntidadeEntidade => new LookupControl(driver, ContainerLocator, "container-OPERACOES__ENTIDADE__ENTIDADE");
	public SeeMorePage EntidadeEntidadeSeeMorePage => new SeeMorePage(driver, "OPERACOES", "OPERACOES__ENTIDADE__ENTIDADE");

	/// <summary>
	/// Operação AA
	/// </summary>
	public BaseInputControl OperacoesOperacao_aa => new BaseInputControl(driver, ContainerLocator, "container-OPERACOES__OPERACOES__OPERACAO_AA", "#OPERACOES__OPERACOES__OPERACAO_AA");

	/// <summary>
	/// Pop abrangida
	/// </summary>
	public BaseInputControl OperacoesPop_aa => new BaseInputControl(driver, ContainerLocator, "container-OPERACOES__OPERACOES__POP_AA", "#OPERACOES__OPERACOES__POP_AA");

	/// <summary>
	/// Sobreposição AA
	/// </summary>
	public CheckboxInputControl OperacoesSobreposicao_aa => new CheckboxInputControl(driver, ContainerLocator, "#container-OPERACOES__OPERACOES__SOBREPOSICAO_AA");

	/// <summary>
	/// Operação AR
	/// </summary>
	public BaseInputControl OperacoesOperacao_ar => new BaseInputControl(driver, ContainerLocator, "container-OPERACOES__OPERACOES__OPERACAO_AR", "#OPERACOES__OPERACOES__OPERACAO_AR");

	/// <summary>
	/// Pop abrangida
	/// </summary>
	public BaseInputControl OperacoesPop_ar => new BaseInputControl(driver, ContainerLocator, "container-OPERACOES__OPERACOES__POP_AR", "#OPERACOES__OPERACOES__POP_AR");

	/// <summary>
	/// Sobreposição AR
	/// </summary>
	public CheckboxInputControl OperacoesSobreposicao_ar => new CheckboxInputControl(driver, ContainerLocator, "#container-OPERACOES__OPERACOES__SOBREPOSICAO_AR");

	/// <summary>
	/// Operação RU
	/// </summary>
	public BaseInputControl OperacoesOperacao_ru => new BaseInputControl(driver, ContainerLocator, "container-OPERACOES__OPERACOES__OPERACAO_RU", "#OPERACOES__OPERACOES__OPERACAO_RU");

	/// <summary>
	/// Pop abrangida
	/// </summary>
	public BaseInputControl OperacoesPop_ru => new BaseInputControl(driver, ContainerLocator, "container-OPERACOES__OPERACOES__POP_RU", "#OPERACOES__OPERACOES__POP_RU");

	/// <summary>
	/// Sobreposição RU
	/// </summary>
	public CheckboxInputControl OperacoesSobreposicao_ru => new CheckboxInputControl(driver, ContainerLocator, "#container-OPERACOES__OPERACOES__SOBREPOSICAO_RU");

	public OperacoesForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "OPERACOES", containerLocator: containerLocator) { }
}

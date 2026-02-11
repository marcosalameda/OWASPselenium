using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntidadeForm : Form
{
	/// <summary>
	/// Nome
	/// </summary>
	public LookupControl ConcelhoNome => new LookupControl(driver, ContainerLocator, "container-ENTIDADE__CONCELHO__NOME");
	public SeeMorePage ConcelhoNomeSeeMorePage => new SeeMorePage(driver, "ENTIDADE", "ENTIDADE__CONCELHO__NOME");

	/// <summary>
	/// ID Entidade
	/// </summary>
	public BaseInputControl EntidadeId_entidade => new BaseInputControl(driver, ContainerLocator, "container-ENTIDADE__ENTIDADE__ID_ENTIDADE", "#ENTIDADE__ENTIDADE__ID_ENTIDADE");

	/// <summary>
	/// Entidade
	/// </summary>
	public BaseInputControl EntidadeEntidade => new BaseInputControl(driver, ContainerLocator, "container-ENTIDADE__ENTIDADE__ENTIDADE", "#ENTIDADE__ENTIDADE__ENTIDADE");

	/// <summary>
	/// Submodelo de gestão
	/// </summary>
	public BaseInputControl EntidadeSub_modelo_gestao => new BaseInputControl(driver, ContainerLocator, "container-ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO", "#ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO");

	/// <summary>
	/// Sistema contabilístico
	/// </summary>
	public EnumControl EntidadeSistema_contabilistico => new EnumControl(driver, ContainerLocator, "container-ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO");

	/// <summary>
	/// Operação
	/// </summary>
	public ListControl PseudOperacoes => new ListControl(driver, ContainerLocator, "#ENTIDADE__PSEUD__OPERACOES");

	public EntidadeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ENTIDADE", containerLocator: containerLocator) { }
}

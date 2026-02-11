using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ConcelhoForm : Form
{
	/// <summary>
	/// Nome
	/// </summary>
	public BaseInputControl ConcelhoNome => new BaseInputControl(driver, ContainerLocator, "container-CONCELHO__CONCELHO__NOME", "#CONCELHO__CONCELHO__NOME");

	/// <summary>
	/// Pop residente
	/// </summary>
	public BaseInputControl ConcelhoPop_residente => new BaseInputControl(driver, ContainerLocator, "container-CONCELHO__CONCELHO__POP_RESIDENTE", "#CONCELHO__CONCELHO__POP_RESIDENTE");

	/// <summary>
	/// Entidade
	/// </summary>
	public ListControl PseudEntidades => new ListControl(driver, ContainerLocator, "#CONCELHO__PSEUD__ENTIDADES");

	public ConcelhoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONCELHO", containerLocator: containerLocator) { }
}

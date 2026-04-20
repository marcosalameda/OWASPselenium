using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ContaForm : PopupForm
{
	/// <summary>
	/// Name:
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-CONTA___PESSONAME____" + IdSuffix);
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "CONTA", "CONTA___PESSONAME____" + IdSuffix);

	/// <summary>
	/// Genre
	/// </summary>
	public LookupControl GenreGender => new LookupControl(driver, ContainerLocator, "container-CONTA___GENREGENDER__" + IdSuffix);
	public SeeMorePage GenreGenderSeeMorePage => new SeeMorePage(driver, "CONTA", "CONTA___GENREGENDER__" + IdSuffix);

	/// <summary>
	/// Contact Type:
	/// </summary>
	public LookupControl TpconTipocont => new LookupControl(driver, ContainerLocator, "container-CONTA___TPCONTIPOCONT" + IdSuffix);
	public SeeMorePage TpconTipocontSeeMorePage => new SeeMorePage(driver, "CONTA", "CONTA___TPCONTIPOCONT" + IdSuffix);

	/// <summary>
	/// Contact
	/// </summary>
	public BaseInputControl ContaContacto => new BaseInputControl(driver, ContainerLocator, "container-CONTA___CONTACONTACTO" + IdSuffix, "#CONTA___CONTACONTACTO" + IdSuffix);

	public ContaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CONTA", usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PwregForm : Form
{
	/// <summary>
	/// Login Name
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, ContainerLocator, "container-PWREG___PSW__NOME____");
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "PWREG", "PWREG___PSW__NOME____");

	/// <summary>
	/// Region
	/// </summary>
	public LookupControl RegioRegiao => new LookupControl(driver, ContainerLocator, "container-PWREG___REGIOREGIAO__");
	public SeeMorePage RegioRegiaoSeeMorePage => new SeeMorePage(driver, "PWREG", "PWREG___REGIOREGIAO__");

	public PwregForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PWREG", containerLocator: containerLocator) { }
}

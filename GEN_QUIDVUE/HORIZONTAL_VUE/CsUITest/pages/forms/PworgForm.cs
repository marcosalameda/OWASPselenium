using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PworgForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, ContainerLocator, "container-PWORG___PSW__NOME____");
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "PWORG", "PWORG___PSW__NOME____");

	/// <summary>
	/// Organization
	/// </summary>
	public LookupControl OrganOrganiza => new LookupControl(driver, ContainerLocator, "container-PWORG___ORGANORGANIZA");
	public SeeMorePage OrganOrganizaSeeMorePage => new SeeMorePage(driver, "PWORG", "PWORG___ORGANORGANIZA");

	public PworgForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PWORG", containerLocator: containerLocator) { }
}

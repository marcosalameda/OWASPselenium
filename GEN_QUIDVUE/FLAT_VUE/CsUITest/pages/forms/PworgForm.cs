using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PworgForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, ContainerLocator, "container-PWORG___PSW__NOME____" + IdSuffix);
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "PWORG", "PWORG___PSW__NOME____" + IdSuffix);

	/// <summary>
	/// Organization
	/// </summary>
	public LookupControl OrganOrganiza => new LookupControl(driver, ContainerLocator, "container-PWORG___ORGANORGANIZA" + IdSuffix);
	public SeeMorePage OrganOrganizaSeeMorePage => new SeeMorePage(driver, "PWORG", "PWORG___ORGANORGANIZA" + IdSuffix);

	public PworgForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PWORG", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

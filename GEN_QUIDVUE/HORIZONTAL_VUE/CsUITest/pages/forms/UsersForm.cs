using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class UsersForm : Form
{
	/// <summary>
	/// Login name
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, ContainerLocator, "container-USERS___PSW__NOME____");
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "USERS", "USERS___PSW__NOME____");

	/// <summary>
	/// Person name
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, ContainerLocator, "container-USERS___PERSONAME____");
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "USERS", "USERS___PERSONAME____");

	public UsersForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "USERS", containerLocator: containerLocator) { }
}

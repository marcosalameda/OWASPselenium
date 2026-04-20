using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PwcomForm : Form
{
	/// <summary>
	/// Login Name
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, ContainerLocator, "container-PWCOM___PSW__NOME____" + IdSuffix);
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "PWCOM", "PWCOM___PSW__NOME____" + IdSuffix);

	/// <summary>
	/// Lending:
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, ContainerLocator, "container-PWCOM___PESS1NAME____" + IdSuffix);
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "PWCOM", "PWCOM___PESS1NAME____" + IdSuffix);

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PwcomFoto => new BaseInputControl(driver, ContainerLocator, "container-PWCOM___PWCOMFOTO____" + IdSuffix, "#PWCOM___PWCOMFOTO____" + IdSuffix);

	public PwcomForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PWCOM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

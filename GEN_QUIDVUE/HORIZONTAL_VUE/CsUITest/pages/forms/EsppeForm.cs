using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EsppeForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-ESPPE___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "ESPPE", "ESPPE___PESSONAME____");

	/// <summary>
	/// Specialty
	/// </summary>
	public LookupControl SpeciEspecial => new LookupControl(driver, ContainerLocator, "container-ESPPE___SPECIESPECIAL");
	public SeeMorePage SpeciEspecialSeeMorePage => new SeeMorePage(driver, "ESPPE", "ESPPE___SPECIESPECIAL");

	public EsppeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ESPPE", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EvcatForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-EVCAT___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "EVCAT", "EVCAT___PESSONAME____");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl Cate1Category => new LookupControl(driver, ContainerLocator, "container-EVCAT___CATE1CATEGORY");
	public SeeMorePage Cate1CategorySeeMorePage => new SeeMorePage(driver, "EVCAT", "EVCAT___CATE1CATEGORY");

	/// <summary>
	/// Since:
	/// </summary>
	public DateInputControl EvcatSince => new DateInputControl(driver, ContainerLocator, "#EVCAT___EVCATSINCE___");

	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl EvcatUntil => new DateInputControl(driver, ContainerLocator, "#EVCAT___EVCATUNTIL___");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl EvcatUntilman => new DateInputControl(driver, ContainerLocator, "#EVCAT___EVCATUNTILMAN");

	/// <summary>
	/// End of period
	/// </summary>
	public DateInputControl EvcatFimperio => new DateInputControl(driver, ContainerLocator, "#EVCAT___EVCATFIMPERIO");

	/// <summary>
	/// Observation
	/// </summary>
	public BaseInputControl EvcatObservat => new BaseInputControl(driver, ContainerLocator, "container-EVCAT___EVCATOBSERVAT", "#EVCAT___EVCATOBSERVAT");

	public EvcatForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EVCAT", containerLocator: containerLocator) { }
}

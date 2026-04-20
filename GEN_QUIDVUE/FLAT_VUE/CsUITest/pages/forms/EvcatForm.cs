using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EvcatForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-EVCAT___PESSONAME____" + IdSuffix);
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "EVCAT", "EVCAT___PESSONAME____" + IdSuffix);

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl Cate1Category => new LookupControl(driver, ContainerLocator, "container-EVCAT___CATE1CATEGORY" + IdSuffix);
	public SeeMorePage Cate1CategorySeeMorePage => new SeeMorePage(driver, "EVCAT", "EVCAT___CATE1CATEGORY" + IdSuffix);

	/// <summary>
	/// Since:
	/// </summary>
	public DateInputControl EvcatSince => new DateInputControl(driver, ContainerLocator, "#EVCAT___EVCATSINCE___" + IdSuffix);

	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl EvcatUntil => new DateInputControl(driver, ContainerLocator, "#EVCAT___EVCATUNTIL___" + IdSuffix);

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl EvcatUntilman => new DateInputControl(driver, ContainerLocator, "#EVCAT___EVCATUNTILMAN" + IdSuffix);

	/// <summary>
	/// End of period
	/// </summary>
	public DateInputControl EvcatFimperio => new DateInputControl(driver, ContainerLocator, "#EVCAT___EVCATFIMPERIO" + IdSuffix);

	/// <summary>
	/// Observation
	/// </summary>
	public BaseInputControl EvcatObservat => new BaseInputControl(driver, ContainerLocator, "container-EVCAT___EVCATOBSERVAT" + IdSuffix, "#EVCAT___EVCATOBSERVAT" + IdSuffix);

	public EvcatForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "EVCAT", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

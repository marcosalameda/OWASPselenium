using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FeecaForm : Form
{
	/// <summary>
	/// Description
	/// </summary>
	public LookupControl FldsDescrip => new LookupControl(driver, ContainerLocator, "container-FEECA___FLDS_DESCRIP_");
	public SeeMorePage FldsDescripSeeMorePage => new SeeMorePage(driver, "FEECA", "FEECA___FLDS_DESCRIP_");

	/// <summary>
	/// Feedback
	/// </summary>
	public BaseInputControl FeecaFeedback => new BaseInputControl(driver, ContainerLocator, "container-FEECA___FEECAFEEDBACK", "#FEECA___FEECAFEEDBACK");

	/// <summary>
	/// Attachments
	/// </summary>
	public IWebElement FldsAttach => throw new NotImplementedException();

	/// <summary>
	/// Passenger capacity on the plane
	/// </summary>
	public IWebElement FldsNpassage => throw new NotImplementedException();

	public FeecaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FEECA", containerLocator: containerLocator) { }
}

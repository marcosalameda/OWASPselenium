using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ManuaForm : Form
{
	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, ContainerLocator, "container-MANUA___KINDEDESIGNAT");
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "MANUA", "MANUA___KINDEDESIGNAT");

	/// <summary>
	/// Manual name
	/// </summary>
	public BaseInputControl ManuaName => new BaseInputControl(driver, ContainerLocator, "container-MANUA___MANUANAME____", "#MANUA___MANUANAME____");

	/// <summary>
	/// Digital document
	/// </summary>
	public DocumentControl ManuaDigdocum => new DocumentControl(driver, ContainerLocator, "MANUA___MANUADIGDOCUM");

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl ManuaNotes => new BaseInputControl(driver, ContainerLocator, "container-MANUA___MANUANOTES___", "#MANUA___MANUANOTES___");

	public ManuaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "MANUA", containerLocator: containerLocator) { }
}

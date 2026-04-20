using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ManuaForm : Form
{
	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, ContainerLocator, "container-MANUA___KINDEDESIGNAT" + IdSuffix);
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "MANUA", "MANUA___KINDEDESIGNAT" + IdSuffix);

	/// <summary>
	/// Manual name
	/// </summary>
	public BaseInputControl ManuaName => new BaseInputControl(driver, ContainerLocator, "container-MANUA___MANUANAME____" + IdSuffix, "#MANUA___MANUANAME____" + IdSuffix);

	/// <summary>
	/// Digital document
	/// </summary>
	public DocumentControl ManuaDigdocum => new DocumentControl(driver, ContainerLocator, "MANUA___MANUADIGDOCUM-container" + IdSuffix);

	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl ManuaNotes => new BaseInputControl(driver, ContainerLocator, "container-MANUA___MANUANOTES___" + IdSuffix, "#MANUA___MANUANOTES___" + IdSuffix);

	public ManuaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "MANUA", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

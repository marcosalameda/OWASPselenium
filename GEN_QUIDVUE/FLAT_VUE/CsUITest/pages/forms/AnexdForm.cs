using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AnexdForm : Form
{
	/// <summary>
	/// No. register
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-ANEXD___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "ANEXD", "ANEXD___EQUIPREGISTNR");

	/// <summary>
	/// Attached
	/// </summary>
	public DateInputControl AnexdDthranex => new DateInputControl(driver, ContainerLocator, "#ANEXD___ANEXDDTHRANEX", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Reference
	/// </summary>
	public BaseInputControl AnexdReferenc => new BaseInputControl(driver, ContainerLocator, "#ANEXD___ANEXDREFERENC");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl AnexdTitle => new BaseInputControl(driver, ContainerLocator, "#ANEXD___ANEXDTITLE___");

	/// <summary>
	/// Language
	/// </summary>
	public LookupControl LanguLangua => new LookupControl(driver, ContainerLocator, "container-ANEXD___LANGULANGUA__");
	public SeeMorePage LanguLanguaSeeMorePage => new SeeMorePage(driver, "ANEXD", "ANEXD___LANGULANGUA__");

	/// <summary>
	/// Translated Title
	/// </summary>
	public BaseInputControl AnexdTittradu => new BaseInputControl(driver, ContainerLocator, "#ANEXD___ANEXDTITTRADU");

	/// <summary>
	/// Document
	/// </summary>
	public DocumentControl AnexdDocument => new DocumentControl(driver, ContainerLocator, "container-ANEXD___ANEXDDOCUMENT");

	public AnexdForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "ANEXD", containerLocator: containerLocator) { }
}

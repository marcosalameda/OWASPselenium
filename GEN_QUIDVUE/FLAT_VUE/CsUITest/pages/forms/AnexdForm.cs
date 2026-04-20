using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AnexdForm : Form
{
	/// <summary>
	/// No. register
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-ANEXD___EQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "ANEXD", "ANEXD___EQUIPREGISTNR" + IdSuffix);

	/// <summary>
	/// Attached
	/// </summary>
	public DateInputControl AnexdDthranex => new DateInputControl(driver, ContainerLocator, "#ANEXD___ANEXDDTHRANEX" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Reference
	/// </summary>
	public BaseInputControl AnexdReferenc => new BaseInputControl(driver, ContainerLocator, "container-ANEXD___ANEXDREFERENC" + IdSuffix, "#ANEXD___ANEXDREFERENC" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl AnexdTitle => new BaseInputControl(driver, ContainerLocator, "container-ANEXD___ANEXDTITLE___" + IdSuffix, "#ANEXD___ANEXDTITLE___" + IdSuffix);

	/// <summary>
	/// Language
	/// </summary>
	public LookupControl LanguLangua => new LookupControl(driver, ContainerLocator, "container-ANEXD___LANGULANGUA__" + IdSuffix);
	public SeeMorePage LanguLanguaSeeMorePage => new SeeMorePage(driver, "ANEXD", "ANEXD___LANGULANGUA__" + IdSuffix);

	/// <summary>
	/// Translated Title
	/// </summary>
	public BaseInputControl AnexdTittradu => new BaseInputControl(driver, ContainerLocator, "container-ANEXD___ANEXDTITTRADU" + IdSuffix, "#ANEXD___ANEXDTITTRADU" + IdSuffix);

	/// <summary>
	/// Document
	/// </summary>
	public DocumentControl AnexdDocument => new DocumentControl(driver, ContainerLocator, "ANEXD___ANEXDDOCUMENT-container" + IdSuffix);

	public AnexdForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "ANEXD", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

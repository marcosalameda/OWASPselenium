using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DsaidForm : Form
{
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl Ware1Warehdes => new LookupControl(driver, ContainerLocator, "container-DSAID___WARE1WAREHDES");
	public SeeMorePage Ware1WarehdesSeeMorePage => new SeeMorePage(driver, "DSAID", "DSAID___WARE1WAREHDES");

	/// <summary>
	/// No:
	/// </summary>
	public BaseInputControl OutptDocumenr => new BaseInputControl(driver, ContainerLocator, "#DSAID___OUTPTDOCUMENR");

	/// <summary>
	/// Date:
	/// </summary>
	public DateInputControl OutptDhdocume => new DateInputControl(driver, ContainerLocator, "#DSAID___OUTPTDHDOCUME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Output:
	/// </summary>
	public ListControl PseudSaidas => new ListControl(driver, ContainerLocator, "#DSAID___PSEUDSAIDAS__");

	/// <summary>
	/// New Output
	/// </summary>
	public ButtonControl PseudSaida => new ButtonControl(driver, ContainerLocator, "#DSAID___PSEUDSAIDA___");

	public DsaidForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DSAID", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DentrForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-DENTR___CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "DENTR", "DENTR___CNTRYCOUNTRY_");

	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-DENTR___CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "DENTR", "DENTR___CMPNYDESIGNAT");

	/// <summary>
	/// Person
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-DENTR___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "DENTR", "DENTR___PESSONAME____");

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl Ware1Warehdes => new LookupControl(driver, ContainerLocator, "container-DENTR___WARE1WAREHDES");
	public SeeMorePage Ware1WarehdesSeeMorePage => new SeeMorePage(driver, "DENTR", "DENTR___WARE1WAREHDES");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl IndocDate => new DateInputControl(driver, ContainerLocator, "#DENTR___INDOCDATE____", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// No.
	/// </summary>
	public BaseInputControl IndocDocumenr => new BaseInputControl(driver, ContainerLocator, "container-DENTR___INDOCDOCUMENR", "#DENTR___INDOCDOCUMENR");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl IndocDhdocume => new DateInputControl(driver, ContainerLocator, "#DENTR___INDOCDHDOCUME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Entries
	/// </summary>
	public ListControl PseudEntradas => new ListControl(driver, ContainerLocator, "#DENTR___PSEUDENTRADAS");

	/// <summary>
	/// Normal Form
	/// </summary>
	public ButtonControl PseudNormal => new ButtonControl(driver, ContainerLocator, "#DENTR___PSEUDNORMAL__");

	public DentrForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DENTR", containerLocator: containerLocator) { }
}

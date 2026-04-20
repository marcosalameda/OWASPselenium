using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DentrForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-DENTR___CNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "DENTR", "DENTR___CNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-DENTR___CMPNYDESIGNAT" + IdSuffix);
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "DENTR", "DENTR___CMPNYDESIGNAT" + IdSuffix);

	/// <summary>
	/// Person
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-DENTR___PESSONAME____" + IdSuffix);
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "DENTR", "DENTR___PESSONAME____" + IdSuffix);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl Ware1Warehdes => new LookupControl(driver, ContainerLocator, "container-DENTR___WARE1WAREHDES" + IdSuffix);
	public SeeMorePage Ware1WarehdesSeeMorePage => new SeeMorePage(driver, "DENTR", "DENTR___WARE1WAREHDES" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl IndocDate => new DateInputControl(driver, ContainerLocator, "#DENTR___INDOCDATE____" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// No.
	/// </summary>
	public BaseInputControl IndocDocumenr => new BaseInputControl(driver, ContainerLocator, "container-DENTR___INDOCDOCUMENR" + IdSuffix, "#DENTR___INDOCDOCUMENR" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl IndocDhdocume => new DateInputControl(driver, ContainerLocator, "#DENTR___INDOCDHDOCUME" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Entries
	/// </summary>
	public ListControl PseudEntradas => new ListControl(driver, ContainerLocator, "#DENTR___PSEUDENTRADAS" + IdSuffix);

	/// <summary>
	/// Normal Form
	/// </summary>
	public ButtonControl PseudNormal => new ButtonControl(driver, ContainerLocator, "#DENTR___PSEUDNORMAL__" + IdSuffix);

	public DentrForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "DENTR", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

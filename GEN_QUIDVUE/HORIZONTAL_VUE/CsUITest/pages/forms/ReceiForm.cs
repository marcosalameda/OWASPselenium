using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ReceiForm : Form
{
	/// <summary>
	/// Receipt date
	/// </summary>
	public DateInputControl ReceiDtreceip => new DateInputControl(driver, ContainerLocator, "#RECEI___RECEIDTRECEIP" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Receipt number
	/// </summary>
	public BaseInputControl ReceiNumber => new BaseInputControl(driver, ContainerLocator, "container-RECEI___RECEINUMBER__" + IdSuffix, "#RECEI___RECEINUMBER__" + IdSuffix);

	/// <summary>
	/// Suplier
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-RECEI___ENTITNAME____" + IdSuffix);
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "RECEI", "RECEI___ENTITNAME____" + IdSuffix);

	/// <summary>
	/// Receipt lines
	/// </summary>
	public ListControl PseudReceiptl => new ListControl(driver, ContainerLocator, "#RECEI___PSEUDRECEIPTL" + IdSuffix);

	/// <summary>
	/// Receipt verification
	/// </summary>
	public DateInputControl ReceiDtcheck => new DateInputControl(driver, ContainerLocator, "#RECEI___RECEIDTCHECK_" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// To check
	/// </summary>
	public CheckboxInputControl ReceiTocheck => new CheckboxInputControl(driver, ContainerLocator, "#container-RECEI___RECEITOCHECK_" + IdSuffix);

	/// <summary>
	/// Checked
	/// </summary>
	public CheckboxInputControl ReceiChecked => new CheckboxInputControl(driver, ContainerLocator, "#container-RECEI___RECEICHECKED_" + IdSuffix);

	/// <summary>
	/// Stored
	/// </summary>
	public CheckboxInputControl ReceiStored => new CheckboxInputControl(driver, ContainerLocator, "#container-RECEI___RECEISTORED__" + IdSuffix);

	/// <summary>
	/// Storage date
	/// </summary>
	public DateInputControl ReceiDtstorag => new DateInputControl(driver, ContainerLocator, "#RECEI___RECEIDTSTORAG" + IdSuffix, "dd/MM/yyyy HH:mm");

	public ReceiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "RECEI", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

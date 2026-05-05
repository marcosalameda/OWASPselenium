using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpequForm : Form
{
	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR01-container");

	/// <summary>
	/// Equipment family
	/// </summary>
	public LookupControl FamilFamily => new LookupControl(driver, ContainerLocator, "container-TPEQU___FAMILFAMILY__");
	public SeeMorePage FamilFamilySeeMorePage => new SeeMorePage(driver, "TPEQU", "TPEQU___FAMILFAMILY__");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public BaseInputControl TpequTipoequi => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUTIPOEQUI", "#TPEQU___TPEQUTIPOEQUI");

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl TpequTpequcod => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUTPEQUCOD", "#TPEQU___TPEQUTPEQUCOD");

	/// <summary>
	/// Level:
	/// </summary>
	public BaseInputControl TpequNivel => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUNIVEL___", "#TPEQU___TPEQUNIVEL___");

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// SET
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR04-container");

	/// <summary>
	/// Kit
	/// </summary>
	public CheckboxInputControl TpequKit => new CheckboxInputControl(driver, ContainerLocator, "#container-TPEQU___TPEQUKIT_____");

	/// <summary>
	/// Maximum Price
	/// </summary>
	public BaseInputControl TpequPrecomax => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUPRECOMAX", "#TPEQU___TPEQUPRECOMAX");

	/// <summary>
	/// Background Color
	/// </summary>
	public BaseInputControl TpequBackcolo => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUBACKCOLO", "#TPEQU___TPEQUBACKCOLO");

	/// <summary>
	/// Letter Color
	/// </summary>
	public BaseInputControl TpequCorletra => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUCORLETRA", "#TPEQU___TPEQUCORLETRA");

	/// <summary>
	/// Dependence on
	/// </summary>
	public BaseInputControl TpequTpequpai => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUTPEQUPAI", "#TPEQU___TPEQUTPEQUPAI");

	/// <summary>
	/// Last Price
	/// </summary>
	public BaseInputControl TpequPrecoult => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUPRECOULT", "#TPEQU___TPEQUPRECOULT");

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl TpequSince => new DateInputControl(driver, ContainerLocator, "#TPEQU___TPEQUSINCE___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Componentes do kit
	/// </summary>
	public ListControl PseudComponen => new ListControl(driver, ContainerLocator, "#TPEQU___PSEUDCOMPONEN");

	/// <summary>
	/// PRICES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR03-container");

	/// <summary>
	/// c
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, ContainerLocator, "#TPEQU___PSEUDEVOLUCAO");

	/// <summary>
	/// HIGHLIGHT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR02-container");

	/// <summary>
	/// Unique
	/// </summary>
	public ButtonControl PseudUnico => new ButtonControl(driver, ContainerLocator, "#TPEQU___PSEUDUNICO___");

	/// <summary>
	/// FACILITIES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR06-container");

	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, ContainerLocator, "#TPEQU___PSEUDINSTALAC");

	/// <summary>
	/// Map with facilities:
	/// </summary>
	public ListControl PseudInstala1 => new ListControl(driver, ContainerLocator, "#TPEQU___PSEUDINSTALA1");

	/// <summary>
	/// Quantity of equipment:
	/// </summary>
	public BaseInputControl TpequQtdequip => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUQTDEQUIP", "#TPEQU___TPEQUQTDEQUIP");

	public TpequForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TPEQU", containerLocator: containerLocator) { }
}

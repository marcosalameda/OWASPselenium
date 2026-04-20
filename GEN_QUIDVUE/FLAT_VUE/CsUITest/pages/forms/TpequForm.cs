using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpequForm : Form
{
	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Equipment family
	/// </summary>
	public LookupControl FamilFamily => new LookupControl(driver, ContainerLocator, "container-TPEQU___FAMILFAMILY__" + IdSuffix);
	public SeeMorePage FamilFamilySeeMorePage => new SeeMorePage(driver, "TPEQU", "TPEQU___FAMILFAMILY__" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public BaseInputControl TpequTipoequi => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUTIPOEQUI" + IdSuffix, "#TPEQU___TPEQUTIPOEQUI" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl TpequTpequcod => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUTPEQUCOD" + IdSuffix, "#TPEQU___TPEQUTPEQUCOD" + IdSuffix);

	/// <summary>
	/// Level:
	/// </summary>
	public BaseInputControl TpequNivel => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUNIVEL___" + IdSuffix, "#TPEQU___TPEQUNIVEL___" + IdSuffix);

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();

	/// <summary>
	/// SET
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Kit
	/// </summary>
	public CheckboxInputControl TpequKit => new CheckboxInputControl(driver, ContainerLocator, "#container-TPEQU___TPEQUKIT_____" + IdSuffix);

	/// <summary>
	/// Maximum Price
	/// </summary>
	public BaseInputControl TpequPrecomax => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUPRECOMAX" + IdSuffix, "#TPEQU___TPEQUPRECOMAX" + IdSuffix);

	/// <summary>
	/// Background Color
	/// </summary>
	public BaseInputControl TpequBackcolo => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUBACKCOLO" + IdSuffix, "#TPEQU___TPEQUBACKCOLO" + IdSuffix);

	/// <summary>
	/// Letter Color
	/// </summary>
	public BaseInputControl TpequCorletra => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUCORLETRA" + IdSuffix, "#TPEQU___TPEQUCORLETRA" + IdSuffix);

	/// <summary>
	/// Dependence on
	/// </summary>
	public BaseInputControl TpequTpequpai => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUTPEQUPAI" + IdSuffix, "#TPEQU___TPEQUTPEQUPAI" + IdSuffix);

	/// <summary>
	/// Last Price
	/// </summary>
	public BaseInputControl TpequPrecoult => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUPRECOULT" + IdSuffix, "#TPEQU___TPEQUPRECOULT" + IdSuffix);

	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl TpequSince => new DateInputControl(driver, ContainerLocator, "#TPEQU___TPEQUSINCE___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Componentes do kit
	/// </summary>
	public ListControl PseudComponen => new ListControl(driver, ContainerLocator, "#TPEQU___PSEUDCOMPONEN" + IdSuffix);

	/// <summary>
	/// PRICES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// c
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, ContainerLocator, "#TPEQU___PSEUDEVOLUCAO" + IdSuffix);

	/// <summary>
	/// HIGHLIGHT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Unique
	/// </summary>
	public ButtonControl PseudUnico => new ButtonControl(driver, ContainerLocator, "#TPEQU___PSEUDUNICO___" + IdSuffix);

	/// <summary>
	/// FACILITIES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#TPEQU___PSEUDNOVOGR06" + IdSuffix + "-container");

	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, ContainerLocator, "#TPEQU___PSEUDINSTALAC" + IdSuffix);

	/// <summary>
	/// Map with facilities:
	/// </summary>
	public ListControl PseudInstala1 => new ListControl(driver, ContainerLocator, "#TPEQU___PSEUDINSTALA1" + IdSuffix);

	/// <summary>
	/// Quantity of equipment:
	/// </summary>
	public BaseInputControl TpequQtdequip => new BaseInputControl(driver, ContainerLocator, "container-TPEQU___TPEQUQTDEQUIP" + IdSuffix, "#TPEQU___TPEQUQTDEQUIP" + IdSuffix);

	public TpequForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "TPEQU", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

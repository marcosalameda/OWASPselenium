using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Tpeq1Form : Form
{
	/// <summary>
	/// Equipment family
	/// </summary>
	public LookupControl Fami1Family => new LookupControl(driver, ContainerLocator, "container-TPEQ1___FAMI1FAMILY__" + IdSuffix);
	public SeeMorePage Fami1FamilySeeMorePage => new SeeMorePage(driver, "TPEQ1", "TPEQ1___FAMI1FAMILY__" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl Tpeq1Tpequcod => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1TPEQUCOD" + IdSuffix, "#TPEQ1___TPEQ1TPEQUCOD" + IdSuffix);

	/// <summary>
	/// Level:
	/// </summary>
	public BaseInputControl Tpeq1Nivel => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1NIVEL___" + IdSuffix, "#TPEQ1___TPEQ1NIVEL___" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public BaseInputControl Tpeq1Tipoequi => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1TIPOEQUI" + IdSuffix, "#TPEQ1___TPEQ1TIPOEQUI" + IdSuffix);

	/// <summary>
	/// Dependence on
	/// </summary>
	public BaseInputControl Tpeq1Tpequpai => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1TPEQUPAI" + IdSuffix, "#TPEQ1___TPEQ1TPEQUPAI" + IdSuffix);

	/// <summary>
	/// Background Color
	/// </summary>
	public BaseInputControl Tpeq1Backcolo => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1BACKCOLO" + IdSuffix, "#TPEQ1___TPEQ1BACKCOLO" + IdSuffix);

	/// <summary>
	/// Letter Color:
	/// </summary>
	public BaseInputControl Tpeq1Corletra => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1CORLETRA" + IdSuffix, "#TPEQ1___TPEQ1CORLETRA" + IdSuffix);

	/// <summary>
	/// Maximum Price
	/// </summary>
	public BaseInputControl Tpeq1Precomax => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1PRECOMAX" + IdSuffix, "#TPEQ1___TPEQ1PRECOMAX" + IdSuffix);

	/// <summary>
	/// Last price
	/// </summary>
	public BaseInputControl Tpeq1Precoult => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1PRECOULT" + IdSuffix, "#TPEQ1___TPEQ1PRECOULT" + IdSuffix);

	/// <summary>
	/// In
	/// </summary>
	public DateInputControl Tpeq1Since => new DateInputControl(driver, ContainerLocator, "#TPEQ1___TPEQ1SINCE___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl Tpeq1Qtdequip => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1QTDEQUIP" + IdSuffix, "#TPEQ1___TPEQ1QTDEQUIP" + IdSuffix);

	/// <summary>
	/// Kit
	/// </summary>
	public CheckboxInputControl Tpeq1Kit => new CheckboxInputControl(driver, ContainerLocator, "#container-TPEQ1___TPEQ1KIT_____" + IdSuffix);

	public Tpeq1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "TPEQ1", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

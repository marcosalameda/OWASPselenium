using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Tpeq1Form : Form
{
	/// <summary>
	/// Equipment family
	/// </summary>
	public LookupControl Fami1Family => new LookupControl(driver, ContainerLocator, "container-TPEQ1___FAMI1FAMILY__");
	public SeeMorePage Fami1FamilySeeMorePage => new SeeMorePage(driver, "TPEQ1", "TPEQ1___FAMI1FAMILY__");

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl Tpeq1Tpequcod => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1TPEQUCOD", "#TPEQ1___TPEQ1TPEQUCOD");

	/// <summary>
	/// Level:
	/// </summary>
	public BaseInputControl Tpeq1Nivel => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1NIVEL___", "#TPEQ1___TPEQ1NIVEL___");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public BaseInputControl Tpeq1Tipoequi => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1TIPOEQUI", "#TPEQ1___TPEQ1TIPOEQUI");

	/// <summary>
	/// Dependence on
	/// </summary>
	public BaseInputControl Tpeq1Tpequpai => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1TPEQUPAI", "#TPEQ1___TPEQ1TPEQUPAI");

	/// <summary>
	/// Background Color
	/// </summary>
	public BaseInputControl Tpeq1Backcolo => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1BACKCOLO", "#TPEQ1___TPEQ1BACKCOLO");

	/// <summary>
	/// Letter Color:
	/// </summary>
	public BaseInputControl Tpeq1Corletra => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1CORLETRA", "#TPEQ1___TPEQ1CORLETRA");

	/// <summary>
	/// Maximum Price
	/// </summary>
	public BaseInputControl Tpeq1Precomax => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1PRECOMAX", "#TPEQ1___TPEQ1PRECOMAX");

	/// <summary>
	/// Last price
	/// </summary>
	public BaseInputControl Tpeq1Precoult => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1PRECOULT", "#TPEQ1___TPEQ1PRECOULT");

	/// <summary>
	/// In
	/// </summary>
	public DateInputControl Tpeq1Since => new DateInputControl(driver, ContainerLocator, "#TPEQ1___TPEQ1SINCE___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl Tpeq1Qtdequip => new BaseInputControl(driver, ContainerLocator, "container-TPEQ1___TPEQ1QTDEQUIP", "#TPEQ1___TPEQ1QTDEQUIP");

	/// <summary>
	/// Kit
	/// </summary>
	public CheckboxInputControl Tpeq1Kit => new CheckboxInputControl(driver, ContainerLocator, "#container-TPEQ1___TPEQ1KIT_____");

	public Tpeq1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TPEQ1", containerLocator: containerLocator) { }
}

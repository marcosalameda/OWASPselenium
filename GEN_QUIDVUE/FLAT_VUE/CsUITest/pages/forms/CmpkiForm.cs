using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CmpkiForm : Form
{
	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-CMPKI___TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "CMPKI", "CMPKI___TPEQUTIPOEQUI");

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl CmpkiOrder => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKIORDER___", "#CMPKI___CMPKIORDER___");

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl Tpeq1Tipoequi => new LookupControl(driver, ContainerLocator, "container-CMPKI___TPEQ1TIPOEQUI");
	public SeeMorePage Tpeq1TipoequiSeeMorePage => new SeeMorePage(driver, "CMPKI", "CMPKI___TPEQ1TIPOEQUI");

	/// <summary>
	/// Quantity:
	/// </summary>
	public BaseInputControl CmpkiQuantida => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKIQUANTIDA", "#CMPKI___CMPKIQUANTIDA");

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl CmpkiCode => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKICODE____", "#CMPKI___CMPKICODE____");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CmpkiDescript => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKIDESCRIPT", "#CMPKI___CMPKIDESCRIPT");

	/// <summary>
	/// Site
	/// </summary>
	public BaseInputControl CmpkiUrl => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKIURL_____", "#CMPKI___CMPKIURL_____");

	public CmpkiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CMPKI", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CmpkiForm : Form
{
	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-CMPKI___TPEQUTIPOEQUI" + IdSuffix);
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "CMPKI", "CMPKI___TPEQUTIPOEQUI" + IdSuffix);

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl CmpkiOrder => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKIORDER___" + IdSuffix, "#CMPKI___CMPKIORDER___" + IdSuffix);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl Tpeq1Tipoequi => new LookupControl(driver, ContainerLocator, "container-CMPKI___TPEQ1TIPOEQUI" + IdSuffix);
	public SeeMorePage Tpeq1TipoequiSeeMorePage => new SeeMorePage(driver, "CMPKI", "CMPKI___TPEQ1TIPOEQUI" + IdSuffix);

	/// <summary>
	/// Quantity:
	/// </summary>
	public BaseInputControl CmpkiQuantida => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKIQUANTIDA" + IdSuffix, "#CMPKI___CMPKIQUANTIDA" + IdSuffix);

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl CmpkiCode => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKICODE____" + IdSuffix, "#CMPKI___CMPKICODE____" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CmpkiDescript => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKIDESCRIPT" + IdSuffix, "#CMPKI___CMPKIDESCRIPT" + IdSuffix);

	/// <summary>
	/// Site
	/// </summary>
	public BaseInputControl CmpkiUrl => new BaseInputControl(driver, ContainerLocator, "container-CMPKI___CMPKIURL_____" + IdSuffix, "#CMPKI___CMPKIURL_____" + IdSuffix);

	public CmpkiForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CMPKI", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

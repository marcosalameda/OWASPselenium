using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamnumForm : Subform
{
	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_NPASSAGE" + IdSuffix, "#CAMNUM__FLDS_NPASSAGE" + IdSuffix);

	/// <summary>
	/// Numeric Decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_DURATION" + IdSuffix, "#CAMNUM__FLDS_DURATION" + IdSuffix);

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_PRICE___" + IdSuffix, "#CAMNUM__FLDS_PRICE___" + IdSuffix);

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_PRECOBIL" + IdSuffix, "#CAMNUM__FLDS_PRECOBIL" + IdSuffix);

	public CamnumForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CAMNUM", "LISTACAM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamnumForm : Subform
{
	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_NPASSAGE", "#CAMNUM__FLDS_NPASSAGE");

	/// <summary>
	/// Numeric Decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_DURATION", "#CAMNUM__FLDS_DURATION");

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_PRICE___", "#CAMNUM__FLDS_PRICE___");

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_PRECOBIL", "#CAMNUM__FLDS_PRECOBIL");

	public CamnumForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CAMNUM", "LISTACAM", containerLocator: containerLocator) { }
}

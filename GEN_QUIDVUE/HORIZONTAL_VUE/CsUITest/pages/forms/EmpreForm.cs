using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EmpreForm : PopupForm
{
	/// <summary>
	/// Logo
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#EMPRE___PSEUDNOVOGR02-container");

	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl CmpnyLogo => new BaseInputControl(driver, ContainerLocator, "#EMPRE___CMPNYLOGO____");

	/// <summary>
	/// Company
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EMPRE___PSEUDNOVOGR01-container");

	/// <summary>
	/// Designation
	/// </summary>
	public BaseInputControl CmpnyDesignat => new BaseInputControl(driver, ContainerLocator, "#EMPRE___CMPNYDESIGNAT");

	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl CmpnyAcronym => new BaseInputControl(driver, ContainerLocator, "#EMPRE___CMPNYACRONYM_");

	/// <summary>
	/// Tax identification:
	/// </summary>
	public BaseInputControl CmpnyNif => new BaseInputControl(driver, ContainerLocator, "#EMPRE___CMPNYNIF_____");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl CmpnyTelephon => new BaseInputControl(driver, ContainerLocator, "#EMPRE___CMPNYTELEPHON");

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl CmpnyEmail => new BaseInputControl(driver, ContainerLocator, "#EMPRE___CMPNYEMAIL___");

	/// <summary>
	/// Origin
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#EMPRE___PSEUDNOVOGR03-container");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-EMPRE___CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "EMPRE", "EMPRE___CNTRYCOUNTRY_");

	/// <summary>
	/// Quantity of people
	/// </summary>
	public BaseInputControl CmpnyQtdpesso => new BaseInputControl(driver, ContainerLocator, "#EMPRE___CMPNYQTDPESSO");

	/// <summary>
	/// Headquarter location
	/// </summary>
	public BaseInputControl CmpnyHeadloc => new BaseInputControl(driver, ContainerLocator, "#EMPRE___CMPNYHEADLOC_");

	public EmpreForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EMPRE") { }
}

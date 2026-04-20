using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EmpreForm : PopupForm
{
	/// <summary>
	/// Logo
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#EMPRE___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl CmpnyLogo => new BaseInputControl(driver, ContainerLocator, "container-EMPRE___CMPNYLOGO____" + IdSuffix, "#EMPRE___CMPNYLOGO____" + IdSuffix);

	/// <summary>
	/// Company
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EMPRE___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Designation
	/// </summary>
	public BaseInputControl CmpnyDesignat => new BaseInputControl(driver, ContainerLocator, "container-EMPRE___CMPNYDESIGNAT" + IdSuffix, "#EMPRE___CMPNYDESIGNAT" + IdSuffix);

	/// <summary>
	/// Acronym
	/// </summary>
	public BaseInputControl CmpnyAcronym => new BaseInputControl(driver, ContainerLocator, "container-EMPRE___CMPNYACRONYM_" + IdSuffix, "#EMPRE___CMPNYACRONYM_" + IdSuffix);

	/// <summary>
	/// Tax identification:
	/// </summary>
	public BaseInputControl CmpnyNif => new BaseInputControl(driver, ContainerLocator, "container-EMPRE___CMPNYNIF_____" + IdSuffix, "#EMPRE___CMPNYNIF_____" + IdSuffix);

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl CmpnyTelephon => new BaseInputControl(driver, ContainerLocator, "container-EMPRE___CMPNYTELEPHON" + IdSuffix, "#EMPRE___CMPNYTELEPHON" + IdSuffix);

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl CmpnyEmail => new BaseInputControl(driver, ContainerLocator, "container-EMPRE___CMPNYEMAIL___" + IdSuffix, "#EMPRE___CMPNYEMAIL___" + IdSuffix);

	/// <summary>
	/// Origin
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#EMPRE___PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-EMPRE___CNTRYCOUNTRY_" + IdSuffix);
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "EMPRE", "EMPRE___CNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Quantity of people
	/// </summary>
	public BaseInputControl CmpnyQtdpesso => new BaseInputControl(driver, ContainerLocator, "container-EMPRE___CMPNYQTDPESSO" + IdSuffix, "#EMPRE___CMPNYQTDPESSO" + IdSuffix);

	/// <summary>
	/// Headquarter location
	/// </summary>
	public BaseInputControl CmpnyHeadloc => new BaseInputControl(driver, ContainerLocator, "container-EMPRE___CMPNYHEADLOC_" + IdSuffix, "#EMPRE___CMPNYHEADLOC_" + IdSuffix);

	public EmpreForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "EMPRE", usePkInId: usePkInId) { }
}

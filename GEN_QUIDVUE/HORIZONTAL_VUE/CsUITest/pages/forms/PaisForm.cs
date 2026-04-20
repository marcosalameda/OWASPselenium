using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PaisForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PAIS____PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl CntryCountry => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYCOUNTRY_" + IdSuffix, "#PAIS____CNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Active
	/// </summary>
	public CheckboxInputControl CntryActive => new CheckboxInputControl(driver, ContainerLocator, "#container-PAIS____CNTRYACTIVE__" + IdSuffix);

	/// <summary>
	/// Country code
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PAIS____PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CntryCodigonr => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYCODIGONR" + IdSuffix, "#PAIS____CNTRYCODIGONR" + IdSuffix);

	/// <summary>
	/// Alphabetic 2:
	/// </summary>
	public BaseInputControl CntryAlfa2 => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYALFA2___" + IdSuffix, "#PAIS____CNTRYALFA2___" + IdSuffix);

	/// <summary>
	/// Alphabetic 3:
	/// </summary>
	public BaseInputControl CntryAlfa3 => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYALFA3___" + IdSuffix, "#PAIS____CNTRYALFA3___" + IdSuffix);

	/// <summary>
	/// Bandeira
	/// </summary>
	public BaseInputControl CntryFlag => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYFLAG____" + IdSuffix, "#PAIS____CNTRYFLAG____" + IdSuffix);

	/// <summary>
	/// real estate
	/// </summary>
	public Propr00Form  PseudImovel => new Propr00Form(driver, FORM_MODE.EDIT, By.Id("PAIS____PSEUDIMOVEL__"), usePkInId: true);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PAIS____PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PAIS____PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Real Estate List
	/// </summary>
	public ListControl PseudProprie1 => new ListControl(driver, ContainerLocator, "#PAIS____PSEUDPROPRIE1" + IdSuffix);

	/// <summary>
	/// Real State Map
	/// </summary>
	public ListControl PseudPropried => new ListControl(driver, ContainerLocator, "#PAIS____PSEUDPROPRIED" + IdSuffix);

	public PaisForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PAIS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PaisForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PAIS____PSEUDNOVOGR02-container");

	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl CntryCountry => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYCOUNTRY_", "#PAIS____CNTRYCOUNTRY_");

	/// <summary>
	/// Active
	/// </summary>
	public CheckboxInputControl CntryActive => new CheckboxInputControl(driver, ContainerLocator, "#container-PAIS____CNTRYACTIVE__");

	/// <summary>
	/// Country code
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PAIS____PSEUDNOVOGR01-container");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CntryCodigonr => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYCODIGONR", "#PAIS____CNTRYCODIGONR");

	/// <summary>
	/// Alphabetic 2:
	/// </summary>
	public BaseInputControl CntryAlfa2 => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYALFA2___", "#PAIS____CNTRYALFA2___");

	/// <summary>
	/// Alphabetic 3:
	/// </summary>
	public BaseInputControl CntryAlfa3 => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYALFA3___", "#PAIS____CNTRYALFA3___");

	/// <summary>
	/// Bandeira
	/// </summary>
	public BaseInputControl CntryFlag => new BaseInputControl(driver, ContainerLocator, "container-PAIS____CNTRYFLAG____", "#PAIS____CNTRYFLAG____");

	/// <summary>
	/// real estate
	/// </summary>
	public Propr00Form  PseudImovel => new Propr00Form(driver, FORM_MODE.EDIT, By.Id("PAIS____PSEUDIMOVEL__"));

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PAIS____PSEUDNOVOGR04-container");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PAIS____PSEUDNOVOGR03-container");

	/// <summary>
	/// Real Estate List
	/// </summary>
	public ListControl PseudProprie1 => new ListControl(driver, ContainerLocator, "#PAIS____PSEUDPROPRIE1");

	/// <summary>
	/// Real State Map
	/// </summary>
	public ListControl PseudPropried => new ListControl(driver, ContainerLocator, "#PAIS____PSEUDPROPRIED");

	public PaisForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PAIS", containerLocator: containerLocator) { }
}

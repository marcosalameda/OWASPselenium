using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProppaisForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPPAISPSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl CntryCountry => new BaseInputControl(driver, ContainerLocator, "container-PROPPAISCNTRYCOUNTRY_" + IdSuffix, "#PROPPAISCNTRYCOUNTRY_" + IdSuffix);

	/// <summary>
	/// Active
	/// </summary>
	public CheckboxInputControl CntryActive => new CheckboxInputControl(driver, ContainerLocator, "#container-PROPPAISCNTRYACTIVE__" + IdSuffix);

	/// <summary>
	/// Country code
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPPAISPSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CntryCodigonr => new BaseInputControl(driver, ContainerLocator, "container-PROPPAISCNTRYCODIGONR" + IdSuffix, "#PROPPAISCNTRYCODIGONR" + IdSuffix);

	/// <summary>
	/// Alphabetic 2:
	/// </summary>
	public BaseInputControl CntryAlfa2 => new BaseInputControl(driver, ContainerLocator, "container-PROPPAISCNTRYALFA2___" + IdSuffix, "#PROPPAISCNTRYALFA2___" + IdSuffix);

	/// <summary>
	/// Alphabetic 3:
	/// </summary>
	public BaseInputControl CntryAlfa3 => new BaseInputControl(driver, ContainerLocator, "container-PROPPAISCNTRYALFA3___" + IdSuffix, "#PROPPAISCNTRYALFA3___" + IdSuffix);

	/// <summary>
	/// Properties
	/// </summary>
	public IWebElement PseudPropried => throw new NotImplementedException();

	public ProppaisForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPPAIS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

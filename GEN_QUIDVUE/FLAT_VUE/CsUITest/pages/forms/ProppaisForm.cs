using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProppaisForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPPAISPSEUDNOVOGR02-container");

	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl CntryCountry => new BaseInputControl(driver, ContainerLocator, "#PROPPAISCNTRYCOUNTRY_");

	/// <summary>
	/// Active
	/// </summary>
	public CheckboxInputControl CntryActive => new CheckboxInputControl(driver, ContainerLocator, "#container-PROPPAISCNTRYACTIVE__");

	/// <summary>
	/// Country code
	/// </summary>
	public IWebElement PseudNovogr01 => throw new NotImplementedException();

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CntryCodigonr => new BaseInputControl(driver, ContainerLocator, "#PROPPAISCNTRYCODIGONR");

	/// <summary>
	/// Alphabetic 2:
	/// </summary>
	public BaseInputControl CntryAlfa2 => new BaseInputControl(driver, ContainerLocator, "#PROPPAISCNTRYALFA2___");

	/// <summary>
	/// Alphabetic 3:
	/// </summary>
	public BaseInputControl CntryAlfa3 => new BaseInputControl(driver, ContainerLocator, "#PROPPAISCNTRYALFA3___");

	/// <summary>
	/// Properties
	/// </summary>
	public IWebElement PseudPropried => throw new NotImplementedException();

	public ProppaisForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROPPAIS", containerLocator: containerLocator) { }
}

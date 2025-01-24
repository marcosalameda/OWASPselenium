using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegisForm : Form
{
	/// <summary>
	/// REGISTRATION IN THE PLATFORM
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#REGIS___PSEUDNOVOGR01-container");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl RegisName => new BaseInputControl(driver, ContainerLocator, "#REGIS___REGISNAME____");

	/// <summary>
	/// Tax ID No:
	/// </summary>
	public BaseInputControl RegisNif => new BaseInputControl(driver, ContainerLocator, "#REGIS___REGISNIF_____");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl RegisTelephon => new BaseInputControl(driver, ContainerLocator, "#REGIS___REGISTELEPHON");

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl RegisEmail1 => new BaseInputControl(driver, ContainerLocator, "#REGIS___REGISEMAIL1__");

	/// <summary>
	/// Alternative Email
	/// </summary>
	public BaseInputControl RegisEmail2 => new BaseInputControl(driver, ContainerLocator, "#REGIS___REGISEMAIL2__");

	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();

	public RegisForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "REGIS", containerLocator: containerLocator) { }
}

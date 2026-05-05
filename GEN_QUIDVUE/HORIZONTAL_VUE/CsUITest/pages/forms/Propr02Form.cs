using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr02Form : Subform
{
	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl ProprQtd_wc => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRQTD_WC__", "#PROPR02_PROPRQTD_WC__");

	/// <summary>
	/// Quartos
	/// </summary>
	public BaseInputControl ProprQtdquart => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRQTDQUART", "#PROPR02_PROPRQTDQUART");

	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl ProprM2 => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRM2______", "#PROPR02_PROPRM2______");

	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl ProprDtdispon => new DateInputControl(driver, ContainerLocator, "#PROPR02_PROPRDTDISPON");

	public Propr02Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROPR02", "PROPR00", containerLocator: containerLocator) { }
}

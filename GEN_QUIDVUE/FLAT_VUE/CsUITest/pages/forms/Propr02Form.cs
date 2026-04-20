using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr02Form : Subform
{
	/// <summary>
	/// Bathroom
	/// </summary>
	public BaseInputControl ProprQtd_wc => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRQTD_WC__" + IdSuffix, "#PROPR02_PROPRQTD_WC__" + IdSuffix);

	/// <summary>
	/// Quartos
	/// </summary>
	public BaseInputControl ProprQtdquart => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRQTDQUART" + IdSuffix, "#PROPR02_PROPRQTDQUART" + IdSuffix);

	/// <summary>
	/// Square meters
	/// </summary>
	public BaseInputControl ProprM2 => new BaseInputControl(driver, ContainerLocator, "container-PROPR02_PROPRM2______" + IdSuffix, "#PROPR02_PROPRM2______" + IdSuffix);

	/// <summary>
	/// Available from
	/// </summary>
	public DateInputControl ProprDtdispon => new DateInputControl(driver, ContainerLocator, "#PROPR02_PROPRDTDISPON" + IdSuffix);

	public Propr02Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPR02", "PROPR00", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

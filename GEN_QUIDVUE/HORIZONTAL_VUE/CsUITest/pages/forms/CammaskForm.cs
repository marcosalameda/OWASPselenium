using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CammaskForm : Subform
{
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_ZIPFIELD", "#CAMMASK_FLDS_ZIPFIELD");

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_VATNUMBR", "#CAMMASK_FLDS_VATNUMBR");

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_LICPLATE", "#CAMMASK_FLDS_LICPLATE");

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_SSNUMBER", "#CAMMASK_FLDS_SSNUMBER");

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_BANKNMBR", "#CAMMASK_FLDS_BANKNMBR");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_EMAILFLD", "#CAMMASK_FLDS_EMAILFLD");

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_IBANFIEL", "#CAMMASK_FLDS_IBANFIEL");

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_UPPRTEXT", "#CAMMASK_FLDS_UPPRTEXT");

	public CammaskForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CAMMASK", "LISTACAM", containerLocator: containerLocator) { }
}

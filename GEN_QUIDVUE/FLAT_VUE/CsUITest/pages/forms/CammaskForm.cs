using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CammaskForm : Subform
{
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_ZIPFIELD" + IdSuffix, "#CAMMASK_FLDS_ZIPFIELD" + IdSuffix);

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_VATNUMBR" + IdSuffix, "#CAMMASK_FLDS_VATNUMBR" + IdSuffix);

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_LICPLATE" + IdSuffix, "#CAMMASK_FLDS_LICPLATE" + IdSuffix);

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_SSNUMBER" + IdSuffix, "#CAMMASK_FLDS_SSNUMBER" + IdSuffix);

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_BANKNMBR" + IdSuffix, "#CAMMASK_FLDS_BANKNMBR" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_EMAILFLD" + IdSuffix, "#CAMMASK_FLDS_EMAILFLD" + IdSuffix);

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_IBANFIEL" + IdSuffix, "#CAMMASK_FLDS_IBANFIEL" + IdSuffix);

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_UPPRTEXT" + IdSuffix, "#CAMMASK_FLDS_UPPRTEXT" + IdSuffix);

	public CammaskForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "CAMMASK", "LISTACAM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

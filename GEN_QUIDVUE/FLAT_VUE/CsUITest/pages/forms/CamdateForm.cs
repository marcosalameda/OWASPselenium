using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamdateForm : Subform
{
	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, ContainerLocator, "container-CAMDATE_FLDS_YEAR____", "#CAMDATE_FLDS_YEAR____");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATE____");

	/// <summary>
	/// Date Time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATETIME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date seconds
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, ContainerLocator, "container-CAMDATE_FLDS_TIME____", "#CAMDATE_FLDS_TIME____");

	public CamdateForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CAMDATE", "LISTACAM", containerLocator: containerLocator) { }
}

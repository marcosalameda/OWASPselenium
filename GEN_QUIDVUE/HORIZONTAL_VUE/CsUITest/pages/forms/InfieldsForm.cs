using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InfieldsForm : Form
{
	/// <summary>
	/// Text inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR02-container");

	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl FldsTxtfield => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_TXTFIELD", "#INFIELDSFLDS_TXTFIELD");

	/// <summary>
	/// Multine Text
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_DESCRIP_", "#INFIELDSFLDS_DESCRIP_");

	/// <summary>
	/// Date/Time Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR01-container");

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_YEAR____", "#INFIELDSFLDS_YEAR____");

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_TIME____", "#INFIELDSFLDS_TIME____");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, ContainerLocator, "#INFIELDSFLDS_DATE____");

	/// <summary>
	/// Date time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, ContainerLocator, "#INFIELDSFLDS_DATETIME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date second
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, ContainerLocator, "#INFIELDSFLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_NPASSAGE", "#INFIELDSFLDS_NPASSAGE");

	/// <summary>
	/// Numeric decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_DURATION", "#INFIELDSFLDS_DURATION");

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_PRECOBIL", "#INFIELDSFLDS_PRECOBIL");

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_PRICE___", "#INFIELDSFLDS_PRICE___");

	/// <summary>
	/// Inputs with Masks
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR04-container");

	/// <summary>
	/// Numeric Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR03-container");

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_SSNUMBER", "#INFIELDSFLDS_SSNUMBER");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_ZIPFIELD", "#INFIELDSFLDS_ZIPFIELD");

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_VATNUMBR", "#INFIELDSFLDS_VATNUMBR");

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_LICPLATE", "#INFIELDSFLDS_LICPLATE");

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_BANKNMBR", "#INFIELDSFLDS_BANKNMBR");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_EMAILFLD", "#INFIELDSFLDS_EMAILFLD");

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_IBANFIEL", "#INFIELDSFLDS_IBANFIEL");

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_UPPRTEXT", "#INFIELDSFLDS_UPPRTEXT");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR05-container");

	/// <summary>
	/// Password
	/// </summary>
	public IWebElement FldsPassfld => throw new NotImplementedException();

	/// <summary>
	/// Colorpicker
	/// </summary>
	public BaseInputControl FldsClrpicke => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CLRPICKE", "#INFIELDSFLDS_CLRPICKE");

	/// <summary>
	/// Other Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR06-container");

	/// <summary>
	/// Logical
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, ContainerLocator, "#container-INFIELDSFLDS_PRIMVIAG");

	/// <summary>
	/// 
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, ContainerLocator, "container-INFIELDSFLDS_LOGICENU");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CREATUSE", "#INFIELDSFLDS_CREATUSE");

	/// <summary>
	/// Day
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CREATDAT", "#INFIELDSFLDS_CREATDAT");

	/// <summary>
	/// Complete Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CREATINS", "#INFIELDSFLDS_CREATINS");

	/// <summary>
	/// Hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CREATHOU", "#INFIELDSFLDS_CREATHOU");

	/// <summary>
	/// Radio Btn
	/// </summary>
	public RadiobuttonControl FldsRadiob => new RadiobuttonControl(driver, ContainerLocator, "container-INFIELDSFLDS_RADIOB__");

	public InfieldsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "INFIELDS", containerLocator: containerLocator) { }
}

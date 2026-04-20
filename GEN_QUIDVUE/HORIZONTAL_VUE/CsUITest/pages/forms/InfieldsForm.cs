using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InfieldsForm : Form
{
	/// <summary>
	/// Text inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl FldsTxtfield => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_TXTFIELD" + IdSuffix, "#INFIELDSFLDS_TXTFIELD" + IdSuffix);

	/// <summary>
	/// Multine Text
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_DESCRIP_" + IdSuffix, "#INFIELDSFLDS_DESCRIP_" + IdSuffix);

	/// <summary>
	/// Date/Time Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_YEAR____" + IdSuffix, "#INFIELDSFLDS_YEAR____" + IdSuffix);

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_TIME____" + IdSuffix, "#INFIELDSFLDS_TIME____" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, ContainerLocator, "#INFIELDSFLDS_DATE____" + IdSuffix);

	/// <summary>
	/// Date time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, ContainerLocator, "#INFIELDSFLDS_DATETIME" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date second
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, ContainerLocator, "#INFIELDSFLDS_DATESECO" + IdSuffix, "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_NPASSAGE" + IdSuffix, "#INFIELDSFLDS_NPASSAGE" + IdSuffix);

	/// <summary>
	/// Numeric decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_DURATION" + IdSuffix, "#INFIELDSFLDS_DURATION" + IdSuffix);

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_PRECOBIL" + IdSuffix, "#INFIELDSFLDS_PRECOBIL" + IdSuffix);

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_PRICE___" + IdSuffix, "#INFIELDSFLDS_PRICE___" + IdSuffix);

	/// <summary>
	/// Inputs with Masks
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Numeric Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_SSNUMBER" + IdSuffix, "#INFIELDSFLDS_SSNUMBER" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_ZIPFIELD" + IdSuffix, "#INFIELDSFLDS_ZIPFIELD" + IdSuffix);

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_VATNUMBR" + IdSuffix, "#INFIELDSFLDS_VATNUMBR" + IdSuffix);

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_LICPLATE" + IdSuffix, "#INFIELDSFLDS_LICPLATE" + IdSuffix);

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_BANKNMBR" + IdSuffix, "#INFIELDSFLDS_BANKNMBR" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_EMAILFLD" + IdSuffix, "#INFIELDSFLDS_EMAILFLD" + IdSuffix);

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_IBANFIEL" + IdSuffix, "#INFIELDSFLDS_IBANFIEL" + IdSuffix);

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_UPPRTEXT" + IdSuffix, "#INFIELDSFLDS_UPPRTEXT" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR05" + IdSuffix + "-container");

	/// <summary>
	/// Password
	/// </summary>
	public IWebElement FldsPassfld => throw new NotImplementedException();

	/// <summary>
	/// Colorpicker
	/// </summary>
	public BaseInputControl FldsClrpicke => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CLRPICKE" + IdSuffix, "#INFIELDSFLDS_CLRPICKE" + IdSuffix);

	/// <summary>
	/// Other Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#INFIELDSPSEUDNOVOGR06" + IdSuffix + "-container");

	/// <summary>
	/// Logical
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, ContainerLocator, "#container-INFIELDSFLDS_PRIMVIAG" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, ContainerLocator, "container-INFIELDSFLDS_LOGICENU" + IdSuffix);

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CREATUSE" + IdSuffix, "#INFIELDSFLDS_CREATUSE" + IdSuffix);

	/// <summary>
	/// Day
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CREATDAT" + IdSuffix, "#INFIELDSFLDS_CREATDAT" + IdSuffix);

	/// <summary>
	/// Complete Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CREATINS" + IdSuffix, "#INFIELDSFLDS_CREATINS" + IdSuffix);

	/// <summary>
	/// Hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, ContainerLocator, "container-INFIELDSFLDS_CREATHOU" + IdSuffix, "#INFIELDSFLDS_CREATHOU" + IdSuffix);

	/// <summary>
	/// Radio Btn
	/// </summary>
	public RadiobuttonControl FldsRadiob => new RadiobuttonControl(driver, ContainerLocator, "container-INFIELDSFLDS_RADIOB__" + IdSuffix);

	public InfieldsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "INFIELDS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

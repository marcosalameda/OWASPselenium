using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FieldhlpForm : Form
{
	/// <summary>
	/// Text inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR02-container");

	/// <summary>
	/// Show record
	/// </summary>
	public CheckboxInputControl FldsShwrc => new CheckboxInputControl(driver, ContainerLocator, "#container-FIELDHLPFLDS_SHWRC___");

	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl FldsTxtfield => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_TXTFIELD", "#FIELDHLPFLDS_TXTFIELD");

	/// <summary>
	/// Multine Text
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_DESCRIP_", "#FIELDHLPFLDS_DESCRIP_");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR06-container");

	/// <summary>
	/// Logical
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, ContainerLocator, "#container-FIELDHLPFLDS_PRIMVIAG");

	/// <summary>
	/// Yes or no
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, ContainerLocator, "container-FIELDHLPFLDS_LOGICENU");

	/// <summary>
	/// Numeric Enumeration
	/// </summary>
	public EnumControl FldsClassnum => new EnumControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CLASSNUM");

	/// <summary>
	/// Radio Btn
	/// </summary>
	public RadiobuttonControl FldsRadiob => new RadiobuttonControl(driver, ContainerLocator, "container-FIELDHLPFLDS_RADIOB__");

	/// <summary>
	/// Static Text 
	/// </summary>
	public IWebElement PseudField002 => throw new NotImplementedException();

	/// <summary>
	/// Static Image
	/// </summary>
	public IWebElement PseudField003 => throw new NotImplementedException();

	/// <summary>
	/// Manual filling field
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// Date/Time Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR01-container");

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_YEAR____", "#FIELDHLPFLDS_YEAR____");

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_TIME____", "#FIELDHLPFLDS_TIME____");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, ContainerLocator, "#FIELDHLPFLDS_DATE____");

	/// <summary>
	/// Date time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, ContainerLocator, "#FIELDHLPFLDS_DATETIME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date second
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, ContainerLocator, "#FIELDHLPFLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Numeric Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR03-container");

	/// <summary>
	/// Numeric decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_DURATION", "#FIELDHLPFLDS_DURATION");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_NPASSAGE", "#FIELDHLPFLDS_NPASSAGE");

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_PRECOBIL", "#FIELDHLPFLDS_PRECOBIL");

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_PRICE___", "#FIELDHLPFLDS_PRICE___");

	/// <summary>
	/// Inputs with Masks
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR04-container");

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_SSNUMBER", "#FIELDHLPFLDS_SSNUMBER");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_ZIPFIELD", "#FIELDHLPFLDS_ZIPFIELD");

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_VATNUMBR", "#FIELDHLPFLDS_VATNUMBR");

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_LICPLATE", "#FIELDHLPFLDS_LICPLATE");

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_BANKNMBR", "#FIELDHLPFLDS_BANKNMBR");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_EMAILFLD", "#FIELDHLPFLDS_EMAILFLD");

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_IBANFIEL", "#FIELDHLPFLDS_IBANFIEL");

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_UPPRTEXT", "#FIELDHLPFLDS_UPPRTEXT");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR05-container");

	/// <summary>
	/// Password
	/// </summary>
	public BaseInputControl FldsPassfld => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_PASSFLD_", "#FIELDHLPFLDS_PASSFLD_");

	/// <summary>
	/// Colorpicker
	/// </summary>
	public BaseInputControl FldsClrpicke => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CLRPICKE", "#FIELDHLPFLDS_CLRPICKE");

	/// <summary>
	/// Documents
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR07-container");

	/// <summary>
	/// Logo (External File Image)
	/// </summary>
	public BaseInputControl FldsLogoexte => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_LOGOEXTE", "#FIELDHLPFLDS_LOGOEXTE");

	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl FldsLogo => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_LOGO____", "#FIELDHLPFLDS_LOGO____");

	/// <summary>
	/// Document
	/// </summary>
	public DocumentControl FldsAttach => new DocumentControl(driver, ContainerLocator, "FIELDHLPFLDS_ATTACH__-container");

	/// <summary>
	/// Day
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CREATDAT", "#FIELDHLPFLDS_CREATDAT");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CREATUSE", "#FIELDHLPFLDS_CREATUSE");

	/// <summary>
	/// Complete Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CREATINS", "#FIELDHLPFLDS_CREATINS");

	/// <summary>
	/// Hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CREATHOU", "#FIELDHLPFLDS_CREATHOU");

	/// <summary>
	/// Airline name
	/// </summary>
	public LookupControl AeroName => new LookupControl(driver, ContainerLocator, "container-FIELDHLPAERO_NAME____");
	public SeeMorePage AeroNameSeeMorePage => new SeeMorePage(driver, "FIELDHLP", "FIELDHLPAERO_NAME____");

	/// <summary>
	/// Conditional
	/// </summary>
	public BaseInputControl FldsConditio => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CONDITIO", "#FIELDHLPFLDS_CONDITIO");

	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl FldsClass => new EnumControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CLASS___");

	public FieldhlpForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FIELDHLP", containerLocator: containerLocator) { }
}

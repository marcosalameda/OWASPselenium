using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FieldhlpForm : Form
{
	/// <summary>
	/// Text inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Show record
	/// </summary>
	public CheckboxInputControl FldsShwrc => new CheckboxInputControl(driver, ContainerLocator, "#container-FIELDHLPFLDS_SHWRC___" + IdSuffix);

	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl FldsTxtfield => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_TXTFIELD" + IdSuffix, "#FIELDHLPFLDS_TXTFIELD" + IdSuffix);

	/// <summary>
	/// Multine Text
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_DESCRIP_" + IdSuffix, "#FIELDHLPFLDS_DESCRIP_" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR06" + IdSuffix + "-container");

	/// <summary>
	/// Logical
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, ContainerLocator, "#container-FIELDHLPFLDS_PRIMVIAG" + IdSuffix);

	/// <summary>
	/// Yes or no
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, ContainerLocator, "container-FIELDHLPFLDS_LOGICENU" + IdSuffix);

	/// <summary>
	/// Numeric Enumeration
	/// </summary>
	public EnumControl FldsClassnum => new EnumControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CLASSNUM" + IdSuffix);

	/// <summary>
	/// Radio Btn
	/// </summary>
	public RadiobuttonControl FldsRadiob => new RadiobuttonControl(driver, ContainerLocator, "container-FIELDHLPFLDS_RADIOB__" + IdSuffix);

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
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_YEAR____" + IdSuffix, "#FIELDHLPFLDS_YEAR____" + IdSuffix);

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_TIME____" + IdSuffix, "#FIELDHLPFLDS_TIME____" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, ContainerLocator, "#FIELDHLPFLDS_DATE____" + IdSuffix);

	/// <summary>
	/// Date time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, ContainerLocator, "#FIELDHLPFLDS_DATETIME" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date second
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, ContainerLocator, "#FIELDHLPFLDS_DATESECO" + IdSuffix, "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Numeric Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Numeric decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_DURATION" + IdSuffix, "#FIELDHLPFLDS_DURATION" + IdSuffix);

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_NPASSAGE" + IdSuffix, "#FIELDHLPFLDS_NPASSAGE" + IdSuffix);

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_PRECOBIL" + IdSuffix, "#FIELDHLPFLDS_PRECOBIL" + IdSuffix);

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_PRICE___" + IdSuffix, "#FIELDHLPFLDS_PRICE___" + IdSuffix);

	/// <summary>
	/// Inputs with Masks
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_SSNUMBER" + IdSuffix, "#FIELDHLPFLDS_SSNUMBER" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_ZIPFIELD" + IdSuffix, "#FIELDHLPFLDS_ZIPFIELD" + IdSuffix);

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_VATNUMBR" + IdSuffix, "#FIELDHLPFLDS_VATNUMBR" + IdSuffix);

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_LICPLATE" + IdSuffix, "#FIELDHLPFLDS_LICPLATE" + IdSuffix);

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_BANKNMBR" + IdSuffix, "#FIELDHLPFLDS_BANKNMBR" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_EMAILFLD" + IdSuffix, "#FIELDHLPFLDS_EMAILFLD" + IdSuffix);

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_IBANFIEL" + IdSuffix, "#FIELDHLPFLDS_IBANFIEL" + IdSuffix);

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_UPPRTEXT" + IdSuffix, "#FIELDHLPFLDS_UPPRTEXT" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR05" + IdSuffix + "-container");

	/// <summary>
	/// Password
	/// </summary>
	public BaseInputControl FldsPassfld => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_PASSFLD_" + IdSuffix, "#FIELDHLPFLDS_PASSFLD_" + IdSuffix);

	/// <summary>
	/// Colorpicker
	/// </summary>
	public BaseInputControl FldsClrpicke => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CLRPICKE" + IdSuffix, "#FIELDHLPFLDS_CLRPICKE" + IdSuffix);

	/// <summary>
	/// Documents
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#FIELDHLPPSEUDNOVOGR07" + IdSuffix + "-container");

	/// <summary>
	/// Logo (External File Image)
	/// </summary>
	public BaseInputControl FldsLogoexte => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_LOGOEXTE" + IdSuffix, "#FIELDHLPFLDS_LOGOEXTE" + IdSuffix);

	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl FldsLogo => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_LOGO____" + IdSuffix, "#FIELDHLPFLDS_LOGO____" + IdSuffix);

	/// <summary>
	/// Document
	/// </summary>
	public DocumentControl FldsAttach => new DocumentControl(driver, ContainerLocator, "FIELDHLPFLDS_ATTACH__-container" + IdSuffix);

	/// <summary>
	/// Day
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CREATDAT" + IdSuffix, "#FIELDHLPFLDS_CREATDAT" + IdSuffix);

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CREATUSE" + IdSuffix, "#FIELDHLPFLDS_CREATUSE" + IdSuffix);

	/// <summary>
	/// Complete Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CREATINS" + IdSuffix, "#FIELDHLPFLDS_CREATINS" + IdSuffix);

	/// <summary>
	/// Hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CREATHOU" + IdSuffix, "#FIELDHLPFLDS_CREATHOU" + IdSuffix);

	/// <summary>
	/// Airline name
	/// </summary>
	public LookupControl AeroName => new LookupControl(driver, ContainerLocator, "container-FIELDHLPAERO_NAME____" + IdSuffix);
	public SeeMorePage AeroNameSeeMorePage => new SeeMorePage(driver, "FIELDHLP", "FIELDHLPAERO_NAME____" + IdSuffix);

	/// <summary>
	/// Conditional
	/// </summary>
	public BaseInputControl FldsConditio => new BaseInputControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CONDITIO" + IdSuffix, "#FIELDHLPFLDS_CONDITIO" + IdSuffix);

	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl FldsClass => new EnumControl(driver, ContainerLocator, "container-FIELDHLPFLDS_CLASS___" + IdSuffix);

	public FieldhlpForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "FIELDHLP", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FldstblForm : Form
{
	/// <summary>
	/// Text inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSTBL_PSEUDNOVOGR02-container");

	/// <summary>
	/// Show record
	/// </summary>
	public CheckboxInputControl FldsShwrc => new CheckboxInputControl(driver, ContainerLocator, "#container-FLDSTBL_FLDS_SHWRC___");

	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl FldsTxtfield => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_TXTFIELD", "#FLDSTBL_FLDS_TXTFIELD");

	/// <summary>
	/// Multine Text
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_DESCRIP_", "#FLDSTBL_FLDS_DESCRIP_");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSTBL_PSEUDNOVOGR06-container");

	/// <summary>
	/// Logical
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, ContainerLocator, "#container-FLDSTBL_FLDS_PRIMVIAG");

	/// <summary>
	/// Yes or no
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_LOGICENU");

	/// <summary>
	/// Numeric Enumeration
	/// </summary>
	public EnumControl FldsClassnum => new EnumControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_CLASSNUM");

	/// <summary>
	/// Radio Btn
	/// </summary>
	public RadiobuttonControl FldsRadiob => new RadiobuttonControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_RADIOB__");

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
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSTBL_PSEUDNOVOGR01-container");

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_YEAR____", "#FLDSTBL_FLDS_YEAR____");

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_TIME____", "#FLDSTBL_FLDS_TIME____");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, ContainerLocator, "#FLDSTBL_FLDS_DATE____");

	/// <summary>
	/// Date time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, ContainerLocator, "#FLDSTBL_FLDS_DATETIME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date second
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, ContainerLocator, "#FLDSTBL_FLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Numeric Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSTBL_PSEUDNOVOGR03-container");

	/// <summary>
	/// Numeric decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_DURATION", "#FLDSTBL_FLDS_DURATION");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_NPASSAGE", "#FLDSTBL_FLDS_NPASSAGE");

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_PRECOBIL", "#FLDSTBL_FLDS_PRECOBIL");

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_PRICE___", "#FLDSTBL_FLDS_PRICE___");

	/// <summary>
	/// Inputs with Masks
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSTBL_PSEUDNOVOGR04-container");

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_SSNUMBER", "#FLDSTBL_FLDS_SSNUMBER");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_ZIPFIELD", "#FLDSTBL_FLDS_ZIPFIELD");

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_VATNUMBR", "#FLDSTBL_FLDS_VATNUMBR");

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_LICPLATE", "#FLDSTBL_FLDS_LICPLATE");

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_BANKNMBR", "#FLDSTBL_FLDS_BANKNMBR");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_EMAILFLD", "#FLDSTBL_FLDS_EMAILFLD");

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_IBANFIEL", "#FLDSTBL_FLDS_IBANFIEL");

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_UPPRTEXT", "#FLDSTBL_FLDS_UPPRTEXT");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNrcntry => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_NRCNTRY_", "#FLDSTBL_FLDS_NRCNTRY_");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSTBL_PSEUDNOVOGR05-container");

	/// <summary>
	/// Password
	/// </summary>
	public BaseInputControl FldsPassfld => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_PASSFLD_", "#FLDSTBL_FLDS_PASSFLD_");

	/// <summary>
	/// Colorpicker
	/// </summary>
	public BaseInputControl FldsClrpicke => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_CLRPICKE", "#FLDSTBL_FLDS_CLRPICKE");

	/// <summary>
	/// Documents
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSTBL_PSEUDNOVOGR07-container");

	/// <summary>
	/// Logo (External File Image)
	/// </summary>
	public BaseInputControl FldsLogoexte => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_LOGOEXTE", "#FLDSTBL_FLDS_LOGOEXTE");

	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl FldsLogo => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_LOGO____", "#FLDSTBL_FLDS_LOGO____");

	/// <summary>
	/// Document
	/// </summary>
	public DocumentControl FldsAttach => new DocumentControl(driver, ContainerLocator, "FLDSTBL_FLDS_ATTACH__");

	/// <summary>
	/// Day
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_CREATDAT", "#FLDSTBL_FLDS_CREATDAT");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_CREATUSE", "#FLDSTBL_FLDS_CREATUSE");

	/// <summary>
	/// Complete Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_CREATINS", "#FLDSTBL_FLDS_CREATINS");

	/// <summary>
	/// Hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_CREATHOU", "#FLDSTBL_FLDS_CREATHOU");

	/// <summary>
	/// Nome da companhia aérea
	/// </summary>
	public LookupControl AeroName => new LookupControl(driver, ContainerLocator, "container-FLDSTBL_AERO_NAME____");
	public SeeMorePage AeroNameSeeMorePage => new SeeMorePage(driver, "FLDSTBL", "FLDSTBL_AERO_NAME____");

	/// <summary>
	/// Conditional
	/// </summary>
	public BaseInputControl FldsConditio => new BaseInputControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_CONDITIO", "#FLDSTBL_FLDS_CONDITIO");

	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl FldsClass => new EnumControl(driver, ContainerLocator, "container-FLDSTBL_FLDS_CLASS___");

	/// <summary>
	/// Field feedback
	/// </summary>
	public ListControl PseudFeeca => new ListControl(driver, ContainerLocator, "#FLDSTBL_PSEUDFEECA___");

	public FldstblForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FLDSTBL", containerLocator: containerLocator) { }
}

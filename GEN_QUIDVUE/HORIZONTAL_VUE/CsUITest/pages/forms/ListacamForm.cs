using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ListacamForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamtexto => new TabControl(driver, ContainerLocator, "#tab-container-LISTACAMPSEUDCAMTEXTO");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamnum => new TabControl(driver, ContainerLocator, "#tab-container-LISTACAMPSEUDCAMNUM__");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamdate => new TabControl(driver, ContainerLocator, "#tab-container-LISTACAMPSEUDCAMDATE_");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCammask => new TabControl(driver, ContainerLocator, "#tab-container-LISTACAMPSEUDCAMMASK_");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamenum => new TabControl(driver, ContainerLocator, "#tab-container-LISTACAMPSEUDCAMENUM_");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamdocs => new TabControl(driver, ContainerLocator, "#tab-container-LISTACAMPSEUDCAMDOCS_");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamaudit => new TabControl(driver, ContainerLocator, "#tab-container-LISTACAMPSEUDCAMAUDIT");

	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl CamtextoFldsTxtfield => new BaseInputControl(driver, ContainerLocator, "container-CAMTEXTOFLDS_TXTFIELD", "#CAMTEXTOFLDS_TXTFIELD");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CamtextoFldsDescrip => new BaseInputControl(driver, ContainerLocator, "container-CAMTEXTOFLDS_DESCRIP_", "#CAMTEXTOFLDS_DESCRIP_");

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CamnumFldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_NPASSAGE", "#CAMNUM__FLDS_NPASSAGE");

	/// <summary>
	/// Numeric Decimal
	/// </summary>
	public BaseInputControl CamnumFldsDuration => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_DURATION", "#CAMNUM__FLDS_DURATION");

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl CamnumFldsPrice => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_PRICE___", "#CAMNUM__FLDS_PRICE___");

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl CamnumFldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_PRECOBIL", "#CAMNUM__FLDS_PRECOBIL");

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl CamdateFldsYear => new BaseInputControl(driver, ContainerLocator, "container-CAMDATE_FLDS_YEAR____", "#CAMDATE_FLDS_YEAR____");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl CamdateFldsDate => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATE____");

	/// <summary>
	/// Date Time
	/// </summary>
	public DateInputControl CamdateFldsDatetime => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATETIME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date seconds
	/// </summary>
	public DateInputControl CamdateFldsDateseco => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl CamdateFldsTime => new BaseInputControl(driver, ContainerLocator, "container-CAMDATE_FLDS_TIME____", "#CAMDATE_FLDS_TIME____");

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl CammaskFldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_ZIPFIELD", "#CAMMASK_FLDS_ZIPFIELD");

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl CammaskFldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_VATNUMBR", "#CAMMASK_FLDS_VATNUMBR");

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl CammaskFldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_LICPLATE", "#CAMMASK_FLDS_LICPLATE");

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl CammaskFldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_SSNUMBER", "#CAMMASK_FLDS_SSNUMBER");

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl CammaskFldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_BANKNMBR", "#CAMMASK_FLDS_BANKNMBR");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl CammaskFldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_EMAILFLD", "#CAMMASK_FLDS_EMAILFLD");

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl CammaskFldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_IBANFIEL", "#CAMMASK_FLDS_IBANFIEL");

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl CammaskFldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_UPPRTEXT", "#CAMMASK_FLDS_UPPRTEXT");

	/// <summary>
	/// Numeric enumeration
	/// </summary>
	public RadiobuttonControl CamenumFldsClassnum => new RadiobuttonControl(driver, ContainerLocator, "container-CAMENUM_FLDS_CLASSNUM");

	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl CamenumFldsClass => new EnumControl(driver, ContainerLocator, "container-CAMENUM_FLDS_CLASS___");

	/// <summary>
	/// Logical Enumeration
	/// </summary>
	public EnumControl CamenumFldsLogicenu => new EnumControl(driver, ContainerLocator, "container-CAMENUM_FLDS_LOGICENU");

	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl CamdocsFldsLogo => new BaseInputControl(driver, ContainerLocator, "container-CAMDOCS_FLDS_LOGO____", "#CAMDOCS_FLDS_LOGO____");

	/// <summary>
	/// Attachments
	/// </summary>
	public DocumentControl CamdocsFldsAttach => new DocumentControl(driver, ContainerLocator, "CAMDOCS_FLDS_ATTACH__-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl CamauditFldsCreatuse => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATUSE", "#CAMAUDITFLDS_CREATUSE");

	/// <summary>
	/// Date of Creation
	/// </summary>
	public BaseInputControl CamauditFldsCreatdat => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATDAT", "#CAMAUDITFLDS_CREATDAT");

	/// <summary>
	/// Creation hour
	/// </summary>
	public BaseInputControl CamauditFldsCreathou => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATHOU", "#CAMAUDITFLDS_CREATHOU");

	/// <summary>
	/// Complete Date of Creation
	/// </summary>
	public BaseInputControl CamauditFldsCreatins => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATINS", "#CAMAUDITFLDS_CREATINS");

	public ListacamForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LISTACAM", containerLocator: containerLocator) { }
}

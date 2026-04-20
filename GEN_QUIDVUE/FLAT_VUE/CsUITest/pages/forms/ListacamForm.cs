using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ListacamForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamtexto => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-LISTACAMPSEUDCAMTEXTO']");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamnum => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-LISTACAMPSEUDCAMNUM__']");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamdate => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-LISTACAMPSEUDCAMDATE_']");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCammask => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-LISTACAMPSEUDCAMMASK_']");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamenum => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-LISTACAMPSEUDCAMENUM_']");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamdocs => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-LISTACAMPSEUDCAMDOCS_']");

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamaudit => new TabControl(driver, ContainerLocator, "[data-testid='tab-container-LISTACAMPSEUDCAMAUDIT']");

	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl CamtextoFldsTxtfield => new BaseInputControl(driver, ContainerLocator, "container-CAMTEXTOFLDS_TXTFIELD" + IdSuffix, "#CAMTEXTOFLDS_TXTFIELD" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CamtextoFldsDescrip => new BaseInputControl(driver, ContainerLocator, "container-CAMTEXTOFLDS_DESCRIP_" + IdSuffix, "#CAMTEXTOFLDS_DESCRIP_" + IdSuffix);

	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CamnumFldsNpassage => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_NPASSAGE" + IdSuffix, "#CAMNUM__FLDS_NPASSAGE" + IdSuffix);

	/// <summary>
	/// Numeric Decimal
	/// </summary>
	public BaseInputControl CamnumFldsDuration => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_DURATION" + IdSuffix, "#CAMNUM__FLDS_DURATION" + IdSuffix);

	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl CamnumFldsPrice => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_PRICE___" + IdSuffix, "#CAMNUM__FLDS_PRICE___" + IdSuffix);

	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl CamnumFldsPrecobil => new BaseInputControl(driver, ContainerLocator, "container-CAMNUM__FLDS_PRECOBIL" + IdSuffix, "#CAMNUM__FLDS_PRECOBIL" + IdSuffix);

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl CamdateFldsYear => new BaseInputControl(driver, ContainerLocator, "container-CAMDATE_FLDS_YEAR____" + IdSuffix, "#CAMDATE_FLDS_YEAR____" + IdSuffix);

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl CamdateFldsDate => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATE____" + IdSuffix);

	/// <summary>
	/// Date Time
	/// </summary>
	public DateInputControl CamdateFldsDatetime => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATETIME" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date seconds
	/// </summary>
	public DateInputControl CamdateFldsDateseco => new DateInputControl(driver, ContainerLocator, "#CAMDATE_FLDS_DATESECO" + IdSuffix, "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl CamdateFldsTime => new BaseInputControl(driver, ContainerLocator, "container-CAMDATE_FLDS_TIME____" + IdSuffix, "#CAMDATE_FLDS_TIME____" + IdSuffix);

	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl CammaskFldsZipfield => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_ZIPFIELD" + IdSuffix, "#CAMMASK_FLDS_ZIPFIELD" + IdSuffix);

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl CammaskFldsVatnumbr => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_VATNUMBR" + IdSuffix, "#CAMMASK_FLDS_VATNUMBR" + IdSuffix);

	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl CammaskFldsLicplate => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_LICPLATE" + IdSuffix, "#CAMMASK_FLDS_LICPLATE" + IdSuffix);

	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl CammaskFldsSsnumber => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_SSNUMBER" + IdSuffix, "#CAMMASK_FLDS_SSNUMBER" + IdSuffix);

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl CammaskFldsBanknmbr => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_BANKNMBR" + IdSuffix, "#CAMMASK_FLDS_BANKNMBR" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl CammaskFldsEmailfld => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_EMAILFLD" + IdSuffix, "#CAMMASK_FLDS_EMAILFLD" + IdSuffix);

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl CammaskFldsIbanfiel => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_IBANFIEL" + IdSuffix, "#CAMMASK_FLDS_IBANFIEL" + IdSuffix);

	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl CammaskFldsUpprtext => new BaseInputControl(driver, ContainerLocator, "container-CAMMASK_FLDS_UPPRTEXT" + IdSuffix, "#CAMMASK_FLDS_UPPRTEXT" + IdSuffix);

	/// <summary>
	/// Numeric enumeration
	/// </summary>
	public RadiobuttonControl CamenumFldsClassnum => new RadiobuttonControl(driver, ContainerLocator, "container-CAMENUM_FLDS_CLASSNUM" + IdSuffix);

	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl CamenumFldsClass => new EnumControl(driver, ContainerLocator, "container-CAMENUM_FLDS_CLASS___" + IdSuffix);

	/// <summary>
	/// Logical Enumeration
	/// </summary>
	public EnumControl CamenumFldsLogicenu => new EnumControl(driver, ContainerLocator, "container-CAMENUM_FLDS_LOGICENU" + IdSuffix);

	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl CamdocsFldsLogo => new BaseInputControl(driver, ContainerLocator, "container-CAMDOCS_FLDS_LOGO____" + IdSuffix, "#CAMDOCS_FLDS_LOGO____" + IdSuffix);

	/// <summary>
	/// Attachments
	/// </summary>
	public DocumentControl CamdocsFldsAttach => new DocumentControl(driver, ContainerLocator, "CAMDOCS_FLDS_ATTACH__-container" + IdSuffix);

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl CamauditFldsCreatuse => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATUSE" + IdSuffix, "#CAMAUDITFLDS_CREATUSE" + IdSuffix);

	/// <summary>
	/// Date of Creation
	/// </summary>
	public BaseInputControl CamauditFldsCreatdat => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATDAT" + IdSuffix, "#CAMAUDITFLDS_CREATDAT" + IdSuffix);

	/// <summary>
	/// Creation hour
	/// </summary>
	public BaseInputControl CamauditFldsCreathou => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATHOU" + IdSuffix, "#CAMAUDITFLDS_CREATHOU" + IdSuffix);

	/// <summary>
	/// Complete Date of Creation
	/// </summary>
	public BaseInputControl CamauditFldsCreatins => new BaseInputControl(driver, ContainerLocator, "container-CAMAUDITFLDS_CREATINS" + IdSuffix, "#CAMAUDITFLDS_CREATINS" + IdSuffix);

	public ListacamForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "LISTACAM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

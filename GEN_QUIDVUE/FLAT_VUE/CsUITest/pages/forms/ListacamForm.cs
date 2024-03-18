namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ListacamForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamtexto => new TabControl(driver, formLocator, "#tab-container-LISTACAMPSEUDCAMTEXTO");
	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamnum => new TabControl(driver, formLocator, "#tab-container-LISTACAMPSEUDCAMNUM__");
	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamdate => new TabControl(driver, formLocator, "#tab-container-LISTACAMPSEUDCAMDATE_");
	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCammask => new TabControl(driver, formLocator, "#tab-container-LISTACAMPSEUDCAMMASK_");
	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamenum => new TabControl(driver, formLocator, "#tab-container-LISTACAMPSEUDCAMENUM_");
	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamdocs => new TabControl(driver, formLocator, "#tab-container-LISTACAMPSEUDCAMDOCS_");
	/// <summary>
	/// 
	/// </summary>
	public TabControl PseudCamaudit => new TabControl(driver, formLocator, "#tab-container-LISTACAMPSEUDCAMAUDIT");
	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl CamtextoFldsTxtfield => new BaseInputControl(driver, formLocator, "#CAMTEXTOFLDS_TXTFIELD");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CamtextoFldsDescrip => new BaseInputControl(driver, formLocator, "#CAMTEXTOFLDS_DESCRIP_");
	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CamnumFldsNpassage => new BaseInputControl(driver, formLocator, "#CAMNUM__FLDS_NPASSAGE");
	/// <summary>
	/// Numeric Decimal
	/// </summary>
	public BaseInputControl CamnumFldsDuration => new BaseInputControl(driver, formLocator, "#CAMNUM__FLDS_DURATION");
	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl CamnumFldsPrice => new BaseInputControl(driver, formLocator, "#CAMNUM__FLDS_PRICE___");
	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl CamnumFldsPrecobil => new BaseInputControl(driver, formLocator, "#CAMNUM__FLDS_PRECOBIL");
	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl CamdateFldsYear => new BaseInputControl(driver, formLocator, "#CAMDATE_FLDS_YEAR____");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl CamdateFldsDate => new DateInputControl(driver, formLocator, "#CAMDATE_FLDS_DATE____");
	/// <summary>
	/// Date Time
	/// </summary>
	public DateInputControl CamdateFldsDatetime => new DateInputControl(driver, formLocator, "#CAMDATE_FLDS_DATETIME", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Date seconds
	/// </summary>
	public DateInputControl CamdateFldsDateseco => new DateInputControl(driver, formLocator, "#CAMDATE_FLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl CamdateFldsTime => new BaseInputControl(driver, formLocator, "#CAMDATE_FLDS_TIME____");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl CammaskFldsZipfield => new BaseInputControl(driver, formLocator, "#CAMMASK_FLDS_ZIPFIELD");
	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl CammaskFldsVatnumbr => new BaseInputControl(driver, formLocator, "#CAMMASK_FLDS_VATNUMBR");
	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl CammaskFldsLicplate => new BaseInputControl(driver, formLocator, "#CAMMASK_FLDS_LICPLATE");
	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl CammaskFldsSsnumber => new BaseInputControl(driver, formLocator, "#CAMMASK_FLDS_SSNUMBER");
	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl CammaskFldsBanknmbr => new BaseInputControl(driver, formLocator, "#CAMMASK_FLDS_BANKNMBR");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl CammaskFldsEmailfld => new BaseInputControl(driver, formLocator, "#CAMMASK_FLDS_EMAILFLD");
	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl CammaskFldsIbanfiel => new BaseInputControl(driver, formLocator, "#CAMMASK_FLDS_IBANFIEL");
	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl CammaskFldsUpprtext => new BaseInputControl(driver, formLocator, "#CAMMASK_FLDS_UPPRTEXT");
	/// <summary>
	/// Numeric enumeration
	/// </summary>
	public RadiobuttonControl CamenumFldsClassnum => new RadiobuttonControl(driver, formLocator, "container-CAMENUM_FLDS_CLASSNUM");
	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl CamenumFldsClass => new EnumControl(driver, formLocator, "container-CAMENUM_FLDS_CLASS___");
	/// <summary>
	/// Logical Enumeration
	/// </summary>
	public EnumControl CamenumFldsLogicenu => new EnumControl(driver, formLocator, "container-CAMENUM_FLDS_LOGICENU");
	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl CamdocsFldsLogo => new BaseInputControl(driver, formLocator, "#CAMDOCS_FLDS_LOGO____");
	/// <summary>
	/// Attachments
	/// </summary>
	public BaseInputControl CamdocsFldsAttach => new BaseInputControl(driver, formLocator, "#CAMDOCS_FLDS_ATTACH__");
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl CamauditFldsCreatuse => new BaseInputControl(driver, formLocator, "#CAMAUDITFLDS_CREATUSE");
	/// <summary>
	/// Date of Creation
	/// </summary>
	public BaseInputControl CamauditFldsCreatdat => new BaseInputControl(driver, formLocator, "#CAMAUDITFLDS_CREATDAT");
	/// <summary>
	/// Creation hour
	/// </summary>
	public BaseInputControl CamauditFldsCreathou => new BaseInputControl(driver, formLocator, "#CAMAUDITFLDS_CREATHOU");
	/// <summary>
	/// Complete Date of Creation
	/// </summary>
	public BaseInputControl CamauditFldsCreatins => new BaseInputControl(driver, formLocator, "#CAMAUDITFLDS_CREATINS");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ListacamForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LISTACAM")).GetAttribute("data-loading") != "true");
    }

	public void Save() {
		WaitForLoading();
		saveBtn.Click();
	}

	public void Cancel() {
		WaitForLoading();
		cancelBtn.Click();
	}

}

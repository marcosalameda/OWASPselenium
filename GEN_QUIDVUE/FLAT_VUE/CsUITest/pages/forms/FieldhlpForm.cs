namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FieldhlpForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Text inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#FIELDHLPPSEUDNOVOGR02-container");
	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl FldsTxtfield => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_TXTFIELD");
	/// <summary>
	/// Multine Text
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_DESCRIP_");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, formLocator, "#FIELDHLPPSEUDNOVOGR06-container");
	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_YEAR____");
	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_TIME____");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, formLocator, "#FIELDHLPFLDS_DATE____");
	/// <summary>
	/// Date time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, formLocator, "#FIELDHLPFLDS_DATETIME", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Date second
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, formLocator, "#FIELDHLPFLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_NPASSAGE");
	/// <summary>
	/// Numeric decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_DURATION");
	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_PRECOBIL");
	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_PRICE___");
	/// <summary>
	/// Date/Time Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#FIELDHLPPSEUDNOVOGR01-container");
	/// <summary>
	/// Numeric Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#FIELDHLPPSEUDNOVOGR03-container");
	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_SSNUMBER");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_ZIPFIELD");
	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_VATNUMBR");
	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_LICPLATE");
	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_BANKNMBR");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_EMAILFLD");
	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_IBANFIEL");
	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_UPPRTEXT");
	/// <summary>
	/// Inputs with Masks
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#FIELDHLPPSEUDNOVOGR04-container");
	/// <summary>
	/// Password
	/// </summary>
	public IWebElement FldsPassfld => throw new NotImplementedException();
	/// <summary>
	/// Colorpicker
	/// </summary>
	public BaseInputControl FldsClrpicke => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_CLRPICKE");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#FIELDHLPPSEUDNOVOGR05-container");
	/// <summary>
	/// Logical
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, formLocator, "#container-FIELDHLPFLDS_PRIMVIAG");
	/// <summary>
	/// 
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, formLocator, "container-FIELDHLPFLDS_LOGICENU");
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_CREATUSE");
	/// <summary>
	/// Day
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_CREATDAT");
	/// <summary>
	/// Complete Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_CREATINS");
	/// <summary>
	/// Hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_CREATHOU");
	/// <summary>
	/// Apply
	/// </summary>
	public ButtonControl PseudBtn_isap => new ButtonControl(driver, formLocator, "#FIELDHLPPSEUDBTN_ISAP");
	/// <summary>
	/// Airline name
	/// </summary>
	public LookupControl AeroName => new LookupControl(driver, formLocator, "container-FIELDHLPAERO_NAME____");
	public SeeMorePage AeroNameSeeMorePage => new SeeMorePage(driver, "FIELDHLP", "AERO.NAME");
	/// <summary>
	/// Conditional
	/// </summary>
	public BaseInputControl FldsConditio => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_CONDITIO");
	/// <summary>
	/// Text Enumeration
	/// </summary>
	public EnumControl FldsClass => new EnumControl(driver, formLocator, "container-FIELDHLPFLDS_CLASS___");
	/// <summary>
	/// Radio Btn
	/// </summary>
	public RadiobuttonControl FldsRadiob => new RadiobuttonControl(driver, formLocator, "container-FIELDHLPFLDS_RADIOB__");
	/// <summary>
	/// Documents
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, formLocator, "#FIELDHLPPSEUDNOVOGR07-container");
	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl FldsLogo => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_LOGO____");
	/// <summary>
	/// Document
	/// </summary>
	public BaseInputControl FldsAttach => new BaseInputControl(driver, formLocator, "#FIELDHLPFLDS_ATTACH__");
	/// <summary>
	/// No. register
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-FIELDHLPEQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "FIELDHLP", "EQUIP.REGISTNR");
	/// <summary>
	/// Show record
	/// </summary>
	public CheckboxInputControl FldsShwrc => new CheckboxInputControl(driver, formLocator, "#container-FIELDHLPFLDS_SHWRC___");
	/// <summary>
	/// Numeric Enumeration
	/// </summary>
	public EnumControl FldsClassnum => new EnumControl(driver, formLocator, "container-FIELDHLPFLDS_CLASSNUM");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public FieldhlpForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("FIELDHLP")).GetAttribute("data-loading") != "true");
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

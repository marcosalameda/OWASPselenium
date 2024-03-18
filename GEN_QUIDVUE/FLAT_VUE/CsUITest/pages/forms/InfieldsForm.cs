namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InfieldsForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Text inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#INFIELDSPSEUDNOVOGR02-container");
	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl FldsTxtfield => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_TXTFIELD");
	/// <summary>
	/// Multine Text
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_DESCRIP_");
	/// <summary>
	/// Date/Time Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#INFIELDSPSEUDNOVOGR01-container");
	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_YEAR____");
	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_TIME____");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, formLocator, "#INFIELDSFLDS_DATE____");
	/// <summary>
	/// Date time
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, formLocator, "#INFIELDSFLDS_DATETIME", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Date second
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, formLocator, "#INFIELDSFLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_NPASSAGE");
	/// <summary>
	/// Numeric decimal
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_DURATION");
	/// <summary>
	/// Currency Decimal
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_PRECOBIL");
	/// <summary>
	/// Currency
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_PRICE___");
	/// <summary>
	/// Inputs with Masks
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#INFIELDSPSEUDNOVOGR04-container");
	/// <summary>
	/// Numeric Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#INFIELDSPSEUDNOVOGR03-container");
	/// <summary>
	/// Social Security No
	/// </summary>
	public BaseInputControl FldsSsnumber => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_SSNUMBER");
	/// <summary>
	/// Zipcode
	/// </summary>
	public BaseInputControl FldsZipfield => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_ZIPFIELD");
	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl FldsVatnumbr => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_VATNUMBR");
	/// <summary>
	/// Licence plate
	/// </summary>
	public BaseInputControl FldsLicplate => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_LICPLATE");
	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl FldsBanknmbr => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_BANKNMBR");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl FldsEmailfld => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_EMAILFLD");
	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl FldsIbanfiel => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_IBANFIEL");
	/// <summary>
	/// Uppercase
	/// </summary>
	public BaseInputControl FldsUpprtext => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_UPPRTEXT");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#INFIELDSPSEUDNOVOGR05-container");
	/// <summary>
	/// Password
	/// </summary>
	public IWebElement FldsPassfld => throw new NotImplementedException();
	/// <summary>
	/// Colorpicker
	/// </summary>
	public BaseInputControl FldsClrpicke => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_CLRPICKE");
	/// <summary>
	/// Other Inputs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, formLocator, "#INFIELDSPSEUDNOVOGR06-container");
	/// <summary>
	/// Logical
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, formLocator, "#container-INFIELDSFLDS_PRIMVIAG");
	/// <summary>
	/// 
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, formLocator, "container-INFIELDSFLDS_LOGICENU");
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_CREATUSE");
	/// <summary>
	/// Day
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_CREATDAT");
	/// <summary>
	/// Complete Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_CREATINS");
	/// <summary>
	/// Hour
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, formLocator, "#INFIELDSFLDS_CREATHOU");
	/// <summary>
	/// Radio Btn
	/// </summary>
	public RadiobuttonControl FldsRadiob => new RadiobuttonControl(driver, formLocator, "container-INFIELDSFLDS_RADIOB__");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public InfieldsForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("INFIELDS")).GetAttribute("data-loading") != "true");
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

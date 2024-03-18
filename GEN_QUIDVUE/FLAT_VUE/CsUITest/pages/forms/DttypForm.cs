namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DttypForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();
	/// <summary>
	/// Char String
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#DTTYP___PSEUDNOVOGR01-container");
	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl DttypString => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPSTRING__");
	/// <summary>
	/// Text (Upper case)
	/// </summary>
	public BaseInputControl DttypUppercas => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPUPPERCAS");
	/// <summary>
	/// Text (UUID aka GUID)
	/// </summary>
	public BaseInputControl DttypUuid => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPUUID____");
	/// <summary>
	/// Multiline text
	/// </summary>
	public BaseInputControl DttypMultilin => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPMULTILIN");
	/// <summary>
	/// Multiline text (Text editor)
	/// </summary>
	public IWebElement DttypMultili3 => throw new NotImplementedException();
	/// <summary>
	/// Boolean
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#DTTYP___PSEUDNOVOGR02-container");
	/// <summary>
	/// Logical (tinyint) (storage: 1 byte)
	/// </summary>
	public CheckboxInputControl DttypBoolean => new CheckboxInputControl(driver, formLocator, "#container-DTTYP___DTTYPBOOLEAN_");
	/// <summary>
	/// Conditional (smallint) (storage: 2 byte)
	/// </summary>
	public BaseInputControl DttypBoolean2 => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPBOOLEAN2");
	/// <summary>
	/// Numeric
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#DTTYP___PSEUDNOVOGR03-container");
	/// <summary>
	/// Numeric  4.0 - small integer (storage: 2 byte)
	/// </summary>
	public BaseInputControl DttypSmallint => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPSMALLINT");
	/// <summary>
	/// Numeric  9.0 - integer (storage: 4 byte)
	/// </summary>
	public BaseInputControl DttypInteger => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPINTEGER_");
	/// <summary>
	/// Numeric 15.0 - big integer (storage: 8 byte)
	/// </summary>
	public BaseInputControl DttypBigint => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPBIGINT__");
	/// <summary>
	/// Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)
	/// </summary>
	public BaseInputControl DttypReal => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPREAL____");
	/// <summary>
	/// Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)
	/// </summary>
	public BaseInputControl DttypFloat => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPFLOAT___");
	/// <summary>
	/// Decimal (1-10) (storage: 5 byte)
	/// </summary>
	public BaseInputControl DttypDecimal => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPDECIMAL_");
	/// <summary>
	/// Decimal (11-15) (storage: 9 byte)
	/// </summary>
	public BaseInputControl DttypDecimal9 => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPDECIMAL9");
	/// <summary>
	/// Money - decimal (1-10) (storage: 5 byte)
	/// </summary>
	public BaseInputControl DttypMoney => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPMONEY___");
	/// <summary>
	/// Money - decimal (11-15) (storage: 9 byte)
	/// </summary>
	public BaseInputControl DttypMoney9 => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPMONEY9__");
	/// <summary>
	/// Date and Time
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#DTTYP___PSEUDNOVOGR04-container");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl DttypDate => new DateInputControl(driver, formLocator, "#DTTYP___DTTYPDATE____");
	/// <summary>
	/// Date Time
	/// </summary>
	public DateInputControl DttypDatetime => new DateInputControl(driver, formLocator, "#DTTYP___DTTYPDATETIME", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Date Time Second
	/// </summary>
	public DateInputControl DttypDtsesond => new DateInputControl(driver, formLocator, "#DTTYP___DTTYPDTSESOND", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl DttypTime => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPTIME____");
	/// <summary>
	/// Image
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#DTTYP___PSEUDNOVOGR05-container");
	/// <summary>
	/// Image (binary)
	/// </summary>
	public BaseInputControl DttypImage => new BaseInputControl(driver, formLocator, "#DTTYP___DTTYPIMAGE___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public DttypForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("DTTYP")).GetAttribute("data-loading") != "true");
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

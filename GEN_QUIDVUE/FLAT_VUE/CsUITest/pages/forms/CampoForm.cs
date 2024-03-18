namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CampoForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Airline
	/// </summary>
	public LookupControl AeroName => new LookupControl(driver, formLocator, "container-CAMPO___AERO_NAME____");
	public SeeMorePage AeroNameSeeMorePage => new SeeMorePage(driver, "CAMPO", "AERO.NAME");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_DESCRIP_");
	/// <summary>
	/// Passenger capacity on the plane
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_NPASSAGE");
	/// <summary>
	/// Trip Duration
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_DURATION");
	/// <summary>
	/// Rounded Ticket Price
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_PRICE___");
	/// <summary>
	/// Ticket price at tenths
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_PRECOBIL");
	/// <summary>
	/// Departure date (DD/MM/YEAR)
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, formLocator, "#CAMPO___FLDS_DATE____");
	/// <summary>
	/// Departure date (hour)
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, formLocator, "#CAMPO___FLDS_DATETIME", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Departure date (seconds)
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, formLocator, "#CAMPO___FLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");
	/// <summary>
	/// Departure hour
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_TIME____");
	/// <summary>
	/// Creation year of the airport
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_YEAR____");
	/// <summary>
	/// 1ªViagem
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, formLocator, "#container-CAMPO___FLDS_PRIMVIAG");
	/// <summary>
	/// Have you traveled before?
	/// </summary>
	public BaseInputControl FldsConditio => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_CONDITIO");
	/// <summary>
	/// Class (Enumeração de Texto)
	/// </summary>
	public EnumControl FldsClass => new EnumControl(driver, formLocator, "container-CAMPO___FLDS_CLASS___");
	/// <summary>
	/// Classe (Enumeração Numérica)
	/// </summary>
	public EnumControl FldsClassnum => new EnumControl(driver, formLocator, "container-CAMPO___FLDS_CLASSNUM");
	/// <summary>
	/// 1st trip (Logical Enumeration)
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, formLocator, "container-CAMPO___FLDS_LOGICENU");
	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl FldsLogo => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_LOGO____");
	/// <summary>
	/// Attachments
	/// </summary>
	public BaseInputControl FldsAttach => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_ATTACH__");
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_CREATUSE");
	/// <summary>
	/// Creation Date (DD/MM/YY)
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_CREATDAT");
	/// <summary>
	/// Creation Date
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_CREATHOU");
	/// <summary>
	/// Complete Creation Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, formLocator, "#CAMPO___FLDS_CREATINS");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public CampoForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("CAMPO")).GetAttribute("data-loading") != "true");
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

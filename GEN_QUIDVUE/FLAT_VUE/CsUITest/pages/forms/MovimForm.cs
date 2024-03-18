namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MovimForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Change
	/// </summary>
	public DateInputControl MovimDhmudanc => new DateInputControl(driver, formLocator, "#MOVIM___MOVIMDHMUDANC", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-MOVIM___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "MOVIM", "EQUIP.REGISTNR");
	/// <summary>
	/// Room No.
	/// </summary>
	public LookupControl RoomsRoomnr => new LookupControl(driver, formLocator, "container-MOVIM___ROOMSROOMNR__");
	public SeeMorePage RoomsRoomnrSeeMorePage => new SeeMorePage(driver, "MOVIM", "ROOMS.ROOMNR");
	/// <summary>
	/// Observation
	/// </summary>
	public BaseInputControl MovimObservat => new BaseInputControl(driver, formLocator, "#MOVIM___MOVIMOBSERVAT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public MovimForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("MOVIM")).GetAttribute("data-loading") != "true");
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

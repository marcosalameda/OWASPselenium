namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InstaForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Equipment
	/// </summary>
	public IWebElement PseudNovogr01 => throw new NotImplementedException();
	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, formLocator, "container-INSTA___TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "INSTA", "TPEQU.TIPOEQUI");
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-INSTA___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "INSTA", "EQUIP.REGISTNR");
	/// <summary>
	/// Designation:
	/// </summary>
	public IWebElement EquipDesignat => throw new NotImplementedException();
	/// <summary>
	/// Photo
	/// </summary>
	public IWebElement EquipPhotogra => throw new NotImplementedException();
	/// <summary>
	/// Cost
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#INSTA___PSEUDNOVOGR02-container");
	/// <summary>
	/// Since:
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, formLocator, "#INSTA___INSTASINCE___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, formLocator, "#INSTA___INSTAUNTIL___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, formLocator, "#INSTA___INSTAHOURS___");
	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, formLocator, "#INSTA___INSTAPRECOHOR");
	/// <summary>
	/// Value:
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, formLocator, "#INSTA___INSTAVALUE___");
	/// <summary>
	/// LOCAL
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#INSTA___PSEUDNOVOGR03-container");
	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, formLocator, "#INSTA___INSTACOORDGEO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public InstaForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("INSTA")).GetAttribute("data-loading") != "true");
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

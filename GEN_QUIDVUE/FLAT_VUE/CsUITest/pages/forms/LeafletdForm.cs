namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LeafletdForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-LEAFLETDEQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "LEAFLETD", "EQUIP.REGISTNR");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public IWebElement TpequTipoequi => throw new NotImplementedException();
	/// <summary>
	/// Scheduling
	/// </summary>
	public BaseInputControl InstaDesignat => new BaseInputControl(driver, formLocator, "#LEAFLETDINSTADESIGNAT");
	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl InstaDtiniage => new DateInputControl(driver, formLocator, "#LEAFLETDINSTADTINIAGE", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// End
	/// </summary>
	public DateInputControl InstaDtfimage => new DateInputControl(driver, formLocator, "#LEAFLETDINSTADTFIMAGE", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl InstaDescript => new BaseInputControl(driver, formLocator, "#LEAFLETDINSTADESCRIPT");
	/// <summary>
	/// All day
	/// </summary>
	public CheckboxInputControl InstaAllday => new CheckboxInputControl(driver, formLocator, "#container-LEAFLETDINSTAALLDAY__");
	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, formLocator, "#LEAFLETDINSTASINCE___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, formLocator, "#LEAFLETDINSTAUNTIL___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, formLocator, "#LEAFLETDINSTAHOURS___");
	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, formLocator, "#LEAFLETDINSTAPRECOHOR");
	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, formLocator, "#LEAFLETDINSTAVALUE___");
	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, formLocator, "#LEAFLETDINSTACOORDGEO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LeafletdForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LEAFLETD")).GetAttribute("data-loading") != "true");
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

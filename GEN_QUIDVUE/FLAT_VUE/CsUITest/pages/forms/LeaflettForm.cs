namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LeaflettForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-LEAFLETTEQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "LEAFLETT", "EQUIP.REGISTNR");
	/// <summary>
	/// 
	/// </summary>
	public IWebElement TpequTipoequi => throw new NotImplementedException();
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl InstaDescript => new BaseInputControl(driver, formLocator, "#LEAFLETTINSTADESCRIPT");
	/// <summary>
	/// Scheduling
	/// </summary>
	public BaseInputControl InstaDesignat => new BaseInputControl(driver, formLocator, "#LEAFLETTINSTADESIGNAT");
	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl InstaDtiniage => new DateInputControl(driver, formLocator, "#LEAFLETTINSTADTINIAGE", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// End
	/// </summary>
	public DateInputControl InstaDtfimage => new DateInputControl(driver, formLocator, "#LEAFLETTINSTADTFIMAGE", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// All day
	/// </summary>
	public CheckboxInputControl InstaAllday => new CheckboxInputControl(driver, formLocator, "#container-LEAFLETTINSTAALLDAY__");
	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl InstaSince => new DateInputControl(driver, formLocator, "#LEAFLETTINSTASINCE___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Until
	/// </summary>
	public DateInputControl InstaUntil => new DateInputControl(driver, formLocator, "#LEAFLETTINSTAUNTIL___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Quantity of hours:
	/// </summary>
	public BaseInputControl InstaHours => new BaseInputControl(driver, formLocator, "#LEAFLETTINSTAHOURS___");
	/// <summary>
	/// Price per hour:
	/// </summary>
	public BaseInputControl InstaPrecohor => new BaseInputControl(driver, formLocator, "#LEAFLETTINSTAPRECOHOR");
	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl InstaValue => new BaseInputControl(driver, formLocator, "#LEAFLETTINSTAVALUE___");
	/// <summary>
	/// Geographic Coordinates
	/// </summary>
	public BaseInputControl InstaCoordgeo => new BaseInputControl(driver, formLocator, "#LEAFLETTINSTACOORDGEO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LeaflettForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LEAFLETT")).GetAttribute("data-loading") != "true");
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

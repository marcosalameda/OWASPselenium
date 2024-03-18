namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AccordiForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// COMPANY
	/// </summary>
	public IWebElement PseudNovogr02 => throw new NotImplementedException();
	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, formLocator, "container-ACCORDI_CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "ACCORDI", "CMPNY.DESIGNAT");
	/// <summary>
	/// Person
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, formLocator, "container-ACCORDI_PESS1NAME____");
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "ACCORDI", "PESS1.NAME");
	/// <summary>
	/// Sequential no.
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, formLocator, "#ACCORDI_EQUIPSEQUENNR");
	/// <summary>
	/// PHOTO
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl EquipPhotogra => new BaseInputControl(driver, formLocator, "#ACCORDI_EQUIPPHOTOGRA");
	/// <summary>
	/// Accordion
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();
	/// <summary>
	/// Facilities
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#ACCORDI_PSEUDNOVOGR03-container");
	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalag => new ListControl(driver, formLocator, "#ACCORDI_PSEUDINSTALAG");
	/// <summary>
	/// PLACES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#ACCORDI_PSEUDNOVOGR04-container");
	/// <summary>
	/// Facilities
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, formLocator, "#ACCORDI_PSEUDINSTALAC");
	/// <summary>
	/// Repairs
	/// </summary>
	public CollapsibleZoneControl PseudNovogr11 => new CollapsibleZoneControl(driver, formLocator, "#ACCORDI_PSEUDNOVOGR11-container");
	/// <summary>
	/// Equipment repairs:
	/// </summary>
	public ListControl PseudReparaco => new ListControl(driver, formLocator, "#ACCORDI_PSEUDREPARACO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AccordiForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ACCORDI")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DispaForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Dispatch date
	/// </summary>
	public DateInputControl DispaDispadt => new DateInputControl(driver, formLocator, "#DISPA___DISPADISPADT_", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Dispatch number
	/// </summary>
	public BaseInputControl DispaDispanr => new BaseInputControl(driver, formLocator, "#DISPA___DISPADISPANR_");
	/// <summary>
	/// Status
	/// </summary>
	public BaseInputControl DispaStatus => new BaseInputControl(driver, formLocator, "#DISPA___DISPASTATUS__");
	/// <summary>
	/// Customer
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, formLocator, "container-DISPA___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "DISPA", "ENTIT.NAME");
	/// <summary>
	/// Is prepared
	/// </summary>
	public CheckboxInputControl DispaIsprepar => new CheckboxInputControl(driver, formLocator, "#container-DISPA___DISPAISPREPAR");
	/// <summary>
	/// Prepared
	/// </summary>
	public DateInputControl DispaPrepared => new DateInputControl(driver, formLocator, "#DISPA___DISPAPREPARED", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Prepared by
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, formLocator, "container-DISPA___PERSONAME____");
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "DISPA", "PERSO.NAME");
	/// <summary>
	/// Items
	/// </summary>
	public ListControl PseudDispatch => new ListControl(driver, formLocator, "#DISPA___PSEUDDISPATCH");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public DispaForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("DISPA")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RelinForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Receipt
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#RELIN___PSEUDNOVOGR01-container");
	/// <summary>
	/// Receipt number
	/// </summary>
	public LookupControl ReceiNumber => new LookupControl(driver, formLocator, "container-RELIN___RECEINUMBER__");
	public SeeMorePage ReceiNumberSeeMorePage => new SeeMorePage(driver, "RELIN", "RECEI.NUMBER");
	/// <summary>
	/// Legal name
	/// </summary>
	public IWebElement EntitName => throw new NotImplementedException();
	/// <summary>
	/// Receipt line
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#RELIN___PSEUDNOVOGR02-container");
	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl RelinLinenumb => new BaseInputControl(driver, formLocator, "#RELIN___RELINLINENUMB");
	/// <summary>
	/// Product
	/// </summary>
	public LookupControl ProduProduct => new LookupControl(driver, formLocator, "container-RELIN___PRODUPRODUCT_");
	public SeeMorePage ProduProductSeeMorePage => new SeeMorePage(driver, "RELIN", "PRODU.PRODUCT");
	/// <summary>
	/// Ordered
	/// </summary>
	public BaseInputControl RelinOrdered => new BaseInputControl(driver, formLocator, "#RELIN___RELINORDERED_");
	/// <summary>
	/// Received
	/// </summary>
	public BaseInputControl RelinReceived => new BaseInputControl(driver, formLocator, "#RELIN___RELINRECEIVED");
	/// <summary>
	/// Outstanding
	/// </summary>
	public BaseInputControl RelinOutstand => new BaseInputControl(driver, formLocator, "#RELIN___RELINOUTSTAND");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public RelinForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("RELIN")).GetAttribute("data-loading") != "true");
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

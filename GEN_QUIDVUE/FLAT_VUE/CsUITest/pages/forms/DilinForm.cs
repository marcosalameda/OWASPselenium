namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DilinForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Dispatch number
	/// </summary>
	public LookupControl DispaDispanr => new LookupControl(driver, formLocator, "container-DILIN___DISPADISPANR_");
	public SeeMorePage DispaDispanrSeeMorePage => new SeeMorePage(driver, "DILIN", "DISPA.DISPANR");
	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl DilinLinenumb => new BaseInputControl(driver, formLocator, "#DILIN___DILINLINENUMB");
	/// <summary>
	/// Product
	/// </summary>
	public LookupControl ProduProduct => new LookupControl(driver, formLocator, "container-DILIN___PRODUPRODUCT_");
	public SeeMorePage ProduProductSeeMorePage => new SeeMorePage(driver, "DILIN", "PRODU.PRODUCT");
	/// <summary>
	/// Ordered
	/// </summary>
	public BaseInputControl DilinOrdered => new BaseInputControl(driver, formLocator, "#DILIN___DILINORDERED_");
	/// <summary>
	/// Delivered
	/// </summary>
	public BaseInputControl DilinDelivere => new BaseInputControl(driver, formLocator, "#DILIN___DILINDELIVERE");
	/// <summary>
	/// Outstanding
	/// </summary>
	public BaseInputControl DilinOutstand => new BaseInputControl(driver, formLocator, "#DILIN___DILINOUTSTAND");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public DilinForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("DILIN")).GetAttribute("data-loading") != "true");
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

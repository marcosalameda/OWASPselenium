namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CmpkiForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, formLocator, "container-CMPKI___TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "CMPKI", "TPEQU.TIPOEQUI");
	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl CmpkiOrder => new BaseInputControl(driver, formLocator, "#CMPKI___CMPKIORDER___");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl Tpeq1Tipoequi => new LookupControl(driver, formLocator, "container-CMPKI___TPEQ1TIPOEQUI");
	public SeeMorePage Tpeq1TipoequiSeeMorePage => new SeeMorePage(driver, "CMPKI", "TPEQ1.TIPOEQUI");
	/// <summary>
	/// Quantity:
	/// </summary>
	public BaseInputControl CmpkiQuantida => new BaseInputControl(driver, formLocator, "#CMPKI___CMPKIQUANTIDA");
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl CmpkiCode => new BaseInputControl(driver, formLocator, "#CMPKI___CMPKICODE____");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CmpkiDescript => new BaseInputControl(driver, formLocator, "#CMPKI___CMPKIDESCRIPT");
	/// <summary>
	/// Site
	/// </summary>
	public BaseInputControl CmpkiUrl => new BaseInputControl(driver, formLocator, "#CMPKI___CMPKIURL_____");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public CmpkiForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("CMPKI")).GetAttribute("data-loading") != "true");
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

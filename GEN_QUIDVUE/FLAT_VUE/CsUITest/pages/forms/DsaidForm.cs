namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DsaidForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl Ware1Warehdes => new LookupControl(driver, formLocator, "container-DSAID___WARE1WAREHDES");
	public SeeMorePage Ware1WarehdesSeeMorePage => new SeeMorePage(driver, "DSAID", "WARE1.WAREHDES");
	/// <summary>
	/// No:
	/// </summary>
	public BaseInputControl OutptDocumenr => new BaseInputControl(driver, formLocator, "#DSAID___OUTPTDOCUMENR");
	/// <summary>
	/// Date:
	/// </summary>
	public DateInputControl OutptDhdocume => new DateInputControl(driver, formLocator, "#DSAID___OUTPTDHDOCUME", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Output:
	/// </summary>
	public ListControl PseudSaidas => new ListControl(driver, formLocator, "#DSAID___PSEUDSAIDAS__");
	/// <summary>
	/// New Output
	/// </summary>
	public ButtonControl PseudSaida => new ButtonControl(driver, formLocator, "#DSAID___PSEUDSAIDA___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public DsaidForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("DSAID")).GetAttribute("data-loading") != "true");
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

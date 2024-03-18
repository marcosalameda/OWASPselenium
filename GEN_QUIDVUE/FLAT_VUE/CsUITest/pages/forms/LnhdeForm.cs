namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhdeForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Order no:
	/// </summary>
	public LookupControl PedidNrpedido => new LookupControl(driver, formLocator, "container-LNHDE___PEDIDNRPEDIDO");
	public SeeMorePage PedidNrpedidoSeeMorePage => new SeeMorePage(driver, "LNHDE", "PEDID.NRPEDIDO");
	/// <summary>
	/// Order line:
	/// </summary>
	public LookupControl LnhpdLine => new LookupControl(driver, formLocator, "container-LNHDE___LNHPDLINE____");
	public SeeMorePage LnhpdLineSeeMorePage => new SeeMorePage(driver, "LNHDE", "LNHPD.LINE");
	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl LnhdeOrdem => new BaseInputControl(driver, formLocator, "#LNHDE___LNHDEORDEM___");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl Tpeq1Tipoequi => new LookupControl(driver, formLocator, "container-LNHDE___TPEQ1TIPOEQUI");
	public SeeMorePage Tpeq1TipoequiSeeMorePage => new SeeMorePage(driver, "LNHDE", "TPEQ1.TIPOEQUI");
	/// <summary>
	/// Quantity:
	/// </summary>
	public BaseInputControl LnhdeQuantida => new BaseInputControl(driver, formLocator, "#LNHDE___LNHDEQUANTIDA");
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl LnhdeCode => new BaseInputControl(driver, formLocator, "#LNHDE___LNHDECODE____");
	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl LnhdeDescript => new BaseInputControl(driver, formLocator, "#LNHDE___LNHDEDESCRIPT");
	/// <summary>
	/// Site
	/// </summary>
	public BaseInputControl LnhdeUrl => new BaseInputControl(driver, formLocator, "#LNHDE___LNHDEURL_____");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LnhdeForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LNHDE")).GetAttribute("data-loading") != "true");
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

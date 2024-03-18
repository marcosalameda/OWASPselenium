namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhagForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// No.
	/// </summary>
	public LookupControl PedidNrpedido => new LookupControl(driver, formLocator, "container-LNHAG___PEDIDNRPEDIDO");
	public SeeMorePage PedidNrpedidoSeeMorePage => new SeeMorePage(driver, "LNHAG", "PEDID.NRPEDIDO");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl Tpeq1Tipoequi => new LookupControl(driver, formLocator, "container-LNHAG___TPEQ1TIPOEQUI");
	public SeeMorePage Tpeq1TipoequiSeeMorePage => new SeeMorePage(driver, "LNHAG", "TPEQ1.TIPOEQUI");
	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl LnhagQtdtpequ => new BaseInputControl(driver, formLocator, "#LNHAG___LNHAGQTDTPEQU");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LnhagForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LNHAG")).GetAttribute("data-loading") != "true");
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

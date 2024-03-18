namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhpdForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Order no:
	/// </summary>
	public LookupControl PedidNrpedido => new LookupControl(driver, formLocator, "container-LNHPD___PEDIDNRPEDIDO");
	public SeeMorePage PedidNrpedidoSeeMorePage => new SeeMorePage(driver, "LNHPD", "PEDID.NRPEDIDO");
	/// <summary>
	/// Line
	/// </summary>
	public BaseInputControl LnhpdLine => new BaseInputControl(driver, formLocator, "#LNHPD___LNHPDLINE____");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, formLocator, "container-LNHPD___TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "LNHPD", "TPEQU.TIPOEQUI");
	/// <summary>
	/// Breaks down
	/// </summary>
	public ButtonControl PseudDesconju => new ButtonControl(driver, formLocator, "#LNHPD___PSEUDDESCONJU");
	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl LnhpdQuantida => new BaseInputControl(driver, formLocator, "#LNHPD___LNHPDQUANTIDA");
	/// <summary>
	/// Breakdown:
	/// </summary>
	public ListControl PseudDesagreg => new ListControl(driver, formLocator, "#LNHPD___PSEUDDESAGREG");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public LnhpdForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("LNHPD")).GetAttribute("data-loading") != "true");
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

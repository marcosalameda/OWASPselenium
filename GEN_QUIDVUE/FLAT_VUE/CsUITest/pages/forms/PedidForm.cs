namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PedidForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Date:
	/// </summary>
	public DateInputControl PedidDtpedido => new DateInputControl(driver, formLocator, "#PEDID___PEDIDDTPEDIDO");
	/// <summary>
	/// Number
	/// </summary>
	public BaseInputControl PedidNrpedido => new BaseInputControl(driver, formLocator, "#PEDID___PEDIDNRPEDIDO");
	/// <summary>
	/// Motive:
	/// </summary>
	public BaseInputControl PedidMotivo => new BaseInputControl(driver, formLocator, "#PEDID___PEDIDMOTIVO__");
	/// <summary>
	/// Lines
	/// </summary>
	public ListControl PseudLinhas => new ListControl(driver, formLocator, "#PEDID___PSEUDLINHAS__");
	/// <summary>
	/// Breakdown:
	/// </summary>
	public ListControl PseudDesagreg => new ListControl(driver, formLocator, "#PEDID___PSEUDDESAGREG");
	/// <summary>
	/// Grouping of Equipment Types
	/// </summary>
	public ListControl PseudAgrupame => new ListControl(driver, formLocator, "#PEDID___PSEUDAGRUPAME");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PedidForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PEDID")).GetAttribute("data-loading") != "true");
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

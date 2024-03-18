namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ReceiForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Receipt date
	/// </summary>
	public DateInputControl ReceiDtreceip => new DateInputControl(driver, formLocator, "#RECEI___RECEIDTRECEIP", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Receipt number
	/// </summary>
	public BaseInputControl ReceiNumber => new BaseInputControl(driver, formLocator, "#RECEI___RECEINUMBER__");
	/// <summary>
	/// Suplier
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, formLocator, "container-RECEI___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "RECEI", "ENTIT.NAME");
	/// <summary>
	/// Receipt lines
	/// </summary>
	public ListControl PseudReceiptl => new ListControl(driver, formLocator, "#RECEI___PSEUDRECEIPTL");
	/// <summary>
	/// Receipt verification
	/// </summary>
	public DateInputControl ReceiDtcheck => new DateInputControl(driver, formLocator, "#RECEI___RECEIDTCHECK_", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// To check
	/// </summary>
	public CheckboxInputControl ReceiTocheck => new CheckboxInputControl(driver, formLocator, "#container-RECEI___RECEITOCHECK_");
	/// <summary>
	/// Checked
	/// </summary>
	public CheckboxInputControl ReceiChecked => new CheckboxInputControl(driver, formLocator, "#container-RECEI___RECEICHECKED_");
	/// <summary>
	/// Stored
	/// </summary>
	public CheckboxInputControl ReceiStored => new CheckboxInputControl(driver, formLocator, "#container-RECEI___RECEISTORED__");
	/// <summary>
	/// Storage date
	/// </summary>
	public DateInputControl ReceiDtstorag => new DateInputControl(driver, formLocator, "#RECEI___RECEIDTSTORAG", "dd/MM/yyyy HH:mm");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ReceiForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("RECEI")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DentrForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, formLocator, "container-DENTR___CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "DENTR", "CNTRY.COUNTRY");
	/// <summary>
	/// Company
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, formLocator, "container-DENTR___CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "DENTR", "CMPNY.DESIGNAT");
	/// <summary>
	/// Person
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, formLocator, "container-DENTR___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "DENTR", "PESSO.NAME");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl Ware1Warehdes => new LookupControl(driver, formLocator, "container-DENTR___WARE1WAREHDES");
	public SeeMorePage Ware1WarehdesSeeMorePage => new SeeMorePage(driver, "DENTR", "WARE1.WAREHDES");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl IndocDate => new DateInputControl(driver, formLocator, "#DENTR___INDOCDATE____", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// No.
	/// </summary>
	public BaseInputControl IndocDocumenr => new BaseInputControl(driver, formLocator, "#DENTR___INDOCDOCUMENR");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl IndocDhdocume => new DateInputControl(driver, formLocator, "#DENTR___INDOCDHDOCUME", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Entries
	/// </summary>
	public ListControl PseudEntradas => new ListControl(driver, formLocator, "#DENTR___PSEUDENTRADAS");
	/// <summary>
	/// Normal Form
	/// </summary>
	public ButtonControl PseudNormal => new ButtonControl(driver, formLocator, "#DENTR___PSEUDNORMAL__");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public DentrForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("DENTR")).GetAttribute("data-loading") != "true");
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

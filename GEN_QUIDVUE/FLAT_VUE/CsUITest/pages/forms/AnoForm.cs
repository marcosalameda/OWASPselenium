namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AnoForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl YearYear => new BaseInputControl(driver, formLocator, "#ANO_____YEAR_YEAR____");
	/// <summary>
	/// Year (numbers)
	/// </summary>
	public BaseInputControl YearYearnum => new BaseInputControl(driver, formLocator, "#ANO_____YEAR_YEARNUM_");
	/// <summary>
	/// All the expenses
	/// </summary>
	public ListControl PseudTodasdes => new ListControl(driver, formLocator, "#ANO_____PSEUDTODASDES");
	/// <summary>
	/// Aggregated per year
	/// </summary>
	public ListControl PseudAgregado => new ListControl(driver, formLocator, "#ANO_____PSEUDAGREGADO");
	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl YearValue => new BaseInputControl(driver, formLocator, "#ANO_____YEAR_VALUE___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AnoForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ANO")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProjeForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Project
	/// </summary>
	public BaseInputControl ProjeProjecto => new BaseInputControl(driver, formLocator, "#PROJE___PROJEPROJECTO");
	/// <summary>
	/// Year
	/// </summary>
	public LookupControl Year1Year => new LookupControl(driver, formLocator, "container-PROJE___YEAR1YEAR____");
	public SeeMorePage Year1YearSeeMorePage => new SeeMorePage(driver, "PROJE", "YEAR1.YEAR");
	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl ProjePrimeiro => new BaseInputControl(driver, formLocator, "#PROJE___PROJEPRIMEIRO");
	/// <summary>
	/// Before
	/// </summary>
	public BaseInputControl ProjeBefore => new BaseInputControl(driver, formLocator, "#PROJE___PROJEBEFORE__");
	/// <summary>
	/// Following
	/// </summary>
	public BaseInputControl ProjeFollowin => new BaseInputControl(driver, formLocator, "#PROJE___PROJEFOLLOWIN");
	/// <summary>
	/// Last
	/// </summary>
	public BaseInputControl ProjeUltimo => new BaseInputControl(driver, formLocator, "#PROJE___PROJEULTIMO__");
	/// <summary>
	/// Next - previous =
	/// </summary>
	public BaseInputControl ProjeSaldo1 => new BaseInputControl(driver, formLocator, "#PROJE___PROJESALDO1__");
	/// <summary>
	/// Last - First =
	/// </summary>
	public BaseInputControl ProjeSaldo2 => new BaseInputControl(driver, formLocator, "#PROJE___PROJESALDO2__");
	/// <summary>
	/// Expenses
	/// </summary>
	public ListControl PseudDespesas => new ListControl(driver, formLocator, "#PROJE___PSEUDDESPESAS");
	/// <summary>
	/// Decomission by year
	/// </summary>
	public ListControl PseudAgregado => new ListControl(driver, formLocator, "#PROJE___PSEUDAGREGADO");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ProjeForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PROJE")).GetAttribute("data-loading") != "true");
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

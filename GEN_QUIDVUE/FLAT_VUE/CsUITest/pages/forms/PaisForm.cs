namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PaisForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Country
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#PAIS____PSEUDNOVOGR02-container");
	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl CntryCountry => new BaseInputControl(driver, formLocator, "#PAIS____CNTRYCOUNTRY_");
	/// <summary>
	/// Active
	/// </summary>
	public CheckboxInputControl CntryActive => new CheckboxInputControl(driver, formLocator, "#container-PAIS____CNTRYACTIVE__");
	/// <summary>
	/// Country code
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PAIS____PSEUDNOVOGR01-container");
	/// <summary>
	/// Numeric
	/// </summary>
	public BaseInputControl CntryCodigonr => new BaseInputControl(driver, formLocator, "#PAIS____CNTRYCODIGONR");
	/// <summary>
	/// Alphabetic 2:
	/// </summary>
	public BaseInputControl CntryAlfa2 => new BaseInputControl(driver, formLocator, "#PAIS____CNTRYALFA2___");
	/// <summary>
	/// Alphabetic 3:
	/// </summary>
	public BaseInputControl CntryAlfa3 => new BaseInputControl(driver, formLocator, "#PAIS____CNTRYALFA3___");
	/// <summary>
	/// Bandeira
	/// </summary>
	public BaseInputControl CntryFlag => new BaseInputControl(driver, formLocator, "#PAIS____CNTRYFLAG____");
	/// <summary>
	/// real estate
	/// </summary>
	public Propr00Form  PseudImovel => new Propr00Form(driver, FORM_MODE.EDIT, By.Id("PAIS____PSEUDIMOVEL__"));
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#PAIS____PSEUDNOVOGR04-container");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#PAIS____PSEUDNOVOGR03-container");
	/// <summary>
	/// Real Estate List
	/// </summary>
	public ListControl PseudProprie1 => new ListControl(driver, formLocator, "#PAIS____PSEUDPROPRIE1");
	/// <summary>
	/// Real State Map
	/// </summary>
	public ListControl PseudPropried => new ListControl(driver, formLocator, "#PAIS____PSEUDPROPRIED");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PaisForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PAIS")).GetAttribute("data-loading") != "true");
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

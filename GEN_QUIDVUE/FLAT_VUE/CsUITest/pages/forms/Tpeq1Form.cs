namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Tpeq1Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Equipment family
	/// </summary>
	public LookupControl Fami1Family => new LookupControl(driver, formLocator, "container-TPEQ1___FAMI1FAMILY__");
	public SeeMorePage Fami1FamilySeeMorePage => new SeeMorePage(driver, "TPEQ1", "FAMI1.FAMILY");
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl Tpeq1Tpequcod => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1TPEQUCOD");
	/// <summary>
	/// Level:
	/// </summary>
	public BaseInputControl Tpeq1Nivel => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1NIVEL___");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public BaseInputControl Tpeq1Tipoequi => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1TIPOEQUI");
	/// <summary>
	/// Dependence on
	/// </summary>
	public BaseInputControl Tpeq1Tpequpai => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1TPEQUPAI");
	/// <summary>
	/// Background Color
	/// </summary>
	public BaseInputControl Tpeq1Backcolo => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1BACKCOLO");
	/// <summary>
	/// Letter Color:
	/// </summary>
	public BaseInputControl Tpeq1Corletra => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1CORLETRA");
	/// <summary>
	/// Maximum Price
	/// </summary>
	public BaseInputControl Tpeq1Precomax => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1PRECOMAX");
	/// <summary>
	/// Last price
	/// </summary>
	public BaseInputControl Tpeq1Precoult => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1PRECOULT");
	/// <summary>
	/// In
	/// </summary>
	public DateInputControl Tpeq1Since => new DateInputControl(driver, formLocator, "#TPEQ1___TPEQ1SINCE___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl Tpeq1Qtdequip => new BaseInputControl(driver, formLocator, "#TPEQ1___TPEQ1QTDEQUIP");
	/// <summary>
	/// Kit
	/// </summary>
	public CheckboxInputControl Tpeq1Kit => new CheckboxInputControl(driver, formLocator, "#container-TPEQ1___TPEQ1KIT_____");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Tpeq1Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("TPEQ1")).GetAttribute("data-loading") != "true");
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

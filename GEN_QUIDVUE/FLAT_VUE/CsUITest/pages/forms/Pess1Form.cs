namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pess1Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, formLocator, "container-PESS1___CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "PESS1", "CMPNY.DESIGNAT");
	/// <summary>
	/// Interested
	/// </summary>
	public LookupControl StakeDesignat => new LookupControl(driver, formLocator, "container-PESS1___STAKEDESIGNAT");
	public SeeMorePage StakeDesignatSeeMorePage => new SeeMorePage(driver, "PESS1", "STAKE.DESIGNAT");
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl Pess1Name => new BaseInputControl(driver, formLocator, "#PESS1___PESS1NAME____");
	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl Pess1Gender => new EnumControl(driver, formLocator, "container-PESS1___PESS1GENDER__");
	/// <summary>
	/// Birth
	/// </summary>
	public DateInputControl Pess1Dtnascim => new DateInputControl(driver, formLocator, "#PESS1___PESS1DTNASCIM");
	/// <summary>
	/// Employee No.
	/// </summary>
	public BaseInputControl Pess1Idfuncio => new BaseInputControl(driver, formLocator, "#PESS1___PESS1IDFUNCIO");
	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl Pess1Telephon => new BaseInputControl(driver, formLocator, "#PESS1___PESS1TELEPHON");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl Pess1Email => new BaseInputControl(driver, formLocator, "#PESS1___PESS1EMAIL___");
	/// <summary>
	/// Email (confirm)
	/// </summary>
	public BaseInputControl Pess1Email2 => new BaseInputControl(driver, formLocator, "#PESS1___PESS1EMAIL2__");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl Pess1Photogra => new BaseInputControl(driver, formLocator, "#PESS1___PESS1PHOTOGRA");
	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl Pess1Dtultcat => new DateInputControl(driver, formLocator, "#PESS1___PESS1DTULTCAT");
	/// <summary>
	/// External
	/// </summary>
	public CheckboxInputControl Pess1Externa => new CheckboxInputControl(driver, formLocator, "#container-PESS1___PESS1EXTERNA_");
	/// <summary>
	/// Intern
	/// </summary>
	public CheckboxInputControl Pess1Interna => new CheckboxInputControl(driver, formLocator, "#container-PESS1___PESS1INTERNA_");
	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl Pess1Idade => new BaseInputControl(driver, formLocator, "#PESS1___PESS1IDADE___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Pess1Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PESS1")).GetAttribute("data-loading") != "true");
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

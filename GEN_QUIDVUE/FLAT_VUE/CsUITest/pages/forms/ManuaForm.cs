namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ManuaForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, formLocator, "container-MANUA___KINDEDESIGNAT");
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "MANUA", "KINDE.DESIGNAT");
	/// <summary>
	/// Manual name
	/// </summary>
	public BaseInputControl ManuaName => new BaseInputControl(driver, formLocator, "#MANUA___MANUANAME____");
	/// <summary>
	/// Digital document
	/// </summary>
	public BaseInputControl ManuaDigdocum => new BaseInputControl(driver, formLocator, "#MANUA___MANUADIGDOCUM");
	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl ManuaNotes => new BaseInputControl(driver, formLocator, "#MANUA___MANUANOTES___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ManuaForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("MANUA")).GetAttribute("data-loading") != "true");
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

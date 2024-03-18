namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ParamForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, formLocator, "container-PARAM___KINDEDESIGNAT");
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "PARAM", "KINDE.DESIGNAT");
	/// <summary>
	/// Parameter
	/// </summary>
	public BaseInputControl ParamParamete => new BaseInputControl(driver, formLocator, "#PARAM___PARAMPARAMETE");
	/// <summary>
	/// Data type
	/// </summary>
	public EnumControl ParamDatatype => new EnumControl(driver, formLocator, "container-PARAM___PARAMDATATYPE");
	/// <summary>
	/// Decimal places
	/// </summary>
	public EnumControl ParamDecplace => new EnumControl(driver, formLocator, "container-PARAM___PARAMDECPLACE");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ParamForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PARAM")).GetAttribute("data-loading") != "true");
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

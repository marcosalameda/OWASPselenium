namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RoigfForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl Rogl1Title => new LookupControl(driver, formLocator, "container-ROIGF___ROGL1TITLE___");
	public SeeMorePage Rogl1TitleSeeMorePage => new SeeMorePage(driver, "ROIGF", "ROGL1.TITLE");
	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl RoigfOrder => new BaseInputControl(driver, formLocator, "#ROIGF___ROIGFORDER___");
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl RoigfTitle => new BaseInputControl(driver, formLocator, "#ROIGF___ROIGFTITLE___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public RoigfForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ROIGF")).GetAttribute("data-loading") != "true");
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

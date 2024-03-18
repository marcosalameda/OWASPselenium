namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FeecaForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Description
	/// </summary>
	public LookupControl FldsDescrip => new LookupControl(driver, formLocator, "container-FEECA___FLDS_DESCRIP_");
	public SeeMorePage FldsDescripSeeMorePage => new SeeMorePage(driver, "FEECA", "FLDS.DESCRIP");
	/// <summary>
	/// Feedback
	/// </summary>
	public BaseInputControl FeecaFeedback => new BaseInputControl(driver, formLocator, "#FEECA___FEECAFEEDBACK");
	/// <summary>
	/// Attachments
	/// </summary>
	public IWebElement FldsAttach => throw new NotImplementedException();
	/// <summary>
	/// Passenger capacity on the plane
	/// </summary>
	public IWebElement FldsNpassage => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public FeecaForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("FEECA")).GetAttribute("data-loading") != "true");
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

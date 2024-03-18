namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AttacForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Identification name
	/// </summary>
	public LookupControl AssetName => new LookupControl(driver, formLocator, "container-ATTAC___ASSETNAME____");
	public SeeMorePage AssetNameSeeMorePage => new SeeMorePage(driver, "ATTAC", "ASSET.NAME");
	/// <summary>
	/// Attached
	/// </summary>
	public DateInputControl AttacAttached => new DateInputControl(driver, formLocator, "#ATTAC___ATTACATTACHED", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Note
	/// </summary>
	public BaseInputControl AttacNote => new BaseInputControl(driver, formLocator, "#ATTAC___ATTACNOTE____");
	/// <summary>
	/// Document
	/// </summary>
	public BaseInputControl AttacDocument => new BaseInputControl(driver, formLocator, "#ATTAC___ATTACDOCUMENT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AttacForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ATTAC")).GetAttribute("data-loading") != "true");
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

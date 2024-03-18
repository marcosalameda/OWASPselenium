namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AssmaForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Identification name
	/// </summary>
	public LookupControl AssetName => new LookupControl(driver, formLocator, "container-ASSMA___ASSETNAME____");
	public SeeMorePage AssetNameSeeMorePage => new SeeMorePage(driver, "ASSMA", "ASSET.NAME");
	/// <summary>
	/// Manual name
	/// </summary>
	public BaseInputControl AssmaName => new BaseInputControl(driver, formLocator, "#ASSMA___ASSMANAME____");
	/// <summary>
	/// Digital document
	/// </summary>
	public BaseInputControl AssmaDigdocum => new BaseInputControl(driver, formLocator, "#ASSMA___ASSMADIGDOCUM");
	/// <summary>
	/// Notes
	/// </summary>
	public BaseInputControl AssmaNotes => new BaseInputControl(driver, formLocator, "#ASSMA___ASSMANOTES___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AssmaForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ASSMA")).GetAttribute("data-loading") != "true");
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

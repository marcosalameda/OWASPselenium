namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FactyForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Facility type
	/// </summary>
	public BaseInputControl FactyType => new BaseInputControl(driver, formLocator, "#FACTY___FACTYTYPE____");
	/// <summary>
	/// Layer name
	/// </summary>
	public BaseInputControl FactyLayrname => new BaseInputControl(driver, formLocator, "#FACTY___FACTYLAYRNAME");
	/// <summary>
	/// Icon URL
	/// </summary>
	public BaseInputControl FactyIconurl => new BaseInputControl(driver, formLocator, "#FACTY___FACTYICONURL_");
	/// <summary>
	/// Shadow URL
	/// </summary>
	public BaseInputControl FactyShadowur => new BaseInputControl(driver, formLocator, "#FACTY___FACTYSHADOWUR");
	/// <summary>
	/// Icon anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyIconancx => new BaseInputControl(driver, formLocator, "#FACTY___FACTYICONANCX");
	/// <summary>
	/// Icon anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyIconancy => new BaseInputControl(driver, formLocator, "#FACTY___FACTYICONANCY");
	/// <summary>
	/// Icon height
	/// </summary>
	public BaseInputControl FactyIconheig => new BaseInputControl(driver, formLocator, "#FACTY___FACTYICONHEIG");
	/// <summary>
	/// Icon width
	/// </summary>
	public BaseInputControl FactyIconwid => new BaseInputControl(driver, formLocator, "#FACTY___FACTYICONWID_");
	/// <summary>
	/// Popup anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyPopupanx => new BaseInputControl(driver, formLocator, "#FACTY___FACTYPOPUPANX");
	/// <summary>
	/// Popup anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyPopupany => new BaseInputControl(driver, formLocator, "#FACTY___FACTYPOPUPANY");
	/// <summary>
	/// Shadow anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyShadowax => new BaseInputControl(driver, formLocator, "#FACTY___FACTYSHADOWAX");
	/// <summary>
	/// Shadow anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyShadoway => new BaseInputControl(driver, formLocator, "#FACTY___FACTYSHADOWAY");
	/// <summary>
	/// Shadow height
	/// </summary>
	public BaseInputControl FactyShadowhe => new BaseInputControl(driver, formLocator, "#FACTY___FACTYSHADOWHE");
	/// <summary>
	/// Shadow width
	/// </summary>
	public BaseInputControl FactyShadowwi => new BaseInputControl(driver, formLocator, "#FACTY___FACTYSHADOWWI");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public FactyForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("FACTY")).GetAttribute("data-loading") != "true");
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

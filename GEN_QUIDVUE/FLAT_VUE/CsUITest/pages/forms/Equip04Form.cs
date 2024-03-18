namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip04Form: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#EQUIP04_PSEUDNOVOGR01-container");
	/// <summary>
	/// Parameters load
	/// </summary>
	public ButtonControl PseudParamloa => new ButtonControl(driver, formLocator, "#EQUIP04_PSEUDPARAMLOA");
	/// <summary>
	/// Manuals load
	/// </summary>
	public ButtonControl PseudManuals => new ButtonControl(driver, formLocator, "#EQUIP04_PSEUDMANUALS_");
	/// <summary>
	/// Parameters
	/// </summary>
	public ListControl PseudParamete => new ListControl(driver, formLocator, "#EQUIP04_PSEUDPARAMETE");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public Equip04Form(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("EQUIP04")).GetAttribute("data-loading") != "true");
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

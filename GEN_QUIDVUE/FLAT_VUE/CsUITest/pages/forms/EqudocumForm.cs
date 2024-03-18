namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EqudocumForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Designation
	/// </summary>
	public BaseInputControl EquipDesignat => new BaseInputControl(driver, formLocator, "#EQUDOCUMEQUIPDESIGNAT");
	/// <summary>
	/// Add ANEXD
	/// </summary>
	public ButtonControl PseudBtn_anex => new ButtonControl(driver, formLocator, "#EQUDOCUMPSEUDBTN_ANEX");
	/// <summary>
	/// Digital Attachements
	/// </summary>
	public ListControl PseudLisanex => new ListControl(driver, formLocator, "#EQUDOCUMPSEUDLISANEX_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public EqudocumForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("EQUDOCUM")).GetAttribute("data-loading") != "true");
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

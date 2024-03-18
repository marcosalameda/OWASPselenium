namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AnexdForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// No. register
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-ANEXD___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "ANEXD", "EQUIP.REGISTNR");
	/// <summary>
	/// Attached
	/// </summary>
	public DateInputControl AnexdDthranex => new DateInputControl(driver, formLocator, "#ANEXD___ANEXDDTHRANEX", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Reference
	/// </summary>
	public BaseInputControl AnexdReferenc => new BaseInputControl(driver, formLocator, "#ANEXD___ANEXDREFERENC");
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl AnexdTitle => new BaseInputControl(driver, formLocator, "#ANEXD___ANEXDTITLE___");
	/// <summary>
	/// Language
	/// </summary>
	public LookupControl LanguLangua => new LookupControl(driver, formLocator, "container-ANEXD___LANGULANGUA__");
	public SeeMorePage LanguLanguaSeeMorePage => new SeeMorePage(driver, "ANEXD", "LANGU.LANGUA");
	/// <summary>
	/// Translated Title
	/// </summary>
	public BaseInputControl AnexdTittradu => new BaseInputControl(driver, formLocator, "#ANEXD___ANEXDTITTRADU");
	/// <summary>
	/// Document
	/// </summary>
	public BaseInputControl AnexdDocument => new BaseInputControl(driver, formLocator, "#ANEXD___ANEXDDOCUMENT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AnexdForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ANEXD")).GetAttribute("data-loading") != "true");
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

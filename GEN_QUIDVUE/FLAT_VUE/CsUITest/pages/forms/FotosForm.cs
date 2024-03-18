namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FotosForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-FOTOS___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "FOTOS", "EQUIP.REGISTNR");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PhotoPhotogra => new BaseInputControl(driver, formLocator, "#FOTOS___PHOTOPHOTOGRA");
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PhotoTitle => new BaseInputControl(driver, formLocator, "#FOTOS___PHOTOTITLE___");
	/// <summary>
	/// Attached:
	/// </summary>
	public DateInputControl PhotoAnexed => new DateInputControl(driver, formLocator, "#FOTOS___PHOTOANEXED__", "dd/MM/yyyy HH:mm");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public FotosForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("FOTOS")).GetAttribute("data-loading") != "true");
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

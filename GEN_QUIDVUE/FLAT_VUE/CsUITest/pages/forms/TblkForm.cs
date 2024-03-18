namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TblkForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl TblkName => new BaseInputControl(driver, formLocator, "#TBLK____TBLK_NAME____");
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl GrpbName => new LookupControl(driver, formLocator, "container-TBLK____GRPB_NAME____");
	public SeeMorePage GrpbNameSeeMorePage => new SeeMorePage(driver, "TBLK", "GRPB.NAME");
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl TrsbName => new LookupControl(driver, formLocator, "container-TBLK____TRSB_NAME____");
	public SeeMorePage TrsbNameSeeMorePage => new SeeMorePage(driver, "TBLK", "TRSB.NAME");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public TblkForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("TBLK")).GetAttribute("data-loading") != "true");
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

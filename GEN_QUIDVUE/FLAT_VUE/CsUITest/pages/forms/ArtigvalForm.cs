namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigvalForm: PageObject {

	private By formLocator = By.CssSelector("#q-modal-form-ARTIGVAL");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, formLocator, "#ARTIGVALITEM_IMAGE___");
	/// <summary>
	/// Global Item
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, formLocator, "container-ARTIGVALGITEMITEMDES_");
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIGVAL", "GITEM.ITEMDES");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-ARTIGVALWAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIGVAL", "WAREH.WAREHDES");
	/// <summary>
	/// Tipo
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, formLocator, "container-ARTIGVALITEM_ITEMTYPE");
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, formLocator, "#ARTIGVALITEM_ITEMCOD_");
	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, formLocator, "#ARTIGVALITEM_ITEMDES_");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ItemDate => new DateInputControl(driver, formLocator, "#ARTIGVALITEM_DATE____");
	/// <summary>
	/// Entries
	/// </summary>
	public BaseInputControl ItemEntries => new BaseInputControl(driver, formLocator, "#ARTIGVALITEM_ENTRIES_");
	/// <summary>
	/// Output:
	/// </summary>
	public BaseInputControl ItemExits => new BaseInputControl(driver, formLocator, "#ARTIGVALITEM_EXITS___");
	/// <summary>
	/// Existence
	/// </summary>
	public BaseInputControl ItemExistenc => new BaseInputControl(driver, formLocator, "#ARTIGVALITEM_EXISTENC");
	/// <summary>
	/// Categorization
	/// </summary>
	public BaseInputControl ItemCategory => new BaseInputControl(driver, formLocator, "#ARTIGVALITEM_CATEGORY");
	/// <summary>
	/// Availability
	/// </summary>
	public BaseInputControl ItemDisponib => new BaseInputControl(driver, formLocator, "#ARTIGVALITEM_DISPONIB");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ArtigvalForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARTIGVAL")).GetAttribute("data-loading") != "true");
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

namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl ItemItemcod => new BaseInputControl(driver, formLocator, "#ARTIG___ITEM_ITEMCOD_");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-ARTIG___WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "ARTIG", "WAREH.WAREHDES");
	/// <summary>
	/// Code
	/// </summary>
	public IWebElement GitemItemgcod => throw new NotImplementedException();
	/// <summary>
	/// Designation:
	/// </summary>
	public LookupControl GitemItemdes => new LookupControl(driver, formLocator, "container-ARTIG___GITEMITEMDES_");
	public SeeMorePage GitemItemdesSeeMorePage => new SeeMorePage(driver, "ARTIG", "GITEM.ITEMDES");
	/// <summary>
	/// Warehouse
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#ARTIG___PSEUDNOVOGR02-container");
	/// <summary>
	/// Global Item
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#ARTIG___PSEUDNOVOGR01-container");
	/// <summary>
	/// Item
	/// </summary>
	public BaseInputControl ItemItemdes => new BaseInputControl(driver, formLocator, "#ARTIG___ITEM_ITEMDES_");
	/// <summary>
	/// In use
	/// </summary>
	public CheckboxInputControl ItemValid => new CheckboxInputControl(driver, formLocator, "#container-ARTIG___ITEM_VALID___");
	/// <summary>
	/// Tipo
	/// </summary>
	public EnumControl ItemItemtype => new EnumControl(driver, formLocator, "container-ARTIG___ITEM_ITEMTYPE");
	/// <summary>
	/// Entries:
	/// </summary>
	public BaseInputControl ItemEntries => new BaseInputControl(driver, formLocator, "#ARTIG___ITEM_ENTRIES_");
	/// <summary>
	/// Output:
	/// </summary>
	public BaseInputControl ItemExits => new BaseInputControl(driver, formLocator, "#ARTIG___ITEM_EXITS___");
	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl ItemImage => new BaseInputControl(driver, formLocator, "#ARTIG___ITEM_IMAGE___");
	/// <summary>
	/// Item
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, formLocator, "#ARTIG___PSEUDNOVOGR07-container");
	/// <summary>
	/// Sequential Movements
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#ARTIG___PSEUDNOVOGR03-container");
	/// <summary>
	/// Movements
	/// </summary>
	public ListControl PseudContacor => new ListControl(driver, formLocator, "#ARTIG___PSEUDCONTACOR");
	/// <summary>
	/// Movements by type
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#ARTIG___PSEUDNOVOGR04-container");
	/// <summary>
	/// Entries
	/// </summary>
	public ListControl PseudLentrada => new ListControl(driver, formLocator, "#ARTIG___PSEUDLENTRADA");
	/// <summary>
	/// Output:
	/// </summary>
	public ListControl PseudLsaidas => new ListControl(driver, formLocator, "#ARTIG___PSEUDLSAIDAS_");
	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();
	/// <summary>
	/// Categorization
	/// </summary>
	public IWebElement PseudCategori => throw new NotImplementedException();
	/// <summary>
	/// Chosen Categories
	/// </summary>
	public IWebElement PseudEsccateg => throw new NotImplementedException();
	/// <summary>
	/// Filtered Checklist
	/// </summary>
	public IWebElement PseudCategor => throw new NotImplementedException();
	/// <summary>
	/// Categorization
	/// </summary>
	public BaseInputControl ItemCategory => new BaseInputControl(driver, formLocator, "#ARTIG___ITEM_CATEGORY");
	/// <summary>
	/// Categorization
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();
	/// <summary>
	/// Existence
	/// </summary>
	public BaseInputControl ItemExistenc => new BaseInputControl(driver, formLocator, "#ARTIG___ITEM_EXISTENC");
	/// <summary>
	/// Availability
	/// </summary>
	public BaseInputControl ItemDisponib => new BaseInputControl(driver, formLocator, "#ARTIG___ITEM_DISPONIB");
	/// <summary>
	/// Image
	/// </summary>
	public IWebElement PseudNovogr08 => throw new NotImplementedException();
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ItemDate => new DateInputControl(driver, formLocator, "#ARTIG___ITEM_DATE____");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ArtigForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ARTIG")).GetAttribute("data-loading") != "true");
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

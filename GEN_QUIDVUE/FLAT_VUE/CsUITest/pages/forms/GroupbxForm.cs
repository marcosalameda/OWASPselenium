namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GroupbxForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Whole Line Off
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#GROUPBX_PSEUDNOVOGR01-container");
	/// <summary>
	/// Sequential No.:
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, formLocator, "#GROUPBX_EQUIPSEQUENNR");
	/// <summary>
	/// Registration No.
	/// </summary>
	public BaseInputControl EquipRegistnr => new BaseInputControl(driver, formLocator, "#GROUPBX_EQUIPREGISTNR");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, formLocator, "container-GROUPBX_TPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "GROUPBX", "TPEQU.TIPOEQUI");
	/// <summary>
	/// Manufacturer's website:
	/// </summary>
	public BaseInputControl EquipSitefabr => new BaseInputControl(driver, formLocator, "#GROUPBX_EQUIPSITEFABR");
	/// <summary>
	/// Warehouse
	/// </summary>
	public LookupControl WarehWarehdes => new LookupControl(driver, formLocator, "container-GROUPBX_WAREHWAREHDES");
	public SeeMorePage WarehWarehdesSeeMorePage => new SeeMorePage(driver, "GROUPBX", "WAREH.WAREHDES");
	/// <summary>
	/// Item:
	/// </summary>
	public LookupControl ItemItemdes => new LookupControl(driver, formLocator, "container-GROUPBX_ITEM_ITEMDES_");
	public SeeMorePage ItemItemdesSeeMorePage => new SeeMorePage(driver, "GROUPBX", "ITEM.ITEMDES");
	/// <summary>
	/// Whole Line On
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#GROUPBX_PSEUDNOVOGR02-container");
	/// <summary>
	/// Decomission:
	/// </summary>
	public DateInputControl EquipDtdeco => new DateInputControl(driver, formLocator, "#GROUPBX_EQUIPDTDECO__");
	/// <summary>
	/// Room No.
	/// </summary>
	public BaseInputControl Room1Roomnr => new BaseInputControl(driver, formLocator, "#GROUPBX_ROOM1ROOMNR__");
	/// <summary>
	/// Room Designation
	/// </summary>
	public IWebElement Room1Designat => throw new NotImplementedException();
	/// <summary>
	/// Designation:
	/// </summary>
	public BaseInputControl EquipDesignat => new BaseInputControl(driver, formLocator, "#GROUPBX_EQUIPDESIGNAT");
	/// <summary>
	/// Acquisition:
	/// </summary>
	public DateInputControl EquipDtaquisi => new DateInputControl(driver, formLocator, "#GROUPBX_EQUIPDTAQUISI");
	/// <summary>
	/// Total Value:
	/// </summary>
	public BaseInputControl EquipValortot => new BaseInputControl(driver, formLocator, "#GROUPBX_EQUIPVALORTOT");
	/// <summary>
	/// Loan Frequency
	/// </summary>
	public EnumControl EquipFrequenc => new EnumControl(driver, formLocator, "container-GROUPBX_EQUIPFREQUENC");
	/// <summary>
	/// Reference
	/// </summary>
	public DateInputControl EquipDtrefere => new DateInputControl(driver, formLocator, "#GROUPBX_EQUIPDTREFERE", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl EquipFirst => new BaseInputControl(driver, formLocator, "#GROUPBX_EQUIPFIRST___");
	/// <summary>
	/// Before
	/// </summary>
	public BaseInputControl EquipBefore => new BaseInputControl(driver, formLocator, "#GROUPBX_EQUIPBEFORE__");
	/// <summary>
	/// Bought
	/// </summary>
	public CheckboxInputControl EquipBought => new CheckboxInputControl(driver, formLocator, "#container-GROUPBX_EQUIPBOUGHT__");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public GroupbxForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("GROUPBX")).GetAttribute("data-loading") != "true");
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

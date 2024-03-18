namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpequForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#TPEQU___PSEUDNOVOGR01-container");
	/// <summary>
	/// Equipment family
	/// </summary>
	public LookupControl FamilFamily => new LookupControl(driver, formLocator, "container-TPEQU___FAMILFAMILY__");
	public SeeMorePage FamilFamilySeeMorePage => new SeeMorePage(driver, "TPEQU", "FAMIL.FAMILY");
	/// <summary>
	/// Type of equipment
	/// </summary>
	public BaseInputControl TpequTipoequi => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUTIPOEQUI");
	/// <summary>
	/// Code
	/// </summary>
	public BaseInputControl TpequTpequcod => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUTPEQUCOD");
	/// <summary>
	/// Level:
	/// </summary>
	public BaseInputControl TpequNivel => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUNIVEL___");
	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr05 => throw new NotImplementedException();
	/// <summary>
	/// SET
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#TPEQU___PSEUDNOVOGR04-container");
	/// <summary>
	/// Kit
	/// </summary>
	public CheckboxInputControl TpequKit => new CheckboxInputControl(driver, formLocator, "#container-TPEQU___TPEQUKIT_____");
	/// <summary>
	/// Maximum Price
	/// </summary>
	public BaseInputControl TpequPrecomax => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUPRECOMAX");
	/// <summary>
	/// Background Color
	/// </summary>
	public BaseInputControl TpequBackcolo => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUBACKCOLO");
	/// <summary>
	/// Letter Color
	/// </summary>
	public BaseInputControl TpequCorletra => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUCORLETRA");
	/// <summary>
	/// Dependence on
	/// </summary>
	public BaseInputControl TpequTpequpai => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUTPEQUPAI");
	/// <summary>
	/// Last Price
	/// </summary>
	public BaseInputControl TpequPrecoult => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUPRECOULT");
	/// <summary>
	/// Since
	/// </summary>
	public DateInputControl TpequSince => new DateInputControl(driver, formLocator, "#TPEQU___TPEQUSINCE___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Componentes do kit
	/// </summary>
	public ListControl PseudComponen => new ListControl(driver, formLocator, "#TPEQU___PSEUDCOMPONEN");
	/// <summary>
	/// PRICES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, formLocator, "#TPEQU___PSEUDNOVOGR03-container");
	/// <summary>
	/// c
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, formLocator, "#TPEQU___PSEUDEVOLUCAO");
	/// <summary>
	/// HIGHLIGHT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#TPEQU___PSEUDNOVOGR02-container");
	/// <summary>
	/// Unique
	/// </summary>
	public ButtonControl PseudUnico => new ButtonControl(driver, formLocator, "#TPEQU___PSEUDUNICO___");
	/// <summary>
	/// FACILITIES
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, formLocator, "#TPEQU___PSEUDNOVOGR06-container");
	/// <summary>
	/// Facilities:
	/// </summary>
	public ListControl PseudInstalac => new ListControl(driver, formLocator, "#TPEQU___PSEUDINSTALAC");
	/// <summary>
	/// Map with facilities:
	/// </summary>
	public ListControl PseudInstala1 => new ListControl(driver, formLocator, "#TPEQU___PSEUDINSTALA1");
	/// <summary>
	/// Quantity of equipment:
	/// </summary>
	public BaseInputControl TpequQtdequip => new BaseInputControl(driver, formLocator, "#TPEQU___TPEQUQTDEQUIP");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public TpequForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("TPEQU")).GetAttribute("data-loading") != "true");
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

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip_emptyForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
    public LookupControl CntryCountry_FG => new LookupControl(driver, ContainerLocator, "container-EQUIP_EMPTY__CNTRY__COUNTRY_FG");

	/// <summary>
	/// Designation
	/// </summary>
    public LookupControl CmpnyDesignat_FG => new LookupControl(driver, ContainerLocator, "container-EQUIP_EMPTY__CMPNY__DESIGNAT_FG");

	/// <summary>
	/// Name
	/// </summary>
    public LookupControl Pess1Name_FG => new LookupControl(driver, ContainerLocator, "container-EQUIP_EMPTY__PESS1__NAME_FG");

	/// <summary>
	/// Show record
	/// </summary>
    public CheckboxInputControl EquipShowrc_FG => new CheckboxInputControl(driver, ContainerLocator, "#container-EQUIP_EMPTY__EQUIP__SHOWRC_FG");

	/// <summary>
	/// Downed equipment
	/// </summary>
	public CheckboxInputControl EquipIfabatif => new CheckboxInputControl(driver, ContainerLocator, "#container-EQUIP_EMPTY__EQUIP__IFABATIF");

	/// <summary>
	/// Loan frequency
	/// </summary>
    public CheckboxGroupControl EquipFrequenc_FG => new CheckboxGroupControl(driver, ContainerLocator, "container-EQUIP_EMPTY__EQUIP__FREQUENC_FG");

	/// <summary>
	/// Article
	/// </summary>
	public IWebElement ItemItemdes_FG => throw new NotImplementedException();

	/// <summary>
	/// TYPE OF EQUIPMENT
	/// </summary>
	public IWebElement TpequTipoequi_FG => throw new NotImplementedException();

	/// <summary>
	/// Equipment
	/// </summary>
	public ListControl PseudEquip_filtrado => new ListControl(driver, ContainerLocator, "#EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO");

	public Equip_emptyForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EQUIP_EMPTY", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class VendaForm : Form
{
	/// <summary>
	/// Organization
	/// </summary>
	public LookupControl OrganOrganiza => new LookupControl(driver, ContainerLocator, "container-VENDA___ORGANORGANIZA");
	public SeeMorePage OrganOrganizaSeeMorePage => new SeeMorePage(driver, "VENDA", "VENDA___ORGANORGANIZA");

	/// <summary>
	/// leader no.
	/// </summary>
	public BaseInputControl SaleNrlide => new BaseInputControl(driver, ContainerLocator, "#VENDA___SALE_NRLIDE__");

	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl SaleStartdt => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_STARTDT_", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Prospection
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDA___PSEUDNOVOGR01-container");

	/// <summary>
	/// Identification of business opportunity
	/// </summary>
	public BaseInputControl SaleIdentifi => new BaseInputControl(driver, ContainerLocator, "#VENDA___SALE_IDENTIFI");

	/// <summary>
	/// Potential Buyers
	/// </summary>
	public BaseInputControl SalePotcompr => new BaseInputControl(driver, ContainerLocator, "#VENDA___SALE_POTCOMPR");

	/// <summary>
	/// Prospection carried out
	/// </summary>
	public CheckboxInputControl SaleProspecc => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDA___SALE_PROSPECC");

	/// <summary>
	/// Qualification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDA___PSEUDNOVOGR02-container");

	/// <summary>
	/// Interested
	/// </summary>
	public CheckboxInputControl SaleInteress => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDA___SALE_INTERESS");

	/// <summary>
	/// Without Financial Resources
	/// </summary>
	public CheckboxInputControl SaleSemrfina => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDA___SALE_SEMRFINA");

	/// <summary>
	/// No decision-making power
	/// </summary>
	public CheckboxInputControl SaleSemcapac => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDA___SALE_SEMCAPAC");

	/// <summary>
	/// Qualification
	/// </summary>
	public DateInputControl SaleDtqualif => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_DTQUALIF", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Qualification carried out
	/// </summary>
	public CheckboxInputControl SaleQualific => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDA___SALE_QUALIFIC");

	/// <summary>
	/// Pre-approach
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDA___PSEUDNOVOGR03-container");

	/// <summary>
	/// Pre-approach
	/// </summary>
	public DateInputControl SalePreabord => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_PREABORD", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Homework done
	/// </summary>
	public CheckboxInputControl SaleHomework => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDA___SALE_HOMEWORK");

	/// <summary>
	/// Approach
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDA___PSEUDNOVOGR04-container");

	/// <summary>
	/// Approach
	/// </summary>
	public DateInputControl SaleDtaborda => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_DTABORDA", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Approach made
	/// </summary>
	public CheckboxInputControl SaleApproach => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDA___SALE_APPROACH");

	/// <summary>
	/// Presentation
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDA___PSEUDNOVOGR05-container");

	/// <summary>
	/// Presentation made
	/// </summary>
	public DateInputControl SaleDtaprese => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_DTAPRESE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Presentation
	/// </summary>
	public CheckboxInputControl SaleApresent => new CheckboxInputControl(driver, ContainerLocator, "#container-VENDA___SALE_APRESENT");

	/// <summary>
	/// Overcoming objections
	/// </summary>
	public CollapsibleZoneControl PseudNovogr06 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDA___PSEUDNOVOGR06-container");

	/// <summary>
	/// Overcoming objections
	/// </summary>
	public DateInputControl SaleDtsupera => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_DTSUPERA", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Closing of the sale
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDA___PSEUDNOVOGR07-container");

	/// <summary>
	/// Closing Attempts
	/// </summary>
	public DateInputControl SaleTentfech => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_TENTFECH", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Closing of the sale
	/// </summary>
	public DateInputControl SaleDtvenda => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_DTVENDA_", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Follow-up
	/// </summary>
	public CollapsibleZoneControl PseudNovogr08 => new CollapsibleZoneControl(driver, ContainerLocator, "#VENDA___PSEUDNOVOGR08-container");

	/// <summary>
	/// Follow-up
	/// </summary>
	public DateInputControl SaleDtacompa => new DateInputControl(driver, ContainerLocator, "#VENDA___SALE_DTACOMPA", "dd/MM/yyyy HH:mm");

	public VendaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "VENDA", containerLocator: containerLocator) { }
}

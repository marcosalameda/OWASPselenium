using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope10Form : Form
{
	/// <summary>
	/// Informações principais
	/// </summary>
	public CollapsibleZoneControl PseudMaininf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE10_PSEUDMAININF_-container");

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "#PROPE10_PROPEPHOTO___");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "#PROPE10_PROPETITLE___");

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "#PROPE10_PROPEPRICE___");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "#PROPE10_PROPEDESCRIPT");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement PseudAcc01 => throw new NotImplementedException();

	/// <summary>
	/// Localização
	/// </summary>
	public CollapsibleZoneControl PseudLocaliza => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE10_PSEUDLOCALIZA-container");

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE10_CITY_CITY____");
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE10", "PROPE10_CITY_CITY____");

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CtryCountry => throw new NotImplementedException();

	/// <summary>
	/// Detalhes
	/// </summary>
	public CollapsibleZoneControl PseudDetails => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE10_PSEUDDETAILS_-container");

	/// <summary>
	/// Tipo de edifício
	/// </summary>
	public EnumControl PropeBuildtyp => new EnumControl(driver, ContainerLocator, "container-PROPE10_PROPEBUILDTYP");

	/// <summary>
	/// Typology
	/// </summary>
	public RadiobuttonControl PropeTypology => new RadiobuttonControl(driver, ContainerLocator, "container-PROPE10_PROPETYPOLOGY");

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "#PROPE10_PROPESIZE____");

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "#PROPE10_PROPEBATHRMS_");

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "#PROPE10_PROPEYEAR____");

	/// <summary>
	/// Informação do agente
	/// </summary>
	public CollapsibleZoneControl PseudAgentinf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE10_PSEUDAGENTINF-container");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE10_AGENTNAME____");
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE10", "PROPE10_AGENTNAME____");

	/// <summary>
	/// Email
	/// </summary>
	public IWebElement AgentEmail => throw new NotImplementedException();

	/// <summary>
	/// Photo
	/// </summary>
	public IWebElement AgentPhoto => throw new NotImplementedException();

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudPropcont => new ListControl(driver, ContainerLocator, "#PROPE10_PSEUDPROPCONT");

	public Prope10Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROPE10", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope19Form : Form
{
	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl PropeOrder => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEORDER___", "#PROPE19_PROPEORDER___");

	/// <summary>
	/// Informações principais
	/// </summary>
	public CollapsibleZoneControl PseudMaininf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE19_PSEUDMAININF_-container");

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEPHOTO___", "#PROPE19_PROPEPHOTO___");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPETITLE___", "#PROPE19_PROPETITLE___");

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEPRICE___", "#PROPE19_PROPEPRICE___");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEDESCRIPT", "#PROPE19_PROPEDESCRIPT");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement PseudAcc01 => throw new NotImplementedException();

	/// <summary>
	/// Localização
	/// </summary>
	public CollapsibleZoneControl PseudLocaliza => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE19_PSEUDLOCALIZA-container");

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE19_CITY_CITY____");
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE19", "PROPE19_CITY_CITY____");

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CtryCountry => throw new NotImplementedException();

	/// <summary>
	/// Detalhes
	/// </summary>
	public CollapsibleZoneControl PseudDetails => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE19_PSEUDDETAILS_-container");

	/// <summary>
	/// Tipo de edifício
	/// </summary>
	public EnumControl PropeBuildtyp => new EnumControl(driver, ContainerLocator, "container-PROPE19_PROPEBUILDTYP");

	/// <summary>
	/// Tamanho do terreno
	/// </summary>
	public BaseInputControl PropeGrndsize => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEGRNDSIZE", "#PROPE19_PROPEGRNDSIZE");

	/// <summary>
	/// Número do andar
	/// </summary>
	public BaseInputControl PropeFloornum => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEFLOORNUM", "#PROPE19_PROPEFLOORNUM");

	/// <summary>
	/// Typology
	/// </summary>
	public RadiobuttonControl PropeTypology => new RadiobuttonControl(driver, ContainerLocator, "container-PROPE19_PROPETYPOLOGY");

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPESIZE____", "#PROPE19_PROPESIZE____");

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEBATHRMS_", "#PROPE19_PROPEBATHRMS_");

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEYEAR____", "#PROPE19_PROPEYEAR____");

	/// <summary>
	/// Building age
	/// </summary>
	public BaseInputControl PropeBuildage => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEBUILDAGE", "#PROPE19_PROPEBUILDAGE");

	/// <summary>
	/// Informação do agente
	/// </summary>
	public CollapsibleZoneControl PseudAgentinf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE19_PSEUDAGENTINF-container");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE19_AGENTNAME____");
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE19", "PROPE19_AGENTNAME____");

	/// <summary>
	/// Email
	/// </summary>
	public IWebElement AgentEmail => throw new NotImplementedException();

	/// <summary>
	/// Photo
	/// </summary>
	public IWebElement AgentPhoto => throw new NotImplementedException();

	/// <summary>
	/// Photos
	/// </summary>
	public ListControl PseudProphoto => new ListControl(driver, ContainerLocator, "#PROPE19_PSEUDPROPHOTO");

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudPropcont => new ListControl(driver, ContainerLocator, "#PROPE19_PSEUDPROPCONT");

	public Prope19Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROPE19", containerLocator: containerLocator) { }
}

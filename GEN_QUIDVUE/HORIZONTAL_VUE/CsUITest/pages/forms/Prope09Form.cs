using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope09Form : Form
{
	/// <summary>
	/// Informações principais
	/// </summary>
	public CollapsibleZoneControl PseudMaininf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE09_PSEUDMAININF_" + IdSuffix + "-container");

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "container-PROPE09_PROPEPHOTO___" + IdSuffix, "#PROPE09_PROPEPHOTO___" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "container-PROPE09_PROPETITLE___" + IdSuffix, "#PROPE09_PROPETITLE___" + IdSuffix);

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "container-PROPE09_PROPEPRICE___" + IdSuffix, "#PROPE09_PROPEPRICE___" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "container-PROPE09_PROPEDESCRIPT" + IdSuffix, "#PROPE09_PROPEDESCRIPT" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public IWebElement PseudAcc01 => throw new NotImplementedException();

	/// <summary>
	/// Localização
	/// </summary>
	public CollapsibleZoneControl PseudLocaliza => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE09_PSEUDLOCALIZA" + IdSuffix + "-container");

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE09_CITY_CITY____" + IdSuffix);
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE09", "PROPE09_CITY_CITY____" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CtryCountry => throw new NotImplementedException();

	/// <summary>
	/// Detalhes
	/// </summary>
	public CollapsibleZoneControl PseudDetails => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE09_PSEUDDETAILS_" + IdSuffix + "-container");

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "container-PROPE09_PROPESIZE____" + IdSuffix, "#PROPE09_PROPESIZE____" + IdSuffix);

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "container-PROPE09_PROPEBATHRMS_" + IdSuffix, "#PROPE09_PROPEBATHRMS_" + IdSuffix);

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "container-PROPE09_PROPEYEAR____" + IdSuffix, "#PROPE09_PROPEYEAR____" + IdSuffix);

	/// <summary>
	/// Informação do agente
	/// </summary>
	public CollapsibleZoneControl PseudAgentinf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE09_PSEUDAGENTINF" + IdSuffix + "-container");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE09_AGENTNAME____" + IdSuffix);
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE09", "PROPE09_AGENTNAME____" + IdSuffix);

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
	public ListControl PseudPropcont => new ListControl(driver, ContainerLocator, "#PROPE09_PSEUDPROPCONT" + IdSuffix);

	public Prope09Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPE09", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

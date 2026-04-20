using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope19Form : Form
{
	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl PropeOrder => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEORDER___" + IdSuffix, "#PROPE19_PROPEORDER___" + IdSuffix);

	/// <summary>
	/// Informações principais
	/// </summary>
	public CollapsibleZoneControl PseudMaininf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE19_PSEUDMAININF_" + IdSuffix + "-container");

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEPHOTO___" + IdSuffix, "#PROPE19_PROPEPHOTO___" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPETITLE___" + IdSuffix, "#PROPE19_PROPETITLE___" + IdSuffix);

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEPRICE___" + IdSuffix, "#PROPE19_PROPEPRICE___" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEDESCRIPT" + IdSuffix, "#PROPE19_PROPEDESCRIPT" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public IWebElement PseudAcc01 => throw new NotImplementedException();

	/// <summary>
	/// Localização
	/// </summary>
	public CollapsibleZoneControl PseudLocaliza => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE19_PSEUDLOCALIZA" + IdSuffix + "-container");

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE19_CITY_CITY____" + IdSuffix);
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE19", "PROPE19_CITY_CITY____" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CtryCountry => throw new NotImplementedException();

	/// <summary>
	/// Detalhes
	/// </summary>
	public CollapsibleZoneControl PseudDetails => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE19_PSEUDDETAILS_" + IdSuffix + "-container");

	/// <summary>
	/// Tipo de edifício
	/// </summary>
	public EnumControl PropeBuildtyp => new EnumControl(driver, ContainerLocator, "container-PROPE19_PROPEBUILDTYP" + IdSuffix);

	/// <summary>
	/// Tamanho do terreno
	/// </summary>
	public BaseInputControl PropeGrndsize => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEGRNDSIZE" + IdSuffix, "#PROPE19_PROPEGRNDSIZE" + IdSuffix);

	/// <summary>
	/// Número do andar
	/// </summary>
	public BaseInputControl PropeFloornum => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEFLOORNUM" + IdSuffix, "#PROPE19_PROPEFLOORNUM" + IdSuffix);

	/// <summary>
	/// Typology
	/// </summary>
	public RadiobuttonControl PropeTypology => new RadiobuttonControl(driver, ContainerLocator, "container-PROPE19_PROPETYPOLOGY" + IdSuffix);

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPESIZE____" + IdSuffix, "#PROPE19_PROPESIZE____" + IdSuffix);

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEBATHRMS_" + IdSuffix, "#PROPE19_PROPEBATHRMS_" + IdSuffix);

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEYEAR____" + IdSuffix, "#PROPE19_PROPEYEAR____" + IdSuffix);

	/// <summary>
	/// Building age
	/// </summary>
	public BaseInputControl PropeBuildage => new BaseInputControl(driver, ContainerLocator, "container-PROPE19_PROPEBUILDAGE" + IdSuffix, "#PROPE19_PROPEBUILDAGE" + IdSuffix);

	/// <summary>
	/// Informação do agente
	/// </summary>
	public CollapsibleZoneControl PseudAgentinf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE19_PSEUDAGENTINF" + IdSuffix + "-container");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE19_AGENTNAME____" + IdSuffix);
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE19", "PROPE19_AGENTNAME____" + IdSuffix);

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
	public ListControl PseudProphoto => new ListControl(driver, ContainerLocator, "#PROPE19_PSEUDPROPHOTO" + IdSuffix);

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudPropcont => new ListControl(driver, ContainerLocator, "#PROPE19_PSEUDPROPCONT" + IdSuffix);

	public Prope19Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPE19", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

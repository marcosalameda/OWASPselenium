using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope17Form : Form
{
	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl PropeOrder => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPEORDER___");

	/// <summary>
	/// Informações principais
	/// </summary>
	public CollapsibleZoneControl PseudMaininf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE17_PSEUDMAININF_-container");

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPEPHOTO___");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPETITLE___");

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPEPRICE___");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPEDESCRIPT");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement PseudAcc01 => throw new NotImplementedException();

	/// <summary>
	/// Localização
	/// </summary>
	public CollapsibleZoneControl PseudLocaliza => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE17_PSEUDLOCALIZA-container");

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE17_CITY_CITY____");
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE17", "PROPE17_CITY_CITY____");

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CtryCountry => throw new NotImplementedException();

	/// <summary>
	/// Detalhes
	/// </summary>
	public CollapsibleZoneControl PseudDetails => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE17_PSEUDDETAILS_-container");

	/// <summary>
	/// Tipo de edifício
	/// </summary>
	public EnumControl PropeBuildtyp => new EnumControl(driver, ContainerLocator, "container-PROPE17_PROPEBUILDTYP");

	/// <summary>
	/// Typology
	/// </summary>
	public RadiobuttonControl PropeTypology => new RadiobuttonControl(driver, ContainerLocator, "container-PROPE17_PROPETYPOLOGY");

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPESIZE____");

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPEBATHRMS_");

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPEYEAR____");

	/// <summary>
	/// Building age
	/// </summary>
	public BaseInputControl PropeBuildage => new BaseInputControl(driver, ContainerLocator, "#PROPE17_PROPEBUILDAGE");

	/// <summary>
	/// Informação do agente
	/// </summary>
	public CollapsibleZoneControl PseudAgentinf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE17_PSEUDAGENTINF-container");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE17_AGENTNAME____");
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE17", "PROPE17_AGENTNAME____");

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
	public ListControl PseudProphoto => new ListControl(driver, ContainerLocator, "#PROPE17_PSEUDPROPHOTO");

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudPropcont => new ListControl(driver, ContainerLocator, "#PROPE17_PSEUDPROPCONT");

	public Prope17Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PROPE17", containerLocator: containerLocator) { }
}

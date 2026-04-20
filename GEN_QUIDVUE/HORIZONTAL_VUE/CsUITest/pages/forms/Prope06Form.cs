using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope06Form : Form
{
	/// <summary>
	/// Informações principais
	/// </summary>
	public CollapsibleZoneControl PseudMaininf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE06_PSEUDMAININF_" + IdSuffix + "-container");

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "container-PROPE06_PROPEPHOTO___" + IdSuffix, "#PROPE06_PROPEPHOTO___" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "container-PROPE06_PROPETITLE___" + IdSuffix, "#PROPE06_PROPETITLE___" + IdSuffix);

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "container-PROPE06_PROPEPRICE___" + IdSuffix, "#PROPE06_PROPEPRICE___" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "container-PROPE06_PROPEDESCRIPT" + IdSuffix, "#PROPE06_PROPEDESCRIPT" + IdSuffix);

	/// <summary>
	/// Localização
	/// </summary>
	public CollapsibleZoneControl PseudLocaliza => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE06_PSEUDLOCALIZA" + IdSuffix + "-container");

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE06_CITY_CITY____" + IdSuffix);
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE06", "PROPE06_CITY_CITY____" + IdSuffix);

	/// <summary>
	/// Detalhes
	/// </summary>
	public CollapsibleZoneControl PseudDetails => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE06_PSEUDDETAILS_" + IdSuffix + "-container");

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "container-PROPE06_PROPESIZE____" + IdSuffix, "#PROPE06_PROPESIZE____" + IdSuffix);

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "container-PROPE06_PROPEBATHRMS_" + IdSuffix, "#PROPE06_PROPEBATHRMS_" + IdSuffix);

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "container-PROPE06_PROPEYEAR____" + IdSuffix, "#PROPE06_PROPEYEAR____" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE06_AGENTNAME____" + IdSuffix);
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE06", "PROPE06_AGENTNAME____" + IdSuffix);

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudPropcont => new ListControl(driver, ContainerLocator, "#PROPE06_PSEUDPROPCONT" + IdSuffix);

	public Prope06Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPE06", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

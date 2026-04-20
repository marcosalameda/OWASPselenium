using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope07Form : Form
{
	/// <summary>
	/// Informações principais
	/// </summary>
	public CollapsibleZoneControl PseudMaininf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE07_PSEUDMAININF_" + IdSuffix + "-container");

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "container-PROPE07_PROPEPHOTO___" + IdSuffix, "#PROPE07_PROPEPHOTO___" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "container-PROPE07_PROPETITLE___" + IdSuffix, "#PROPE07_PROPETITLE___" + IdSuffix);

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "container-PROPE07_PROPEPRICE___" + IdSuffix, "#PROPE07_PROPEPRICE___" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "container-PROPE07_PROPEDESCRIPT" + IdSuffix, "#PROPE07_PROPEDESCRIPT" + IdSuffix);

	/// <summary>
	/// Localização
	/// </summary>
	public CollapsibleZoneControl PseudLocaliza => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE07_PSEUDLOCALIZA" + IdSuffix + "-container");

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE07_CITY_CITY____" + IdSuffix);
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE07", "PROPE07_CITY_CITY____" + IdSuffix);

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CtryCountry => throw new NotImplementedException();

	/// <summary>
	/// Detalhes
	/// </summary>
	public CollapsibleZoneControl PseudDetails => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE07_PSEUDDETAILS_" + IdSuffix + "-container");

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "container-PROPE07_PROPESIZE____" + IdSuffix, "#PROPE07_PROPESIZE____" + IdSuffix);

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "container-PROPE07_PROPEBATHRMS_" + IdSuffix, "#PROPE07_PROPEBATHRMS_" + IdSuffix);

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "container-PROPE07_PROPEYEAR____" + IdSuffix, "#PROPE07_PROPEYEAR____" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE07_AGENTNAME____" + IdSuffix);
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE07", "PROPE07_AGENTNAME____" + IdSuffix);

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
	public ListControl PseudPropcont => new ListControl(driver, ContainerLocator, "#PROPE07_PSEUDPROPCONT" + IdSuffix);

	public Prope07Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPE07", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

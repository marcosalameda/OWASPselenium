using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope05Form : Form
{
	/// <summary>
	/// Informações principais
	/// </summary>
	public CollapsibleZoneControl PseudMaininf => new CollapsibleZoneControl(driver, ContainerLocator, "#PROPE05_PSEUDMAININF_" + IdSuffix + "-container");

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "container-PROPE05_PROPEPHOTO___" + IdSuffix, "#PROPE05_PROPEPHOTO___" + IdSuffix);

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "container-PROPE05_PROPETITLE___" + IdSuffix, "#PROPE05_PROPETITLE___" + IdSuffix);

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "container-PROPE05_PROPEPRICE___" + IdSuffix, "#PROPE05_PROPEPRICE___" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "container-PROPE05_PROPEDESCRIPT" + IdSuffix, "#PROPE05_PROPEDESCRIPT" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE05_AGENTNAME____" + IdSuffix);
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE05", "PROPE05_AGENTNAME____" + IdSuffix);

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "container-PROPE05_PROPEBATHRMS_" + IdSuffix, "#PROPE05_PROPEBATHRMS_" + IdSuffix);

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "container-PROPE05_PROPESIZE____" + IdSuffix, "#PROPE05_PROPESIZE____" + IdSuffix);

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "container-PROPE05_PROPEYEAR____" + IdSuffix, "#PROPE05_PROPEYEAR____" + IdSuffix);

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE05_CITY_CITY____" + IdSuffix);
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE05", "PROPE05_CITY_CITY____" + IdSuffix);

	public Prope05Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPE05", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

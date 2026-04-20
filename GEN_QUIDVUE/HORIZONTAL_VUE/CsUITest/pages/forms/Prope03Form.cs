using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Prope03Form : Form
{
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropeTitle => new BaseInputControl(driver, ContainerLocator, "container-PROPE03_PROPETITLE___" + IdSuffix, "#PROPE03_PROPETITLE___" + IdSuffix);

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropePrice => new BaseInputControl(driver, ContainerLocator, "container-PROPE03_PROPEPRICE___" + IdSuffix, "#PROPE03_PROPEPRICE___" + IdSuffix);

	/// <summary>
	/// Foto principal
	/// </summary>
	public BaseInputControl PropePhoto => new BaseInputControl(driver, ContainerLocator, "container-PROPE03_PROPEPHOTO___" + IdSuffix, "#PROPE03_PROPEPHOTO___" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-PROPE03_AGENTNAME____" + IdSuffix);
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "PROPE03", "PROPE03_AGENTNAME____" + IdSuffix);

	/// <summary>
	/// Tamanho (m2)
	/// </summary>
	public BaseInputControl PropeSize => new BaseInputControl(driver, ContainerLocator, "container-PROPE03_PROPESIZE____" + IdSuffix, "#PROPE03_PROPESIZE____" + IdSuffix);

	/// <summary>
	/// Numero de Casa de banhos
	/// </summary>
	public BaseInputControl PropeBathrms => new BaseInputControl(driver, ContainerLocator, "container-PROPE03_PROPEBATHRMS_" + IdSuffix, "#PROPE03_PROPEBATHRMS_" + IdSuffix);

	/// <summary>
	/// Ano construído
	/// </summary>
	public BaseInputControl PropeYear => new BaseInputControl(driver, ContainerLocator, "container-PROPE03_PROPEYEAR____" + IdSuffix, "#PROPE03_PROPEYEAR____" + IdSuffix);

	/// <summary>
	/// Cidade
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-PROPE03_CITY_CITY____" + IdSuffix);
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "PROPE03", "PROPE03_CITY_CITY____" + IdSuffix);

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl PropeDescript => new BaseInputControl(driver, ContainerLocator, "container-PROPE03_PROPEDESCRIPT" + IdSuffix, "#PROPE03_PROPEDESCRIPT" + IdSuffix);

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudPropcont => new ListControl(driver, ContainerLocator, "#PROPE03_PSEUDPROPCONT" + IdSuffix);

	public Prope03Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PROPE03", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

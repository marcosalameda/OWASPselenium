using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Agent05Form : Form
{
	/// <summary>
	/// Informação do agente
	/// </summary>
	public CollapsibleZoneControl PseudAgentinf => new CollapsibleZoneControl(driver, ContainerLocator, "#AGENT05_PSEUDAGENTINF" + IdSuffix + "-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AgentPhoto => new BaseInputControl(driver, ContainerLocator, "container-AGENT05_AGENTPHOTO___" + IdSuffix, "#AGENT05_AGENTPHOTO___" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl AgentName => new BaseInputControl(driver, ContainerLocator, "container-AGENT05_AGENTNAME____" + IdSuffix, "#AGENT05_AGENTNAME____" + IdSuffix);

	/// <summary>
	/// Data de nascimento
	/// </summary>
	public DateInputControl AgentBirthdat => new DateInputControl(driver, ContainerLocator, "#AGENT05_AGENTBIRTHDAT" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl AgentEmail => new BaseInputControl(driver, ContainerLocator, "container-AGENT05_AGENTEMAIL___" + IdSuffix, "#AGENT05_AGENTEMAIL___" + IdSuffix);

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl AgentTelephon => new BaseInputControl(driver, ContainerLocator, "container-AGENT05_AGENTTELEPHON" + IdSuffix, "#AGENT05_AGENTTELEPHON" + IdSuffix);

	public Agent05Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "AGENT05", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Agent05Form : Form
{
	/// <summary>
	/// Informação do agente
	/// </summary>
	public CollapsibleZoneControl PseudAgentinf => new CollapsibleZoneControl(driver, ContainerLocator, "#AGENT05_PSEUDAGENTINF-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AgentPhoto => new BaseInputControl(driver, ContainerLocator, "#AGENT05_AGENTPHOTO___");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl AgentName => new BaseInputControl(driver, ContainerLocator, "#AGENT05_AGENTNAME____");

	/// <summary>
	/// Data de nascimento
	/// </summary>
	public DateInputControl AgentBirthdat => new DateInputControl(driver, ContainerLocator, "#AGENT05_AGENTBIRTHDAT");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl AgentEmail => new BaseInputControl(driver, ContainerLocator, "#AGENT05_AGENTEMAIL___");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl AgentTelephon => new BaseInputControl(driver, ContainerLocator, "#AGENT05_AGENTTELEPHON");

	public Agent05Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "AGENT05", containerLocator: containerLocator) { }
}

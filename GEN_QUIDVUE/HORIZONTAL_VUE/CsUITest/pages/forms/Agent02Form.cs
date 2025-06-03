using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Agent02Form : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AgentPhoto => new BaseInputControl(driver, ContainerLocator, "container-AGENT02_AGENTPHOTO___", "#AGENT02_AGENTPHOTO___");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl AgentName => new BaseInputControl(driver, ContainerLocator, "container-AGENT02_AGENTNAME____", "#AGENT02_AGENTNAME____");

	/// <summary>
	/// Data de nascimento
	/// </summary>
	public DateInputControl AgentBirthdat => new DateInputControl(driver, ContainerLocator, "#AGENT02_AGENTBIRTHDAT");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl AgentEmail => new BaseInputControl(driver, ContainerLocator, "container-AGENT02_AGENTEMAIL___", "#AGENT02_AGENTEMAIL___");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl AgentTelephon => new BaseInputControl(driver, ContainerLocator, "container-AGENT02_AGENTTELEPHON", "#AGENT02_AGENTTELEPHON");

	public Agent02Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "AGENT02", containerLocator: containerLocator) { }
}

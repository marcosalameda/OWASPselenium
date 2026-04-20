using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Agent02Form : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AgentPhoto => new BaseInputControl(driver, ContainerLocator, "container-AGENT02_AGENTPHOTO___" + IdSuffix, "#AGENT02_AGENTPHOTO___" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl AgentName => new BaseInputControl(driver, ContainerLocator, "container-AGENT02_AGENTNAME____" + IdSuffix, "#AGENT02_AGENTNAME____" + IdSuffix);

	/// <summary>
	/// Data de nascimento
	/// </summary>
	public DateInputControl AgentBirthdat => new DateInputControl(driver, ContainerLocator, "#AGENT02_AGENTBIRTHDAT" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl AgentEmail => new BaseInputControl(driver, ContainerLocator, "container-AGENT02_AGENTEMAIL___" + IdSuffix, "#AGENT02_AGENTEMAIL___" + IdSuffix);

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl AgentTelephon => new BaseInputControl(driver, ContainerLocator, "container-AGENT02_AGENTTELEPHON" + IdSuffix, "#AGENT02_AGENTTELEPHON" + IdSuffix);

	public Agent02Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "AGENT02", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

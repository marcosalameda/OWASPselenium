using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Agent01Form : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AgentPhoto => new BaseInputControl(driver, ContainerLocator, "container-AGENT01_AGENTPHOTO___" + IdSuffix, "#AGENT01_AGENTPHOTO___" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl AgentName => new BaseInputControl(driver, ContainerLocator, "container-AGENT01_AGENTNAME____" + IdSuffix, "#AGENT01_AGENTNAME____" + IdSuffix);

	/// <summary>
	/// Data de nascimento
	/// </summary>
	public DateInputControl AgentBirthdat => new DateInputControl(driver, ContainerLocator, "#AGENT01_AGENTBIRTHDAT" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl AgentEmail => new BaseInputControl(driver, ContainerLocator, "container-AGENT01_AGENTEMAIL___" + IdSuffix, "#AGENT01_AGENTEMAIL___" + IdSuffix);

	public Agent01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "AGENT01", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Agent01Form : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AgentPhoto => new BaseInputControl(driver, ContainerLocator, "#AGENT01_AGENTPHOTO___");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl AgentName => new BaseInputControl(driver, ContainerLocator, "#AGENT01_AGENTNAME____");

	/// <summary>
	/// Data de nascimento
	/// </summary>
	public DateInputControl AgentBirthdat => new DateInputControl(driver, ContainerLocator, "#AGENT01_AGENTBIRTHDAT");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl AgentEmail => new BaseInputControl(driver, ContainerLocator, "#AGENT01_AGENTEMAIL___");

	public Agent01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "AGENT01", containerLocator: containerLocator) { }
}

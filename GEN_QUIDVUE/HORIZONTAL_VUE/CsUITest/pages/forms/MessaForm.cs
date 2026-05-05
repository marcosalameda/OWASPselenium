using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MessaForm : Form
{
	/// <summary>
	/// Notification ID
	/// </summary>
	public BaseInputControl MessaIdnotif => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAIDNOTIF_", "#MESSA___MESSAIDNOTIF_");

	/// <summary>
	/// Message ID
	/// </summary>
	public BaseInputControl MessaIdmsg => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAIDMSG___", "#MESSA___MESSAIDMSG___");

	/// <summary>
	/// E-mail sent
	/// </summary>
	public CheckboxInputControl MessaMailsent => new CheckboxInputControl(driver, ContainerLocator, "#container-MESSA___MESSAMAILSENT");

	/// <summary>
	/// Error sending mail
	/// </summary>
	public BaseInputControl MessaMailerr => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAMAILERR_", "#MESSA___MESSAMAILERR_");

	/// <summary>
	/// Entity name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-MESSA___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "MESSA", "MESSA___ENTITNAME____");

	/// <summary>
	/// Person name
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, ContainerLocator, "container-MESSA___PERSONAME____");
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "MESSA", "MESSA___PERSONAME____");

	/// <summary>
	/// Document number
	/// </summary>
	public BaseInputControl MessaDocum_nr => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSADOCUM_NR", "#MESSA___MESSADOCUM_NR");

	/// <summary>
	/// To whom the message was sent
	/// </summary>
	public BaseInputControl MessaDesignat => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSADESIGNAT", "#MESSA___MESSADESIGNAT");

	/// <summary>
	/// E-mail to whom the message was sent
	/// </summary>
	public BaseInputControl MessaEmail => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAEMAIL___", "#MESSA___MESSAEMAIL___");

	/// <summary>
	/// Message
	/// </summary>
	public BaseInputControl MessaMessage => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAMESSAGE_", "#MESSA___MESSAMESSAGE_");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl MessaCreatope => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSACREATOPE", "#MESSA___MESSACREATOPE");

	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl MessaCreatdat => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSACREATDAT", "#MESSA___MESSACREATDAT");

	public MessaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "MESSA", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MessaForm : Form
{
	/// <summary>
	/// Notification ID
	/// </summary>
	public BaseInputControl MessaIdnotif => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAIDNOTIF_" + IdSuffix, "#MESSA___MESSAIDNOTIF_" + IdSuffix);

	/// <summary>
	/// Message ID
	/// </summary>
	public BaseInputControl MessaIdmsg => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAIDMSG___" + IdSuffix, "#MESSA___MESSAIDMSG___" + IdSuffix);

	/// <summary>
	/// E-mail sent
	/// </summary>
	public CheckboxInputControl MessaMailsent => new CheckboxInputControl(driver, ContainerLocator, "#container-MESSA___MESSAMAILSENT" + IdSuffix);

	/// <summary>
	/// Error sending mail
	/// </summary>
	public BaseInputControl MessaMailerr => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAMAILERR_" + IdSuffix, "#MESSA___MESSAMAILERR_" + IdSuffix);

	/// <summary>
	/// Entity name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, ContainerLocator, "container-MESSA___ENTITNAME____" + IdSuffix);
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "MESSA", "MESSA___ENTITNAME____" + IdSuffix);

	/// <summary>
	/// Person name
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, ContainerLocator, "container-MESSA___PERSONAME____" + IdSuffix);
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "MESSA", "MESSA___PERSONAME____" + IdSuffix);

	/// <summary>
	/// Document number
	/// </summary>
	public BaseInputControl MessaDocum_nr => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSADOCUM_NR" + IdSuffix, "#MESSA___MESSADOCUM_NR" + IdSuffix);

	/// <summary>
	/// To whom the message was sent
	/// </summary>
	public BaseInputControl MessaDesignat => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSADESIGNAT" + IdSuffix, "#MESSA___MESSADESIGNAT" + IdSuffix);

	/// <summary>
	/// E-mail to whom the message was sent
	/// </summary>
	public BaseInputControl MessaEmail => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAEMAIL___" + IdSuffix, "#MESSA___MESSAEMAIL___" + IdSuffix);

	/// <summary>
	/// Message
	/// </summary>
	public BaseInputControl MessaMessage => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSAMESSAGE_" + IdSuffix, "#MESSA___MESSAMESSAGE_" + IdSuffix);

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl MessaCreatope => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSACREATOPE" + IdSuffix, "#MESSA___MESSACREATOPE" + IdSuffix);

	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl MessaCreatdat => new BaseInputControl(driver, ContainerLocator, "container-MESSA___MESSACREATDAT" + IdSuffix, "#MESSA___MESSACREATDAT" + IdSuffix);

	public MessaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "MESSA", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

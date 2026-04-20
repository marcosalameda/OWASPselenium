using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class NotifForm : Form
{
	/// <summary>
	/// Lending No
	/// </summary>
	public BaseInputControl NotifNrcomoda => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFNRCOMODA" + IdSuffix, "#NOTIF___NOTIFNRCOMODA" + IdSuffix);

	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl NotifBegin => new DateInputControl(driver, ContainerLocator, "#NOTIF___NOTIFBEGIN___" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl NotifEnd => new DateInputControl(driver, ContainerLocator, "#NOTIF___NOTIFEND_____" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Receiver's Email
	/// </summary>
	public BaseInputControl NotifEmail => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFEMAIL___" + IdSuffix, "#NOTIF___NOTIFEMAIL___" + IdSuffix);

	/// <summary>
	/// ID of the notification that generated the message
	/// </summary>
	public BaseInputControl NotifIdnotif => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFIDNOTIF_" + IdSuffix, "#NOTIF___NOTIFIDNOTIF_" + IdSuffix);

	/// <summary>
	/// Mensage ID
	/// </summary>
	public BaseInputControl NotifIdmsg => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFIDMSG___" + IdSuffix, "#NOTIF___NOTIFIDMSG___" + IdSuffix);

	/// <summary>
	/// Text of sent message
	/// </summary>
	public BaseInputControl NotifMessage => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFMESSAGE_" + IdSuffix, "#NOTIF___NOTIFMESSAGE_" + IdSuffix);

	/// <summary>
	/// Erro on sending the email
	/// </summary>
	public BaseInputControl NotifMailerr => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFMAILERR_" + IdSuffix, "#NOTIF___NOTIFMAILERR_" + IdSuffix);

	/// <summary>
	/// Receiver
	/// </summary>
	public BaseInputControl NotifDesignat => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFDESIGNAT" + IdSuffix, "#NOTIF___NOTIFDESIGNAT" + IdSuffix);

	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl NotifCreatdat => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFCREATDAT" + IdSuffix, "#NOTIF___NOTIFCREATDAT" + IdSuffix);

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl NotifCreatope => new BaseInputControl(driver, ContainerLocator, "container-NOTIF___NOTIFCREATOPE" + IdSuffix, "#NOTIF___NOTIFCREATOPE" + IdSuffix);

	/// <summary>
	/// Returned
	/// </summary>
	public CheckboxInputControl NotifReturned => new CheckboxInputControl(driver, ContainerLocator, "#container-NOTIF___NOTIFRETURNED" + IdSuffix);

	/// <summary>
	/// Returned
	/// </summary>
	public DateInputControl NotifDtdevolu => new DateInputControl(driver, ContainerLocator, "#NOTIF___NOTIFDTDEVOLU" + IdSuffix);

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl Pess2Name => new LookupControl(driver, ContainerLocator, "container-NOTIF___PESS2NAME____" + IdSuffix);
	public SeeMorePage Pess2NameSeeMorePage => new SeeMorePage(driver, "NOTIF", "NOTIF___PESS2NAME____" + IdSuffix);

	public NotifForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "NOTIF", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

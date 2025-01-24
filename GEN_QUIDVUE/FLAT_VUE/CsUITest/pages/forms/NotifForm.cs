using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class NotifForm : Form
{
	/// <summary>
	/// Lending No
	/// </summary>
	public BaseInputControl NotifNrcomoda => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFNRCOMODA");

	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl NotifBegin => new DateInputControl(driver, ContainerLocator, "#NOTIF___NOTIFBEGIN___", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// End
	/// </summary>
	public DateInputControl NotifEnd => new DateInputControl(driver, ContainerLocator, "#NOTIF___NOTIFEND_____", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Receiver's Email
	/// </summary>
	public BaseInputControl NotifEmail => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFEMAIL___");

	/// <summary>
	/// ID of the notification that generated the message
	/// </summary>
	public BaseInputControl NotifIdnotif => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFIDNOTIF_");

	/// <summary>
	/// Mensage ID
	/// </summary>
	public BaseInputControl NotifIdmsg => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFIDMSG___");

	/// <summary>
	/// Text of sent message
	/// </summary>
	public BaseInputControl NotifMessage => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFMESSAGE_");

	/// <summary>
	/// Erro on sending the email
	/// </summary>
	public BaseInputControl NotifMailerr => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFMAILERR_");

	/// <summary>
	/// Receiver
	/// </summary>
	public BaseInputControl NotifDesignat => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFDESIGNAT");

	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl NotifCreatdat => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFCREATDAT");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl NotifCreatope => new BaseInputControl(driver, ContainerLocator, "#NOTIF___NOTIFCREATOPE");

	/// <summary>
	/// Returned
	/// </summary>
	public CheckboxInputControl NotifReturned => new CheckboxInputControl(driver, ContainerLocator, "#container-NOTIF___NOTIFRETURNED");

	/// <summary>
	/// Returned
	/// </summary>
	public DateInputControl NotifDtdevolu => new DateInputControl(driver, ContainerLocator, "#NOTIF___NOTIFDTDEVOLU");

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl Pess2Name => new LookupControl(driver, ContainerLocator, "container-NOTIF___PESS2NAME____");
	public SeeMorePage Pess2NameSeeMorePage => new SeeMorePage(driver, "NOTIF", "NOTIF___PESS2NAME____");

	public NotifForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "NOTIF", containerLocator: containerLocator) { }
}

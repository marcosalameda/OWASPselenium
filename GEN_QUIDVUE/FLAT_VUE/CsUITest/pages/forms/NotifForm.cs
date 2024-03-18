namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class NotifForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Lending No
	/// </summary>
	public BaseInputControl NotifNrcomoda => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFNRCOMODA");
	/// <summary>
	/// Start
	/// </summary>
	public DateInputControl NotifBegin => new DateInputControl(driver, formLocator, "#NOTIF___NOTIFBEGIN___", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// End
	/// </summary>
	public DateInputControl NotifEnd => new DateInputControl(driver, formLocator, "#NOTIF___NOTIFEND_____", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Receiver's Email
	/// </summary>
	public BaseInputControl NotifEmail => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFEMAIL___");
	/// <summary>
	/// ID of the notification that generated the message
	/// </summary>
	public BaseInputControl NotifIdnotif => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFIDNOTIF_");
	/// <summary>
	/// Mensage ID
	/// </summary>
	public BaseInputControl NotifIdmsg => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFIDMSG___");
	/// <summary>
	/// Text of sent message
	/// </summary>
	public BaseInputControl NotifMessage => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFMESSAGE_");
	/// <summary>
	/// Erro on sending the email
	/// </summary>
	public BaseInputControl NotifMailerr => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFMAILERR_");
	/// <summary>
	/// Receiver
	/// </summary>
	public BaseInputControl NotifDesignat => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFDESIGNAT");
	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl NotifCreatdat => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFCREATDAT");
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl NotifCreatope => new BaseInputControl(driver, formLocator, "#NOTIF___NOTIFCREATOPE");
	/// <summary>
	/// Returned
	/// </summary>
	public CheckboxInputControl NotifReturned => new CheckboxInputControl(driver, formLocator, "#container-NOTIF___NOTIFRETURNED");
	/// <summary>
	/// Returned
	/// </summary>
	public DateInputControl NotifDtdevolu => new DateInputControl(driver, formLocator, "#NOTIF___NOTIFDTDEVOLU");
	/// <summary>
	/// Name
	/// </summary>
	public LookupControl Pess2Name => new LookupControl(driver, formLocator, "container-NOTIF___PESS2NAME____");
	public SeeMorePage Pess2NameSeeMorePage => new SeeMorePage(driver, "NOTIF", "PESS2.NAME");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public NotifForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("NOTIF")).GetAttribute("data-loading") != "true");
    }

	public void Save() {
		WaitForLoading();
		saveBtn.Click();
	}

	public void Cancel() {
		WaitForLoading();
		cancelBtn.Click();
	}

}

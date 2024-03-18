using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class NotifForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Notif']"));

	public BaseInputControl LED_NOTIF___NOTIFNRCOMODA => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFNRCOMODA']");
	public BaseInputControl LED_NOTIF___NOTIFBEGIN___ => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFBEGIN___']");
	public BaseInputControl LED_NOTIF___NOTIFEND_____ => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFEND_____']");
	public BaseInputControl LED_NOTIF___NOTIFEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFEMAIL___']");
	public BaseInputControl LED_NOTIF___NOTIFIDNOTIF_ => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFIDNOTIF_']");
	public BaseInputControl LED_NOTIF___NOTIFIDMSG___ => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFIDMSG___']");
	public BaseInputControl LED_NOTIF___NOTIFMESSAGE_ => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFMESSAGE_']");
	public BaseInputControl LED_NOTIF___NOTIFMAILERR_ => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFMAILERR_']");
	public BaseInputControl LED_NOTIF___NOTIFDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFDESIGNAT']");
	public BaseInputControl LED_NOTIF___NOTIFCREATDAT => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFCREATDAT']");
	public BaseInputControl LED_NOTIF___NOTIFCREATOPE => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFCREATOPE']");
	public BaseInputControl LED_NOTIF___NOTIFRETURNED => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFRETURNED']");
	public BaseInputControl LED_NOTIF___NOTIFDTDEVOLU => new BaseInputControl(driver, "[data-identifier='LED_NOTIF___NOTIFDTDEVOLU']");
	public LookupControl IFF_NOTIF___PESS2NAME____ => new LookupControl(driver, "CONTAINER_IFF_NOTIF___PESS2NAME____", "ValCodpesso_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public NotifForm(IWebDriver driver, FORM_MODE mode): base(driver) {
		this.mode = mode;		
		wait.Until(c => form.GetAttribute("qform-loaded").Contains("true"));
	}

	public void Save() {
		saveBtn.Click();
	}

	public void Cancel() {
		cancelBtn.Click();
	}

}

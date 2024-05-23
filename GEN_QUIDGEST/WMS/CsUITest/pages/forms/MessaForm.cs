using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MessaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Messa']"));

	public BaseInputControl LED_MESSA___MESSAIDNOTIF_ => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSAIDNOTIF_']");
	public BaseInputControl LED_MESSA___MESSAIDMSG___ => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSAIDMSG___']");
	public BaseInputControl LED_MESSA___MESSAMAILSENT => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSAMAILSENT']");
	public BaseInputControl LED_MESSA___MESSAMAILERR_ => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSAMAILERR_']");
	public LookupControl IFF_MESSA___ENTITNAME____ => new LookupControl(driver, "CONTAINER_IFF_MESSA___ENTITNAME____", "ValCodentit_chzn");
	public LookupControl IFF_MESSA___PERSONAME____ => new LookupControl(driver, "CONTAINER_IFF_MESSA___PERSONAME____", "ValCodperso_chzn");
	public BaseInputControl LED_MESSA___MESSADOCUM_NR => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSADOCUM_NR']");
	public BaseInputControl LED_MESSA___MESSADESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSADESIGNAT']");
	public BaseInputControl LED_MESSA___MESSAEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSAEMAIL___']");
	public BaseInputControl LED_MESSA___MESSAMESSAGE_ => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSAMESSAGE_']");
	public BaseInputControl LED_MESSA___MESSACREATOPE => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSACREATOPE']");
	public BaseInputControl LED_MESSA___MESSACREATDAT => new BaseInputControl(driver, "[data-identifier='LED_MESSA___MESSACREATDAT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public MessaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

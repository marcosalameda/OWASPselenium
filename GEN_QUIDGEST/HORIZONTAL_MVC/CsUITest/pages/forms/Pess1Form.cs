using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pess1Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pess1']"));

	public LookupControl IFF_PESS1___CMPNYDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_PESS1___CMPNYDESIGNAT", "ValCodempre_chzn");
	public LookupControl IFF_PESS1___STAKEDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_PESS1___STAKEDESIGNAT", "ValCodparte_chzn");
	public BaseInputControl LED_PESS1___PESS1NAME____ => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1NAME____']");
	public EnumControl LED_PESS1___PESS1GENDER__ => new EnumControl(driver, "CONTAINER_LED_PESS1___PESS1GENDER__", "ValGender_chzn_Pess1");
	public BaseInputControl LED_PESS1___PESS1DTNASCIM => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1DTNASCIM']");
	public BaseInputControl LED_PESS1___PESS1IDFUNCIO => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1IDFUNCIO']");
	public BaseInputControl LED_PESS1___PESS1TELEPHON => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1TELEPHON']");
	public BaseInputControl LED_PESS1___PESS1EMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1EMAIL___']");
	public BaseInputControl LED_PESS1___PESS1EMAIL2__ => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1EMAIL2__']");
	public BaseInputControl LED_PESS1___PESS1PHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1PHOTOGRA']");
	public BaseInputControl LED_PESS1___PESS1DTULTCAT => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1DTULTCAT']");
	public BaseInputControl LED_PESS1___PESS1EXTERNA_ => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1EXTERNA_']");
	public BaseInputControl LED_PESS1___PESS1INTERNA_ => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1INTERNA_']");
	public BaseInputControl LED_PESS1___PESS1IDADE___ => new BaseInputControl(driver, "[data-identifier='LED_PESS1___PESS1IDADE___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Pess1Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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

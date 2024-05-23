using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AccordiForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Accordi']"));

	public BaseInputControl IFF_ACCORDI_PSEUDNOVOGR02 => new BaseInputControl(driver, "[data-identifier='IFF_ACCORDI_PSEUDNOVOGR02']");
	public LookupControl IFF_ACCORDI_CMPNYDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_ACCORDI_CMPNYDESIGNAT", "ValCodempre_chzn");
	public LookupControl IFF_ACCORDI_PESS1NAME____ => new LookupControl(driver, "CONTAINER_IFF_ACCORDI_PESS1NAME____", "ValCodpesso_chzn");
	public BaseInputControl LED_ACCORDI_EQUIPSEQUENNR => new BaseInputControl(driver, "[data-identifier='LED_ACCORDI_EQUIPSEQUENNR']");
	public BaseInputControl IFF_ACCORDI_PSEUDNOVOGR06 => new BaseInputControl(driver, "[data-identifier='IFF_ACCORDI_PSEUDNOVOGR06']");
	public BaseInputControl LED_ACCORDI_EQUIPPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_ACCORDI_EQUIPPHOTOGRA']");
	public BaseInputControl IFF_ACCORDI_PSEUDNOVOGR05 => new BaseInputControl(driver, "[data-identifier='IFF_ACCORDI_PSEUDNOVOGR05']");
	public ListControl IFF_ACCORDI_PSEUDINSTALAG => new ListControl(driver, "ValInstalag", "#Accordi_ValInstalag");
	public ListControl IFF_ACCORDI_PSEUDINSTALAC => new ListControl(driver, "ValInstalac", "#Accordi_ValInstalac");
	public ListControl IFF_ACCORDI_PSEUDREPARACO => new ListControl(driver, "ValReparaco", "#Accordi_ValReparaco");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public AccordiForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

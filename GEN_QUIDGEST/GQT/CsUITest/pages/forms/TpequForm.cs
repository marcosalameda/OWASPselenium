using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpequForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Tpequ']"));

	public LookupControl IFF_TPEQU___FAMILFAMILY__ => new LookupControl(driver, "CONTAINER_IFF_TPEQU___FAMILFAMILY__", "ValCodfamil_chzn");
	public BaseInputControl LED_TPEQU___TPEQUTIPOEQUI => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUTIPOEQUI']");
	public BaseInputControl LED_TPEQU___TPEQUTPEQUCOD => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUTPEQUCOD']");
	public BaseInputControl LED_TPEQU___TPEQUNIVEL___ => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUNIVEL___']");
	public BaseInputControl IFF_TPEQU___PSEUDNOVOGR05 => new BaseInputControl(driver, "[data-identifier='IFF_TPEQU___PSEUDNOVOGR05']");
	public BaseInputControl LED_TPEQU___TPEQUKIT_____ => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUKIT_____']");
	public BaseInputControl LED_TPEQU___TPEQUPRECOMAX => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUPRECOMAX']");
	public BaseInputControl LED_TPEQU___TPEQUBACKCOLO => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUBACKCOLO']");
	public BaseInputControl LED_TPEQU___TPEQUCORLETRA => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUCORLETRA']");
	public BaseInputControl LED_TPEQU___TPEQUTPEQUPAI => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUTPEQUPAI']");
	public BaseInputControl LED_TPEQU___TPEQUPRECOULT => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUPRECOULT']");
	public BaseInputControl LED_TPEQU___TPEQUSINCE___ => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUSINCE___']");
	public ListControl IFF_TPEQU___PSEUDCOMPONEN => new ListControl(driver, "ValComponen", "#Tpequ_ValComponen");
	public ListControl IFF_TPEQU___PSEUDEVOLUCAO => new ListControl(driver, "ValEvolucao", "#Tpequ_ValEvolucao");
	public IWebElement IFF_TPEQU___PSEUDUNICO___ => throw new NotImplementedException();
	public ListControl IFF_TPEQU___PSEUDINSTALAC => new ListControl(driver, "ValInstalac", "#Tpequ_ValInstalac");
	public ListControl IFF_TPEQU___PSEUDINSTALA1 => new ListControl(driver, "ValInstala1", "#Tpequ_ValInstala1");
	public BaseInputControl LED_TPEQU___TPEQUQTDEQUIP => new BaseInputControl(driver, "[data-identifier='LED_TPEQU___TPEQUQTDEQUIP']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public TpequForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

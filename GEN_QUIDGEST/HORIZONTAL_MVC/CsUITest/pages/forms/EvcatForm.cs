using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EvcatForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Evcat']"));

	public LookupControl IFF_EVCAT___PESSONAME____ => new LookupControl(driver, "CONTAINER_IFF_EVCAT___PESSONAME____", "ValCodpesso_chzn");
	public LookupControl IFF_EVCAT___CATE1CATEGORY => new LookupControl(driver, "CONTAINER_IFF_EVCAT___CATE1CATEGORY", "ValCodcateg_chzn");
	public BaseInputControl LED_EVCAT___EVCATSINCE___ => new BaseInputControl(driver, "[data-identifier='LED_EVCAT___EVCATSINCE___']");
	public BaseInputControl LED_EVCAT___EVCATUNTIL___ => new BaseInputControl(driver, "[data-identifier='LED_EVCAT___EVCATUNTIL___']");
	public BaseInputControl LED_EVCAT___EVCATUNTILMAN => new BaseInputControl(driver, "[data-identifier='LED_EVCAT___EVCATUNTILMAN']");
	public BaseInputControl LED_EVCAT___EVCATFIMPERIO => new BaseInputControl(driver, "[data-identifier='LED_EVCAT___EVCATFIMPERIO']");
	public BaseInputControl LED_EVCAT___EVCATOBSERVAT => new BaseInputControl(driver, "[data-identifier='LED_EVCAT___EVCATOBSERVAT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EvcatForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

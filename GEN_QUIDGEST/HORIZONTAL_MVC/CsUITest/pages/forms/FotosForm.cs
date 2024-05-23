using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FotosForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Fotos']"));

	public LookupControl IFF_FOTOS___EQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_FOTOS___EQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_FOTOS___PHOTOPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_FOTOS___PHOTOPHOTOGRA']");
	public BaseInputControl LED_FOTOS___PHOTOTITLE___ => new BaseInputControl(driver, "[data-identifier='LED_FOTOS___PHOTOTITLE___']");
	public BaseInputControl LED_FOTOS___PHOTOANEXED__ => new BaseInputControl(driver, "[data-identifier='LED_FOTOS___PHOTOANEXED__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public FotosForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

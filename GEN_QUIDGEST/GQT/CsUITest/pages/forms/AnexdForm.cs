using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AnexdForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Anexd']"));

	public LookupControl IFF_ANEXD___EQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_ANEXD___EQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_ANEXD___ANEXDDTHRANEX => new BaseInputControl(driver, "[data-identifier='LED_ANEXD___ANEXDDTHRANEX']");
	public BaseInputControl LED_ANEXD___ANEXDREFERENC => new BaseInputControl(driver, "[data-identifier='LED_ANEXD___ANEXDREFERENC']");
	public BaseInputControl LED_ANEXD___ANEXDTITLE___ => new BaseInputControl(driver, "[data-identifier='LED_ANEXD___ANEXDTITLE___']");
	public LookupControl IFF_ANEXD___LANGULANGUA__ => new LookupControl(driver, "CONTAINER_IFF_ANEXD___LANGULANGUA__", "ValCodlang_chzn");
	public BaseInputControl LED_ANEXD___ANEXDTITTRADU => new BaseInputControl(driver, "[data-identifier='LED_ANEXD___ANEXDTITTRADU']");
	public BaseInputControl LED_ANEXD___ANEXDDOCUMENT => new BaseInputControl(driver, "[data-identifier='LED_ANEXD___ANEXDDOCUMENT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public AnexdForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

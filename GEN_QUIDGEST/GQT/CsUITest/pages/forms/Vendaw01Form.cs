using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw01Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Vendaw01']"));

	public LookupControl IFF_VENDAW01ORGANORGANIZA => new LookupControl(driver, "CONTAINER_IFF_VENDAW01ORGANORGANIZA", "ValCodorgan_chzn");
	public BaseInputControl LED_VENDAW01SALE_IDENTIFI => new BaseInputControl(driver, "[data-identifier='LED_VENDAW01SALE_IDENTIFI']");
	public BaseInputControl LED_VENDAW01SALE_POTCOMPR => new BaseInputControl(driver, "[data-identifier='LED_VENDAW01SALE_POTCOMPR']");
	public BaseInputControl LED_VENDAW01SALE_PROSPECC => new BaseInputControl(driver, "[data-identifier='LED_VENDAW01SALE_PROSPECC']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Vendaw01Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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

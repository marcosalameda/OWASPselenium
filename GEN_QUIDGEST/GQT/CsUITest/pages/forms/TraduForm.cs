using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TraduForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Tradu']"));

	public BaseInputControl LED_TRADU___TRADUREFERENC => new BaseInputControl(driver, "[data-identifier='LED_TRADU___TRADUREFERENC']");
	public LookupControl IFF_TRADU___LANG1LANGUA__ => new LookupControl(driver, "CONTAINER_IFF_TRADU___LANG1LANGUA__", "ValCodlang_chzn");
	public BaseInputControl LED_TRADU___TRADUATRADUZI => new BaseInputControl(driver, "[data-identifier='LED_TRADU___TRADUATRADUZI']");
	public LookupControl IFF_TRADU___LANG2LANGUA__ => new LookupControl(driver, "CONTAINER_IFF_TRADU___LANG2LANGUA__", "ValCodlang_chzn");
	public BaseInputControl LED_TRADU___TRADUTRADUZID => new BaseInputControl(driver, "[data-identifier='LED_TRADU___TRADUTRADUZID']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public TraduForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

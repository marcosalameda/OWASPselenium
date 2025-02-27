using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TabprForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Tabpr']"));

	public LookupControl IFF_TABPR___TPEQUTIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_TABPR___TPEQUTIPOEQUI", "ValCodtpequ_chzn");
	public BaseInputControl LED_TABPR___TABPRSINCE___ => new BaseInputControl(driver, "[data-identifier='LED_TABPR___TABPRSINCE___']");
	public BaseInputControl LED_TABPR___TABPRPRECOHOR => new BaseInputControl(driver, "[data-identifier='LED_TABPR___TABPRPRECOHOR']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public TabprForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

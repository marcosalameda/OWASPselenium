using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CatarForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Catar']"));

	public LookupControl IFF_CATAR___ITEM_ITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_CATAR___ITEM_ITEMDES_", "ValCoditem_chzn");
	public LookupControl IFF_CATAR___CATTPTPCATEGO => new LookupControl(driver, "CONTAINER_IFF_CATAR___CATTPTPCATEGO", "ValCodtpcat_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CatarForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

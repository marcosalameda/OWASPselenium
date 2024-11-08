using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Fami1Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Fami1']"));

	public BaseInputControl LED_FAMI1___FAMI1FAMILY__ => new BaseInputControl(driver, "[data-identifier='LED_FAMI1___FAMI1FAMILY__']");
	public ListControl IFF_FAMI1___PSEUDTIPOSEQU => new ListControl(driver, "ValTiposequ", "#Fami1_ValTiposequ");
	public BaseInputControl IFF_FAMI1___PSEUDTIPOSEQ1 => new BaseInputControl(driver, "[data-identifier='IFF_FAMI1___PSEUDTIPOSEQ1']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Fami1Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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

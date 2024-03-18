using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TimequipForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Timequip']"));

	public ListControl IFF_TIMEQUIPPSEUDREPARACO => new ListControl(driver, "ValReparaco", "#Timequip_ValReparaco");
	public BaseInputControl IFF_TIMEQUIPPSEUDPRIMARY_ => new BaseInputControl(driver, "[data-identifier='IFF_TIMEQUIPPSEUDPRIMARY_']");
	public BaseInputControl IFF_TIMEQUIPPSEUDSECUNDAR => new BaseInputControl(driver, "[data-identifier='IFF_TIMEQUIPPSEUDSECUNDAR']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public TimequipForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

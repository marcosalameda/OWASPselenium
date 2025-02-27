using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Armaz02Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Armaz02']"));

	public BaseInputControl IFF_ARMAZ02_PSEUDARTIGAPO => new BaseInputControl(driver, "[data-identifier='IFF_ARMAZ02_PSEUDARTIGAPO']");
	public ListControl IFF_ARMAZ02_PSEUDARTIGOS_ => new ListControl(driver, "ValArtigos", "#Armaz02_ValArtigos");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public Armaz02Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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

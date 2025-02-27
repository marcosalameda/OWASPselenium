using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ExtformsForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Extforms']"));

	public BaseInputControl IFF_EXTFORMSPSEUDARTIGAPO => new BaseInputControl(driver, "[data-identifier='IFF_EXTFORMSPSEUDARTIGAPO']");
	public ListControl IFF_EXTFORMSPSEUDARTIGOS_ => new ListControl(driver, "ValArtigos", "#Extforms_ValArtigos");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public ExtformsForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

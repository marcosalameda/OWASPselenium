using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EsppeForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Esppe']"));

	public LookupControl IFF_ESPPE___PESSONAME____ => new LookupControl(driver, "CONTAINER_IFF_ESPPE___PESSONAME____", "ValCodpesso_chzn");
	public LookupControl IFF_ESPPE___SPECIESPECIAL => new LookupControl(driver, "CONTAINER_IFF_ESPPE___SPECIESPECIAL", "ValCodespec_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EsppeForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

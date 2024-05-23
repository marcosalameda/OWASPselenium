using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ContaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Conta']"));

	public LookupControl IFF_CONTA___PESSONAME____ => new LookupControl(driver, "CONTAINER_IFF_CONTA___PESSONAME____", "ValCodpesso_chzn");
	public LookupControl IFF_CONTA___GENREGENDER__ => new LookupControl(driver, "CONTAINER_IFF_CONTA___GENREGENDER__", "ValCodgenre_chzn");
	public LookupControl IFF_CONTA___TPCONTIPOCONT => new LookupControl(driver, "CONTAINER_IFF_CONTA___TPCONTIPOCONT", "ValCodtpcon_chzn");
	public BaseInputControl LED_CONTA___CONTACONTACTO => new BaseInputControl(driver, "[data-identifier='LED_CONTA___CONTACONTACTO']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ContaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

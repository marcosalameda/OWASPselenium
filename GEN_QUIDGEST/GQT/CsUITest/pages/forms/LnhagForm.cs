using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhagForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Lnhag']"));

	public LookupControl IFF_LNHAG___PEDIDNRPEDIDO => new LookupControl(driver, "CONTAINER_IFF_LNHAG___PEDIDNRPEDIDO", "ValCodpedid_chzn");
	public LookupControl IFF_LNHAG___TPEQ1TIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_LNHAG___TPEQ1TIPOEQUI", "ValCodtpequ_chzn");
	public BaseInputControl LED_LNHAG___LNHAGQTDTPEQU => new BaseInputControl(driver, "[data-identifier='LED_LNHAG___LNHAGQTDTPEQU']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public LnhagForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

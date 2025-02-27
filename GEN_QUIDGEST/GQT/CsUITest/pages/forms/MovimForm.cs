using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MovimForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Movim']"));

	public BaseInputControl LED_MOVIM___MOVIMDHMUDANC => new BaseInputControl(driver, "[data-identifier='LED_MOVIM___MOVIMDHMUDANC']");
	public LookupControl IFF_MOVIM___EQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_MOVIM___EQUIPREGISTNR", "ValCodequip_chzn");
	public LookupControl IFF_MOVIM___ROOMSROOMNR__ => new LookupControl(driver, "CONTAINER_IFF_MOVIM___ROOMSROOMNR__", "ValCodrooms_chzn");
	public BaseInputControl LED_MOVIM___MOVIMOBSERVAT => new BaseInputControl(driver, "[data-identifier='LED_MOVIM___MOVIMOBSERVAT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public MovimForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

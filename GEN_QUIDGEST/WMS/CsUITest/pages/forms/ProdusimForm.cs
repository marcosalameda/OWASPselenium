using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProdusimForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Produsim']"));

	public BaseInputControl LED_PRODUSIMPRODUPRODUCT_ => new BaseInputControl(driver, "[data-identifier='LED_PRODUSIMPRODUPRODUCT_']");
	public BaseInputControl LED_PRODUSIMPRODUDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_PRODUSIMPRODUDESCRIPT']");
	public BaseInputControl LED_PRODUSIMPRODUSKU_____ => new BaseInputControl(driver, "[data-identifier='LED_PRODUSIMPRODUSKU_____']");
	public BaseInputControl LED_PRODUSIMPRODUGTIN____ => new BaseInputControl(driver, "[data-identifier='LED_PRODUSIMPRODUGTIN____']");
	public BaseInputControl LED_PRODUSIMPRODUSIZE____ => new BaseInputControl(driver, "[data-identifier='LED_PRODUSIMPRODUSIZE____']");
	public BaseInputControl LED_PRODUSIMPRODUWEIGHT__ => new BaseInputControl(driver, "[data-identifier='LED_PRODUSIMPRODUWEIGHT__']");
	public BaseInputControl IFF_PRODUSIMPSEUDNOVOGR02 => new BaseInputControl(driver, "[data-identifier='IFF_PRODUSIMPSEUDNOVOGR02']");
	public LookupControl IFF_PRODUSIMLOCATGLN_____ => new LookupControl(driver, "CONTAINER_IFF_PRODUSIMLOCATGLN_____", "ValCodlocat_chzn");
	public LookupControl IFF_PRODUSIMLCEXTGLNEXT__ => new LookupControl(driver, "CONTAINER_IFF_PRODUSIMLCEXTGLNEXT__", "ValCodlcext_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ProdusimForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

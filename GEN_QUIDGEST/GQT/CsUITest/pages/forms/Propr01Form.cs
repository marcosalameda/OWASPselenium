using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr01Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Propr01']"));

	public BaseInputControl LED_PROPR01_PROPRENDERECO => new BaseInputControl(driver, "[data-identifier='LED_PROPR01_PROPRENDERECO']");
	public BaseInputControl LED_PROPR01_PROPRLOCALIDA => new BaseInputControl(driver, "[data-identifier='LED_PROPR01_PROPRLOCALIDA']");
	public BaseInputControl LED_PROPR01_PROPRPOSTALCO => new BaseInputControl(driver, "[data-identifier='LED_PROPR01_PROPRPOSTALCO']");
	public BaseInputControl LED_PROPR01_PROPRPOSTALLO => new BaseInputControl(driver, "[data-identifier='LED_PROPR01_PROPRPOSTALLO']");
	public LookupControl IFF_PROPR01_CNTRYCOUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_PROPR01_CNTRYCOUNTRY_", "ValCodcntry_chzn");
	public LookupControl IFF_PROPR01_REGIOREGIAO__ => new LookupControl(driver, "CONTAINER_IFF_PROPR01_REGIOREGIAO__", "ValCodregia_chzn");
	public BaseInputControl LED_PROPR01_PROPRCOORDGEO => new BaseInputControl(driver, "[data-identifier='LED_PROPR01_PROPRCOORDGEO']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Propr01Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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

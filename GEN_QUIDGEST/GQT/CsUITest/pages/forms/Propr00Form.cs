using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr00Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Propr00']"));

	public BaseInputControl LED_PROPR00_PROPRNAME____ => new BaseInputControl(driver, "[data-identifier='LED_PROPR00_PROPRNAME____']");
	public BaseInputControl LED_PROPR00_PROPRPRECOEST => new BaseInputControl(driver, "[data-identifier='LED_PROPR00_PROPRPRECOEST']");
	public LookupControl IFF_PROPR00_TPPROTPPROPRI => new LookupControl(driver, "CONTAINER_IFF_PROPR00_TPPROTPPROPRI", "ValCodtppro_chzn");
	public BaseInputControl LED_PROPR00_PROPRMOBILADA => new BaseInputControl(driver, "[data-identifier='LED_PROPR00_PROPRMOBILADA']");
	public LookupControl IFF_PROPR00_PESSONAME____ => new LookupControl(driver, "CONTAINER_IFF_PROPR00_PESSONAME____", "ValCodpesso_chzn");
	public BaseInputControl LED_PROPR00_PROPRPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_PROPR00_PROPRPHOTOGRA']");
	public BaseInputControl IFF_PROPR00_PSEUDPROPR02_ => new BaseInputControl(driver, "[data-identifier='IFF_PROPR00_PSEUDPROPR02_']");
	public BaseInputControl IFF_PROPR00_PSEUDPROPR01_ => new BaseInputControl(driver, "[data-identifier='IFF_PROPR00_PSEUDPROPR01_']");
	public BaseInputControl IFF_PROPR00_PSEUDPROPR03_ => new BaseInputControl(driver, "[data-identifier='IFF_PROPR00_PSEUDPROPR03_']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Propr00Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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

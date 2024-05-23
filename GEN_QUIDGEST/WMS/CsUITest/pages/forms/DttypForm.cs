using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DttypForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Dttyp']"));

	public BaseInputControl IFF_DTTYP___PSEUDNOVOGR06 => new BaseInputControl(driver, "[data-identifier='IFF_DTTYP___PSEUDNOVOGR06']");
	public BaseInputControl LED_DTTYP___DTTYPSTRING__ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPSTRING__']");
	public BaseInputControl LED_DTTYP___DTTYPUPPERCAS => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPUPPERCAS']");
	public BaseInputControl LED_DTTYP___DTTYPUUID____ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPUUID____']");
	public BaseInputControl LED_DTTYP___DTTYPQRCODE__ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPQRCODE__']");
	public BaseInputControl LED_DTTYP___DTTYPMULTILIN => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPMULTILIN']");
	public BaseInputControl IFF_DTTYP___DTTYPMULTILI3 => new BaseInputControl(driver, "[data-identifier='IFF_DTTYP___DTTYPMULTILI3']");
	public BaseInputControl LED_DTTYP___DTTYPBOOLEAN_ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPBOOLEAN_']");
	public BaseInputControl LED_DTTYP___DTTYPBOOLEAN2 => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPBOOLEAN2']");
	public BaseInputControl LED_DTTYP___DTTYPSMALLINT => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPSMALLINT']");
	public BaseInputControl LED_DTTYP___DTTYPINTEGER_ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPINTEGER_']");
	public BaseInputControl LED_DTTYP___DTTYPBIGINT__ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPBIGINT__']");
	public BaseInputControl LED_DTTYP___DTTYPREAL____ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPREAL____']");
	public BaseInputControl LED_DTTYP___DTTYPFLOAT___ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPFLOAT___']");
	public BaseInputControl LED_DTTYP___DTTYPDECIMAL_ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPDECIMAL_']");
	public BaseInputControl LED_DTTYP___DTTYPDECIMAL9 => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPDECIMAL9']");
	public BaseInputControl LED_DTTYP___DTTYPMONEY___ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPMONEY___']");
	public BaseInputControl LED_DTTYP___DTTYPMONEY9__ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPMONEY9__']");
	public BaseInputControl LED_DTTYP___DTTYPDATE____ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPDATE____']");
	public BaseInputControl LED_DTTYP___DTTYPDATETIME => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPDATETIME']");
	public BaseInputControl LED_DTTYP___DTTYPDTSESOND => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPDTSESOND']");
	public BaseInputControl LED_DTTYP___DTTYPTIME____ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPTIME____']");
	public BaseInputControl LED_DTTYP___DTTYPIMAGE___ => new BaseInputControl(driver, "[data-identifier='LED_DTTYP___DTTYPIMAGE___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public DttypForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

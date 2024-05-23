using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FacilfexForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Facilfex']"));

	public LookupControl IFF_FACILFEXENTITNAME____ => new LookupControl(driver, "CONTAINER_IFF_FACILFEXENTITNAME____", "ValCodentit_chzn");
	public BaseInputControl LED_FACILFEXFACILINCORPOR => new BaseInputControl(driver, "[data-identifier='LED_FACILFEXFACILINCORPOR']");
	public BaseInputControl LED_FACILFEXFACILNAME____ => new BaseInputControl(driver, "[data-identifier='LED_FACILFEXFACILNAME____']");
	public EnumControl LED_FACILFEXFACILFACILTYP => new EnumControl(driver, "CONTAINER_LED_FACILFEXFACILFACILTYP", "ValFaciltyp_chzn_Facilfex");
	public LookupControl IFF_FACILFEXFACTYTYPE____ => new LookupControl(driver, "CONTAINER_IFF_FACILFEXFACTYTYPE____", "ValCodfacty_chzn");
	public BaseInputControl LED_FACILFEXFACILLATITUDE => new BaseInputControl(driver, "[data-identifier='LED_FACILFEXFACILLATITUDE']");
	public BaseInputControl LED_FACILFEXFACILLONGITUD => new BaseInputControl(driver, "[data-identifier='LED_FACILFEXFACILLONGITUD']");
	public BaseInputControl LED_FACILFEXFACILADDRESS_ => new BaseInputControl(driver, "[data-identifier='LED_FACILFEXFACILADDRESS_']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public FacilfexForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

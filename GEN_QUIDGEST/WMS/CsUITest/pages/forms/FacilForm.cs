using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FacilForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Facil']"));

	public LookupControl IFF_FACIL___ENTITNAME____ => new LookupControl(driver, "CONTAINER_IFF_FACIL___ENTITNAME____", "ValCodentit_chzn");
	public BaseInputControl LED_FACIL___FACILINCORPOR => new BaseInputControl(driver, "[data-identifier='LED_FACIL___FACILINCORPOR']");
	public BaseInputControl LED_FACIL___FACILNAME____ => new BaseInputControl(driver, "[data-identifier='LED_FACIL___FACILNAME____']");
	public EnumControl LED_FACIL___FACILFACILTYP => new EnumControl(driver, "CONTAINER_LED_FACIL___FACILFACILTYP", "ValFaciltyp_chzn_Facil");
	public LookupControl IFF_FACIL___FACTYTYPE____ => new LookupControl(driver, "CONTAINER_IFF_FACIL___FACTYTYPE____", "ValCodfacty_chzn");
	public BaseInputControl LED_FACIL___FACILADDRESS_ => new BaseInputControl(driver, "[data-identifier='LED_FACIL___FACILADDRESS_']");
	public BaseInputControl LED_FACIL___FACILIMAGE___ => new BaseInputControl(driver, "[data-identifier='LED_FACIL___FACILIMAGE___']");
	public EnumControl LED_FACIL___FACILGPSINPUT => new EnumControl(driver, "CONTAINER_LED_FACIL___FACILGPSINPUT", "ValGpsinput_chzn_Facil");
	public BaseInputControl LED_FACIL___FACILLATITUDE => new BaseInputControl(driver, "[data-identifier='LED_FACIL___FACILLATITUDE']");
	public BaseInputControl LED_FACIL___FACILLONGITUD => new BaseInputControl(driver, "[data-identifier='LED_FACIL___FACILLONGITUD']");
	public BaseInputControl LED_FACIL___FACILGEOCOORI => new BaseInputControl(driver, "[data-identifier='LED_FACIL___FACILGEOCOORI']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public FacilForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntitForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Entit']"));

	public BaseInputControl LED_ENTIT___ENTITNAME____ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITNAME____']");
	public BaseInputControl LED_ENTIT___ENTITINITIALS => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITINITIALS']");
	public BaseInputControl LED_ENTIT___ENTITREGISTRA => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITREGISTRA']");
	public BaseInputControl LED_ENTIT___ENTITTAXNUMBE => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITTAXNUMBE']");
	public BaseInputControl LED_ENTIT___ENTITEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITEMAIL___']");
	public BaseInputControl LED_ENTIT___ENTITPHONENUM => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITPHONENUM']");
	public BaseInputControl LED_ENTIT___ENTITIBAN____ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITIBAN____']");
	public BaseInputControl LED_ENTIT___ENTITBUILDING => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITBUILDING']");
	public BaseInputControl LED_ENTIT___ENTITSTREET__ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITSTREET__']");
	public BaseInputControl LED_ENTIT___ENTITTOWN____ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITTOWN____']");
	public BaseInputControl LED_ENTIT___ENTITCOUNTY__ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITCOUNTY__']");
	public BaseInputControl LED_ENTIT___ENTITSTATE___ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITSTATE___']");
	public BaseInputControl LED_ENTIT___ENTITPOBOX___ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITPOBOX___']");
	public BaseInputControl LED_ENTIT___ENTITPOSTALCO => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITPOSTALCO']");
	public BaseInputControl LED_ENTIT___ENTITTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITTELEPHON']");
	public BaseInputControl LED_ENTIT___ENTITFAX_____ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITFAX_____']");
	public BaseInputControl LED_ENTIT___ENTITWEBSITE_ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITWEBSITE_']");
	public BaseInputControl LED_ENTIT___ENTITPERSON__ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITPERSON__']");
	public BaseInputControl LED_ENTIT___ENTITCONTACT_ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITCONTACT_']");
	public BaseInputControl LED_ENTIT___ENTITOWNER___ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITOWNER___']");
	public BaseInputControl LED_ENTIT___ENTITCARRIER_ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITCARRIER_']");
	public BaseInputControl LED_ENTIT___ENTITSUPPLIER => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITSUPPLIER']");
	public BaseInputControl LED_ENTIT___ENTITMANUFACT => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITMANUFACT']");
	public BaseInputControl LED_ENTIT___ENTITFOUNDED_ => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITFOUNDED_']");
	public LookupControl IFF_ENTIT___FACI1NAME____ => new LookupControl(driver, "CONTAINER_IFF_ENTIT___FACI1NAME____", "ValCodfacil_chzn");
	public LookupControl IFF_ENTIT___FACI2NAME____ => new LookupControl(driver, "CONTAINER_IFF_ENTIT___FACI2NAME____", "ValCodfacil_chzn");
	public BaseInputControl LED_ENTIT___ENTITLANGUAGE => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITLANGUAGE']");
	public BaseInputControl LED_ENTIT___ENTITCURRENCY => new BaseInputControl(driver, "[data-identifier='LED_ENTIT___ENTITCURRENCY']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EntitForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

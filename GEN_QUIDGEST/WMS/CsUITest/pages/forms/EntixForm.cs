using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EntixForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Entix']"));

	public BaseInputControl LED_ENTIX___ENTITNAME____ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITNAME____']");
	public BaseInputControl LED_ENTIX___ENTITFOUNDED_ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITFOUNDED_']");
	public BaseInputControl LED_ENTIX___ENTITINITIALS => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITINITIALS']");
	public BaseInputControl LED_ENTIX___ENTITREGISTRA => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITREGISTRA']");
	public BaseInputControl LED_ENTIX___ENTITTAXNUMBE => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITTAXNUMBE']");
	public BaseInputControl LED_ENTIX___ENTITIBAN____ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITIBAN____']");
	public BaseInputControl LED_ENTIX___ENTITPHONENUM => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITPHONENUM']");
	public BaseInputControl LED_ENTIX___ENTITOWNER___ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITOWNER___']");
	public BaseInputControl LED_ENTIX___ENTITCARRIER_ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITCARRIER_']");
	public BaseInputControl LED_ENTIX___ENTITSUPPLIER => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITSUPPLIER']");
	public BaseInputControl LED_ENTIX___ENTITMANUFACT => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITMANUFACT']");
	public BaseInputControl IFF_ENTIX___PSEUDNOVOGR05 => new BaseInputControl(driver, "[data-identifier='IFF_ENTIX___PSEUDNOVOGR05']");
	public BaseInputControl LED_ENTIX___ENTITTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITTELEPHON']");
	public BaseInputControl LED_ENTIX___ENTITFAX_____ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITFAX_____']");
	public BaseInputControl LED_ENTIX___ENTITEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITEMAIL___']");
	public BaseInputControl LED_ENTIX___ENTITWEBSITE_ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITWEBSITE_']");
	public BaseInputControl LED_ENTIX___ENTITPERSON__ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITPERSON__']");
	public BaseInputControl LED_ENTIX___ENTITCONTACT_ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITCONTACT_']");
	public BaseInputControl LED_ENTIX___ENTITLANGUAGE => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITLANGUAGE']");
	public BaseInputControl LED_ENTIX___ENTITCURRENCY => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITCURRENCY']");
	public BaseInputControl LED_ENTIX___ENTITBUILDING => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITBUILDING']");
	public BaseInputControl LED_ENTIX___ENTITSTREET__ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITSTREET__']");
	public BaseInputControl LED_ENTIX___ENTITTOWN____ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITTOWN____']");
	public BaseInputControl LED_ENTIX___ENTITCOUNTY__ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITCOUNTY__']");
	public BaseInputControl LED_ENTIX___ENTITSTATE___ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITSTATE___']");
	public BaseInputControl LED_ENTIX___ENTITPOSTALCO => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITPOSTALCO']");
	public BaseInputControl LED_ENTIX___ENTITPOBOX___ => new BaseInputControl(driver, "[data-identifier='LED_ENTIX___ENTITPOBOX___']");
	public LookupControl IFF_ENTIX___FACI1NAME____ => new LookupControl(driver, "CONTAINER_IFF_ENTIX___FACI1NAME____", "ValCodfacil_chzn");
	public LookupControl IFF_ENTIX___FACI2NAME____ => new LookupControl(driver, "CONTAINER_IFF_ENTIX___FACI2NAME____", "ValCodfacil_chzn");
	public ListControl IFF_ENTIX___PSEUDFACILITE => new ListControl(driver, "ValFacilite", "#Entix_ValFacilite");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EntixForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

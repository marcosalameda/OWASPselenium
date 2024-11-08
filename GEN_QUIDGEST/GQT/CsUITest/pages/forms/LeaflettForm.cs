using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LeaflettForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Leaflett']"));

	public LookupControl IFF_LEAFLETTEQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_LEAFLETTEQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_LEAFLETTTPEQUTIPOEQUI => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTTPEQUTIPOEQUI']");
	public BaseInputControl LED_LEAFLETTINSTADESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTADESCRIPT']");
	public BaseInputControl LED_LEAFLETTINSTADESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTADESIGNAT']");
	public BaseInputControl LED_LEAFLETTINSTADTINIAGE => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTADTINIAGE']");
	public BaseInputControl LED_LEAFLETTINSTADTFIMAGE => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTADTFIMAGE']");
	public BaseInputControl LED_LEAFLETTINSTAALLDAY__ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTAALLDAY__']");
	public BaseInputControl LED_LEAFLETTINSTASINCE___ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTASINCE___']");
	public BaseInputControl LED_LEAFLETTINSTAUNTIL___ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTAUNTIL___']");
	public BaseInputControl LED_LEAFLETTINSTAHOURS___ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTAHOURS___']");
	public BaseInputControl LED_LEAFLETTINSTAPRECOHOR => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTAPRECOHOR']");
	public BaseInputControl LED_LEAFLETTINSTAVALUE___ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTAVALUE___']");
	public BaseInputControl LED_LEAFLETTINSTACOORDGEO => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETTINSTACOORDGEO']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public LeaflettForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

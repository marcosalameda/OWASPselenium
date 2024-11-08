using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LeafletdForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Leafletd']"));

	public LookupControl IFF_LEAFLETDEQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_LEAFLETDEQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_LEAFLETDTPEQUTIPOEQUI => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDTPEQUTIPOEQUI']");
	public BaseInputControl LED_LEAFLETDINSTADESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTADESIGNAT']");
	public BaseInputControl LED_LEAFLETDINSTADTINIAGE => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTADTINIAGE']");
	public BaseInputControl LED_LEAFLETDINSTADTFIMAGE => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTADTFIMAGE']");
	public BaseInputControl LED_LEAFLETDINSTADESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTADESCRIPT']");
	public BaseInputControl LED_LEAFLETDINSTAALLDAY__ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTAALLDAY__']");
	public BaseInputControl LED_LEAFLETDINSTASINCE___ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTASINCE___']");
	public BaseInputControl LED_LEAFLETDINSTAUNTIL___ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTAUNTIL___']");
	public BaseInputControl LED_LEAFLETDINSTAHOURS___ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTAHOURS___']");
	public BaseInputControl LED_LEAFLETDINSTAPRECOHOR => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTAPRECOHOR']");
	public BaseInputControl LED_LEAFLETDINSTAVALUE___ => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTAVALUE___']");
	public BaseInputControl LED_LEAFLETDINSTACOORDGEO => new BaseInputControl(driver, "[data-identifier='LED_LEAFLETDINSTACOORDGEO']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public LeafletdForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

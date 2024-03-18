using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InstaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Insta']"));

	public BaseInputControl IFF_INSTA___PSEUDNOVOGR01 => new BaseInputControl(driver, "[data-identifier='IFF_INSTA___PSEUDNOVOGR01']");
	public LookupControl IFF_INSTA___TPEQUTIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_INSTA___TPEQUTIPOEQUI", "ValCodtpequ_chzn");
	public LookupControl IFF_INSTA___EQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_INSTA___EQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_INSTA___EQUIPDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_INSTA___EQUIPDESIGNAT']");
	public BaseInputControl LED_INSTA___EQUIPPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_INSTA___EQUIPPHOTOGRA']");
	public BaseInputControl LED_INSTA___INSTASINCE___ => new BaseInputControl(driver, "[data-identifier='LED_INSTA___INSTASINCE___']");
	public BaseInputControl LED_INSTA___INSTAUNTIL___ => new BaseInputControl(driver, "[data-identifier='LED_INSTA___INSTAUNTIL___']");
	public BaseInputControl LED_INSTA___INSTAHOURS___ => new BaseInputControl(driver, "[data-identifier='LED_INSTA___INSTAHOURS___']");
	public BaseInputControl LED_INSTA___INSTAPRECOHOR => new BaseInputControl(driver, "[data-identifier='LED_INSTA___INSTAPRECOHOR']");
	public BaseInputControl LED_INSTA___INSTAVALUE___ => new BaseInputControl(driver, "[data-identifier='LED_INSTA___INSTAVALUE___']");
	public BaseInputControl LED_INSTA___INSTACOORDGEO => new BaseInputControl(driver, "[data-identifier='LED_INSTA___INSTACOORDGEO']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public InstaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

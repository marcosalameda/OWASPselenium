using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PersoForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Perso']"));

	public BaseInputControl LED_PERSO___PERSOPHOTO___ => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOPHOTO___']");
	public BaseInputControl LED_PERSO___PERSONAME____ => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSONAME____']");
	public BaseInputControl LED_PERSO___PERSOIDENTIFI => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOIDENTIFI']");
	public EnumControl LED_PERSO___PERSOGENDER__ => new EnumControl(driver, "CONTAINER_LED_PERSO___PERSOGENDER__", "ValGender_chzn_Perso");
	public BaseInputControl LED_PERSO___PERSOEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOEMAIL___']");
	public BaseInputControl LED_PERSO___PERSODOB_____ => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSODOB_____']");
	public BaseInputControl LED_PERSO___PERSOTOB_____ => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOTOB_____']");
	public BaseInputControl LED_PERSO___PERSOYEAR____ => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOYEAR____']");
	public EnumControl LED_PERSO___PERSOMONTH___ => new EnumControl(driver, "CONTAINER_LED_PERSO___PERSOMONTH___", "ValMonth_chzn_Perso");
	public BaseInputControl LED_PERSO___PERSOCREATUSR => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOCREATUSR']");
	public BaseInputControl LED_PERSO___PERSOCREATDAT => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOCREATDAT']");
	public BaseInputControl LED_PERSO___PERSOMODIFUSR => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOMODIFUSR']");
	public BaseInputControl LED_PERSO___PERSOMODIFDAT => new BaseInputControl(driver, "[data-identifier='LED_PERSO___PERSOMODIFDAT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public PersoForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

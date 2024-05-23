using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AsspaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Asspa']"));

	public LookupControl IFF_ASSPA___ASSETNAME____ => new LookupControl(driver, "CONTAINER_IFF_ASSPA___ASSETNAME____", "ValCodasset_chzn");
	public EnumControl LED_ASSPA___ASSPADATATYPE => new EnumControl(driver, "CONTAINER_LED_ASSPA___ASSPADATATYPE", "ValDatatype_chzn_Asspa");
	public BaseInputControl LED_ASSPA___ASSPADECPLACE => new BaseInputControl(driver, "[data-identifier='LED_ASSPA___ASSPADECPLACE']");
	public LookupControl IFF_ASSPA___PARAMPARAMETE => new LookupControl(driver, "CONTAINER_IFF_ASSPA___PARAMPARAMETE", "ValCodparam_chzn");
	public BaseInputControl LED_ASSPA___ASSPATEXT____ => new BaseInputControl(driver, "[data-identifier='LED_ASSPA___ASSPATEXT____']");
	public BaseInputControl LED_ASSPA___ASSPAQUANTITY => new BaseInputControl(driver, "[data-identifier='LED_ASSPA___ASSPAQUANTITY']");
	public BaseInputControl LED_ASSPA___ASSPADATE____ => new BaseInputControl(driver, "[data-identifier='LED_ASSPA___ASSPADATE____']");
	public BaseInputControl LED_ASSPA___ASSPATOSHOW__ => new BaseInputControl(driver, "[data-identifier='LED_ASSPA___ASSPATOSHOW__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public AsspaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

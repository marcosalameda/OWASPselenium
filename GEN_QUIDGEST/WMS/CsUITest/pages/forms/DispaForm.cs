using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DispaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Dispa']"));

	public BaseInputControl LED_DISPA___DISPADISPADT_ => new BaseInputControl(driver, "[data-identifier='LED_DISPA___DISPADISPADT_']");
	public BaseInputControl LED_DISPA___DISPADISPANR_ => new BaseInputControl(driver, "[data-identifier='LED_DISPA___DISPADISPANR_']");
	public EnumControl LED_DISPA___DISPASTATUS__ => new EnumControl(driver, "CONTAINER_LED_DISPA___DISPASTATUS__", "ValStatus_chzn_Dispa");
	public LookupControl IFF_DISPA___ENTITNAME____ => new LookupControl(driver, "CONTAINER_IFF_DISPA___ENTITNAME____", "ValCodentit_chzn");
	public BaseInputControl LED_DISPA___DISPAISPREPAR => new BaseInputControl(driver, "[data-identifier='LED_DISPA___DISPAISPREPAR']");
	public BaseInputControl LED_DISPA___DISPAPREPARED => new BaseInputControl(driver, "[data-identifier='LED_DISPA___DISPAPREPARED']");
	public LookupControl IFF_DISPA___PERSONAME____ => new LookupControl(driver, "CONTAINER_IFF_DISPA___PERSONAME____", "ValCodperso_chzn");
	public ListControl IFF_DISPA___PSEUDDISPATCH => new ListControl(driver, "ValDispatch", "#Dispa_ValDispatch");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public DispaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

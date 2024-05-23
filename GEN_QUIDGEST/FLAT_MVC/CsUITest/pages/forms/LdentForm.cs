using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdentForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Ldent']"));

	public LookupControl IFF_LDENT___INDOCDOCUMENR => new LookupControl(driver, "CONTAINER_IFF_LDENT___INDOCDOCUMENR", "ValCoddentr_chzn");
	public LookupControl IFF_LDENT___WAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_LDENT___WAREHWAREHDES", "ValCodwareh_chzn");
	public BaseInputControl LED_LDENT___LDENTLINE____ => new BaseInputControl(driver, "[data-identifier='LED_LDENT___LDENTLINE____']");
	public BaseInputControl LED_LDENT___LDENTEMUSO___ => new BaseInputControl(driver, "[data-identifier='LED_LDENT___LDENTEMUSO___']");
	public LookupControl IFF_LDENT___ITEM_ITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_LDENT___ITEM_ITEMDES_", "ValCoditem_chzn");
	public BaseInputControl LED_LDENT___LDENTQTDENTRA => new BaseInputControl(driver, "[data-identifier='LED_LDENT___LDENTQTDENTRA']");
	public BaseInputControl LED_LDENT___INDOCCODWAREH => new BaseInputControl(driver, "[data-identifier='LED_LDENT___INDOCCODWAREH']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public LdentForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

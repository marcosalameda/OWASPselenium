using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdsaiForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Ldsai']"));

	public LookupControl IFF_LDSAI___OUTPTDOCUMENR => new LookupControl(driver, "CONTAINER_IFF_LDSAI___OUTPTDOCUMENR", "ValCodoutpt_chzn");
	public BaseInputControl LED_LDSAI___OUTPTCODWAREH => new BaseInputControl(driver, "[data-identifier='LED_LDSAI___OUTPTCODWAREH']");
	public BaseInputControl LED_LDSAI___OUTPULINE____ => new BaseInputControl(driver, "[data-identifier='LED_LDSAI___OUTPULINE____']");
	public LookupControl IFF_LDSAI___WAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_LDSAI___WAREHWAREHDES", "ValCodwareh_chzn");
	public LookupControl IFF_LDSAI___ITEM_ITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_LDSAI___ITEM_ITEMDES_", "ValCoditem_chzn");
	public BaseInputControl LED_LDSAI___OUTPUEXITQNTY => new BaseInputControl(driver, "[data-identifier='LED_LDSAI___OUTPUEXITQNTY']");
	public LookupControl IFF_LDSAI___OUDOCNRDOCSDA => new LookupControl(driver, "CONTAINER_IFF_LDSAI___OUDOCNRDOCSDA", "ValCoddocsd_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public LdsaiForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DsaidForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Dsaid']"));

	public LookupControl IFF_DSAID___WARE1WAREHDES => new LookupControl(driver, "CONTAINER_IFF_DSAID___WARE1WAREHDES", "ValCodwareh_chzn");
	public BaseInputControl LED_DSAID___OUTPTDOCUMENR => new BaseInputControl(driver, "[data-identifier='LED_DSAID___OUTPTDOCUMENR']");
	public BaseInputControl LED_DSAID___OUTPTDHDOCUME => new BaseInputControl(driver, "[data-identifier='LED_DSAID___OUTPTDHDOCUME']");
	public ListControl IFF_DSAID___PSEUDSAIDAS__ => new ListControl(driver, "ValSaidas", "#Dsaid_ValSaidas");
	public IWebElement IFF_DSAID___PSEUDSAIDA___ => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public DsaidForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

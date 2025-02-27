using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegraForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Regra']"));

	public EnumControl LED_REGRA___RULESTIPOCOND => new EnumControl(driver, "CONTAINER_LED_REGRA___RULESTIPOCOND", "ValTipocond_chzn_Regra");
	public BaseInputControl LED_REGRA___RULESDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_REGRA___RULESDESCRIPT']");
	public EnumControl LED_REGRA___RULESLOCAL___ => new EnumControl(driver, "CONTAINER_LED_REGRA___RULESLOCAL___", "ValLocal_chzn_Regra");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public RegraForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

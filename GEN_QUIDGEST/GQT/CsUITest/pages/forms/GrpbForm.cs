using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GrpbForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Grpb']"));

	public BaseInputControl LED_GRPB____GRPB_NAME____ => new BaseInputControl(driver, "[data-identifier='LED_GRPB____GRPB_NAME____']");
	public ListControl IFF_GRPB____PSEUDTBLB____ => new ListControl(driver, "ValTblb", "#Grpb_ValTblb");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public GrpbForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

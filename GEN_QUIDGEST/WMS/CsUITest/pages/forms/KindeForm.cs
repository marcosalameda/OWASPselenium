using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class KindeForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Kinde']"));

	public BaseInputControl LED_KINDE___KINDEDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_KINDE___KINDEDESIGNAT']");
	public ListControl IFF_KINDE___PSEUDPARAMETE => new ListControl(driver, "ValParamete", "#Kinde_ValParamete");
	public ListControl IFF_KINDE___PSEUDMANUALS_ => new ListControl(driver, "ValManuals", "#Kinde_ValManuals");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public KindeForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

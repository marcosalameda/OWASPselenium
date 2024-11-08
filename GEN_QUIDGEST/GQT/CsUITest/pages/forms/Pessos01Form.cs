using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pessos01Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pessos01']"));

	public BaseInputControl IFF_PESSOS01PSEUDNOVOGR06 => new BaseInputControl(driver, "[data-identifier='IFF_PESSOS01PSEUDNOVOGR06']");
	public BaseInputControl LED_PESSOS01PESSOTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_PESSOS01PESSOTELEPHON']");
	public BaseInputControl LED_PESSOS01PESSOEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_PESSOS01PESSOEMAIL___']");
	public BaseInputControl LED_PESSOS01PESSOPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_PESSOS01PESSOPHOTOGRA']");
	public ListControl IFF_PESSOS01PSEUDEVOLUCAO => new ListControl(driver, "ValEvolucao", "#Pessos01_ValEvolucao");
	public BaseInputControl IFF_PESSOS01PSEUDFICHACAR => new BaseInputControl(driver, "[data-identifier='IFF_PESSOS01PSEUDFICHACAR']");
	public ListControl IFF_PESSOS01PSEUDCONTACTO => new ListControl(driver, "ValContacto", "#Pessos01_ValContacto");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Pessos01Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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

using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ReparForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Repar']"));

	public LookupControl IFF_REPAR___EQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_REPAR___EQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_REPAR___EQUIPDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_REPAR___EQUIPDESIGNAT']");
	public BaseInputControl LED_REPAR___EQUIPPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_REPAR___EQUIPPHOTOGRA']");
	public BaseInputControl LED_REPAR___REPARDTREPARA => new BaseInputControl(driver, "[data-identifier='LED_REPAR___REPARDTREPARA']");
	public BaseInputControl LED_REPAR___REPARNRREPARA => new BaseInputControl(driver, "[data-identifier='LED_REPAR___REPARNRREPARA']");
	public EnumControl LED_REPAR___REPARTIPOAREA => new EnumControl(driver, "CONTAINER_LED_REPAR___REPARTIPOAREA", "ValTipoarea_chzn_Repar");
	public LookupControl IFF_REPAR___SPECIESPECIAL => new LookupControl(driver, "CONTAINER_IFF_REPAR___SPECIESPECIAL", "ValCodespec_chzn");
	public LookupControl IFF_REPAR___PESSONAME____ => new LookupControl(driver, "CONTAINER_IFF_REPAR___PESSONAME____", "ValCodpesso_chzn");
	public BaseInputControl LED_REPAR___REPARDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_REPAR___REPARDESCRIPT']");
	public BaseInputControl LED_REPAR___REPARHOURS___ => new BaseInputControl(driver, "[data-identifier='LED_REPAR___REPARHOURS___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public ReparForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

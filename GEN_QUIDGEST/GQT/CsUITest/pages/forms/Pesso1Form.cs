using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pesso1Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pesso1']"));

	public BaseInputControl LED_PESSO1__PESSOPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSOPHOTOGRA']");
	public BaseInputControl LED_PESSO1__PESSOIDFUNCIO => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSOIDFUNCIO']");
	public BaseInputControl LED_PESSO1__PESSONAME____ => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSONAME____']");
	public BaseInputControl LED_PESSO1__PESSODTNASCIM => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSODTNASCIM']");
	public BaseInputControl LED_PESSO1__PESSOIDADE___ => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSOIDADE___']");
	public EnumControl IFF_PESSO1__PESSOGENDER__ => new EnumControl(driver, "CONTAINER_IFF_PESSO1__PESSOGENDER__", "ValGender_chzn_Pesso1");
	public BaseInputControl LED_PESSO1__PESSOINTERNA_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSOINTERNA_']");
	public BaseInputControl LED_PESSO1__PESSOEXTERNA_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSOEXTERNA_']");
	public LookupControl IFF_PESSO1__CATEGCATEGORY => new LookupControl(driver, "CONTAINER_IFF_PESSO1__CATEGCATEGORY", "ValCodcateg_chzn");
	public BaseInputControl LED_PESSO1__PESSODTULTCAT => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSODTULTCAT']");
	public BaseInputControl LED_PESSO1__PESSOTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSOTELEPHON']");
	public BaseInputControl LED_PESSO1__PESSOEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PESSOEMAIL___']");
	public ListControl IFF_PESSO1__PSEUDCONTACTO => new ListControl(driver, "ValContacto", "#Pesso1_ValContacto");
	public LookupControl IFF_PESSO1__CMPNYDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_PESSO1__CMPNYDESIGNAT", "ValCodempre_chzn");
	public BaseInputControl LED_PESSO1__CNTRYCOUNTRY_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__CNTRYCOUNTRY_']");
	public ListControl IFF_PESSO1__PSEUDEVOLUCAO => new ListControl(driver, "ValEvolucao", "#Pesso1_ValEvolucao");
	public BaseInputControl IFF_PESSO1__PSEUDOBRIGATO => new BaseInputControl(driver, "[data-identifier='IFF_PESSO1__PSEUDOBRIGATO']");
	public LookupControl IFF_PESSO1__REGI1REGIAO__ => new LookupControl(driver, "CONTAINER_IFF_PESSO1__REGI1REGIAO__", "ValCodregia_chzn");
	public BaseInputControl LED_PESSO1__PAIS1COUNTRY_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO1__PAIS1COUNTRY_']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Pesso1Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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

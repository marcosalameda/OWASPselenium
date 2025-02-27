using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessoForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pesso']"));

	public BaseInputControl LED_PESSO___PESSOPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOPHOTOGRA']");
	public BaseInputControl LED_PESSO___PESSOIDFUNCIO => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOIDFUNCIO']");
	public BaseInputControl LED_PESSO___PESSONAME____ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSONAME____']");
	public EnumControl LED_PESSO___PESSOGENDER__ => new EnumControl(driver, "CONTAINER_LED_PESSO___PESSOGENDER__", "ValGender_chzn_Pesso");
	public BaseInputControl LED_PESSO___PESSODTNASCIM => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSODTNASCIM']");
	public BaseInputControl LED_PESSO___PESSOIDADE___ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOIDADE___']");
	public BaseInputControl LED_PESSO___PESSOINTERNA_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOINTERNA_']");
	public BaseInputControl LED_PESSO___PESSOEXTERNA_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOEXTERNA_']");
	public LookupControl IFF_PESSO___CATEGCATEGORY => new LookupControl(driver, "CONTAINER_IFF_PESSO___CATEGCATEGORY", "ValCodcateg_chzn");
	public BaseInputControl LED_PESSO___PESSODTULTCAT => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSODTULTCAT']");
	public LookupControl IFF_PESSO___PAIS1COUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_PESSO___PAIS1COUNTRY_", "ValCodcntry_chzn");
	public BaseInputControl IFF_PESSO___PSEUDESPECIAL => new BaseInputControl(driver, "[data-identifier='IFF_PESSO___PSEUDESPECIAL']");
	public ListControl IFF_PESSO___PSEUDESPECITL => new ListControl(driver, "ValEspecitl", "#Pesso_ValEspecitl");
	public BaseInputControl LED_PESSO___PESSOTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOTELEPHON']");
	public BaseInputControl LED_PESSO___PESSOEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOEMAIL___']");
	public ListControl IFF_PESSO___PSEUDCONTACTO => new ListControl(driver, "ValContacto", "#Pesso_ValContacto");
	public LookupControl IFF_PESSO___CMPNYDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_PESSO___CMPNYDESIGNAT", "ValCodempre_chzn");
	public BaseInputControl LED_PESSO___CNTRYCOUNTRY_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___CNTRYCOUNTRY_']");
	public LookupControl IFF_PESSO___REGI1REGIAO__ => new LookupControl(driver, "CONTAINER_IFF_PESSO___REGI1REGIAO__", "ValCodregia_chzn");
	public ListControl IFF_PESSO___PSEUDEVOLUCAO => new ListControl(driver, "ValEvolucao", "#Pesso_ValEvolucao");
	public BaseInputControl IFF_PESSO___PSEUDNOVOGR06 => new BaseInputControl(driver, "[data-identifier='IFF_PESSO___PSEUDNOVOGR06']");
	public BaseInputControl IFF_PESSO___PSEUDSTATICIM => new BaseInputControl(driver, "[data-identifier='IFF_PESSO___PSEUDSTATICIM']");
	public BaseInputControl IFF_PESSO___PSEUDOBRIGATO => new BaseInputControl(driver, "[data-identifier='IFF_PESSO___PSEUDOBRIGATO']");
	public BaseInputControl LED_PESSO___PESSOEMAIL2__ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOEMAIL2__']");
	public BaseInputControl IFF_PESSO___PSEUDTERRAGRP => new BaseInputControl(driver, "[data-identifier='IFF_PESSO___PSEUDTERRAGRP']");
	public BaseInputControl LED_PESSO___PESSOEXTQUERY => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOEXTQUERY']");
	public BaseInputControl LED_PESSO___PESSOZOOMLVL_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOZOOMLVL_']");
	public BaseInputControl LED_PESSO___PESSOEXTMINZM => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOEXTMINZM']");
	public BaseInputControl LED_PESSO___PESSOMAPHEIGH => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOMAPHEIGH']");
	public BaseInputControl LED_PESSO___PESSOOUTWEIGH => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOOUTWEIGH']");
	public BaseInputControl LED_PESSO___PESSOLINECLR_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOLINECLR_']");
	public BaseInputControl LED_PESSO___PESSOPOLYCLR_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOPOLYCLR_']");
	public BaseInputControl LED_PESSO___PESSODRAWMRK_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSODRAWMRK_']");
	public BaseInputControl LED_PESSO___PESSOALLOWLIN => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOALLOWLIN']");
	public BaseInputControl LED_PESSO___PESSOALLOWPOL => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOALLOWPOL']");
	public BaseInputControl LED_PESSO___PESSOCANEXPOR => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOCANEXPOR']");
	public BaseInputControl LED_PESSO___PESSOGROUPMRK => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOGROUPMRK']");
	public BaseInputControl LED_PESSO___PESSOCANEDIT_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOCANEDIT_']");
	public BaseInputControl LED_PESSO___PESSOCANCUT__ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOCANCUT__']");
	public BaseInputControl LED_PESSO___PESSOCANDRAG_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOCANDRAG_']");
	public BaseInputControl LED_PESSO___PESSOCANROT__ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOCANROT__']");
	public BaseInputControl LED_PESSO___PESSOCANREMOV => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOCANREMOV']");
	public BaseInputControl LED_PESSO___PESSOTERRAIN_ => new BaseInputControl(driver, "[data-identifier='LED_PESSO___PESSOTERRAIN_']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public PessoForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

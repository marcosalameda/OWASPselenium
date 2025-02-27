using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquigrouForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Equigrou']"));

	public BaseInputControl LED_EQUIGROUPESS1PHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUPESS1PHOTOGRA']");
	public LookupControl IFF_EQUIGROUPESS1NAME____ => new LookupControl(driver, "CONTAINER_IFF_EQUIGROUPESS1NAME____", "ValCodpesso_chzn");
	public EnumControl LED_EQUIGROUPESS1GENDER__ => new EnumControl(driver, "CONTAINER_LED_EQUIGROUPESS1GENDER__", "ValGender_chzn_Equigrou");
	public BaseInputControl LED_EQUIGROUPESS1DTNASCIM => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUPESS1DTNASCIM']");
	public BaseInputControl LED_EQUIGROUPESS1IDADE___ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUPESS1IDADE___']");
	public BaseInputControl IFF_EQUIGROUPSEUDNEWGRP17 => new BaseInputControl(driver, "[data-identifier='IFF_EQUIGROUPSEUDNEWGRP17']");
	public BaseInputControl LED_EQUIGROUPESS1IDFUNCIO => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUPESS1IDFUNCIO']");
	public BaseInputControl LED_EQUIGROUPESS1TELEPHON => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUPESS1TELEPHON']");
	public BaseInputControl LED_EQUIGROUPESS1EMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUPESS1EMAIL___']");
	public BaseInputControl LED_EQUIGROUPESS1EMAIL2__ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUPESS1EMAIL2__']");
	public BaseInputControl IFF_EQUIGROUPSEUDFIELD001 => new BaseInputControl(driver, "[data-identifier='IFF_EQUIGROUPSEUDFIELD001']");
	public BaseInputControl LED_EQUIGROUCMPNYLOGO____ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUCMPNYLOGO____']");
	public BaseInputControl LED_EQUIGROUCMPNYDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUCMPNYDESIGNAT']");
	public BaseInputControl LED_EQUIGROUCMPNYACRONYM_ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUCMPNYACRONYM_']");
	public BaseInputControl LED_EQUIGROUCMPNYNIF_____ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUCMPNYNIF_____']");
	public BaseInputControl IFF_EQUIGROUPSEUDNEWGRP03 => new BaseInputControl(driver, "[data-identifier='IFF_EQUIGROUPSEUDNEWGRP03']");
	public BaseInputControl LED_EQUIGROUCMPNYTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUCMPNYTELEPHON']");
	public BaseInputControl LED_EQUIGROUCMPNYEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUCMPNYEMAIL___']");
	public BaseInputControl IFF_EQUIGROUPSEUDNEWGRP08 => new BaseInputControl(driver, "[data-identifier='IFF_EQUIGROUPSEUDNEWGRP08']");
	public BaseInputControl LED_EQUIGROUEQUIPQTDMOVIM => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPQTDMOVIM']");
	public BaseInputControl LED_EQUIGROUEQUIPDTAQUISI => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPDTAQUISI']");
	public LookupControl IFF_EQUIGROUTPEQUTIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_EQUIGROUTPEQUTIPOEQUI", "ValCodtpequ_chzn");
	public BaseInputControl LED_EQUIGROUTPEQUTPEQUCOD => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUTPEQUTPEQUCOD']");
	public BaseInputControl LED_EQUIGROUTPEQUPRECOMAX => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUTPEQUPRECOMAX']");
	public BaseInputControl LED_EQUIGROUTPEQUTPEQUPAI => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUTPEQUTPEQUPAI']");
	public BaseInputControl LED_EQUIGROUTPEQUNIVEL___ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUTPEQUNIVEL___']");
	public BaseInputControl LED_EQUIGROUTPEQUBACKCOLO => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUTPEQUBACKCOLO']");
	public BaseInputControl LED_EQUIGROUTPEQUCORLETRA => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUTPEQUCORLETRA']");
	public BaseInputControl LED_EQUIGROUEQUIPSEQUENNR => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPSEQUENNR']");
	public BaseInputControl LED_EQUIGROUEQUIPREGISTNR => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPREGISTNR']");
	public BaseInputControl LED_EQUIGROUEQUIPVALORTOT => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPVALORTOT']");
	public EnumControl LED_EQUIGROUEQUIPFREQUENC => new EnumControl(driver, "CONTAINER_LED_EQUIGROUEQUIPFREQUENC", "ValFrequenc_chzn_Equigrou");
	public BaseInputControl LED_EQUIGROUEQUIPBOUGHT__ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPBOUGHT__']");
	public BaseInputControl LED_EQUIGROUEQUIPDTREFERE => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPDTREFERE']");
	public BaseInputControl LED_EQUIGROUEQUIPFIRST___ => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPFIRST___']");
	public BaseInputControl LED_EQUIGROUEQUIPPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPPHOTOGRA']");
	public BaseInputControl LED_EQUIGROUEQUIPDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_EQUIGROUEQUIPDESIGNAT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public EquigrouForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

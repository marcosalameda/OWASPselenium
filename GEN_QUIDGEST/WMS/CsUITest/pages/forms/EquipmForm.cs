using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquipmForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Equipm']"));

	public BaseInputControl LED_EQUIPM__ASSETNAME____ => new BaseInputControl(driver, "[data-identifier='LED_EQUIPM__ASSETNAME____']");
	public EnumControl LED_EQUIPM__ASSETASSETTYP => new EnumControl(driver, "CONTAINER_LED_EQUIPM__ASSETASSETTYP", "ValAssettyp_chzn_Equipm");
	public BaseInputControl LED_EQUIPM__ASSETASSETNUM => new BaseInputControl(driver, "[data-identifier='LED_EQUIPM__ASSETASSETNUM']");
	public EnumControl LED_EQUIPM__ASSETIDENTTYP => new EnumControl(driver, "CONTAINER_LED_EQUIPM__ASSETIDENTTYP", "ValIdenttyp_chzn_Equipm");
	public BaseInputControl LED_EQUIPM__ASSETGRAI____ => new BaseInputControl(driver, "[data-identifier='LED_EQUIPM__ASSETGRAI____']");
	public BaseInputControl LED_EQUIPM__ASSETGIAI____ => new BaseInputControl(driver, "[data-identifier='LED_EQUIPM__ASSETGIAI____']");
	public LookupControl IFF_EQUIPM__MANUFNAME____ => new LookupControl(driver, "CONTAINER_IFF_EQUIPM__MANUFNAME____", "ValCodentit_chzn");
	public BaseInputControl IFF_EQUIPM__PSEUDEQUIP01_ => new BaseInputControl(driver, "[data-identifier='IFF_EQUIPM__PSEUDEQUIP01_']");
	public BaseInputControl IFF_EQUIPM__PSEUDEQUIP02_ => new BaseInputControl(driver, "[data-identifier='IFF_EQUIPM__PSEUDEQUIP02_']");
	public BaseInputControl IFF_EQUIPM__PSEUDEQUIP03_ => new BaseInputControl(driver, "[data-identifier='IFF_EQUIPM__PSEUDEQUIP03_']");
	public BaseInputControl IFF_EQUIPM__PSEUDEQUIP04_ => new BaseInputControl(driver, "[data-identifier='IFF_EQUIPM__PSEUDEQUIP04_']");
	public LookupControl IFF_EQUIPM__KINDEDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_EQUIPM__KINDEDESIGNAT", "ValCodkinde_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EquipmForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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

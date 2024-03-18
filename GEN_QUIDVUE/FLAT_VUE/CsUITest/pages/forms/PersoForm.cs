namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PersoForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, formLocator, "#PERSO___PSEUDNOVOGR01-container");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, formLocator, "#PERSO___PSEUDNOVOGR04-container");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PersoPhoto => new BaseInputControl(driver, formLocator, "#PERSO___PERSOPHOTO___");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, formLocator, "#PERSO___PSEUDNOVOGR05-container");
	/// <summary>
	/// Person name
	/// </summary>
	public BaseInputControl PersoName => new BaseInputControl(driver, formLocator, "#PERSO___PERSONAME____");
	/// <summary>
	/// Identification number
	/// </summary>
	public BaseInputControl PersoIdentifi => new BaseInputControl(driver, formLocator, "#PERSO___PERSOIDENTIFI");
	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl PersoGender => new EnumControl(driver, formLocator, "container-PERSO___PERSOGENDER__");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl PersoEmail => new BaseInputControl(driver, formLocator, "#PERSO___PERSOEMAIL___");
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, formLocator, "#PERSO___PSEUDNOVOGR02-container");
	/// <summary>
	/// Date of birth
	/// </summary>
	public DateInputControl PersoDob => new DateInputControl(driver, formLocator, "#PERSO___PERSODOB_____");
	/// <summary>
	/// Time of birth
	/// </summary>
	public BaseInputControl PersoTob => new BaseInputControl(driver, formLocator, "#PERSO___PERSOTOB_____");
	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl PersoYear => new BaseInputControl(driver, formLocator, "#PERSO___PERSOYEAR____");
	/// <summary>
	/// Month
	/// </summary>
	public EnumControl PersoMonth => new EnumControl(driver, formLocator, "container-PERSO___PERSOMONTH___");
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl PersoCreatusr => new BaseInputControl(driver, formLocator, "#PERSO___PERSOCREATUSR");
	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl PersoCreatdat => new BaseInputControl(driver, formLocator, "#PERSO___PERSOCREATDAT");
	/// <summary>
	/// Modified by
	/// </summary>
	public BaseInputControl PersoModifusr => new BaseInputControl(driver, formLocator, "#PERSO___PERSOMODIFUSR");
	/// <summary>
	/// Modified on
	/// </summary>
	public BaseInputControl PersoModifdat => new BaseInputControl(driver, formLocator, "#PERSO___PERSOMODIFDAT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PersoForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("PERSO")).GetAttribute("data-loading") != "true");
    }

	public void Save() {
		WaitForLoading();
		saveBtn.Click();
	}

	public void Cancel() {
		WaitForLoading();
		cancelBtn.Click();
	}

}

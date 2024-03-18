namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ReparForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, formLocator, "container-REPAR___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "REPAR", "EQUIP.REGISTNR");
	/// <summary>
	/// Designation
	/// </summary>
	public IWebElement EquipDesignat => throw new NotImplementedException();
	/// <summary>
	/// Photo
	/// </summary>
	public IWebElement EquipPhotogra => throw new NotImplementedException();
	/// <summary>
	/// Repaired on
	/// </summary>
	public DateInputControl ReparDtrepara => new DateInputControl(driver, formLocator, "#REPAR___REPARDTREPARA", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Company Repair Number
	/// </summary>
	public BaseInputControl ReparNrrepara => new BaseInputControl(driver, formLocator, "#REPAR___REPARNRREPARA");
	/// <summary>
	/// Technical area
	/// </summary>
	public RadiobuttonControl ReparTipoarea => new RadiobuttonControl(driver, formLocator, "container-REPAR___REPARTIPOAREA");
	/// <summary>
	/// Specialty
	/// </summary>
	public LookupControl SpeciEspecial => new LookupControl(driver, formLocator, "container-REPAR___SPECIESPECIAL");
	public SeeMorePage SpeciEspecialSeeMorePage => new SeeMorePage(driver, "REPAR", "SPECI.ESPECIAL");
	/// <summary>
	/// Technician
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, formLocator, "container-REPAR___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "REPAR", "PESSO.NAME");
	/// <summary>
	/// Repair Description
	/// </summary>
	public BaseInputControl ReparDescript => new BaseInputControl(driver, formLocator, "#REPAR___REPARDESCRIPT");
	/// <summary>
	/// Spent in Hours
	/// </summary>
	public BaseInputControl ReparHours => new BaseInputControl(driver, formLocator, "#REPAR___REPARHOURS___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public ReparForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("REPAR")).GetAttribute("data-loading") != "true");
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

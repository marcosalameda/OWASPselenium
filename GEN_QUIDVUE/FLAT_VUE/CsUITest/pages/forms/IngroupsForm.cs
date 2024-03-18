namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class IngroupsForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Text
	/// </summary>
	public IWebElement PseudTextspan => throw new NotImplementedException();
	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl InpgrNumbgro => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRNUMBGRO_");
	/// <summary>
	/// Profile
	/// </summary>
	public IWebElement PseudSpangro => throw new NotImplementedException();
	/// <summary>
	/// View
	/// </summary>
	public ButtonControl PseudButtngro => new ButtonControl(driver, formLocator, "#INGROUPSPSEUDBUTTNGRO");
	/// <summary>
	/// First name
	/// </summary>
	public BaseInputControl InpgrName => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRNAME____");
	/// <summary>
	/// Last name
	/// </summary>
	public BaseInputControl InpgrLastname => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRLASTNAME");
	/// <summary>
	/// Prefix
	/// </summary>
	public EnumControl InpgrPrefix => new EnumControl(driver, formLocator, "container-INGROUPSINPGRPREFIX__");
	/// <summary>
	/// Text with input
	/// </summary>
	public IWebElement PseudInputgr1 => throw new NotImplementedException();
	/// <summary>
	/// Single Inputs
	/// </summary>
	public CollapsibleZoneControl PseudGroup1 => new CollapsibleZoneControl(driver, formLocator, "#INGROUPSPSEUDGROUP1__-container");
	/// <summary>
	/// Multiple Inputs
	/// </summary>
	public CollapsibleZoneControl PseudGroup2 => new CollapsibleZoneControl(driver, formLocator, "#INGROUPSPSEUDGROUP2__-container");
	/// <summary>
	/// User
	/// </summary>
	public IWebElement PseudInputgr2 => throw new NotImplementedException();
	/// <summary>
	/// Buton addon
	/// </summary>
	public CollapsibleZoneControl PseudGroup3 => new CollapsibleZoneControl(driver, formLocator, "#INGROUPSPSEUDGROUP3__-container");
	/// <summary>
	/// Tax data
	/// </summary>
	public IWebElement PseudInputgr3 => throw new NotImplementedException();
	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl InpgrPhone => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRPHONE___");
	/// <summary>
	/// Contact Data
	/// </summary>
	public CollapsibleZoneControl PseudGroup4 => new CollapsibleZoneControl(driver, formLocator, "#INGROUPSPSEUDGROUP4__-container");
	/// <summary>
	/// Phone number
	/// </summary>
	public IWebElement PseudInputgr4 => throw new NotImplementedException();
	/// <summary>
	/// Address type
	/// </summary>
	public EnumControl InpgrAdress => new EnumControl(driver, formLocator, "container-INGROUPSINPGRADRESS__");
	/// <summary>
	/// E-mail
	/// </summary>
	public BaseInputControl InpgrEmail => new BaseInputControl(driver, formLocator, "#INGROUPSINPGREMAIL___");
	/// <summary>
	/// Web
	/// </summary>
	public BaseInputControl InpgrWeb => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRWEB_____");
	/// <summary>
	/// Entity
	/// </summary>
	public EnumControl InpgrBankcomp => new EnumControl(driver, formLocator, "container-INGROUPSINPGRBANKCOMP");
	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl InpgrIban => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRIBAN____");
	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl InpgrTextgro => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRTEXTGRO_");
	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl InpgrBankacco => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRBANKACCO");
	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl InpgrDirectio => new BaseInputControl(driver, formLocator, "#INGROUPSINPGRDIRECTIO");
	/// <summary>
	/// View
	/// </summary>
	public ButtonControl PseudSavebtt => new ButtonControl(driver, formLocator, "#INGROUPSPSEUDSAVEBTT_");
	/// <summary>
	/// View
	/// </summary>
	public ButtonControl PseudSendbtt => new ButtonControl(driver, formLocator, "#INGROUPSPSEUDSENDBTT_");
	/// <summary>
	/// Bank Account
	/// </summary>
	public IWebElement PseudInputgr6 => throw new NotImplementedException();
	/// <summary>
	/// Bank Data
	/// </summary>
	public CollapsibleZoneControl PseudGroup6 => new CollapsibleZoneControl(driver, formLocator, "#INGROUPSPSEUDGROUP6__-container");
	/// <summary>
	/// Email and web
	/// </summary>
	public IWebElement PseudInputgr5 => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public IngroupsForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("INGROUPS")).GetAttribute("data-loading") != "true");
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

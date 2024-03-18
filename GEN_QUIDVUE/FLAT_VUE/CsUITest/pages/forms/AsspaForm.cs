namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AsspaForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Identification name
	/// </summary>
	public LookupControl AssetName => new LookupControl(driver, formLocator, "container-ASSPA___ASSETNAME____");
	public SeeMorePage AssetNameSeeMorePage => new SeeMorePage(driver, "ASSPA", "ASSET.NAME");
	/// <summary>
	/// Data type
	/// </summary>
	public EnumControl AsspaDatatype => new EnumControl(driver, formLocator, "container-ASSPA___ASSPADATATYPE");
	/// <summary>
	/// Decimal places
	/// </summary>
	public BaseInputControl AsspaDecplace => new BaseInputControl(driver, formLocator, "#ASSPA___ASSPADECPLACE");
	/// <summary>
	/// Parameter
	/// </summary>
	public LookupControl ParamParamete => new LookupControl(driver, formLocator, "container-ASSPA___PARAMPARAMETE");
	public SeeMorePage ParamParameteSeeMorePage => new SeeMorePage(driver, "ASSPA", "PARAM.PARAMETE");
	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl AsspaText => new BaseInputControl(driver, formLocator, "#ASSPA___ASSPATEXT____");
	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl AsspaQuantity => new BaseInputControl(driver, formLocator, "#ASSPA___ASSPAQUANTITY");
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl AsspaDate => new DateInputControl(driver, formLocator, "#ASSPA___ASSPADATE____");
	/// <summary>
	/// To show
	/// </summary>
	public BaseInputControl AsspaToshow => new BaseInputControl(driver, formLocator, "#ASSPA___ASSPATOSHOW__");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AsspaForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("ASSPA")).GetAttribute("data-loading") != "true");
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

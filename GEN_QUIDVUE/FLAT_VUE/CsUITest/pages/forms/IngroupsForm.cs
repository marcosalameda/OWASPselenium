using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class IngroupsForm : Form
{
	/// <summary>
	/// Text
	/// </summary>
	public IWebElement PseudTextspan => throw new NotImplementedException();

	/// <summary>
	/// VAT Number
	/// </summary>
	public BaseInputControl InpgrNumbgro => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRNUMBGRO_" + IdSuffix, "#INGROUPSINPGRNUMBGRO_" + IdSuffix);

	/// <summary>
	/// Profile
	/// </summary>
	public IWebElement PseudSpangro => throw new NotImplementedException();

	/// <summary>
	/// View
	/// </summary>
	public ButtonControl PseudButtngro => new ButtonControl(driver, ContainerLocator, "#INGROUPSPSEUDBUTTNGRO" + IdSuffix);

	/// <summary>
	/// First name
	/// </summary>
	public BaseInputControl InpgrName => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRNAME____" + IdSuffix, "#INGROUPSINPGRNAME____" + IdSuffix);

	/// <summary>
	/// Last name
	/// </summary>
	public BaseInputControl InpgrLastname => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRLASTNAME" + IdSuffix, "#INGROUPSINPGRLASTNAME" + IdSuffix);

	/// <summary>
	/// Prefix
	/// </summary>
	public EnumControl InpgrPrefix => new EnumControl(driver, ContainerLocator, "container-INGROUPSINPGRPREFIX__" + IdSuffix);

	/// <summary>
	/// Text with input
	/// </summary>
	public IWebElement PseudInputgr1 => throw new NotImplementedException();

	/// <summary>
	/// Single Inputs
	/// </summary>
	public CollapsibleZoneControl PseudGroup1 => new CollapsibleZoneControl(driver, ContainerLocator, "#INGROUPSPSEUDGROUP1__" + IdSuffix + "-container");

	/// <summary>
	/// Multiple Inputs
	/// </summary>
	public CollapsibleZoneControl PseudGroup2 => new CollapsibleZoneControl(driver, ContainerLocator, "#INGROUPSPSEUDGROUP2__" + IdSuffix + "-container");

	/// <summary>
	/// User
	/// </summary>
	public IWebElement PseudInputgr2 => throw new NotImplementedException();

	/// <summary>
	/// Buton addon
	/// </summary>
	public CollapsibleZoneControl PseudGroup3 => new CollapsibleZoneControl(driver, ContainerLocator, "#INGROUPSPSEUDGROUP3__" + IdSuffix + "-container");

	/// <summary>
	/// Tax data
	/// </summary>
	public IWebElement PseudInputgr3 => throw new NotImplementedException();

	/// <summary>
	/// Phone number
	/// </summary>
	public BaseInputControl InpgrPhone => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRPHONE___" + IdSuffix, "#INGROUPSINPGRPHONE___" + IdSuffix);

	/// <summary>
	/// Contact Data
	/// </summary>
	public CollapsibleZoneControl PseudGroup4 => new CollapsibleZoneControl(driver, ContainerLocator, "#INGROUPSPSEUDGROUP4__" + IdSuffix + "-container");

	/// <summary>
	/// Phone number
	/// </summary>
	public IWebElement PseudInputgr4 => throw new NotImplementedException();

	/// <summary>
	/// Address type
	/// </summary>
	public EnumControl InpgrAdress => new EnumControl(driver, ContainerLocator, "container-INGROUPSINPGRADRESS__" + IdSuffix);

	/// <summary>
	/// E-mail
	/// </summary>
	public BaseInputControl InpgrEmail => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGREMAIL___" + IdSuffix, "#INGROUPSINPGREMAIL___" + IdSuffix);

	/// <summary>
	/// Web
	/// </summary>
	public BaseInputControl InpgrWeb => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRWEB_____" + IdSuffix, "#INGROUPSINPGRWEB_____" + IdSuffix);

	/// <summary>
	/// Entity
	/// </summary>
	public EnumControl InpgrBankcomp => new EnumControl(driver, ContainerLocator, "container-INGROUPSINPGRBANKCOMP" + IdSuffix);

	/// <summary>
	/// IBAN
	/// </summary>
	public BaseInputControl InpgrIban => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRIBAN____" + IdSuffix, "#INGROUPSINPGRIBAN____" + IdSuffix);

	/// <summary>
	/// Text Field
	/// </summary>
	public BaseInputControl InpgrTextgro => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRTEXTGRO_" + IdSuffix, "#INGROUPSINPGRTEXTGRO_" + IdSuffix);

	/// <summary>
	/// Banking Account Number
	/// </summary>
	public BaseInputControl InpgrBankacco => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRBANKACCO" + IdSuffix, "#INGROUPSINPGRBANKACCO" + IdSuffix);

	/// <summary>
	/// Adress
	/// </summary>
	public BaseInputControl InpgrDirectio => new BaseInputControl(driver, ContainerLocator, "container-INGROUPSINPGRDIRECTIO" + IdSuffix, "#INGROUPSINPGRDIRECTIO" + IdSuffix);

	/// <summary>
	/// View
	/// </summary>
	public ButtonControl PseudSavebtt => new ButtonControl(driver, ContainerLocator, "#INGROUPSPSEUDSAVEBTT_" + IdSuffix);

	/// <summary>
	/// View
	/// </summary>
	public ButtonControl PseudSendbtt => new ButtonControl(driver, ContainerLocator, "#INGROUPSPSEUDSENDBTT_" + IdSuffix);

	/// <summary>
	/// Bank Account
	/// </summary>
	public IWebElement PseudInputgr6 => throw new NotImplementedException();

	/// <summary>
	/// Bank Data
	/// </summary>
	public CollapsibleZoneControl PseudGroup6 => new CollapsibleZoneControl(driver, ContainerLocator, "#INGROUPSPSEUDGROUP6__" + IdSuffix + "-container");

	/// <summary>
	/// Email and web
	/// </summary>
	public IWebElement PseudInputgr5 => throw new NotImplementedException();

	public IngroupsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "INGROUPS", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

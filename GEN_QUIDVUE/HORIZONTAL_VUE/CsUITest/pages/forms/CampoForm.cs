using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CampoForm : Form
{
	/// <summary>
	/// Airline
	/// </summary>
	public LookupControl AeroName => new LookupControl(driver, ContainerLocator, "container-CAMPO___AERO_NAME____");
	public SeeMorePage AeroNameSeeMorePage => new SeeMorePage(driver, "CAMPO", "CAMPO___AERO_NAME____");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl FldsDescrip => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_DESCRIP_");

	/// <summary>
	/// Passenger capacity on the plane
	/// </summary>
	public BaseInputControl FldsNpassage => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_NPASSAGE");

	/// <summary>
	/// Trip Duration
	/// </summary>
	public BaseInputControl FldsDuration => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_DURATION");

	/// <summary>
	/// Rounded Ticket Price
	/// </summary>
	public BaseInputControl FldsPrice => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_PRICE___");

	/// <summary>
	/// Ticket price at tenths
	/// </summary>
	public BaseInputControl FldsPrecobil => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_PRECOBIL");

	/// <summary>
	/// Departure date (DD/MM/YEAR)
	/// </summary>
	public DateInputControl FldsDate => new DateInputControl(driver, ContainerLocator, "#CAMPO___FLDS_DATE____");

	/// <summary>
	/// Departure date (hour)
	/// </summary>
	public DateInputControl FldsDatetime => new DateInputControl(driver, ContainerLocator, "#CAMPO___FLDS_DATETIME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Departure date (seconds)
	/// </summary>
	public DateInputControl FldsDateseco => new DateInputControl(driver, ContainerLocator, "#CAMPO___FLDS_DATESECO", "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Departure hour
	/// </summary>
	public BaseInputControl FldsTime => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_TIME____");

	/// <summary>
	/// Creation year of the airport
	/// </summary>
	public BaseInputControl FldsYear => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_YEAR____");

	/// <summary>
	/// 1ªViagem
	/// </summary>
	public CheckboxInputControl FldsPrimviag => new CheckboxInputControl(driver, ContainerLocator, "#container-CAMPO___FLDS_PRIMVIAG");

	/// <summary>
	/// Have you traveled before?
	/// </summary>
	public BaseInputControl FldsConditio => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_CONDITIO");

	/// <summary>
	/// Class (Enumeração de Texto)
	/// </summary>
	public EnumControl FldsClass => new EnumControl(driver, ContainerLocator, "container-CAMPO___FLDS_CLASS___");

	/// <summary>
	/// Classe (Enumeração Numérica)
	/// </summary>
	public EnumControl FldsClassnum => new EnumControl(driver, ContainerLocator, "container-CAMPO___FLDS_CLASSNUM");

	/// <summary>
	/// 1st trip (Logical Enumeration)
	/// </summary>
	public EnumControl FldsLogicenu => new EnumControl(driver, ContainerLocator, "container-CAMPO___FLDS_LOGICENU");

	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl FldsLogo => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_LOGO____");

	/// <summary>
	/// Attachments
	/// </summary>
	public DocumentControl FldsAttach => new DocumentControl(driver, ContainerLocator, "container-CAMPO___FLDS_ATTACH__");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl FldsCreatuse => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_CREATUSE");

	/// <summary>
	/// Creation Date (DD/MM/YY)
	/// </summary>
	public BaseInputControl FldsCreatdat => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_CREATDAT");

	/// <summary>
	/// Creation Date
	/// </summary>
	public BaseInputControl FldsCreathou => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_CREATHOU");

	/// <summary>
	/// Complete Creation Date
	/// </summary>
	public BaseInputControl FldsCreatins => new BaseInputControl(driver, ContainerLocator, "#CAMPO___FLDS_CREATINS");

	public CampoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CAMPO", containerLocator: containerLocator) { }
}

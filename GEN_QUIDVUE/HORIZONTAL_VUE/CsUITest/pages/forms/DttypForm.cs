using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DttypForm : Form
{
	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();

	/// <summary>
	/// Char String
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#DTTYP___PSEUDNOVOGR01-container");

	/// <summary>
	/// Text
	/// </summary>
	public BaseInputControl DttypString => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPSTRING__", "#DTTYP___DTTYPSTRING__");

	/// <summary>
	/// Text (Upper case)
	/// </summary>
	public BaseInputControl DttypUppercas => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPUPPERCAS", "#DTTYP___DTTYPUPPERCAS");

	/// <summary>
	/// Text (UUID aka GUID)
	/// </summary>
	public BaseInputControl DttypUuid => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPUUID____", "#DTTYP___DTTYPUUID____");

	/// <summary>
	/// Multiline text
	/// </summary>
	public BaseInputControl DttypMultilin => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPMULTILIN", "#DTTYP___DTTYPMULTILIN");

	/// <summary>
	/// Multiline text (Text editor)
	/// </summary>
	public IWebElement DttypMultili3 => throw new NotImplementedException();

	/// <summary>
	/// Boolean
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#DTTYP___PSEUDNOVOGR02-container");

	/// <summary>
	/// Logical (tinyint) (storage: 1 byte)
	/// </summary>
	public CheckboxInputControl DttypBoolean => new CheckboxInputControl(driver, ContainerLocator, "#container-DTTYP___DTTYPBOOLEAN_");

	/// <summary>
	/// Conditional (smallint) (storage: 2 byte)
	/// </summary>
	public BaseInputControl DttypBoolean2 => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPBOOLEAN2", "#DTTYP___DTTYPBOOLEAN2");

	/// <summary>
	/// Numeric
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#DTTYP___PSEUDNOVOGR03-container");

	/// <summary>
	/// Numeric  4.0 - small integer (storage: 2 byte)
	/// </summary>
	public BaseInputControl DttypSmallint => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPSMALLINT", "#DTTYP___DTTYPSMALLINT");

	/// <summary>
	/// Numeric  9.0 - integer (storage: 4 byte)
	/// </summary>
	public BaseInputControl DttypInteger => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPINTEGER_", "#DTTYP___DTTYPINTEGER_");

	/// <summary>
	/// Numeric 15.0 - big integer (storage: 8 byte)
	/// </summary>
	public BaseInputControl DttypBigint => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPBIGINT__", "#DTTYP___DTTYPBIGINT__");

	/// <summary>
	/// Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)
	/// </summary>
	public BaseInputControl DttypReal => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPREAL____", "#DTTYP___DTTYPREAL____");

	/// <summary>
	/// Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)
	/// </summary>
	public BaseInputControl DttypFloat => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPFLOAT___", "#DTTYP___DTTYPFLOAT___");

	/// <summary>
	/// Decimal (1-10) (storage: 5 byte)
	/// </summary>
	public BaseInputControl DttypDecimal => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPDECIMAL_", "#DTTYP___DTTYPDECIMAL_");

	/// <summary>
	/// Decimal (11-15) (storage: 9 byte)
	/// </summary>
	public BaseInputControl DttypDecimal9 => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPDECIMAL9", "#DTTYP___DTTYPDECIMAL9");

	/// <summary>
	/// Money - decimal (1-10) (storage: 5 byte)
	/// </summary>
	public BaseInputControl DttypMoney => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPMONEY___", "#DTTYP___DTTYPMONEY___");

	/// <summary>
	/// Money - decimal (11-15) (storage: 9 byte)
	/// </summary>
	public BaseInputControl DttypMoney9 => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPMONEY9__", "#DTTYP___DTTYPMONEY9__");

	/// <summary>
	/// Date and Time
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#DTTYP___PSEUDNOVOGR04-container");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl DttypDate => new DateInputControl(driver, ContainerLocator, "#DTTYP___DTTYPDATE____");

	/// <summary>
	/// Date Time
	/// </summary>
	public DateInputControl DttypDatetime => new DateInputControl(driver, ContainerLocator, "#DTTYP___DTTYPDATETIME", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Date Time Second
	/// </summary>
	public DateInputControl DttypDtsesond => new DateInputControl(driver, ContainerLocator, "#DTTYP___DTTYPDTSESOND", "dd/MM/yyyy HH:mm:ss");

	/// <summary>
	/// Time
	/// </summary>
	public BaseInputControl DttypTime => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPTIME____", "#DTTYP___DTTYPTIME____");

	/// <summary>
	/// Image
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#DTTYP___PSEUDNOVOGR05-container");

	/// <summary>
	/// Image (binary)
	/// </summary>
	public BaseInputControl DttypImage => new BaseInputControl(driver, ContainerLocator, "container-DTTYP___DTTYPIMAGE___", "#DTTYP___DTTYPIMAGE___");

	public DttypForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "DTTYP", containerLocator: containerLocator) { }
}

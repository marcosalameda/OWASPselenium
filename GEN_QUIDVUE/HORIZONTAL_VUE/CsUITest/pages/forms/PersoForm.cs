using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PersoForm : Form
{
	/// <summary>
	/// Identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PERSO___PSEUDNOVOGR01-container");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PERSO___PSEUDNOVOGR04-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PersoPhoto => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOPHOTO___", "#PERSO___PERSOPHOTO___");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PERSO___PSEUDNOVOGR05-container");

	/// <summary>
	/// Person name
	/// </summary>
	public BaseInputControl PersoName => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSONAME____", "#PERSO___PERSONAME____");

	/// <summary>
	/// Identification number
	/// </summary>
	public BaseInputControl PersoIdentifi => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOIDENTIFI", "#PERSO___PERSOIDENTIFI");

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl PersoGender => new EnumControl(driver, ContainerLocator, "container-PERSO___PERSOGENDER__");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl PersoEmail => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOEMAIL___", "#PERSO___PERSOEMAIL___");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PERSO___PSEUDNOVOGR02-container");

	/// <summary>
	/// Date of birth
	/// </summary>
	public DateInputControl PersoDob => new DateInputControl(driver, ContainerLocator, "#PERSO___PERSODOB_____");

	/// <summary>
	/// Time of birth
	/// </summary>
	public BaseInputControl PersoTob => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOTOB_____", "#PERSO___PERSOTOB_____");

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl PersoYear => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOYEAR____", "#PERSO___PERSOYEAR____");

	/// <summary>
	/// Month
	/// </summary>
	public EnumControl PersoMonth => new EnumControl(driver, ContainerLocator, "container-PERSO___PERSOMONTH___");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl PersoCreatusr => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOCREATUSR", "#PERSO___PERSOCREATUSR");

	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl PersoCreatdat => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOCREATDAT", "#PERSO___PERSOCREATDAT");

	/// <summary>
	/// Modified by
	/// </summary>
	public BaseInputControl PersoModifusr => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOMODIFUSR", "#PERSO___PERSOMODIFUSR");

	/// <summary>
	/// Modified on
	/// </summary>
	public BaseInputControl PersoModifdat => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOMODIFDAT", "#PERSO___PERSOMODIFDAT");

	public PersoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PERSO", containerLocator: containerLocator) { }
}

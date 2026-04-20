using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PersoForm : Form
{
	/// <summary>
	/// Identification
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#PERSO___PSEUDNOVOGR01" + IdSuffix + "-container");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PERSO___PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PersoPhoto => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOPHOTO___" + IdSuffix, "#PERSO___PERSOPHOTO___" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PERSO___PSEUDNOVOGR05" + IdSuffix + "-container");

	/// <summary>
	/// Person name
	/// </summary>
	public BaseInputControl PersoName => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSONAME____" + IdSuffix, "#PERSO___PERSONAME____" + IdSuffix);

	/// <summary>
	/// Identification number
	/// </summary>
	public BaseInputControl PersoIdentifi => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOIDENTIFI" + IdSuffix, "#PERSO___PERSOIDENTIFI" + IdSuffix);

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl PersoGender => new EnumControl(driver, ContainerLocator, "container-PERSO___PERSOGENDER__" + IdSuffix);

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl PersoEmail => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOEMAIL___" + IdSuffix, "#PERSO___PERSOEMAIL___" + IdSuffix);

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#PERSO___PSEUDNOVOGR02" + IdSuffix + "-container");

	/// <summary>
	/// Date of birth
	/// </summary>
	public DateInputControl PersoDob => new DateInputControl(driver, ContainerLocator, "#PERSO___PERSODOB_____" + IdSuffix);

	/// <summary>
	/// Time of birth
	/// </summary>
	public BaseInputControl PersoTob => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOTOB_____" + IdSuffix, "#PERSO___PERSOTOB_____" + IdSuffix);

	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl PersoYear => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOYEAR____" + IdSuffix, "#PERSO___PERSOYEAR____" + IdSuffix);

	/// <summary>
	/// Month
	/// </summary>
	public EnumControl PersoMonth => new EnumControl(driver, ContainerLocator, "container-PERSO___PERSOMONTH___" + IdSuffix);

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl PersoCreatusr => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOCREATUSR" + IdSuffix, "#PERSO___PERSOCREATUSR" + IdSuffix);

	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl PersoCreatdat => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOCREATDAT" + IdSuffix, "#PERSO___PERSOCREATDAT" + IdSuffix);

	/// <summary>
	/// Modified by
	/// </summary>
	public BaseInputControl PersoModifusr => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOMODIFUSR" + IdSuffix, "#PERSO___PERSOMODIFUSR" + IdSuffix);

	/// <summary>
	/// Modified on
	/// </summary>
	public BaseInputControl PersoModifdat => new BaseInputControl(driver, ContainerLocator, "container-PERSO___PERSOMODIFDAT" + IdSuffix, "#PERSO___PERSOMODIFDAT" + IdSuffix);

	public PersoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PERSO", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

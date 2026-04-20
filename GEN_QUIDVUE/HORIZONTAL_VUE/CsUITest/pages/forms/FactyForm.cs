using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FactyForm : Form
{
	/// <summary>
	/// Facility type
	/// </summary>
	public BaseInputControl FactyType => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYTYPE____" + IdSuffix, "#FACTY___FACTYTYPE____" + IdSuffix);

	/// <summary>
	/// Layer name
	/// </summary>
	public BaseInputControl FactyLayrname => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYLAYRNAME" + IdSuffix, "#FACTY___FACTYLAYRNAME" + IdSuffix);

	/// <summary>
	/// Icon URL
	/// </summary>
	public BaseInputControl FactyIconurl => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONURL_" + IdSuffix, "#FACTY___FACTYICONURL_" + IdSuffix);

	/// <summary>
	/// Shadow URL
	/// </summary>
	public BaseInputControl FactyShadowur => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWUR" + IdSuffix, "#FACTY___FACTYSHADOWUR" + IdSuffix);

	/// <summary>
	/// Icon anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyIconancx => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONANCX" + IdSuffix, "#FACTY___FACTYICONANCX" + IdSuffix);

	/// <summary>
	/// Icon anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyIconancy => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONANCY" + IdSuffix, "#FACTY___FACTYICONANCY" + IdSuffix);

	/// <summary>
	/// Icon height
	/// </summary>
	public BaseInputControl FactyIconheig => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONHEIG" + IdSuffix, "#FACTY___FACTYICONHEIG" + IdSuffix);

	/// <summary>
	/// Icon width
	/// </summary>
	public BaseInputControl FactyIconwid => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONWID_" + IdSuffix, "#FACTY___FACTYICONWID_" + IdSuffix);

	/// <summary>
	/// Popup anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyPopupanx => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYPOPUPANX" + IdSuffix, "#FACTY___FACTYPOPUPANX" + IdSuffix);

	/// <summary>
	/// Popup anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyPopupany => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYPOPUPANY" + IdSuffix, "#FACTY___FACTYPOPUPANY" + IdSuffix);

	/// <summary>
	/// Shadow anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyShadowax => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWAX" + IdSuffix, "#FACTY___FACTYSHADOWAX" + IdSuffix);

	/// <summary>
	/// Shadow anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyShadoway => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWAY" + IdSuffix, "#FACTY___FACTYSHADOWAY" + IdSuffix);

	/// <summary>
	/// Shadow height
	/// </summary>
	public BaseInputControl FactyShadowhe => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWHE" + IdSuffix, "#FACTY___FACTYSHADOWHE" + IdSuffix);

	/// <summary>
	/// Shadow width
	/// </summary>
	public BaseInputControl FactyShadowwi => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWWI" + IdSuffix, "#FACTY___FACTYSHADOWWI" + IdSuffix);

	public FactyForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "FACTY", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

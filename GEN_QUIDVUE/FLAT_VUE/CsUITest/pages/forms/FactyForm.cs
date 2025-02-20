using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FactyForm : Form
{
	/// <summary>
	/// Facility type
	/// </summary>
	public BaseInputControl FactyType => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYTYPE____", "#FACTY___FACTYTYPE____");

	/// <summary>
	/// Layer name
	/// </summary>
	public BaseInputControl FactyLayrname => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYLAYRNAME", "#FACTY___FACTYLAYRNAME");

	/// <summary>
	/// Icon URL
	/// </summary>
	public BaseInputControl FactyIconurl => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONURL_", "#FACTY___FACTYICONURL_");

	/// <summary>
	/// Shadow URL
	/// </summary>
	public BaseInputControl FactyShadowur => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWUR", "#FACTY___FACTYSHADOWUR");

	/// <summary>
	/// Icon anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyIconancx => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONANCX", "#FACTY___FACTYICONANCX");

	/// <summary>
	/// Icon anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyIconancy => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONANCY", "#FACTY___FACTYICONANCY");

	/// <summary>
	/// Icon height
	/// </summary>
	public BaseInputControl FactyIconheig => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONHEIG", "#FACTY___FACTYICONHEIG");

	/// <summary>
	/// Icon width
	/// </summary>
	public BaseInputControl FactyIconwid => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYICONWID_", "#FACTY___FACTYICONWID_");

	/// <summary>
	/// Popup anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyPopupanx => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYPOPUPANX", "#FACTY___FACTYPOPUPANX");

	/// <summary>
	/// Popup anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyPopupany => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYPOPUPANY", "#FACTY___FACTYPOPUPANY");

	/// <summary>
	/// Shadow anchor (x-axis)
	/// </summary>
	public BaseInputControl FactyShadowax => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWAX", "#FACTY___FACTYSHADOWAX");

	/// <summary>
	/// Shadow anchor (y-axis)
	/// </summary>
	public BaseInputControl FactyShadoway => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWAY", "#FACTY___FACTYSHADOWAY");

	/// <summary>
	/// Shadow height
	/// </summary>
	public BaseInputControl FactyShadowhe => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWHE", "#FACTY___FACTYSHADOWHE");

	/// <summary>
	/// Shadow width
	/// </summary>
	public BaseInputControl FactyShadowwi => new BaseInputControl(driver, ContainerLocator, "container-FACTY___FACTYSHADOWWI", "#FACTY___FACTYSHADOWWI");

	public FactyForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FACTY", containerLocator: containerLocator) { }
}

using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_menuitForm : Form
{
	/// <summary>
	/// Sigla
	/// </summary>
	public BaseInputControl MenuitSigl => new BaseInputControl(driver, ContainerLocator, "container-F_MENUIT__MENUIT__SIGL", "#F_MENUIT__MENUIT__SIGL");

	/// <summary>
	/// Order
	/// </summary>
	public BaseInputControl MenuitOrder => new BaseInputControl(driver, ContainerLocator, "container-F_MENUIT__MENUIT__ORDER", "#F_MENUIT__MENUIT__ORDER");

	/// <summary>
	/// Menu Item Type
	/// </summary>
	public BaseInputControl MenuitMtype => new BaseInputControl(driver, ContainerLocator, "container-F_MENUIT__MENUIT__MTYPE", "#F_MENUIT__MENUIT__MTYPE");

	/// <summary>
	/// Menu Item Class
	/// </summary>
	public LookupControl MenucMenucl => new LookupControl(driver, ContainerLocator, "container-F_MENUITMENUCMENUCL__");
	public SeeMorePage MenucMenuclSeeMorePage => new SeeMorePage(driver, "F_MENUIT", "F_MENUITMENUCMENUCL__");

	/// <summary>
	/// Menu Type Description
	/// </summary>
	public BaseInputControl MenuitMdesc => new BaseInputControl(driver, ContainerLocator, "container-F_MENUIT__MENUIT__MDESC", "#F_MENUIT__MENUIT__MDESC");

	/// <summary>
	/// 
	/// </summary>
	public BaseInputControl MenuitMenuimg => new BaseInputControl(driver, ContainerLocator, "container-F_MENUIT__MENUIT__MENUIMG", "#F_MENUIT__MENUIT__MENUIMG");

	/// <summary>
	/// Example Link
	/// </summary>
	public BaseInputControl MenuitLink => new BaseInputControl(driver, ContainerLocator, "container-F_MENUIT__MENUIT__LINK", "#F_MENUIT__MENUIT__LINK");

	public F_menuitForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_MENUIT", containerLocator: containerLocator) { }
}

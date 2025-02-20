using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ParamForm : Form
{
	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, ContainerLocator, "container-PARAM___KINDEDESIGNAT");
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "PARAM", "PARAM___KINDEDESIGNAT");

	/// <summary>
	/// Parameter
	/// </summary>
	public BaseInputControl ParamParamete => new BaseInputControl(driver, ContainerLocator, "container-PARAM___PARAMPARAMETE", "#PARAM___PARAMPARAMETE");

	/// <summary>
	/// Data type
	/// </summary>
	public EnumControl ParamDatatype => new EnumControl(driver, ContainerLocator, "container-PARAM___PARAMDATATYPE");

	/// <summary>
	/// Decimal places
	/// </summary>
	public EnumControl ParamDecplace => new EnumControl(driver, ContainerLocator, "container-PARAM___PARAMDECPLACE");

	public ParamForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PARAM", containerLocator: containerLocator) { }
}

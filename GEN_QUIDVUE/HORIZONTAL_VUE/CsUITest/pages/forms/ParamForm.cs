using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ParamForm : Form
{
	/// <summary>
	/// Kind of equipment
	/// </summary>
	public LookupControl KindeDesignat => new LookupControl(driver, ContainerLocator, "container-PARAM___KINDEDESIGNAT" + IdSuffix);
	public SeeMorePage KindeDesignatSeeMorePage => new SeeMorePage(driver, "PARAM", "PARAM___KINDEDESIGNAT" + IdSuffix);

	/// <summary>
	/// Parameter
	/// </summary>
	public BaseInputControl ParamParamete => new BaseInputControl(driver, ContainerLocator, "container-PARAM___PARAMPARAMETE" + IdSuffix, "#PARAM___PARAMPARAMETE" + IdSuffix);

	/// <summary>
	/// Data type
	/// </summary>
	public EnumControl ParamDatatype => new EnumControl(driver, ContainerLocator, "container-PARAM___PARAMDATATYPE" + IdSuffix);

	/// <summary>
	/// Decimal places
	/// </summary>
	public EnumControl ParamDecplace => new EnumControl(driver, ContainerLocator, "container-PARAM___PARAMDECPLACE" + IdSuffix);

	public ParamForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PARAM", containerLocator: containerLocator, usePkInId: usePkInId) { }
}

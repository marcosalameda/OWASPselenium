[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PlistPseudPlistPropertyList(IWebDriver driver, By containerLocator, string css) : BasePropertyListControl(driver, containerLocator, By.Id(css))
{

	/// <summary>
	/// Text Prop
	/// </summary>
    public BaseInputControl Txtprop => new BaseInputControl(driver, m_controlLocator, "", "#FLD_TXTPROP");

	/// <summary>
	/// Multiline Text Prop
	/// </summary>
    public BaseInputControl Multprop => new BaseInputControl(driver, m_controlLocator, "", "#FLD_MULTPROP");

	/// <summary>
	/// Date Prop
	/// </summary>
    public DateInputControl Dateprop => new DateInputControl(driver, m_controlLocator, "#FLD_DATEPROP");

	/// <summary>
	/// Boolean Prop
	/// </summary>
    public IWebElement Boolprop => throw new NotImplementedException();

	/// <summary>
	/// Numeric Prop
	/// </summary>
    public BaseInputControl Numprop => new BaseInputControl(driver, m_controlLocator, "", "#FLD_NUMPROP");

	/// <summary>
	/// Enumeration Prop
	/// </summary>
    public EnumControl Enumprop => new EnumControl(driver, m_controlLocator, "#FLD_ENUMPROP");
}

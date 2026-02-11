
[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquipmPseudA_tagsGrid(IWebDriver driver, By containerLocator, string css) : BaseGridControl(driver, containerLocator, By.CssSelector(css))
{
	/// <summary>
	/// Tag name
	/// </summary>
	public BaseInputControl AtagsName => new BaseInputControl(driver, lineLocator, "container-EQUIPM__PSEUDA_TAGS____ATAGS__NAME", "#EQUIPM__PSEUDA_TAGS____ATAGS__NAME");
}

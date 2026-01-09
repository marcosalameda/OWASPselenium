
[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FldscondPseudGridtblGrid(IWebDriver driver, By containerLocator, string css) : BaseGridControl(driver, containerLocator, By.CssSelector(css))
{
	/// <summary>
	/// Feedback
	/// </summary>
	public BaseInputControl FeecaFeedback => new BaseInputControl(driver, lineLocator, "container-FLDSCONDPSEUDGRIDTBL___FEECA__FEEDBACK", "#FLDSCONDPSEUDGRIDTBL___FEECA__FEEDBACK");
}

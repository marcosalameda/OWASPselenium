
[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FldscondPseudGridtblGrid : BaseGridControl
{

    public FldscondPseudGridtblGrid(IWebDriver driver, By containerLocator, string css) 
        : base(driver, containerLocator, By.CssSelector(css))
    {
    }

	/// <summary>
	/// Feedback
	/// </summary>
	public BaseInputControl FeecaFeedback => new BaseInputControl(driver, lineLocator, "#FLDSCONDPSEUDGRIDTBL_FEECAFEEDBACK");


}
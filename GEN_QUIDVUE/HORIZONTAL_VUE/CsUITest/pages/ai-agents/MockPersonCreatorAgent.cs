[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MockPersonCreatorAgent: BaseAgent
{

    public MockPersonCreatorAgent(IWebDriver driver) : base(driver){}

    /// <summary>
    /// Official No.
    /// </summary>
    public string Employee_Number => "[data-testid='official-no']";

    /// <summary>
    /// Phone
    /// </summary>
    public string Telephone => "[data-testid='phone']";

    /// <summary>
    /// Name
    /// </summary>
    public string Name => "[data-testid='name']";

    /// <summary>
    /// Email
    /// </summary>
    public string Email => "[data-testid='email']";

}

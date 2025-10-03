//Platform: MVC | Type: UITESTIMPORTS | Module: GQT | Parameter: AiTests | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:e713a054-b655-4da0-977e-e2fd1a52fd01
using OpenQA.Selenium.Support.UI;
//END_MANUALCODE

namespace quidgest.uitests.tests;

//Platform: MVC | Type: UITEST | Module: GQT | Parameter: AiTests | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:5ae4744b-1506-48ff-941e-67a90ed531f8
public class AiTests : BaseSeleniumTest
{
    private AppPage Authenticate()
    {
        var a = new AppPage(Driver);
        a.ClickLogin();

        var p = new LoginPage(Driver);
        p.Login("quidgest", "zph2lab");

        Assert.That(a.IsAuthenticated());
        return a;
    }

    [Test]
    public void CallAgentWithTrigger()
    {
        var app = Authenticate();
        app.Menu.ActivateModule("GQT");
        app.Menu.ActivateMenu("GQT", "REPAIR");
        var list = new MenuListPage(Driver, "GQT", "REPAIR_LIST").List;
        list.ClickRow(0);
        var form = new ReparForm(Driver, FORM_MODE.EDIT);
        form.ReparTipoarea.SetValue("L");
        form.ReparDescript.SetValue("Replaced battery");
        form.PseudCateg_ai.Click();
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        wait.Until(d =>form.ReparTipoarea.GetValue() == "L");
    }
    
    [Test]
    public void DirectAgentInteraction()
    {
        var app = Authenticate();
        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "71");

        var list = new MenuListPage(Driver, "PTN", "711").List;
        list.ClickRow(0);

        var form = new Pess1Form(Driver, FORM_MODE.SHOW);

        app.Sidebar.ChatbotButton.Click();

        var chatbot = new ChatbotPage(Driver);
        chatbot.ChangeChat("MockPersonCreator");
        chatbot.SendMessage("Sugere me um valor para email e nome");

        var agent = new MockPersonCreatorAgent(Driver);
        var suggestions = agent.GetAllSuggestions();
        Assert.That(suggestions.Count, Is.EqualTo(2));

        var email = agent.GetSuggestionText(agent.Email);
        var name = agent.GetSuggestionText(agent.Name);

        agent.ApplyLatestSuggestions();

        Assert.That(form.Pess1Name.GetValue(), Is.EqualTo(name));
        Assert.That(form.Pess1Email.GetValue(), Is.EqualTo(email));

        //chatbot.ClearChat();
        form.Save();
    }
}
//END_MANUALCODE




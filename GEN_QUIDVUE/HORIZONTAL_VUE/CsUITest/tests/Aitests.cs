using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using quidgest.uitests.pages;
using quidgest.uitests.pages.common; // Asegúrate de que LoginPage y ChatbotPage estén referenciados

namespace quidgest.uitests.tests;

public class AiTests : BaseSeleniumTest
{
    private AppPage Authenticate()
    {
        // Iniciamos en la página principal
        var a = new AppPage(Driver);
        a.ClickLogin();

        // Realizamos el login
        var p = new LoginPage(Driver);
        p.Login("quidgest", "zph2lab");

        // Verificamos autenticación antes de devolver la página
        Assert.That(a.IsAuthenticated(), "La autenticación falló o el avatar no apareció.");
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
        wait.Until(d => form.ReparTipoarea.GetValue() == "L");
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

        // Click button to create mock person
        form.PseudField001.Click();

        var chatbot = new ChatbotPage(Driver);
        chatbot.WaitForResponse();

        var agent = new MockPersonCreatorAgent(Driver);
        var suggestions = agent.GetAllSuggestions();
        Assert.That(suggestions.Count, Is.EqualTo(4));

        var employeeNumber = agent.GetSuggestionText(agent.Employee_Number);
        var name = agent.GetSuggestionText(agent.Name);
        var email = agent.GetSuggestionText(agent.Email);
        var phoneNumber = agent.GetSuggestionText(agent.Telephone);

        // Apply single suggestion and check that it worked
        agent.ApplySuggestion(agent.Name);
        Assert.That(form.Pess1Name.GetValue(), Is.EqualTo(name));

        // Apply all suggestions and check that it worked
        agent.ApplyLatestSuggestions();

        Assert.That(form.Pess1Idfuncio.GetValue(), Is.EqualTo(employeeNumber));
        Assert.That(form.Pess1Name.GetValue(), Is.EqualTo(name));
        Assert.That(form.Pess1Email.GetValue(), Is.EqualTo(email));
        Assert.That(form.Pess1Telephon.GetValue(), Is.EqualTo(phoneNumber));

        chatbot.ClearChat();
        form.Save();
    }

    [Test]
    public void McpToolsCheck()
    {
        var app = Authenticate();

        // --- CORRECCIÓN ERROR 5: Acceso seguro al Chatbot ---
        // Si 'app.Sidebar' es nulo, usamos una espera directa para evitar el NullReferenceException
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));

        try
        {
            // Intentamos la vía normal
            app.Sidebar.ChatbotButton().Click();
        }
        catch (NullReferenceException)
        {
            // Vía de rescate si el objeto Sidebar no está instanciado en AppPage
            var chatbotBtn = wait.Until(d => d.FindElement(By.Id("chatbot-sidebar-btn")));
            chatbotBtn.Click();
        }

        var chatbot = new ChatbotPage(Driver);

        string resMcpTools = chatbot.SendMessage("Does this application have MCP tools? If so, which ones?");

        Assert.That(resMcpTools.Contains("Create a country"), $"El bot no devolvió la herramienta esperada. Respuesta: {resMcpTools}");
    }
}
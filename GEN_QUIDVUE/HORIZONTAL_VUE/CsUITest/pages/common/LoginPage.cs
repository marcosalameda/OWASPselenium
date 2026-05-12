using OpenQA.Selenium;
using quidgest.uitests.core;

namespace quidgest.uitests.pages;

public class LoginPage : PageObject
{
    private IWebElement loginForm => driver.FindElement(By.Id("login-container"));
    private IWebElement username => loginForm.FindElement(By.Name("username"));
    private IWebElement password => loginForm.FindElement(By.Name("password"));
    private IWebElement submitButton => loginForm.FindElement(By.Id("login-btn"));

    public LoginPage(IWebDriver driver) : base(driver)
    {
        // --- MEJORA: Espera hasta que el formulario sea realmente visible ---
        wait.Until(c => loginForm.Displayed);
    }

    private void WaitForLoad()
    {
        // Usamos GetAttribute para mantener compatibilidad con tu versión funcional
        wait.Until(c => submitButton.GetAttribute("data-loading") == "false");
    }

    public void Login(string username, string password)
    {
        // Aseguramos que el campo de usuario esté listo para recibir texto
        wait.Until(c => this.username.Enabled);

        FillUsername(username);
        FillPassword(password);

        this.submitButton.Click();
    }

    public void FillPassword(string password)
    {
        this.password.Clear();
        this.password.SendKeys(password);
    }

    public void FillUsername(string username)
    {
        this.username.Clear();
        this.username.SendKeys(username);
    }

    public void Register()
    {
        var btn = loginForm.FindElement(By.Id("link-register"));
        btn.Click();
    }

    public void ForgotPassword()
    {
        var btn = loginForm.FindElement(By.Id("link-forgot-password"));
        btn.Click();
    }

    // --- RE-INTEGRACIÓN MÉTODO FALTANTE (SOLUCIÓN CS1061) ---
    public bool HasErrorMessage(string id)
    {
        WaitForLoad();
        try
        {
            IWebElement errorMessage = loginForm.FindElement(By.Id(id));
            return errorMessage.Text.Length > 0;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
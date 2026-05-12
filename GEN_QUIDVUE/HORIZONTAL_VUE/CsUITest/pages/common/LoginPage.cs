using OpenQA.Selenium;
using quidgest.uitests.core;
using System;

namespace quidgest.uitests.pages;

public class LoginPage : PageObject
{
    private IWebElement loginForm => driver.FindElement(By.Id("login-container"));
    private IWebElement username => driver.FindElement(By.Name("username"));
    private IWebElement password => driver.FindElement(By.Name("password"));
    private IWebElement submitButton => driver.FindElement(By.Id("login-btn"));

    public LoginPage(IWebDriver driver) : base(driver)
    {
        // Espera hasta que el formulario sea visible
        wait.Until(c => loginForm.Displayed);
    }

    private void WaitForLoad()
    {
        try
        {
            wait.Until(c => submitButton.GetAttribute("data-loading") != "true");
        }
        catch
        {
            // Silenciamos si el atributo no existe
        }
    }

    public void Login(string username, string password)
    {
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

    public bool HasErrorMessage(string id)
    {
        WaitForLoad();
        try
        {
            IWebElement errorMessage = driver.FindElement(By.Id(id));
            return errorMessage.Displayed && errorMessage.Text.Length > 0;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
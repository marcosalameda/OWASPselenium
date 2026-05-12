using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace quidgest.uitests.core;

public class DriverFactory
{
    public static IWebDriver getWebDriver()
    {
        var c = Configuration.Instance;
        return getWebDriver(
            c.Browser,
            c.Headless.Value,
            c.ImplicitWait.Value,
            c.WindowWidth.Value,
            c.WindowHeight.Value
        );
    }

    public static IWebDriver getWebDriver(
        string browser,
        bool headless,
        int implicitWaitMilliseconds,
        int windowwidth,
        int windowheight)
    {
        IWebDriver driver;
        // Detectamos si Jenkins nos está pidiendo un navegador remoto
        var remoteUrl = Environment.GetEnvironmentVariable("SELENIUM_REMOTE_URL");

        switch (browser.ToLower())
        {
            case "firefox":
                new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                if (headless) firefoxOptions.AddArguments("--headless");
                driver = new FirefoxDriver(firefoxOptions);
                break;

            case "edge":
                new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                driver = new EdgeDriver();
                break;

            default: // ✅ CHROME
                ChromeOptions chromeOptions = new ChromeOptions();

                // Lógica de Headless: Si hay remoteUrl (Jenkins), forzamos headless
                if (!string.IsNullOrEmpty(remoteUrl) || headless)
                {
                    chromeOptions.AddArgument("--headless=new");
                }

                chromeOptions.AddArgument($"--window-size={windowwidth},{windowheight}");
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");
                chromeOptions.AddArgument("--ignore-certificate-errors");
                chromeOptions.AddArgument("--allow-insecure-localhost");
                chromeOptions.AddArgument("--allow-running-insecure-content");
                chromeOptions.AddArgument("--disable-web-security");

                // --- DECISIÓN FINAL: ¿Remoto o Local? ---
                if (!string.IsNullOrEmpty(remoteUrl))
                {
                    // Estamos en Jenkins/Docker
                    driver = new RemoteWebDriver(new Uri(remoteUrl), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(180));
                }
                else
                {
                    // Estamos en tu PC: Usamos el WebDriverManager de tu copia buena
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new ChromeDriver(chromeOptions);
                }
                break;
        }

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWaitMilliseconds);

        return driver;
    }
}
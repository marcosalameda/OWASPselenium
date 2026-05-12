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

        // Variables de entorno inyectadas por Docker Compose o Jenkins
        var remoteUrl = Environment.GetEnvironmentVariable("SELENIUM_REMOTE_URL");
        var zapProxyUrl = Environment.GetEnvironmentVariable("ZAP_PROXY");

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

                // --- CONFIGURACIÓN DEL PROXY (CRÍTICO PARA ZAP) ---
                // Le indica al navegador que enrute el tráfico a través del proxy ZAP
                if (!string.IsNullOrEmpty(zapProxyUrl))
                {
                    var proxy = new Proxy
                    {
                        HttpProxy = zapProxyUrl,
                        SslProxy = zapProxyUrl,
                        Kind = ProxyKind.Manual
                    };
                    chromeOptions.Proxy = proxy;
                }

                // Lógica de Headless: forzado si es remoto o configurado manualmente
                if (!string.IsNullOrEmpty(remoteUrl) || headless)
                {
                    chromeOptions.AddArgument("--headless=new");
                }

                // Argumentos de estabilidad y seguridad necesarios para entornos Docker/Linux
                chromeOptions.AddArgument($"--window-size={windowwidth},{windowheight}");
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");
                chromeOptions.AddArgument("--ignore-certificate-errors"); // Permite confiar en el certificado de ZAP
                chromeOptions.AddArgument("--allow-insecure-localhost");
                chromeOptions.AddArgument("--allow-running-insecure-content");
                chromeOptions.AddArgument("--disable-web-security");

                // --- DECISIÓN FINAL: ¿Remoto o Local? ---
                if (!string.IsNullOrEmpty(remoteUrl))
                {
                    // Entorno de red Docker/Jenkins: Conectamos al Selenium Hub remoto
                    driver = new RemoteWebDriver(new Uri(remoteUrl), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(180));
                }
                else
                {
                    // Entorno Local: Descarga el driver adecuado y arranca Chrome local
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new ChromeDriver(chromeOptions);
                }
                break;
        }

        // Aplicar el ImplicitWait definido globalmente
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWaitMilliseconds);

        return driver;
    }
}
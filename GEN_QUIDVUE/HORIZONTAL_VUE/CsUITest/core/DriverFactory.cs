using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
// using OpenQA.Selenium.Opera;
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

        switch (browser)
        {
            case "firefox":
                new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                if (headless)
                    firefoxOptions.AddArguments("--headless");
                driver = new FirefoxDriver(firefoxOptions);
                break;

            case "edge":
                new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                driver = new EdgeDriver();
                break;

            // case "opera":
            //     new DriverManager().SetUpDriver(new OperaConfig());
            //     driver = new OperaDriver();
            //     break;

            default: // ✅ CHROME
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

                ChromeOptions chromeOptions = new ChromeOptions();

                if (headless)
{
    chromeOptions.AddArgument("--headless=new");
}


                chromeOptions.AddArgument($"--window-size={windowwidth},{windowheight}");

                // 🔐 Desactivar Safe Browsing y avisos de seguridad
                chromeOptions.AddArgument("--disable-features=SafeBrowsing");
                chromeOptions.AddUserProfilePreference("safebrowsing.enabled", false);
                chromeOptions.AddUserProfilePreference("safebrowsing.disable_download_protection", true);

                // 🌐 Permitir HTTP, IPs internas, certificados no válidos
                chromeOptions.AddArgument("--ignore-certificate-errors");
                chromeOptions.AddArgument("--allow-insecure-localhost");
                chromeOptions.AddArgument("--allow-running-insecure-content");

                // 🧪 Flags habituales en automatización / CI
                chromeOptions.AddArgument("--disable-web-security");
                chromeOptions.AddArgument("--no-sandbox");
                // ✅ IMPRESCINDIBLES en Docker
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");
                chromeOptions.AddArgument("--disable-gpu");

                // 🚫 Desactivar gestor de contraseñas de Chrome
                chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
                chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
                chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);

                // Proxy ZAP (Windows)
                var zapProxy = Environment.GetEnvironmentVariable("ZAP_PROXY");

                if (!string.IsNullOrEmpty(zapProxy))
                {
                    chromeOptions.AddArgument($"--proxy-server={zapProxy}");
                    chromeOptions.AcceptInsecureCertificates = true;
                }

                driver = new ChromeDriver(chromeOptions);
                break;
        }

        driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromMilliseconds(implicitWaitMilliseconds);

        return driver;
    }
}

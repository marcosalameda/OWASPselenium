using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

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

        switch (browser.ToLowerInvariant())
        {
            case "firefox":
                FirefoxOptions firefoxOptions = new FirefoxOptions();

                if (headless)
                {
                    firefoxOptions.AddArgument("--headless");
                }

                driver = new FirefoxDriver(firefoxOptions);
                break;

            case "edge":
                driver = new EdgeDriver();
                break;

            default: // ✅ CHROME / CHROMIUM (Docker)

                ChromeOptions chromeOptions = new ChromeOptions();

                // ✅ MUY IMPORTANTE: indicar explícitamente Chromium
                chromeOptions.BinaryLocation = "/usr/bin/chromium";

                // ✅ Headless moderno (Chrome/Chromium >= 109)
                if (headless)
                {
                    chromeOptions.AddArgument("--headless=new");
                }

                // ✅ Tamaño de ventana
                chromeOptions.AddArgument($"--window-size={windowwidth},{windowheight}");

                // ✅ FLAGS OBLIGATORIOS EN DOCKER
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");
                chromeOptions.AddArgument("--disable-gpu");

                // ✅ Seguridad / certificados (útil para test y ZAP)
                chromeOptions.AddArgument("--ignore-certificate-errors");
                chromeOptions.AddArgument("--allow-insecure-localhost");
                chromeOptions.AddArgument("--allow-running-insecure-content");

                chromeOptions.AcceptInsecureCertificates = true;

                // ✅ Desactivar funcionalidades problemáticas en CI
                chromeOptions.AddArgument("--disable-web-security");
                chromeOptions.AddArgument("--disable-features=SafeBrowsing");

                chromeOptions.AddUserProfilePreference("safebrowsing.enabled", false);
                chromeOptions.AddUserProfilePreference("safebrowsing.disable_download_protection", true);
                chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
                chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
                chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);

                // ✅ Proxy ZAP (si existe)
                var zapProxy = Environment.GetEnvironmentVariable("ZAP_PROXY");
                if (!string.IsNullOrWhiteSpace(zapProxy))
                {
                    chromeOptions.AddArgument($"--proxy-server={zapProxy}");
                }

                // ✅ Crear el driver (Chromedriver del sistema)
                driver = new ChromeDriver(chromeOptions);
                break;
        }

        // ✅ Timeouts
        driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromMilliseconds(implicitWaitMilliseconds);

        return driver;
    }
}

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
            {
                var firefoxOptions = new FirefoxOptions();

                if (headless)
                {
                    firefoxOptions.AddArgument("--headless");
                }

                driver = new FirefoxDriver(firefoxOptions);
                break;
            }

            case "edge":
                driver = new EdgeDriver();
                break;

            default: // ✅ CHROME / CHROMIUM EN DOCKER
            {
                var chromeOptions = new ChromeOptions();

                // ✅ Forzar Chromium (no google-chrome)
                chromeOptions.BinaryLocation = "/usr/bin/chromium";

                // ✅ Directorios escribibles (CRÍTICO en Docker)
                chromeOptions.AddArgument("--user-data-dir=/tmp/chrome-user-data");
                chromeOptions.AddArgument("--data-path=/tmp/chrome-data");
                chromeOptions.AddArgument("--disk-cache-dir=/tmp/chrome-cache");

                // ✅ Headless moderno
                if (headless)
                {
                    chromeOptions.AddArgument("--headless=new");
                }

                // ✅ Ventana
                chromeOptions.AddArgument($"--window-size={windowwidth},{windowheight}");

                // ✅ Flags obligatorios en contenedores
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");
                chromeOptions.AddArgument("--disable-gpu");

                // ✅ Certificados e inseguridad controlada (tests / ZAP)
                chromeOptions.AddArgument("--ignore-certificate-errors");
                chromeOptions.AddArgument("--allow-insecure-localhost");
                chromeOptions.AddArgument("--allow-running-insecure-content");
                chromeOptions.AcceptInsecureCertificates = true;

                // ✅ Evitar cosas problemáticas en CI
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

                // ✅ ChromeDriver del sistema (/usr/bin/chromedriver)
                driver = new ChromeDriver(chromeOptions);
                break;
            }
        }

        driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromMilliseconds(implicitWaitMilliseconds);

        return driver;
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

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

        var remoteUrl = Environment.GetEnvironmentVariable("SELENIUM_REMOTE_URL");
        if (string.IsNullOrWhiteSpace(remoteUrl))
        {
            throw new InvalidOperationException(
                "SELENIUM_REMOTE_URL environment variable is not set"
            );
        }

        switch (browser.ToLowerInvariant())
        {
            case "firefox":
            {
                var options = new FirefoxOptions();

                if (headless)
                {
                    options.AddArgument("--headless");
                }

                ConfigureZapProxy(options);

                driver = new RemoteWebDriver(new Uri(remoteUrl), options);
                break;
            }

            case "edge":
            {
                var options = new EdgeOptions();
                ConfigureZapProxy(options);

                driver = new RemoteWebDriver(new Uri(remoteUrl), options);
                break;
            }

            default: // ✅ CHROME (REMOTE)
            {
                var options = new ChromeOptions();

                if (headless)
                {
                    options.AddArgument("--headless=new");
                }

                options.AddArgument($"--window-size={windowwidth},{windowheight}");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--disable-gpu");

                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--allow-insecure-localhost");
                options.AcceptInsecureCertificates = true;

                ConfigureZapProxy(options);

                driver = new RemoteWebDriver(new Uri(remoteUrl), options);
                break;
            }
        }

        driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromMilliseconds(implicitWaitMilliseconds);

        return driver;
    }

    private static void ConfigureZapProxy(DriverOptions options)
    {
        var zapProxy = Environment.GetEnvironmentVariable("ZAP_PROXY");
        if (!string.IsNullOrWhiteSpace(zapProxy))
        {
            options.AddArgument($"--proxy-server={zapProxy}");
        }
    }
}

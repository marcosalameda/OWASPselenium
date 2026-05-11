using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace quidgest.uitests.core;

public static class DriverFactory
{
    public static IWebDriver getWebDriver()
    {
        var remoteUrl = Environment.GetEnvironmentVariable("SELENIUM_REMOTE_URL");
        if (string.IsNullOrWhiteSpace(remoteUrl))
            throw new InvalidOperationException("SELENIUM_REMOTE_URL not set");

        var options = new ChromeOptions();

        // ✅ Ejecución CI
        options.AddArgument("--headless=new");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--window-size=1920,1080");

        // ✅ CLAVE PARA OWASP ZAP (MITM HTTPS)
        options.AcceptInsecureCertificates = true;
        options.AddArgument("--ignore-certificate-errors");
        options.AddArgument("--ignore-ssl-errors=yes");
        options.AddArgument("--allow-insecure-localhost");

        // ✅ Proxy OWASP ZAP (si existe)
        var zapProxy = Environment.GetEnvironmentVariable("ZAP_PROXY");
        if (!string.IsNullOrWhiteSpace(zapProxy))
        {
            options.AddArgument($"--proxy-server={zapProxy}");
        }

        return new RemoteWebDriver(
            new Uri(remoteUrl),
            options,
            TimeSpan.FromSeconds(120) // timeout más seguro en CI
        );
    }
}

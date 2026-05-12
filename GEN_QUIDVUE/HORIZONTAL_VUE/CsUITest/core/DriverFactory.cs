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

        // --- Configuración básica CI / Docker ---
        options.AddArgument("--headless=new");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--window-size=1920,1080");

        // --- BLOQUEO DE RUIDO Y TRÁFICO DE FONDO (Clave para evitar los 32MB de Google) ---
        // Deshabilita el servicio de predicción de red y guías de optimización
        options.AddArgument("--disable-features=OptimizationHints,OptimizationGuideModelDownloading,OptimizationTargetPrediction,OptimizationHintsFetching");
        // Deshabilita actualizaciones automáticas de componentes y extensiones
        options.AddArgument("--disable-component-update");
        options.AddArgument("--disable-extensions");
        options.AddArgument("--disable-default-apps");
        // Deshabilita servicios de Google (Safe Browsing, Translate, etc.) que generan tráfico extra
        options.AddArgument("--disable-background-networking");
        options.AddArgument("--disable-sync");
        options.AddArgument("--disable-translate");

        // --- CLAVE PARA OWASP ZAP (MITM HTTPS) ---
        options.AddArgument("--ignore-certificate-errors");
        options.AddArgument("--ignore-ssl-errors=yes");
        options.AddArgument("--ignore-certificate-errors-spki-list");
        options.AddArgument("--allow-insecure-localhost");
        options.AddArgument("--disable-web-security");
        options.AddArgument("--allow-running-insecure-content");

        // --- Configuración de Proxy ZAP ---
        var zapProxy = Environment.GetEnvironmentVariable("ZAP_PROXY");
        if (!string.IsNullOrWhiteSpace(zapProxy))
        {
            // Forzamos a que todo pase por el proxy excepto lo definido en NO_PROXY si fuera necesario
            options.AddArgument($"--proxy-server={zapProxy}");
        }

        // Aumentamos el timeout de la sesión remota para dar margen a ZAP de procesar las peticiones
        return new RemoteWebDriver(
            new Uri(remoteUrl),
            options.ToCapabilities(),
            TimeSpan.FromSeconds(180) 
        );
    }
}

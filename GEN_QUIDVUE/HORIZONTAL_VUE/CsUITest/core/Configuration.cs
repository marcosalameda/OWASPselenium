using System.IO;
using System.Text.Json;

namespace quidgest.uitests.core;

public class Configuration
{
    public string Browser { get; set; }
    public string BaseUrl { get; set; }
    public bool? Headless { get; set; }
    public int? ImplicitWait { get; set; }
    public int? ExplicitWait { get; set; }

    public int? WindowWidth { get; set; }
    public int? WindowHeight { get; set; }

    private static Configuration _instance;

    public Configuration() { }

    public static Configuration Instance
    {
        get
        {
            if (_instance == null)
            {
                // --- ARREGLO ERROR 2: Tiempos por defecto realistas ---
                _instance = new Configuration
                {
                    Browser = "chrome",
                    // --- ARREGLO ERROR 1: BaseUrl asegurada ---
                    BaseUrl = "https://jenkinsvm.quidgest.pt/gqt_horizontal_vue/",
                    Headless = false, // En local preferimos ver el navegador
                    ImplicitWait = 10000, // 10 segundos (antes 0.1s)
                    ExplicitWait = 30000, // 30 segundos (antes 1s)
                    WindowWidth = 1920,
                    WindowHeight = 1080
                };

                // Sobrescribir con JSON si existe
                if (File.Exists("SeleniumWebTest.json"))
                {
                    var settings = File.ReadAllText("SeleniumWebTest.json");
                    var f = JsonSerializer.Deserialize<Configuration>(settings);
                    if (f != null)
                    {
                        if (f.Browser != null) _instance.Browser = f.Browser;
                        if (f.BaseUrl != null) _instance.BaseUrl = f.BaseUrl;
                        if (f.Headless != null) _instance.Headless = f.Headless;
                        if (f.ImplicitWait != null) _instance.ImplicitWait = f.ImplicitWait;
                        if (f.ExplicitWait != null) _instance.ExplicitWait = f.ExplicitWait;
                        if (f.WindowWidth != null) _instance.WindowWidth = f.WindowWidth;
                        if (f.WindowHeight != null) _instance.WindowHeight = f.WindowHeight;
                    }
                }

                // --- COMPATIBILIDAD MEJORADA: Soporte para variables de Jenkins/Docker ---
                _instance.Browser = GetEnv("selenium.browser", "selenium_browser") ?? _instance.Browser;
                _instance.BaseUrl = GetEnv("selenium.baseurl", "selenium_baseurl") ?? _instance.BaseUrl;

                var h = GetEnv("selenium.headless", "selenium_headless");
                if (h != null) _instance.Headless = bool.Parse(h);

                var iw = GetEnv("selenium.implicitwait", "selenium_implicitwait");
                if (iw != null) _instance.ImplicitWait = int.Parse(iw);

                var ew = GetEnv("selenium.explicitwait", "selenium_explicitwait");
                if (ew != null) _instance.ExplicitWait = int.Parse(ew);

                var ww = GetEnv("selenium.windowwidth", "selenium_windowwidth");
                if (ww != null) _instance.WindowWidth = int.Parse(ww);

                var wh = GetEnv("selenium.windowheight", "selenium_windowheight");
                if (wh != null) _instance.WindowHeight = int.Parse(wh);
            }
            return _instance;
        }
    }

    // Método auxiliar para leer variables con dos posibles nombres
    private static string GetEnv(string key1, string key2)
    {
        return Environment.GetEnvironmentVariable(key1) ?? Environment.GetEnvironmentVariable(key2);
    }
}
using Administration.AuxClass;
using CSGenio;
using CSGenio.framework;
using GenioServer.framework;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    public class ConfigMigrationController : ControllerBase
    {
        private IActionResult startPage(Models.ConfigMigrationModel model, bool redirect)
        {
            model.ConfigVersion = AuxFunctions.GetConfigVersion();

            if (!AuxFunctions.CheckXMLIsValid())
            {
                model.ResultMsg = Resources.Resources.E_NECESSARIO_PROCEDE36325;
                redirect = false;
            }

            return Json(new { model, redirect });
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new Models.ConfigMigrationModel();
            return startPage(model, false);
        }

        [HttpPost]
        public IActionResult MigrateConfig([FromBody] Models.ConfigMigrationModel model)
        {
            ConfigXMLMigration.Migration(AuxFunctions.GetConfigVersion());

            //reload configuration file
            string pathConfig = CSGenio.framework.Configuration.GetConfigPath();
            pathConfig = Path.Combine(pathConfig, "Configuracoes.xml");
            ConfigurationXML conf = ConfigurationXML.readXML(pathConfig);
            CSGenio.framework.Configuration.ReadConfiguration(conf);

            return startPage(model, true);
        }

        
    }
}

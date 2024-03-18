using CSGenio.framework;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Administration.AuxClass
{
    public static class AuxFunctions
    {


        public static double GetDBSize(string year, string Schema)
        {
            double sizeIdxDb = 0;
            try
            {
                var sp = CSGenio.persistence.PersistentSupport.getPersistentSupport(year);
                sp.openConnection();
                string qs;
                if (sp.DatabaseType == DatabaseType.ORACLE)
                {
                    qs = "select BYTES/1024/1024 SizeMB from SYS.DBA_DATA_FILES WHERE TABLESPACE_NAME = '" + Schema + "'";
                }
                else if (sp.DatabaseType == DatabaseType.MYSQL)
                {
                    qs = "SELECT ROUND(SUM(data_length + index_length) / 1024 / 1024, 1) SizeMB FROM information_schema.tables where table_schema = '" + Schema + "' GROUP BY table_schema";
                }
                else
                {
                    qs = "SELECT (size * 8) / 1024 SizeMB FROM sys.master_files WHERE Name = '" + Schema + "'";
                }

                double val = CSGenio.persistence.DBConversion.ToNumeric(sp.executeScalar(qs));
                sizeIdxDb = val;

                sp.closeConnection();
            }
            catch
            {
                //we ignore errors for now (version will look as 0)
            }

            return sizeIdxDb;
        }	

		public static int GetConfigVersion()
        {
            try
            {
                string pathConfig = Configuration.GetConfigPath();
                pathConfig = Path.Combine(pathConfig, "Configuracoes.xml");

                //read configuration document
                XDocument xmlConfig = XDocument.Load(pathConfig);
                XAttribute version = xmlConfig.Descendants().Attributes("configVersion").FirstOrDefault();
                if (version == null)
                    return 0;

                //parse configuration verion
                return Int32.Parse(version.Value);
            }
            catch (Exception)
            {
                return -1;
            }
        }
        
        public static bool CheckXMLIsValid()
        {
            string pathConfig = Configuration.GetConfigPath();
            pathConfig = Path.Combine(pathConfig, "Configuracoes.xml");
            
            //check if file exists
            if (!System.IO.File.Exists(pathConfig))
                return false;

            int version = GetConfigVersion();
            if (version == -1 || version != GenioServer.framework.ConfigXMLMigration.CurConfigurationVerion)
                return false;

            return true;
        }
		
		public static CSGenio.persistence.PersistentSupport GetPersistentSupport(string year)
        {
            string pathConfig = Configuration.GetConfigPath();
            CSGenio.ConfigurationXML conf = CSGenio.ConfigurationXML.readXML(pathConfig + Path.DirectorySeparatorChar + "Configuracoes.xml");
            var dataSystem = conf.DataSystems.FirstOrDefault(ds => ds.Name == year);
            return CSGenio.persistence.PersistentSupport.getPersistentSupport(dataSystem.Name);
        }


        #region Helpers
        private static string GetEnumDisplayName<TEnum>(object item)
        {
            string res = item.ToString();
            var da = ((DisplayAttribute)(typeof(TEnum).GetField(res).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault()));
            return da == null ? res : da.GetName();
        }

        public static IEnumerable<SelectListItem> ToSelectList<TEnum>(object selected = null)
        {
            return Enum.GetValues(typeof(TEnum)).Cast<IFormattable>().Select(v =>
            new SelectListItem()
            {
                Text = GetEnumDisplayName<TEnum>(v),
                Value = v.ToString("d", null),
                Selected = selected == null ? false : (v.ToString() == selected.ToString())
            });
        }
        #endregion
    }
}

using CSGenio.business;
using CSGenio.framework;
using CSGenio.framework.TableConfiguration;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Linq;
using Quidgest.Persistence;

namespace CSGenio.core.persistence
{

    /// <summary>
    /// Class that gets and sets table configuration information in the database
    /// </summary>
    public static class TableConfigurationIO
    {
        /*
		 * Parse string-encoded table configuration data to an object.
		 */
        public static TableConfiguration ParseTableConfigData(string encodedString)
        {
            // Set options to allow converting numbers to strings (used in advanced filters, column filters, searchbar filters)
            JsonSerializerOptions serializationOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };

            TableConfiguration tableConfiguration;

            try
            {
                tableConfiguration = JsonSerializer.Deserialize<TableConfiguration>(encodedString, serializationOptions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                tableConfiguration = new TableConfiguration();
            }

            return tableConfiguration;
        }

        /*
		 * Get a table configuration record from the database.
		 */
        public static CSGenioAtblcfg GetTableConfigNameRecord(PersistentSupport sp, User user, string uuid, string configName)
        {
            //Get saved configuration
            return CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldName, configName),
                new string[] { CSGenioAtblcfg.FldName.Field, CSGenioAtblcfg.FldConfig.Field })
                .FirstOrDefault();
        }

        /*
		 * Get a table configuration from the database.
		 */
        public static TableConfiguration GetTableConfig(PersistentSupport sp, User user, string uuid, string configName)
        {
            // Get record from the database
            CSGenioAtblcfg configRecord = GetTableConfigNameRecord(sp, user, uuid, configName);

            // If configuration does not exist
            if (configRecord == null)
                return null;

            // Parse to object
            TableConfiguration tableConfig = ParseTableConfigData(configRecord.ValConfig);

            // Add configuration name
            tableConfig.Name = configRecord.ValName;

            return tableConfig;
        }

        /*
		 * Get default table configuration from the database.
		 */
        public static TableConfiguration GetTableDefaultConfig(PersistentSupport sp, User user, string uuid)
        {
            string tableConfigJson;
            string tableConfigName;

            // Get table configuration and name fields from the default configuration record
            // tblcfg has the table configurations
            // tblcfgsel has the records that specify which record in tblcfg, if any, is the default
            SelectQuery query = new SelectQuery()
                .Select(CSGenioAtblcfg.FldName)
                .Select(CSGenioAtblcfg.FldConfig)
                .From(Area.AreaTBLCFG)
                .Join(Area.AreaTBLCFGSEL)
                    .On(CriteriaSet.And().Equal(CSGenioAtblcfg.FldCodtblcfg, CSGenioAtblcfgsel.FldCodtblcfg)
                )
                .Where(CriteriaSet.And()
                    .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                    .Equal(CSGenioAtblcfg.FldUuid, uuid)
                );

            var result = sp.Execute(query);

            // If configuration does not exist
            if (result.NumRows == 0 || result.NumCols != 2)
                return null;

            tableConfigName = DBConversion.ToString(result.GetDirect(0, 0));
            tableConfigJson = DBConversion.ToString(result.GetDirect(0, 1));

            // If configuration is empty
            if (string.IsNullOrEmpty(tableConfigJson))
                return null;

            // Parse to object
            TableConfiguration tableConfig = ParseTableConfigData(tableConfigJson);

            // Add configuration name
            tableConfig.Name = tableConfigName;

            return tableConfig;
        }

        /*
		 * Determine which table configuration to use.
		 */
        public static TableConfiguration DetermineTableConfig(PersistentSupport sp, User user, string uuid, TableConfiguration currentTableConfig, string configName = "", bool loadDefaultView = false)
        {
            // Default to the current table configuration
            TableConfiguration tableConfig = currentTableConfig;

            // If loading the default configuration
            if (!string.IsNullOrEmpty(uuid) && loadDefaultView)
                tableConfig = GetTableDefaultConfig(sp, user, uuid);
            // If loading a saved table configuration
            else if (!string.IsNullOrEmpty(uuid) && !string.IsNullOrEmpty(configName))
                tableConfig = GetTableConfig(sp, user, uuid, configName);

            if (tableConfig == null)
                tableConfig = new TableConfiguration();

            return tableConfig;
        }
    }
}

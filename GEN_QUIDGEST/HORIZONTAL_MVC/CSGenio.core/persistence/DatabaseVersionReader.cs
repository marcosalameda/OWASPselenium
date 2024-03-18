using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;


namespace CSGenio.core.persistence
{

    /// <summary>
    /// Class that obtains the various version information from the database
    /// </summary>
    public class DatabaseVersionReader : IVersionReader
    {

        private PersistentSupport sp;

        /// <summary>
        /// Creates a database version reader object. The Persistent Support is expected to be open.
        /// </summary>
        public DatabaseVersionReader(PersistentSupport sp)
        {
            this.sp = sp;
        }

        private object GetValueFromCfg(string columnName)
        {
            if (sp.CheckIfDatabaseExists())
            {
                string tableName = Configuration.Program + "cfg";
                SelectQuery query = new SelectQuery()
                    .Select(tableName, columnName)
                    .From(tableName);
                var value = sp.ExecuteScalar(query);
                return value;
            }
            else
            {
                throw new FrameworkException("The database doesn't exist", "", "");
            }
        }

        /// <summary>
        /// Returns the current database version for this database
        /// </summary>
        public double GetDbVersion()
        {
            var value = GetValueFromCfg("versao");
            double versionDb = DBConversion.ToNumeric(value);
            return versionDb;
        }

        /// <summary>
        /// Returns the last version of the upgrade script executed for this function
        /// </summary>
        public int GetDbUpgradeVersion()
        {
            var value = GetValueFromCfg("upgrindx");
            int version = DBConversion.ToInteger(value);
            return version;
        }

        /// <summary>
        /// Returns the current version of the indexes in this database
        /// </summary>
        public double GetDbIndexVersion()
        {
            var value = GetValueFromCfg("versindx");
            double versionDb = DBConversion.ToNumeric(value);
            return versionDb;
        }

        /// <summary>
        /// Returns the current version of the indexes in this database or 0 if there is an error.
        /// This method never throws an exception.
        /// </summary>
        public double GetDbVersionOrZero()
        {
            try
            {
                return GetDbVersion();
            }
            catch 
            {
                return 0;
            }

        }

    }
}

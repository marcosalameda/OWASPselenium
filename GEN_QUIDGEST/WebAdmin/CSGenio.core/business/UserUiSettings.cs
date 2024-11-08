using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSGenio.business
{
    /// <summary>
    /// Manages user interface settings and configurations, including table layouts and user preferences.
    /// Handles the persistence and caching of UI settings for individual users.
    /// </summary>
    public class UserUiSettings
    {
        #region Table Configuration Properties

        /// <summary>
        /// Gets the list of selected configuration information rows.
        /// </summary>
        public List<CSGenioAtblcfgsel> UserTableConfigSelectedInfoRow { get; private set; }

        /// <summary>
        /// Gets the primary key of the selected table configuration.
        /// </summary>
        public string UserTableConfigSelectedPk { get; private set; }

        /// <summary>
        /// Gets the selected table configuration row.
        /// </summary>
        public CSGenioAtblcfg UserTableConfigSelectedRow { get; private set; }

        /// <summary>
        /// Gets the selected table configuration data.
        /// </summary>
        public string UserTableConfigSelected { get; private set; }

        /// <summary>
        /// Gets the name of the selected table configuration.
        /// </summary>
        public string UserTableConfigSelectedName { get; private set; }

        /// <summary>
        /// Gets the list of all available table configurations.
        /// </summary>
        public List<CSGenioAtblcfg> UserTableConfigs { get; private set; }

        /// <summary>
        /// Gets the list of all table configuration names.
        /// </summary>
        public List<string> UserTableConfigNames { get; private set; }

        /// <summary>
        /// Gets the default table configuration row.
        /// </summary>
        public CSGenioAtblcfg UserTableConfigDefaultRow { get; private set; }

        /// <summary>
        /// Gets the name of the default table configuration.
        /// </summary>
        public string UserTableConfigDefaultName { get; private set; }

        #endregion

        #region User Settings Properties

        /// <summary>
        /// Gets the user settings.
        /// </summary>
        public CSGenioAlstusr UserSettings { get; private set; }

        /// <summary>
        /// Gets the list of column configurations.
        /// </summary>
        public List<CSGenioAlstcol> UserColumns { get; private set; }

        /// <summary>
        /// Gets the list of rendering configurations.
        /// </summary>
        public List<CSGenioAlstren> UserRenderings { get; private set; }

        /// <summary>
        /// Gets the list of widget configurations.
        /// </summary>
        public List<CSGenioAusrwid> UserWidgets { get; private set; }

        /// <summary>
        /// Gets the cache key for this settings instance.
        /// </summary>
        private string Key { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the UserUiSettings class.
        /// </summary>
        private UserUiSettings(string key)
        {
            Key = key;
        }

        #region Public Methods

        /// <summary>
        /// Loads user interface settings from cache or database.
        /// </summary>
        /// <param name="sp">The persistence support instance for database operations.</param>
        /// <param name="uuid">The unique identifier for the settings.</param>
        /// <param name="user">The user for whom to load settings.</param>
        /// <param name="userTableConfigName">Optional table configuration name to load specific settings.</param>
        /// <param name="loadBase">If true, forces loading from database instead of cache.</param>
        /// <returns>A UserUiSettings instance containing the loaded settings.</returns>
        public static UserUiSettings Load(
            PersistentSupport sp, 
            string uuid, 
            User user, 
            string userTableConfigName = "", 
            bool loadBase = false)
        {
            string cacheKey = GenerateCacheKey(uuid, user);
            UserUiSettings settings = loadBase ? null : GetFromCache(cacheKey);

            if (ShouldLoadFreshSettings(settings, userTableConfigName))
            {
                settings = new UserUiSettings(cacheKey);
                settings.LoadFreshSettings(sp, uuid, user, userTableConfigName);
            }

            settings.LoadAllTableConfigurations(sp, uuid, user);
            return settings;
        }

        /// <summary>
        /// Invalidates the cached settings for a specific user.
        /// </summary>
        /// <param name="uuid">The unique identifier for the settings.</param>
        /// <param name="user">The user whose settings should be invalidated.</param>
        public static void Invalidate(string uuid, User user)
        {
            string cacheKey = GenerateCacheKey(uuid, user);
            QCache.Instance.User.Invalidate(cacheKey);
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Generates a cache key for the specified user and UUID.
        /// </summary>
        private static string GenerateCacheKey(string uuid, User user) 
            => $"lstUser_{uuid};{user.Codpsw};{user.Year}";

        /// <summary>
        /// Retrieves settings from cache.
        /// </summary>
        private static UserUiSettings GetFromCache(string cacheKey)
            => QCache.Instance.User.Get(cacheKey) as UserUiSettings;

        /// <summary>
        /// Determines if fresh settings should be loaded from the database.
        /// </summary>
        private static bool ShouldLoadFreshSettings(UserUiSettings settings, string tableConfigName)
            => settings == null || 
               (settings.UserTableConfigSelectedName != null && 
                !settings.UserTableConfigSelectedName.Equals(tableConfigName));

        /// <summary>
        /// Loads fresh settings from the database.
        /// </summary>
        private void LoadFreshSettings(
            PersistentSupport sp,
            string uuid,
            User user,
            string tableConfigName)
        {
            LoadSelectedTableConfiguration(sp, uuid, user, tableConfigName);
            LoadUserSettings(sp, uuid, user);

            if (string.IsNullOrEmpty(tableConfigName))
            {
                CacheSettings();
            }
        }

        /// <summary>
        /// Loads the selected table configuration and related settings.
        /// </summary>
        private void LoadSelectedTableConfiguration(
            PersistentSupport sp,
            string uuid,
            User user,
            string tableConfigName)
        {
            // Load selected configuration info
            UserTableConfigSelectedInfoRow = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfgsel.FldUuid, uuid)
                .Equal(CSGenioAtblcfgsel.FldZzstate, 0))
                .ToList();

            // Load default configuration
            if (UserTableConfigSelectedInfoRow?.Any() == true)
            {
                UserTableConfigDefaultRow = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                    .Equal(CSGenioAtblcfg.FldCodtblcfg, UserTableConfigSelectedInfoRow[0].ValCodtblcfg)
                    .Equal(CSGenioAtblcfg.FldZzstate, 0))
                    .FirstOrDefault();

                UserTableConfigDefaultName = UserTableConfigDefaultRow?.ValName;
            }

            // Load user selected configuration
            if (!string.IsNullOrEmpty(tableConfigName))
            {
                LoadUserSelectedConfig(sp, uuid, user, tableConfigName);
            }
            else if (UserTableConfigDefaultRow != null)
            {
                UseDefaultConfig();
            }
        }

        /// <summary>
        /// Loads the user selected configuration.
        /// </summary>
        private void LoadUserSelectedConfig(
            PersistentSupport sp,
            string uuid,
            User user,
            string configName)
        {
            UserTableConfigSelectedRow = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldName, configName)
                .Equal(CSGenioAtblcfg.FldZzstate, 0))
                .FirstOrDefault();

            UserTableConfigSelected = UserTableConfigSelectedRow?.ValConfig;
            UserTableConfigSelectedName = UserTableConfigSelectedRow?.ValName;
            UserTableConfigSelectedPk = UserTableConfigSelectedRow?.ValCodtblcfg;
        }

        /// <summary>
        /// Uses the default configuration as the selected configuration.
        /// </summary>
        private void UseDefaultConfig()
        {
            UserTableConfigSelectedRow = UserTableConfigDefaultRow;
            UserTableConfigSelected = UserTableConfigSelectedRow.ValConfig;
            UserTableConfigSelectedName = UserTableConfigSelectedRow.ValName;
            UserTableConfigSelectedPk = UserTableConfigSelectedRow.ValCodtblcfg;
        }

        /// <summary>
        /// Loads all available table configurations.
        /// </summary>
        private void LoadAllTableConfigurations(PersistentSupport sp, string uuid, User user)
        {
            UserTableConfigs = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldZzstate, 0))
                .ToList();

            UserTableConfigNames = UserTableConfigs.Select(c => c.ValName).ToList();
        }

        /// <summary>
        /// Loads user settings and related configurations.
        /// </summary>
        private void LoadUserSettings(PersistentSupport sp, string uuid, User user)
        {
            UserSettings = CSGenioAlstusr.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstusr.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAlstusr.FldDescric, uuid)
                .Equal(CSGenioAlstusr.FldZzstate, 0))
                .FirstOrDefault();

            if (UserSettings != null)
            {
                LoadUserConfigurations(sp, user);
            }
        }

        /// <summary>
        /// Loads user-specific configurations (columns, renderings, and widgets).
        /// </summary>
        private void LoadUserConfigurations(PersistentSupport sp, User user)
        {
            UserColumns = CSGenioAlstcol.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstcol.FldCodlstusr, UserSettings.ValCodlstusr)
                .Equal(CSGenioAlstcol.FldZzstate, 0))
                .OrderBy(x => x.ValPosicao)
                .ToList();

            UserRenderings = CSGenioAlstren.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAlstren.FldCodlstusr, UserSettings.ValCodlstusr)
                .Equal(CSGenioAlstren.FldZzstate, 0))
                .OrderBy(x => x.ValPosicao)
                .ToList();

            UserWidgets = CSGenioAusrwid.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAusrwid.FldCodlstusr, UserSettings.ValCodlstusr)
                .Equal(CSGenioAusrwid.FldZzstate, 0))
                .ToList();
        }

        /// <summary>
        /// Caches the current settings instance.
        /// </summary>
        private void CacheSettings()
        {
            QCache.Instance.User.Put(Key, this, TimeSpan.FromHours(1));
        }

        #endregion
    }
}
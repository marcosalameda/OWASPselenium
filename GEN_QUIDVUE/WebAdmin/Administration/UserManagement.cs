using System.Xml.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using Administration.Models;
using CSGenio;
using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using DbAdmin;
using IConfigurationManager = CSGenio.config.IConfigurationManager;

namespace Administration
{
    /// <summary>
    /// This is for use to manage users (create and disable) on application
    /// </summary>
    public class UserManagement : IUserManagementService
    {
        private readonly IConfigurationManager _configManager;

        public UserManagement(IConfigurationManager configManager)
        {
            _configManager = configManager;
        }
        
		/// <summary>
        /// Return a list of all Permitions accept for each user and for each module on application
        /// </summary>
        /// <returns>All permitions of each module</returns>
        public List<ModulesLevel> GetPermissions()
        {
            List<ModulesLevel> perm = new List<ModulesLevel>();
            perm.Add(new ModulesLevel("STY", Resources.Resources.STYLE47121, "ADMINISTRATOR", Resources.Resources.ADMINISTRATOR54799));
            perm.Add(new ModulesLevel("GQT", Resources.Resources.GENIO_QUALITY_TESTS30896, "ADMINISTRATOR", Resources.Resources.ADMINISTRATOR54799));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "ADMINISTRATOR", Resources.Resources.ADMINISTRATOR54799));
            perm.Add(new ModulesLevel("UIS", Resources.Resources.USER_INTERFACE32384, "ADMINISTRATOR", Resources.Resources.ADMINISTRATOR54799));
            perm.Add(new ModulesLevel("TBS", Resources.Resources.BASE_TABLES04823, "ADMINISTRATOR", Resources.Resources.ADMINISTRATOR54799));
            perm.Add(new ModulesLevel("PTN", Resources.Resources.PATTERNS16056, "ADMINISTRATOR", Resources.Resources.ADMINISTRATOR54799));
            perm.Add(new ModulesLevel("REG", Resources.Resources.REGISTRATION03584, "ADMINISTRATOR", Resources.Resources.ADMINISTRATOR54799));
            perm.Add(new ModulesLevel("IMO", Resources.Resources.REAL_ESTATE24996, "ADMINISTRATOR", Resources.Resources.ADMINISTRATOR54799));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "EDIT", Resources.Resources.EDIT07023));
            perm.Add(new ModulesLevel("STY", Resources.Resources.STYLE47121, "EDIT", Resources.Resources.EDIT07023));
            perm.Add(new ModulesLevel("GQT", Resources.Resources.GENIO_QUALITY_TESTS30896, "EDIT", Resources.Resources.EDIT07023));
            perm.Add(new ModulesLevel("PTN", Resources.Resources.PATTERNS16056, "EDIT", Resources.Resources.EDIT07023));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "EDIT_PESSO", Resources.Resources.EDITOR_RECURSOS23553));
            perm.Add(new ModulesLevel("PTN", Resources.Resources.PATTERNS16056, "EDIT_PESSO", Resources.Resources.EDITOR_RECURSOS23553));
            perm.Add(new ModulesLevel("REG", Resources.Resources.REGISTRATION03584, "EMPLOYEE", Resources.Resources.EMPLOYEE08184));
            perm.Add(new ModulesLevel("TBS", Resources.Resources.BASE_TABLES04823, "MANAGER", Resources.Resources.MANAGER18024));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "MANAGER", Resources.Resources.MANAGER18024));
            perm.Add(new ModulesLevel("IMO", Resources.Resources.REAL_ESTATE24996, "MANAGER", Resources.Resources.MANAGER18024));
            perm.Add(new ModulesLevel("PTN", Resources.Resources.PATTERNS16056, "MANAGER", Resources.Resources.MANAGER18024));
            perm.Add(new ModulesLevel("TBS", Resources.Resources.BASE_TABLES04823, "SYSADMIN", Resources.Resources.SYSADMIN53289));
            perm.Add(new ModulesLevel("PTN", Resources.Resources.PATTERNS16056, "SYSADMIN", Resources.Resources.SYSADMIN53289));
            perm.Add(new ModulesLevel("GQT", Resources.Resources.GENIO_QUALITY_TESTS30896, "SYSADMIN", Resources.Resources.SYSADMIN53289));
            perm.Add(new ModulesLevel("IMO", Resources.Resources.REAL_ESTATE24996, "SYSADMIN", Resources.Resources.SYSADMIN53289));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "SYSADMIN", Resources.Resources.SYSADMIN53289));
            perm.Add(new ModulesLevel("REG", Resources.Resources.REGISTRATION03584, "SYSADMIN", Resources.Resources.SYSADMIN53289));
            perm.Add(new ModulesLevel("STY", Resources.Resources.STYLE47121, "SYSADMIN", Resources.Resources.SYSADMIN53289));
            perm.Add(new ModulesLevel("UIS", Resources.Resources.USER_INTERFACE32384, "SYSADMIN", Resources.Resources.SYSADMIN53289));
            perm.Add(new ModulesLevel("GQT", Resources.Resources.GENIO_QUALITY_TESTS30896, "VIEW", Resources.Resources.VIEW37934));
            perm.Add(new ModulesLevel("PTN", Resources.Resources.PATTERNS16056, "VIEW_PESSO", Resources.Resources.EDITOR_RECURSOS23553));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "VIEW_PESSO", Resources.Resources.EDITOR_RECURSOS23553));
            perm.Add(new ModulesLevel("REG", Resources.Resources.REGISTRATION03584, "1", Resources.Resources.QUERY30986));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "1", Resources.Resources.QUERY30986));
            perm.Add(new ModulesLevel("TBS", Resources.Resources.BASE_TABLES04823, "1", Resources.Resources.QUERY30986));
            perm.Add(new ModulesLevel("IMO", Resources.Resources.REAL_ESTATE24996, "1", Resources.Resources.QUERY30986));
            perm.Add(new ModulesLevel("GQT", Resources.Resources.GENIO_QUALITY_TESTS30896, "1", Resources.Resources.QUERY30986));
            perm.Add(new ModulesLevel("UIS", Resources.Resources.USER_INTERFACE32384, "1", Resources.Resources.QUERY30986));
            perm.Add(new ModulesLevel("PTN", Resources.Resources.PATTERNS16056, "1", Resources.Resources.QUERY30986));
            perm.Add(new ModulesLevel("STY", Resources.Resources.STYLE47121, "1", Resources.Resources.QUERY30986));
            perm.Add(new ModulesLevel("GQT", Resources.Resources.GENIO_QUALITY_TESTS30896, "2", Resources.Resources.VENDEDOR34177));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "3", Resources.Resources.OFFICER20358));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "4", Resources.Resources.AGENT00994));
            perm.Add(new ModulesLevel("WMS", Resources.Resources.WAREHOUSE_MANAGEMENT10443, "20", Resources.Resources.MANAGER60821));
            perm.Add(new ModulesLevel("IMO", Resources.Resources.REAL_ESTATE24996, "20", Resources.Resources.MANAGER60821));
            perm.Add(new ModulesLevel("GQT", Resources.Resources.GENIO_QUALITY_TESTS30896, "20", Resources.Resources.MANAGER60821));
            perm.Add(new ModulesLevel("IMO", Resources.Resources.REAL_ESTATE24996, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("REG", Resources.Resources.REGISTRATION03584, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("TRN", Resources.Resources.TRAINING_EXERCISES07801, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("PTN", Resources.Resources.PATTERNS16056, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("TBS", Resources.Resources.BASE_TABLES04823, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("UIS", Resources.Resources.USER_INTERFACE32384, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("GQT", Resources.Resources.GENIO_QUALITY_TESTS30896, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("WMS", Resources.Resources.WAREHOUSE_MANAGEMENT10443, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("XRS", Resources.Resources.WHAREHOUSE_API10412, "99", Resources.Resources.ADMINISTRATOR27313));
            perm.Add(new ModulesLevel("STY", Resources.Resources.STYLE47121, "99", Resources.Resources.ADMINISTRATOR27313));
	
            return perm;
        }

        private PersistentSupport getSP()
        {
            var conf = _configManager.GetExistingConfig();
            var dataSystem = conf.DataSystems.FirstOrDefault(ds => ds.Name == Configuration.DefaultYear); // Default == null

            if (dataSystem == null)
                return null;

            return PersistentSupport.getPersistentSupport(dataSystem.Name);
        }

        /// <summary>
        /// To search one user by name
        /// </summary>
        /// <param name="username">Name to search</param>
        /// <returns>If "username" exist than return PK field of user</returns>
        private string getUser(string username)
        {
            string codUsr = "";
            var sp = getSP();

            try
            {
                sp.openConnection();

                //verificar se já existe um utilizador com o mesmo nome
                SelectQuery userQuery = new SelectQuery()
                    .Select(CSGenioApsw.FldCodpsw)
                    .From("USERLOGIN", "psw")
                    .PageSize(1);

                CriteriaSet where = new CriteriaSet(CriteriaSetOperator.And);
                where.Equal(CSGenioApsw.FldNome, username);
                where.Equal(CSGenioApsw.FldZzstate, 0);

                userQuery.Where(where);
                codUsr = CSGenio.persistence.DBConversion.ToString(sp.ExecuteScalar(userQuery));
            }
            catch { }
            finally
            {
                sp.closeConnection();
            }

            return codUsr;
        }

        private void saveUserLevel(User user, string codUser, PersistentSupport sp, string modulo, string level)
        {
            var persisted = CSGenioAuserauthorization.searchList(sp, user, CriteriaSet.And()
                                .Equal(CSGenioAuserauthorization.FldSistema, "VVC")
                                .Equal(CSGenioAuserauthorization.FldCodpsw, codUser)
                                .Equal(CSGenioAuserauthorization.FldModulo, modulo) 
                                .Equal(CSGenioAuserauthorization.FldZzstate, 0));
            Role role = Role.GetRole(level);
            if(!persisted.Any(x=>x.IsRole(modulo, role)))
            {
                CSGenioAuserauthorization.InsertRole(sp, user, codUser, modulo, role);
            }
        }
        
		/// <summary>
        /// Create user
        /// </summary>
        /// <param name="username">name for user</param>
        /// <param name="password">password to use for the same user</param>
        /// <param name="levels">priviledge for access for each module</param>
        /// <returns>true if create successful</returns>
        public bool CreateUserWithPassAndLevels(string username, string password, List<ModulesLevel> levels)
        {
            //Check if user exist and return if true
            if (getUser(username) != "")
                return false;

            try
            {
                var sp = getSP();
                sp.openConnection();

                //Temporary user to insert the new one
                User user = SysConfiguration.CreateWebAdminUser(userName: "WebServer");

                CSGenioApsw userPsw = new CSGenioApsw(user, "GQT");
                userPsw.ValNome = username;
                userPsw.ValEmail = String.Empty;
                userPsw.ValPhone = String.Empty;
                userPsw.ValStatus = 0;
                if (password != "")
                {
                    string pswEnc = GenioServer.security.PasswordFactory.Encrypt(password);
                    userPsw.ValPassword = pswEnc;
                    userPsw.ValSalt = "";
                    userPsw.ValPswtype = Configuration.Security.PasswordAlgorithms.ToString();
                }
                userPsw.insert(sp);


                //save all access levels
                if (levels != null && levels.Count != 0)
                {
                    string codUsr = getUser(username);
                    foreach (ModulesLevel level in levels)
                        saveUserLevel(user, codUsr, sp, level.Module, level.Level);
                }

                sp.closeConnection();

                return true;
            }
            catch
            {
                return false;
            }
        }

		/// <summary>
        /// Create User
        /// </summary>
        /// <param name="username">name for user</param>
        /// <param name="password">password to use for the same user</param>
        /// <returns>true if create successful</returns>
        public bool CreateUserWithPass(string username, string password)
        {
            return CreateUserWithPassAndLevels(username, password, new List<ModulesLevel>());
        }

		/// <summary>
        /// Create User
        /// </summary>
        /// <param name="username">name for user</param>
        /// <param name="levels">priviledge for access for each module</param>
        /// <returns>true if create successful</returns>
        public bool CreateUserWithLevels(string username, List<ModulesLevel> levels)
        {
            if (levels == null)
                return false;

            return CreateUserWithPassAndLevels(username, "", levels);
        }

		/// <summary>
        /// Create User
        /// </summary>
        /// <param name="username">name for user</param>
        /// <returns>true if create successful</returns>
        public bool CreateUser(string username)
        {
            //Can be one sistem only with windows authentication and only be mandatory to save username
            return CreateUserWithPassAndLevels(username, "", null);
        }

		/// <summary>
        /// Disable User
        /// </summary>
        /// <param name="username">name of user</param>
        /// <returns>true if disable successful</returns>
        public bool DeleteUser(string username)
        {
            //check if exist user to disable that
            string codUsr = getUser(username);
            if (String.IsNullOrEmpty(codUsr))
                return false;

            try
            {
                var sp = getSP();
                sp.openConnection();

                User user = SysConfiguration.CreateWebAdminUser(userName: "WebServer");

                //update the user data
                CriteriaSet where = new CriteriaSet(CriteriaSetOperator.And);
                where.Equal("psw", "codpsw", codUsr);
                where.Equal("psw", "zzstate", "0");
                CSGenioApsw userPsw = new CSGenioApsw(user, "GQT");
                CSGenioApsw userPswAux = CSGenioApsw.searchList(sp, user, where).First();
                userPsw.ValCodpsw = userPswAux.ValCodpsw;
                userPsw.ValNome = userPswAux.ValNome;
                userPsw.ValEmail = userPswAux.ValEmail;
                userPsw.ValPhone = userPswAux.ValPhone;
                userPsw.ValStatus = 2; //Doesn't remove user but put that disable with value 2
                userPsw.ValCertsn = userPswAux.ValCertsn;
                userPsw.ValPswtype = userPswAux.ValPswtype;
                userPsw.update(sp);

                sp.closeConnection();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Test(string s)
        {
            return s;
        }
    }
}

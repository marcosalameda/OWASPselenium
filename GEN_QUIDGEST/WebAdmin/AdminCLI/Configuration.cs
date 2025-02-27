using CommandLine;
using CSGenio;
using CSGenio.config;
using DbAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace AdminCLI
{
    [Verb("dbconfig-write", HelpText = "Database Configuration")]
    class WriteConfigurationOptions
    {
        [Option('u', "username", Required = true, HelpText = "Database instance username")]
        public string Username { get; set; }

        [Option('p', "password", Required = true, HelpText = "Database instance password")]
        public string Password { get; set; }

        [Option("server", Required = true, HelpText = "Server name or IP where the instance is located")]
        public string Server { get; set; }

        [Option("port", HelpText = "Server port (default is 1433)")]
        public string Port { get; set; }

        [Option("type", Required = true, HelpText = "Database server type")]
        public string Type { get; set; }

        [Option("schema", Required = true, HelpText = "The database schema/name")]
        public string Schema { get; set; }

        [Option("encrypt-connection", HelpText = "Encrypt the database connection")]
        public bool EncryptConnection { get; set; }

        [Option("domain-user", HelpText = "Specify if it's a domain user")]
        public bool DomainUser { get; set; }

        [Option("is-log", HelpText = "Specify if its a log database configuration")]
        public bool IsLog { get; set; }

        [Option("path", HelpText = "The location of the configuration file. Creates a new one if not exists")]
        public string Path { get; set; }
    }

    [Verb("dbconfig-read", HelpText = "Database Configuration")]
    class ReadConfigurationOptions
    {
        [Option('y', "year", HelpText = "Database year")]
        public string Year { get; set; }

        [Option('s', "schema", HelpText = "The database schema/name")]
        public string Schema { get; set; }
    }


    [Verb("create-redirect", HelpText = "Create a new redirect file")]
    class CreateRedirectOptions
    {
        [Option("config-path", Required=true, HelpText = "The path with the Configuracoes.xml")]
        public string ConfigPath { get; set; }

        [Option("redirect-path", HelpText = "The path where the new Configuracoes.redirect.xml will be created")]
        public string RedirectPath { get; set; }
    }



    partial class AdminCLI
    {
        /// <summary>
        /// Fetches the available database types
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<string> FetchDatabaseTypes()
        {
            return new List<string>(Enum.GetNames(typeof(CSGenio.framework.DatabaseType)));
        }

        /// <summary>
        /// Validates the configuration options that are passed by the user
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>        
        private static bool ValidateOptions(WriteConfigurationOptions options)
        {
            //Check if the inserted DB type exists
            if(string.IsNullOrEmpty(options.Type) || !FetchDatabaseTypes().Any(x => x.ToLower() == options.Type.ToLower()))
            {
                Console.WriteLine("The inserted Database Type does not exist. " + 
                    "Please make sure it is one of the following: [" + string.Join(", ", FetchDatabaseTypes().ToArray()) + "]");
                return false;
            }

            //Check if the port is valid
            if(!string.IsNullOrEmpty(options.Port))
            {
                try
                {
                    int port = Convert.ToInt32(options.Port);

                    //Check if the port number is within the range
                    if(port <= 0 || port > 65535)
                    {
                        Console.WriteLine("The port number you have inserted is invalid, please make sure it is between 1 and 65535");
                        return false;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Please make sure the server port is a valid number!");
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Configures a database
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private static int WriteConfiguration(WriteConfigurationOptions options)
        {
            if (!ValidateOptions(options))
                return 1;

            SysConfiguration sysConfig = sysConfiguration;
            if(!String.IsNullOrEmpty(options.Path))
            {
                var fileManager = new FileConfigurationManager(options.Path);
                sysConfig = new SysConfiguration(fileManager);
            }

            try
            {
                if(options.IsLog)
                    sysConfig.SaveLogDatabaseConfig(options.Username, options.Password, options.Server, options.Type, options.Schema,
                        options.Port, options.EncryptConnection, options.DomainUser);
                else
                    sysConfig.SaveDatabaseConfig(options.Username, options.Password, options.Server, options.Type, options.Schema,
                        options.Port, options.EncryptConnection, options.DomainUser);
            }
            catch (Exception e)
            {
                Console.WriteLine("The following error has ocurred: \n" + e.Message);
            }
            
            Console.WriteLine("Configuration saved successfully!");
            return 0;
        }

        /// <summary>
        /// Reads the current configuration
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private static int ReadConfiguration(ReadConfigurationOptions options)
        {
            DataSystemXml dataSystem = sysConfiguration.ReadDatabaseConfig(options.Year, options.Schema);

            if (dataSystem == null)
            {
                Console.WriteLine("There is no data to display.");
                return 1;
            }

            DisplayDataSystem(dataSystem);
            return 0;
        }

        /// <summary>
        /// Creates a new redirect file
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private static int CreateNewRedirect(CreateRedirectOptions options)
        {            
            try
            {
                var redirect = sysConfiguration.CreateRedirect(options.ConfigPath);
                string path = Path.Combine(options.RedirectPath, "Configuracoes.redirect.xml");
                RedirectXML.WriteRedirectFile(redirect, path);
                return 0;
            }
            catch (Exception ex) {             
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }

        /// <summary>
        /// Displays a data system
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private static void DisplayDataSystem(DataSystemXml dataSystem)
        {
            Console.WriteLine($"Name: {dataSystem.Name}");
            Console.WriteLine($"Type: {dataSystem.Type}");
            Console.WriteLine($"Server: {dataSystem.Server}");
            Console.WriteLine($"Port: {dataSystem.Port}");
            Console.WriteLine($"TnsName: {dataSystem.TnsName}");
            Console.WriteLine($"Service: {dataSystem.Service}");
            Console.WriteLine($"Login: {Encoding.UTF8.GetString(Convert.FromBase64String(dataSystem.Login))}");
            Console.WriteLine($"Password: {Encoding.UTF8.GetString(Convert.FromBase64String(dataSystem.Password))}\n");

            Console.WriteLine("Schemas:");
            foreach (DataXml schema in dataSystem.Schemas)
            {
                Console.WriteLine($"ID: {schema.Id}");
                Console.WriteLine($"Schema: {schema.Schema}");
                Console.WriteLine("Encrypt Connection: " + ((schema.ConnEncrypt == true) ? "Yes" : "No"));
                Console.WriteLine("Domain User: " + ((schema.ConnWithDomainUser == true) ? "Yes" : "No"));
                Console.WriteLine(); //Leave a blank space as a separator
            }

            Console.WriteLine("Log Schemas:");
            foreach (DataXml schema in dataSystem.DataSystemLog.Schemas)
            {
                Console.WriteLine($"ID: {schema.Id}");
                Console.WriteLine($"Schema: {schema.Schema}");
                Console.WriteLine("Encrypt Connection: " + ((schema.ConnEncrypt == true) ? "Yes" : "No"));
                Console.WriteLine("Domain User: " + ((schema.ConnWithDomainUser == true) ? "Yes" : "No"));
                Console.WriteLine(); //Leave a blank space as a separator
            }

            Console.WriteLine(); //Leave a blank space as a separator
        }
    }
}

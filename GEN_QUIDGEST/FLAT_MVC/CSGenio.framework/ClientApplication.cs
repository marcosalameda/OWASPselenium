using System;
using System.Collections.Generic;

namespace CSGenio.framework
{
    public class ClientApplication
    {
        public static readonly ClientApplication FLAT_MVC = 
            new ClientApplication("FLAT_MVC", "Styles") 
            {
                Modules = new Dictionary<string, string>
				{
                    { "STY", "STYLE47121" },
                    { "GQT", "GENIO_QUALITY_TESTS30896" },
                    { "PTN", "PATTERNS16056" },
                },
                Platform = "MVC",
            };

        public static readonly ClientApplication GQT = 
            new ClientApplication("GQT", "Genio Quality Tests") 
            {
                Modules = new Dictionary<string, string>
				{
                    { "GQT", "GENIO_QUALITY_TESTS30896" },
                    { "PTN", "GENIO_PATTERNS30857" },
                    { "TBS", "BASE_TABLES04823" },
                    { "REG", "REGISTRATION03584" },
                    { "STY", "STYLE47121" },
                },
                Platform = "MVC",
            };

        public static readonly ClientApplication WMS = 
            new ClientApplication("WMS", "Warehouse Management System") 
            {
                Modules = new Dictionary<string, string>
				{
                    { "WMS", "WAREHOUSE_MANAGEMENT10443" },
                    { "IMO", "REAL_ESTATE24996" },
                },
                Platform = "MVC",
            };

        public static readonly ClientApplication HORIZONTAL_MVC = 
            new ClientApplication("HORIZONTAL_MVC", "Horizontal Layout") 
            {
                Modules = new Dictionary<string, string>
				{
                    { "STY", "STYLE47121" },
                    { "PTN", "PATTERNS16056" },
                    { "GQT", "GENIO_QUALITY_TESTS30896" },
                },
                Platform = "MVC",
            };

        public static readonly ClientApplication WEBADMIN = 
            new ClientApplication("WebAdmin", "WebAdmin") 
                { 
                    Security = false
                };

        public ClientApplication(string id, string name)
        {
            Name = name;
            Id = id;
            Security = true;
            Path = true;
            Modules = new Dictionary<string, string>();
            Platform = string.Empty;
        }

        public Dictionary<string, string> Modules {get; private set;}
        public String Name { get; private set; }
        public String Id { get; private set; }
        public String Platform { get; private set; }
        public bool Security { get; set; }
        public bool Path { get; set; }
		
		public static List<ClientApplication> Applications => applications;

        private static readonly List<ClientApplication> applications = new List<ClientApplication>()
        {
            FLAT_MVC,      
            GQT,      
            WMS,      
            HORIZONTAL_MVC,      
            WEBADMIN
        };
    }
}

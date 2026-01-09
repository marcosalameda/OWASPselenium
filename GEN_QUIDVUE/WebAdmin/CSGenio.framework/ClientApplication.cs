using System;
using System.Collections.Generic;

namespace CSGenio.framework
{
    public class ClientApplication
    {
        public static readonly ClientApplication FLAT_VUE = 
            new ClientApplication("FLAT_VUE", "Vertical layout - Vue") 
            {
                Modules = new Dictionary<string, string>
				{
                    { "STY", "STYLE47121" },
                    { "GQT", "GENIO_QUALITY_TESTS30896" },
                    { "PTN", "PATTERNS16056" },
                    { "TBS", "BASE_TABLES04823" },
                    { "WMS", "WAREHOUSE_MANAGEMENT10443" },
                    { "REG", "REGISTRATION03584" },
                    { "IMO", "REAL_ESTATE24996" },
                    { "TRN", "TRAINING_EXERCISES07801" },
                    { "UIS", "USER_INTERFACE32384" },
                },
                Platform = "VUE",
            };

        public static readonly ClientApplication HORIZONTAL_VUE = 
            new ClientApplication("HORIZONTAL_VUE", "Horizontal Layout - Vue") 
            {
                Modules = new Dictionary<string, string>
				{
                    { "STY", "STYLE47121" },
                    { "PTN", "PATTERNS16056" },
                    { "GQT", "GENIO_QUALITY_TESTS30896" },
                    { "IMO", "REAL_ESTATE24996" },
                    { "REG", "REGISTRATION03584" },
                    { "TBS", "BASE_TABLES04823" },
                    { "WMS", "WAREHOUSE_MANAGEMENT10443" },
                    { "TRN", "TRAINING_EXERCISES07801" },
                    { "UIS", "USER_INTERFACE32384" },
                },
                Platform = "VUE",
            };

        public static readonly ClientApplication REST = 
            new ClientApplication("REST", "Rest") 
            {
                Modules = new Dictionary<string, string>
				{
                    { "XRS", "WHAREHOUSE_API10412" },
                },
                Platform = "REST",
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
            FLAT_VUE,      
            HORIZONTAL_VUE,      
            REST,      
            WEBADMIN
        };
    }
}

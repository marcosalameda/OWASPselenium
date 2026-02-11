using CSGenio.business;
using CSGenio.core.ai;
using CSGenio.framework;
using CSGenio.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenioServer.ai
{
    public class MockPersonCreatorAgent : ModelAiAgent
    {
        public override string AGENT_ID => "MockPersonCreator";

        public MockPersonCreatorAgent(IChatbotService service) : base(service)
        {
        }

        private CSGenioApess1 pess1;
        
        private PersistentSupport sp;
        private User user;
        private string module; 

        public void LoadRecords(string key, PersistentSupport sp, User user)
        {
            //Base area
            var area = CSGenioApess1.search(sp, key, user, new string[] {
            });
            LoadRecords(area, sp, user);
        }

        public override void LoadRecords(DbArea area, PersistentSupport sp, User user)
        {
            this.sp = sp;
            this.user = user;
            this.module = user.CurrentModule;

            pess1 = (CSGenioApess1) area;
			Files = new List<DBFile>();
			// Documents to load

            // Areas dependent on base table

        }

		public void LoadFile(PersistentSupport sp, string valDocFk)
        {
            DBFile file = DbArea.getFileDB(valDocFk, sp);
            if (file != null && file.File != null)
            {
                Files.Add(file);
            }
        }

        public override string BuildUserPrompt()
        {
                return
                $"You are working inside the PERSON table of a system.\n"+
                $"The goal is to help testers quickly populate forms with realistic mock data, so they can validate system behavior without needing to type everything manually.  \n"+
                $"\n"+
                $"Focus on generating values for fields such as Employee number, Email, and Telephone, following the given rules. \n"+
                $"Always keep consistency across records, make sure data formats follow typical expectations, and guarantee that no real personal data is ever used.\n";
        }

        public override string BuildSystemPrompt()
        {
                return
                $"You are an assistant that generates realistic mock data for person records to support testing activities. Your task is to create safe, fictional data that looks authentic but does not use any real personal information.\n"+
                $"\n"+
                $"Rules:\n"+
                $"- The Employee number must be a numeric value between 1 and 6 digits (e.g., 27, 48392)\n"+
                $"- Name just needs to be a random first and last name\n"+
                $"- Always generate a valid-looking email address using this format: [firstname].[lastname]@example.com \n"+
                $"- Telephone numbers must follow Portuguese formatting rules (9 digits, starting with 2 or 9).  \n"+
                $"    Examples: 912345678, 234567890.\n"+
                $"- Ensure all generated values look realistic\n"+
                $"- Never use real personal data, everything must be fictional.\n";
        }

        public override void Execute(DbArea area, PersistentSupport sp, User user, AgentContextData context = null)
        {
            LoadRecords(area, sp, user);

            if(context == null)
                context = BuildAgentContext(user, area.QPrimaryKey);

            MockPersonCreatorResponse response = base.GetResponse<MockPersonCreatorResponse>(context);
            if (response == null)
                throw new FrameworkException("Answer from AI service was empty", "MockPersonCreatorAgent.Execute", "Answer from AI service was empty");
            
            MapResponse(response);
        }




        public override object JsonSchema => new
        {
            type = "object",
            required = new[] { "Employee_Number", 
"Telephone", 
"Name", 
"Email"},
            properties = new
            {
                Employee_Number = new
                {
                    type = "number",
                    title = Translations.Get("Official No.", user.Language),
                    description = "The number of the employee, any number from 1 -> 6 characters"
                }, 

                Telephone = new
                {
                    type = "string",
                    title = Translations.Get("Phone", user.Language),
                    description = "The person's telephone number, a portuguese valid. Numbers must follow Portuguese formatting rules"
                }, 

                Name = new
                {
                    type = "string",
                    title = Translations.Get("Name", user.Language),
                    description = "The person first and last name"
                }, 

                Email = new
                {
                    type = "string",
                    title = Translations.Get("Email", user.Language),
                    description = "The person's email should be a combination of their first and last name"
                }            }
        };


        protected void MapResponse(MockPersonCreatorResponse response)
        {
            Log.Info($"Agent {this.AGENT_ID} responded in Employee_Number parameter ${response.Employee_Number }");
            pess1.ValIdfuncio = response.Employee_Number;
            Log.Info($"Agent {this.AGENT_ID} responded in Telephone parameter ${response.Telephone }");
            pess1.ValTelephon = response.Telephone;
            Log.Info($"Agent {this.AGENT_ID} responded in Name parameter ${response.Name }");
            pess1.ValName = response.Name;
            Log.Info($"Agent {this.AGENT_ID} responded in Email parameter ${response.Email }");
            pess1.ValEmail = response.Email;
        }

        public override void PersistRecord(PersistentSupport sp)
        {
            pess1.apply(sp);
        }

    }

    public class MockPersonCreatorResponse
    {             
        [Newtonsoft.Json.JsonProperty("Employee_Number")]
        public decimal Employee_Number { get; set; }
        [Newtonsoft.Json.JsonProperty("Telephone")]
        public string Telephone { get; set; }
        [Newtonsoft.Json.JsonProperty("Name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("Email")]
        public string Email { get; set; }
    }


}

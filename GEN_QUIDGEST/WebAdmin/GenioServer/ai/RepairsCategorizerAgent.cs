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
    public class RepairsCategorizerAgent : ModelAiAgent
    {
        public override string AGENT_ID => "RepairsCategorizer";

        public override object JsonSchema => new
        {
            type = "object",
            required = new[] { "Category"},
            properties = new
            {
                Category = new
                {
                    type = "string",
                    description = "A one letter with the correct mapping"
                }
            }
        };

        public RepairsCategorizerAgent(IChatbotService service) : base(service)
        {
        }

        private CSGenioArepar repar;
        

        public void LoadRecords(string key, PersistentSupport sp, User user)
        {
            //Base area
            var area = CSGenioArepar.search(sp, key, user, new string[] {
                CSGenioArepar.FldDescript.FullName,
            });
            LoadRecords(area, sp, user);
        }

        public override void LoadRecords(DbArea area, PersistentSupport sp, User user)
        {
            repar = (CSGenioArepar) area;

            // Areas dependent on base table
        }

        public override void Execute(DbArea area, PersistentSupport sp, User user)
        {
            LoadRecords(area, sp, user);

            RepairsCategorizerResponse response = base.GetResponse<RepairsCategorizerResponse>(user);
            if (response == null)
                throw new FrameworkException("Answer from AI service was empty", "RepairsCategorizerAgent.Execute", "Answer from AI service was empty");
            SaveResponse(response);
        }

        public void SaveResponse(RepairsCategorizerResponse response)
        {
            Log.Info($"Agent {this.AGENT_ID} responded in Category parameter ${response.Category }");
            repar.ValTipoarea = response.Category;
        }

        public override string BuildUserPrompt()
        {
                return
                $"The repair description is:\n"+
                $"{repar.ValDescript}\n";
        }

        public override string BuildSystemPrompt()
        {
                return
                $"Classify the repair in categories acording to the given description. The category must return a one letter code, with the following mapping:\n"+
                $"M: Mechanical\n"+
                $"E: Electrical\n"+
                $"L: Cleaning\n"+
                $"G: Management\n"+
                $"\n"+
                $"You can't return a letter not in this 4 categories.\n";
        }
    }

    public class RepairsCategorizerResponse
    {             
        [Newtonsoft.Json.JsonProperty("Category")]         
        public string Category { get; set; }
    }

}

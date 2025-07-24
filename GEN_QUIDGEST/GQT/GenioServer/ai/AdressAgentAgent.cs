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
    public class AdressAgentAgent : ModelAiAgent
    {
        public override string AGENT_ID => "AdressAgent";

        public AdressAgentAgent(IChatbotService service) : base(service)
        {
        }

        private CSGenioAaddre addre;
        
        private PersistentSupport sp;
        private User user;
        private string module; 


        public void LoadRecords(string key, PersistentSupport sp, User user)
        {
            //Base area
            var area = CSGenioAaddre.search(sp, key, user, new string[] {
            });
            LoadRecords(area, sp, user);
        }

        public override void LoadRecords(DbArea area, PersistentSupport sp, User user)
        {
            this.sp = sp;
            this.user = user;
            this.module = user.CurrentModule;

            addre = (CSGenioAaddre) area;

            // Areas dependent on base table

        }

        public override string BuildUserPrompt()
        {
                return
                $"\n";
        }

        public override string BuildSystemPrompt()
        {
                return
                $"Instruction Prompt\n";
        }

        public override void Execute(DbArea area, PersistentSupport sp, User user)
        {
            LoadRecords(area, sp, user);

            AdressAgentResponse response = base.GetResponse<AdressAgentResponse>(user);
            if (response == null)
                throw new FrameworkException("Answer from AI service was empty", "AdressAgentAgent.Execute", "Answer from AI service was empty");
            
            MapResponse(response);
        }




        public override object JsonSchema => new
        {

            type = "object",
            required = new[] { },
            properties = new
            {
            }
        };


        protected void MapResponse(AdressAgentResponse response)
        {
        }

        public override void PersistRecord(PersistentSupport sp)
        {
            addre.apply(sp);
        }

    }

    public class AdressAgentResponse
    {             
    }


}

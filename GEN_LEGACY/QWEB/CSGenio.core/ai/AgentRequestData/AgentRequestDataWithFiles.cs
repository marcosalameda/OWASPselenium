using CSGenio.business;
using System.Collections.Generic;

public class AgentRequestDataWithFiles : AgentRequestData
{
    public List<DBFile> Files { get; set; } 

    public AgentRequestDataWithFiles(object jsonSchema, string prompt, string systemPrompt, string project, List<DBFile> files = null) :
                    base(jsonSchema, prompt, systemPrompt, project)
    {
        Files = files;
    }
}
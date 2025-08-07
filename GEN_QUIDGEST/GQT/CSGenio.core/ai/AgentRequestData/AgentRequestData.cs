public class AgentRequestData
{
    public object JsonSchema { get; set; }
    public string Prompt { get; set; }
    public string SystemPrompt { get; set; }
    public string Project { get; set; }

    public AgentRequestData(object jsonSchema, string prompt, string systemPrompt, string project)
    {
        JsonSchema = jsonSchema;
        Prompt = prompt;
        SystemPrompt = systemPrompt;
        Project = project;
    }
}
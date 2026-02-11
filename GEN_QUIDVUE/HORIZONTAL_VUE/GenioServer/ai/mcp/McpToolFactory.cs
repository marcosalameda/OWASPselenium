

using CSGenio.core.ai;
using CSGenio.framework;

public class McpToolFactory  {

    public static McpToolRepo AllGenioTools() {
        var repo = new McpToolRepo();
        //Tools for application HORIZONTAL_VUE
        repo.RegisterTool(new DeleteCompanyTool());
        repo.RegisterTool(new CreateCompanyTool());
        repo.RegisterTool(new ChangeCountryNameTool());
        repo.RegisterTool(new ListAllCountriesTool());
        return repo;
    }

}
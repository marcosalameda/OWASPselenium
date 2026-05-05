
using CSGenio.framework;
using System.Collections.Generic;
using System.Linq;

namespace Administration.Models
{
    public class ModuleRoleModel : ModelBase
    {
        public string Module { get;  set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }

        public static bool IsInModule(Role role, string module)
        {
            return ALL_MODULE_ROLES.Any(mr => mr.Role == role.Id && mr.Module == module);
        }

        public static ModuleRoleModel GetRole(string module, string role, int level = 0)
        {
            //If the role is empty get the level. This means it was set by backoffice
            if (string.IsNullOrEmpty(role))
                role = level.ToString();
            return ALL_MODULE_ROLES.Find(x => x.Module == module && x.Role == role);
        }

        public static List<ModuleRoleModel> ALL_MODULE_ROLES { get; } = new List<ModuleRoleModel>()
        {
            new ModuleRoleModel() {
                Role = "ADMINISTRATOR",
                Designation = "ADMINISTRATOR54799",
                Description = "",              
                Module = "STY"
            },
            new ModuleRoleModel() {
                Role = "ADMINISTRATOR",
                Designation = "ADMINISTRATOR54799",
                Description = "",              
                Module = "GQT"
            },
            new ModuleRoleModel() {
                Role = "ADMINISTRATOR",
                Designation = "ADMINISTRATOR54799",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "ADMINISTRATOR",
                Designation = "ADMINISTRATOR54799",
                Description = "",              
                Module = "UIS"
            },
            new ModuleRoleModel() {
                Role = "ADMINISTRATOR",
                Designation = "ADMINISTRATOR54799",
                Description = "",              
                Module = "TBS"
            },
            new ModuleRoleModel() {
                Role = "ADMINISTRATOR",
                Designation = "ADMINISTRATOR54799",
                Description = "",              
                Module = "PTN"
            },
            new ModuleRoleModel() {
                Role = "ADMINISTRATOR",
                Designation = "ADMINISTRATOR54799",
                Description = "",              
                Module = "REG"
            },
            new ModuleRoleModel() {
                Role = "ADMINISTRATOR",
                Designation = "ADMINISTRATOR54799",
                Description = "",              
                Module = "IMO"
            },
            new ModuleRoleModel() {
                Role = "EDIT",
                Designation = "EDIT07023",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "EDIT",
                Designation = "EDIT07023",
                Description = "",              
                Module = "STY"
            },
            new ModuleRoleModel() {
                Role = "EDIT",
                Designation = "EDIT07023",
                Description = "",              
                Module = "GQT"
            },
            new ModuleRoleModel() {
                Role = "EDIT",
                Designation = "EDIT07023",
                Description = "",              
                Module = "PTN"
            },
            new ModuleRoleModel() {
                Role = "EDIT_PESSO",
                Designation = "EDITOR_RECURSOS23553",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "EDIT_PESSO",
                Designation = "EDITOR_RECURSOS23553",
                Description = "",              
                Module = "PTN"
            },
            new ModuleRoleModel() {
                Role = "EMPLOYEE",
                Designation = "EMPLOYEE08184",
                Description = "",              
                Module = "REG"
            },
            new ModuleRoleModel() {
                Role = "MANAGER",
                Designation = "MANAGER18024",
                Description = "",              
                Module = "TBS"
            },
            new ModuleRoleModel() {
                Role = "MANAGER",
                Designation = "MANAGER18024",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "MANAGER",
                Designation = "MANAGER18024",
                Description = "",              
                Module = "IMO"
            },
            new ModuleRoleModel() {
                Role = "MANAGER",
                Designation = "MANAGER18024",
                Description = "",              
                Module = "PTN"
            },
            new ModuleRoleModel() {
                Role = "SYSADMIN",
                Designation = "SYSADMIN53289",
                Description = "",              
                Module = "TBS"
            },
            new ModuleRoleModel() {
                Role = "SYSADMIN",
                Designation = "SYSADMIN53289",
                Description = "",              
                Module = "PTN"
            },
            new ModuleRoleModel() {
                Role = "SYSADMIN",
                Designation = "SYSADMIN53289",
                Description = "",              
                Module = "GQT"
            },
            new ModuleRoleModel() {
                Role = "SYSADMIN",
                Designation = "SYSADMIN53289",
                Description = "",              
                Module = "IMO"
            },
            new ModuleRoleModel() {
                Role = "SYSADMIN",
                Designation = "SYSADMIN53289",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "SYSADMIN",
                Designation = "SYSADMIN53289",
                Description = "",              
                Module = "REG"
            },
            new ModuleRoleModel() {
                Role = "SYSADMIN",
                Designation = "SYSADMIN53289",
                Description = "",              
                Module = "STY"
            },
            new ModuleRoleModel() {
                Role = "SYSADMIN",
                Designation = "SYSADMIN53289",
                Description = "",              
                Module = "UIS"
            },
            new ModuleRoleModel() {
                Role = "VIEW",
                Designation = "VIEW37934",
                Description = "",              
                Module = "GQT"
            },
            new ModuleRoleModel() {
                Role = "VIEW_PESSO",
                Designation = "EDITOR_RECURSOS23553",
                Description = "",              
                Module = "PTN"
            },
            new ModuleRoleModel() {
                Role = "VIEW_PESSO",
                Designation = "EDITOR_RECURSOS23553",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "1",
                Designation = "QUERY30986",
                Description = "",              
                Module = "REG"
            },
            new ModuleRoleModel() {
                Role = "1",
                Designation = "QUERY30986",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "1",
                Designation = "QUERY30986",
                Description = "",              
                Module = "TBS"
            },
            new ModuleRoleModel() {
                Role = "1",
                Designation = "QUERY30986",
                Description = "",              
                Module = "IMO"
            },
            new ModuleRoleModel() {
                Role = "1",
                Designation = "QUERY30986",
                Description = "",              
                Module = "GQT"
            },
            new ModuleRoleModel() {
                Role = "1",
                Designation = "QUERY30986",
                Description = "",              
                Module = "UIS"
            },
            new ModuleRoleModel() {
                Role = "1",
                Designation = "QUERY30986",
                Description = "",              
                Module = "PTN"
            },
            new ModuleRoleModel() {
                Role = "1",
                Designation = "QUERY30986",
                Description = "",              
                Module = "STY"
            },
            new ModuleRoleModel() {
                Role = "2",
                Designation = "VENDEDOR34177",
                Description = "",              
                Module = "GQT"
            },
            new ModuleRoleModel() {
                Role = "3",
                Designation = "OFFICER20358",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "4",
                Designation = "AGENT00994",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "20",
                Designation = "MANAGER60821",
                Description = "",              
                Module = "WMS"
            },
            new ModuleRoleModel() {
                Role = "20",
                Designation = "MANAGER60821",
                Description = "",              
                Module = "IMO"
            },
            new ModuleRoleModel() {
                Role = "20",
                Designation = "MANAGER60821",
                Description = "",              
                Module = "GQT"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "IMO"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "REG"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "TRN"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "PTN"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "TBS"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "UIS"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "GQT"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "WMS"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "XRS"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRATOR27313",
                Description = "",              
                Module = "STY"
            }
        };
    }
}
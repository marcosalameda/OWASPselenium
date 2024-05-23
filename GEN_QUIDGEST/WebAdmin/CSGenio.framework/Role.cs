using System;
using System.Collections.Generic;
using System.Linq;

namespace CSGenio.framework
{

    public enum RoleType {
        LEVEL,
        ROLE, 
        SYSTEM   
    }

	public class Role 
	{
		//Access Levels
        public static readonly Role UNAUTHORIZED;
        public static readonly Role ADMINISTRATION;
        public static readonly Role AUTHORIZED;
        public static readonly Role INVALID;
        
        public static readonly Role ROLE_1; //Query
        public static readonly Role ROLE_2; //Vendedor
        public static readonly Role ROLE_20; //Manager
        //Roles
		public static readonly Role ROLE_A; //Authorizer
		public static readonly Role ROLE_ADMINISTRATOR; //ADMINISTRATOR
		public static readonly Role ROLE_EDIT; //EDIT
		public static readonly Role ROLE_EDIT_PESSO; //Editor dados pessoais
		public static readonly Role ROLE_EMPLOYEE; //EMPLOYEE
		public static readonly Role ROLE_MANAGER; //MANAGER
		public static readonly Role ROLE_SYSADMIN; //SYSADMIN
		public static readonly Role ROLE_VIEW; //VIEW
		public static readonly Role ROLE_VIEW_PESSO; //Consulta dados pessoais

        public static readonly Dictionary<string, Role> ALL_ROLES = new Dictionary<string, Role>();

		private readonly List<Role> directSubRoles;
        private List<Role> allSubRoles;
        private readonly LevelAccess level;
    
        public RoleType Type
        {
            get;
        }
 
        public List<string> AvaiableModules
        {
            get; private set;
        }

		public Role(RoleType type, string title, params Role[] subRoles)
        {
            directSubRoles = new List<Role>(subRoles);
            Type = type;
			Title = title;
        }

        public Role(LevelAccess level, string title, params Role[] subRoles)
        {
            directSubRoles = new List<Role>(subRoles);
            Type = RoleType.LEVEL;
            this.level = level;
			Title = title;
        }

		static Role()
		{
            //Hardcoded role to represent admin priviliges
            ADMINISTRATION = new Role(RoleType.SYSTEM, "ADMINISTRADOR57294");
            //Hardcoded role to represent unauthorized access. This can also be interpreted as the public access
            UNAUTHORIZED = new Role(RoleType.SYSTEM, "DESAUTORIZADO34584");
            //A role that is below every role except unauthorized. Used when no role was definied in an item.
            AUTHORIZED = new Role(RoleType.SYSTEM, "AUTORIZADO16093"); 
            //Represents an invalid role
            INVALID = new Role(RoleType.SYSTEM, "INVALID40876");

            //Create all roles
            ROLE_A = new Role(RoleType.ROLE, "AUTHORIZER35432");
            ALL_ROLES.Add("A", ROLE_A);

            ROLE_ADMINISTRATOR = new Role(RoleType.ROLE, "ADMINISTRATOR54799");
            ALL_ROLES.Add("ADMINISTRATOR", ROLE_ADMINISTRATOR);

            ROLE_EDIT = new Role(RoleType.ROLE, "EDIT07023");
            ALL_ROLES.Add("EDIT", ROLE_EDIT);

            ROLE_EDIT_PESSO = new Role(RoleType.ROLE, "EDITOR_DADOS_PESSOAI56223");
            ALL_ROLES.Add("EDIT_PESSO", ROLE_EDIT_PESSO);

            ROLE_EMPLOYEE = new Role(RoleType.ROLE, "EMPLOYEE08184");
            ALL_ROLES.Add("EMPLOYEE", ROLE_EMPLOYEE);

            ROLE_MANAGER = new Role(RoleType.ROLE, "MANAGER18024");
            ALL_ROLES.Add("MANAGER", ROLE_MANAGER);

            ROLE_SYSADMIN = new Role(RoleType.ROLE, "SYSADMIN53289");
            ALL_ROLES.Add("SYSADMIN", ROLE_SYSADMIN);

            ROLE_VIEW = new Role(RoleType.ROLE, "VIEW37934");
            ALL_ROLES.Add("VIEW", ROLE_VIEW);

            ROLE_VIEW_PESSO = new Role(RoleType.ROLE, "CONSULTA_DADOS_PESSO62240");
            ALL_ROLES.Add("VIEW_PESSO", ROLE_VIEW_PESSO);

            ROLE_1 = new Role(LevelAccess.NV1, "QUERY30986");
            ALL_ROLES.Add("1", ROLE_1);

            ROLE_2 = new Role(LevelAccess.NV2, "VENDEDOR34177");
            ALL_ROLES.Add("2", ROLE_2);

            ROLE_20 = new Role(LevelAccess.NV20, "MANAGER60821");
            ALL_ROLES.Add("20", ROLE_20);

            //This roles are hardcoded and have these values for backwards compatibility reasons
            ALL_ROLES.Add("0",  UNAUTHORIZED);
            ALL_ROLES.Add("99",  ADMINISTRATION);
            ALL_ROLES.Add("SYSTEM_AUTHORIZED", AUTHORIZED);

            //Add subroles
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         
			ROLE_A.Add(ADMINISTRATION);         
			ROLE_A.Add(ROLE_20);         

			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         
			ROLE_ADMINISTRATOR.Add(ROLE_SYSADMIN);         

			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT.Add(ROLE_MANAGER);         
			ROLE_EDIT.Add(ROLE_SYSADMIN);         
			ROLE_EDIT.Add(ROLE_ADMINISTRATOR);         

			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         
			ROLE_EDIT_PESSO.Add(ROLE_20);         
			ROLE_EDIT_PESSO.Add(ROLE_ADMINISTRATOR);         

			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         
			ROLE_EMPLOYEE.Add(ROLE_MANAGER);         

			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         
			ROLE_MANAGER.Add(ROLE_ADMINISTRATOR);         


			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW.Add(ROLE_EDIT);         
			ROLE_VIEW.Add(ROLE_EMPLOYEE);         

			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         
			ROLE_VIEW_PESSO.Add(ROLE_EDIT_PESSO);         
			ROLE_VIEW_PESSO.Add(ROLE_1);         
			ROLE_VIEW_PESSO.Add(ROLE_EMPLOYEE);         


			UNAUTHORIZED.Add(ROLE_1);
			UNAUTHORIZED.Add(ROLE_2);
			UNAUTHORIZED.Add(ROLE_20);
			UNAUTHORIZED.Add(ADMINISTRATION);
			ROLE_1.Add(ROLE_2);
			ROLE_1.Add(ROLE_20);
			ROLE_1.Add(ADMINISTRATION);
			ROLE_2.Add(ROLE_20);
			ROLE_2.Add(ADMINISTRATION);
			ROLE_20.Add(ADMINISTRATION);
			foreach(Role role in ALL_ROLES.Values)
				role.FlattenRole();
        }
		
		private void FlattenRole()
        {
            if (allSubRoles == null)
            {
                allSubRoles = new List<Role>();
                allSubRoles.Add(this);

                foreach (Role child in directSubRoles)
                {
                    allSubRoles.Add(child);

                    if (child.Type == RoleType.LEVEL)
                        continue;

                    child.FlattenRole();
                    allSubRoles.AddRange(child.allSubRoles.Where(x => !allSubRoles.Contains(x)));
                }
            }
        }

        private void Add(Role role)
        {
            directSubRoles.Add(role);
        }

        public string Id
        {
            get
            {
                return ALL_ROLES.First(p=>p.Value == this).Key;
            }
        }
		
		public string Title { get; private set; }

        public bool IsAdmin
        {
            get { return ADMINISTRATION.HasRole(this); }
        }

        /// <summary>
        /// Returns a list of all roles that have permissions to do whatever this role can. It includes the role itself.
        /// </summary>
        public List<Role> AllRolesAbove()
        {
            return allSubRoles;
        }
		
		/// <summary>
        /// Returns a list of all roles below this role. It includes the role itself.
        /// </summary>
        public List<Role> AllRolesBelow()
        {
            IEnumerable<Role> rolesBelow = (from Role role in ALL_ROLES.Values
                                     where role.directSubRoles.Contains(this)
                                     select role).ToList();

            List<Role> allRolesBelow = new List<Role>(rolesBelow);

            // Recursive
            foreach (var role in rolesBelow)
                foreach(Role roleBelow in role.AllRolesBelow())
                    if (!allRolesBelow.Contains(roleBelow))
                        allRolesBelow.Add(roleBelow);

            // Add the role itself
            if (!allRolesBelow.Contains(this))
                allRolesBelow.Add(this);
            
            return allRolesBelow;
        }

        /// <summary>
        /// Checks if role @other is in the hierarchy above this role. 
        /// For example ROLE_3.HasRole(ROLE_4) should return true
        /// </summary>
		public bool HasRole(Role other)
        {
            //First check system roles            
            if (this == INVALID || other == INVALID)//Check invalid roles
                return false; 
            else if (this == UNAUTHORIZED) //Unauthorized is below everything            
                return true;            
            else if(this == AUTHORIZED) //Authorized is below everything except Unauthorized
                return other != UNAUTHORIZED;
            else if(other == ADMINISTRATION && this.Type != RoleType.ROLE) //Administration is above all levels
                return true; 

            return this.allSubRoles.Contains(other);
        }

        public bool HasRole(string other)
        {
            Role otherRole = GetRole(other);
            return HasRole(otherRole);
        }

        public bool HasLevel(LevelAccess levelAccess)
        {
            return this.allSubRoles.Contains(GetRole(levelAccess));
        }	

        public int GetLevelInt()
        {
            if (Type == RoleType.LEVEL)
                return level.LevelValue;
            else if (this == Role.ADMINISTRATION)
                return 99;
            else if (this == Role.UNAUTHORIZED)
                return 0;
            else
                throw new InvalidOperationException();
        }

        
        public static Role GetRole(LevelAccess levelAccess)
        {
            return ALL_ROLES.Values.First(x => x.level == levelAccess);
        }	

        /// <summary>
        /// Returns a role with the specified id. If it doesn't exist returns UNAUTHORIZED role
        /// </summary>
        public static Role GetRole(string roleId)
        {
            if (ALL_ROLES.TryGetValue(roleId?.Trim(), out Role result))
                return result;

            if(!String.IsNullOrEmpty(roleId))
                Log.Error($"Trying to get an unexisting role:{roleId}");
            return INVALID;
        }

        /// <summary>
        /// Returns the role ID
        /// </summary>
        public override string ToString()
        {
            return this.Id;
        }
	}
}

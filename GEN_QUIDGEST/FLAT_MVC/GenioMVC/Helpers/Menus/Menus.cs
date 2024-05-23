using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using CSGenio.framework;
using System.Linq.Expressions;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace GenioMVC.Helpers.Menus
{

    public class UserAvatarMenu
    {
        /// <summary>
        /// Action triggered in the controller
        /// </summary>
        public string Action { set; get; }

        /// <summary>
        /// Controller where to invoke the action
        /// </summary>
        public string Controller { set; get; }

        /// <summary>
        /// ID of the record to pass to the action
        /// </summary>
        public string RecordID { set; get; }

        /// <summary>
        /// Title/description to display
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// CSS class for the displayed icon
        /// </summary>
        public string Font { set; get; }

        /// <summary>
        /// Image to display
        /// </summary>
        public string Image { set; get; }

        /// <summary>
        /// Retrieve from MANWIN a list of UserAvatarMenu items.
        /// </summary>
        /// <param name="sp">Persisent support for DB access</param>
        /// <param name="user">Current user</param>
        /// <returns>List with positioned UserAvatarMenu items</returns>
        public static List<UserAvatarMenu> GetMenus(PersistentSupport sp, User user)
        {
            List<UserAvatarMenu> result = new List<UserAvatarMenu>();

            // Specify custom items to show on user avatar menu.
            // result.Add(new UserAvatarMenu {
            //    Action = "",
            //    Controller = "",
            //    RecordID = "",
            //    Title = "",
            //    Font = "",
            //    Image = ""
            // });
// USE /[MANUAL GQT USER_AVATAR_MENU]/

            return result;
        }
    }

    /// <summary>
    /// User avatar menu item that comes from a MenuEntry and an EPH
    /// Created by [TMV] (2020.09.23)
    /// Refactored by [JMN] (2021.01.22)
    /// </summary>
    public class EPHUserAvatarMenu : UserAvatarMenu
    {
        /// <summary>
        /// ID of the associated MenuEntry
        /// </summary>
        public string MenuID { set; get; }

        public EPHUserAvatarMenu(MenuEntry other)
        {
            Title = other.Title;
            Action = other.Children.FirstOrDefault().Action_MVC;
            Controller = other.Children.FirstOrDefault().Controller;
            MenuID = other.ID;
            Font = other.Font;
            Image = other.Image;
        }

        /// <summary>
        /// Retrieve User Avatar items from EPH form menus.
        /// EPH takes into account the current user and module.
        /// </summary>
        public static List<EPHUserAvatarMenu> GetMenus()
        {
            List<EPHUserAvatarMenu> result = new List<EPHUserAvatarMenu>();
            try
            {
                User user = UserContext.Current.User;

                List<string> forms = EPH.GetEphCurrentForm(user);
                string modulo = user.CurrentModule;

                foreach (string form in forms.Distinct())
                {
                    try
                    {
                        string id = form;
                        MenuEntry menu = null;

                        //search the root menu for the dbedit
                        while (!String.IsNullOrEmpty(id))
                        {
                            menu = Menus.FindMenu(modulo, id);

                            if (String.IsNullOrEmpty(menu.Controller))
                                break;

                            id = menu.ParentId;
                        }

                        result.Add(new EPHUserAvatarMenu(menu));
                    }
                    catch (System.Exception e)
                    {
                        CSGenio.framework.Log.Error("Error creating EPH avatar menu for the menu " + forms + e.Message);
                    }
                }
            }
            catch (System.Exception e)
            {
                CSGenio.framework.Log.Error("Unexpected error retrieving EPH avatar menus" + e.Message);
            }

            return result;
        }
    }


    /// <summary>
    /// Classe auxiliar to receber a àrvore de menus serializada em Xml pela API de geração
    /// Representa uma entrada de menu
    /// </summary>
    [XmlRoot("MENU")]
    public class MenuEntry
    {
        /// <summary>
        /// Supreme Administrator
        /// </summary>
        private const int MAX_LEVEL = 99;

        /// <summary>
        /// Type de menu
        /// ITEM - Item normal de menu
        /// LIST - Listing dos elementos de uma table
        /// REPORT - Relatório
        /// </summary>
        [XmlAttribute("TYPE")]
        [Newtonsoft.Json.JsonProperty("Type", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Descrição que o user vê associada a esta entrada de menu
        /// </summary>
        [XmlAttribute("DESC")]
        [Newtonsoft.Json.JsonProperty("Title", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Sigla que o user vê associada a esta entrada de menu
        /// </summary>
        [XmlAttribute("SIGLA")]
        [Newtonsoft.Json.JsonProperty("Sigla", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Sigla { get; set; }

        /// <summary>
        /// ID do módulo / entrada de menu
        /// </summary>
        [XmlAttribute("ID")]
        [Newtonsoft.Json.JsonProperty("Id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ID { get; set; }

        /// <summary>
        /// ID do módulo / entrada de menu anterior
        /// </summary>
        [XmlAttribute("PRTID")]
        [Newtonsoft.Json.JsonIgnore]
        public string ParentId { get; set; }

        /// <summary>
        /// Nível de acesso necessário to poder aceder a este menu
        /// </summary>
        [XmlElement("ACCESS")]
        [Newtonsoft.Json.JsonIgnore]
        public string RoleId { get; set; }

        /// <summary>
        /// Documento ou página externa a abrir
        /// </summary>
        [XmlAttribute("WEBPAGE")]
        [Newtonsoft.Json.JsonProperty("WebPage", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WEBPAGE { get; set; }

        /// <summary>
        /// text do bullet
        /// </summary>
        [XmlAttribute("HELPTITLE")]
        [Newtonsoft.Json.JsonProperty("HelpTitle", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HELPTITLE { get; set; }

        /// <summary>
        /// Imagem associada a esta entrada de menu
        /// </summary>
        [XmlAttribute("IMG")]
        [Newtonsoft.Json.JsonProperty("Image", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Image { get; set; }

        /// <summary>
        /// Imagem associada a esta entrada de menu(VUE)
        /// </summary>
        [XmlAttribute("IMGVUE")]
        [Newtonsoft.Json.JsonProperty("ImageVUE", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ImageVUE { get; set; }

        /// <summary>
        /// Fonte (icon) associada a esta entrada de menu
        /// </summary>
        [XmlAttribute("FNT")]
        [Newtonsoft.Json.JsonProperty("Font", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Font { get; set; }

        /// <summary>
        /// Vector (icon) associada a esta entrada de menu
        /// </summary>
        [XmlAttribute("SVG")]
        [Newtonsoft.Json.JsonProperty("Vector", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Vector { get; set; }

        /// <summary>
        /// Menu to open after clicking the parent menu 
        /// </summary>
        [XmlAttribute("OPENDEFAULT")]
        [Newtonsoft.Json.JsonProperty("OpenDefault", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool OpenDefault { get; set; }

        /// <summary>
        /// Acção desencadeada por esta entrada de menu
        /// </summary>
        [XmlAttribute("ACT")]
        [Newtonsoft.Json.JsonProperty("Action", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Action { get; set; }

        /// <summary>
        /// Acção desencadeada por esta entrada de menu(VUE)
        /// </summary>
        [XmlAttribute("ACTVUE")]
        [Newtonsoft.Json.JsonProperty("RouteName", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Route_VUE { get; set; }

        #region MVC Specific parameters

        /// <summary>
        /// Acção desencadada no lado do MVC por esta entrada de menu
        /// </summary>
        [XmlAttribute("ACTMVC")]
        [Newtonsoft.Json.JsonProperty("ActionMVC", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Action_MVC { get; set; }

        /// <summary>
        /// Controller invocado na acção desencadeada por esta entrada de menu
        /// </summary>
        [XmlAttribute("CONT")]
        [Newtonsoft.Json.JsonProperty("Controller", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Controller { get; set; }

        /// <summary>
        /// Filters for this action
        /// </summary>
        [XmlElement("FILTERS")]
        [Newtonsoft.Json.JsonIgnore]
        public string Filters { get; set; }

        /// <summary>
        /// QueryString for this action
        /// </summary>
        [XmlAttribute("QUERYSTRING")]
        [Newtonsoft.Json.JsonIgnore]
        public string QueryString { get; set; }

        #endregion

        /// <summary>
        /// Nível deste menu na àrvore, o nível associado aos módulos é o nível 0
        /// </summary>
        [XmlAttribute("LVL")]
        [Newtonsoft.Json.JsonProperty("TreeLevel", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TreeLevel { get; set; }

        /// <summary>
        /// Indica se o relatório deve ser pré-visualizado
        /// </summary>
        [XmlAttribute("PREVIEW")]
        [Newtonsoft.Json.JsonProperty("Preview", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Preview { get; set; }

        /// <summary>
        /// Indica se o menu tem um separador (visual)
        /// </summary>
        [XmlAttribute("SEPARATES")]
        [Newtonsoft.Json.JsonProperty("Separates", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Separates { get; set; }

        /// <summary>
        /// Filhos deste menu
        /// </summary>
        [XmlElement("MENU")]
        [Newtonsoft.Json.JsonProperty("Children", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<MenuEntry> Children { get; set; }

		/// <summary>
        /// Se ativo soma os elementos deste DbEdit/menu
        /// </summary>
        [XmlAttribute("SUMMENU")]
        [Newtonsoft.Json.JsonIgnore]
        public bool SumMenu { get; set; }

        /// <summary>
        /// Se ativo significa que o menu tem condições
        /// </summary>
        [XmlAttribute("HASCONDITION")]
        [Newtonsoft.Json.JsonIgnore]
        public bool HasCondition { get; set; }

        /// <summary>
        /// Se ativo, significa que menu tem continuação para form
        /// </summary>
        [XmlAttribute("ISFORM")]
        [Newtonsoft.Json.JsonProperty("IsForm", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsForm { get; set; }

        /// <summary>
        /// Modo de entrada
        /// </summary>
        [XmlAttribute("FORMMODE")]
        [Newtonsoft.Json.JsonProperty("Mode", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Mode { get; set; }

        /// <summary>
        /// The menu order
        /// </summary>
        [XmlAttribute("ORDER")]
        [Newtonsoft.Json.JsonProperty("Order", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Order { get; set; }

        /// <summary>
        /// Contador desta lista presente neste menu
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Count", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Count { get; set; }

        public MenuEntry(MenuEntry other)
        {
            Type = other.Type;
            Title = other.Title;
            Sigla = other.Sigla;
            ID = other.ID;
            RoleId = other.RoleId; // este copia o apontador, deve ser irrelevante!
            Image = other.Image;
            ImageVUE = other.ImageVUE;
            Font = other.Font;
            Action = other.Action;
            Vector = other.Vector;
            Route_VUE = other.Route_VUE;
            TreeLevel = other.TreeLevel;
            // não copia os filhos, para efeitos do algoritmo de reconstrução da árvore de menus
            // ignorar o Children é propositado
            Children = new List<MenuEntry>();
            WEBPAGE = other.WEBPAGE;
            HELPTITLE = other.HELPTITLE;
            Action_MVC = other.Action_MVC;
            Controller = other.Controller;
            Filters = other.Filters;
            QueryString = other.QueryString;

            Preview = other.Preview;
            Separates = other.Separates;
            SumMenu = other.SumMenu;
            HasCondition = other.HasCondition;
            IsForm = other.IsForm;
            Mode = other.Mode;
            Order = other.Order;
            OpenDefault = other.OpenDefault;
        }

        // construtor vazio para permitir (des)serializar em format XML
        public MenuEntry() { }

        /// <summary>
        /// Checks if a user has access to view a menu entry
        /// </summary>
        /// <param name="user">User we want to check</param>
        /// <param name="module">Module the entry is in</param>
        /// <returns></returns>
        public bool Allows(User user, string module)
        {
            //use the full qualified name to prevent problems with tables with name ROLE
            CSGenio.framework.Role role = CSGenio.framework.Role.GetRole(RoleId);
            //JGF 2021.11.17 When there is no role assigned every role is allowed.
            if (role.Equals(CSGenio.framework.Role.INVALID))
                return true;
            return user.VerifyAccess(role, module);
        }
    }

    public class Menus
    {
        public static List<MenuEntry> AllMenus {
            get
            {
                if (m_allMenus == null)
                {
                    m_allMenus = LoadMenuXml(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "menus.xml"));
                }

                return m_allMenus;
            }
        }

        public static MenuEntry FindMenu(string module, string menuID)
        {
            string findKey = module + menuID;
            if(m_flatMenus == null )
            {
                m_flatMenus = new Dictionary<string, MenuEntry>();
                foreach(var moduleEntry in AllMenus)
                {
                    var menus = FlattenMenu(moduleEntry);
                    foreach(var entry in menus)
                    {
                        string key = moduleEntry.ID + entry.ID;
                        m_flatMenus[key] = entry;
                    }
                }
            }
            return m_flatMenus[findKey];
        }

        public static MenuEntry FindMenuActionName(string module, string menuID)
        {
            string findKey = module + menuID;
            if (m_flatMenusActionName == null)
            {
                m_flatMenusActionName = new Dictionary<string, MenuEntry>();
                foreach (var moduleEntry in AllMenus)
                {
                    var menus = FlattenMenu(moduleEntry);
                    foreach (var entry in menus)
                    {
                        string key = moduleEntry.ID + entry.Action_MVC;
                        m_flatMenusActionName[key] = entry;
                    }
                }
            }
            return m_flatMenusActionName[findKey];
        }

        private static List<MenuEntry> FlattenMenu(MenuEntry entry)
        {
            List<MenuEntry> menuList = new List<MenuEntry>();
            menuList.Add(entry);
            foreach(var child in entry.Children)
            {
                menuList.AddRange(FlattenMenu(child));
            }
            return menuList;
        }



        private static Dictionary<string, MenuEntry> m_flatMenus = null;

        private static Dictionary<string, MenuEntry> m_flatMenusActionName = null;

        /// <summary>
        /// Deserializes a list of menu entries contained in a xml file
        /// </summary>
        /// <param name="filePath">Path to the xml file</param>
        /// <returns></returns>
        public static List<MenuEntry> LoadMenuXml(string fileLocation)
        {
            List<MenuEntry> entries;
            XmlSerializer s = new XmlSerializer(typeof(List<MenuEntry>));
            using (StreamReader r = new StreamReader(fileLocation, Encoding.UTF8))
            {
                entries = s.Deserialize(r) as List<MenuEntry>;
            }
            return entries;
        }

        private static List<MenuEntry> m_allMenus = null;

        public static List<MenuEntry> MenusForUser(User user)
        {
            List<MenuEntry> result = new List<MenuEntry>();

            foreach (MenuEntry mod in AllMenus)
            {

                var module = mod.ID;

                List<MenuEntry> modMenus = MenusForUserRec(user, mod.Children, module);

                // só se o módulo tiver entradas de menu é que se adiciona às entradas de módulos
                if (modMenus.Count > 0)
                {
                    MenuEntry thisMod = new MenuEntry(mod);
                    thisMod.Children = modMenus;
                    result.Add(thisMod);
                }

            }

            return result;
        }

        public static List<MenuEntry> AvailableModules(User user)
        {
            List<MenuEntry> result = new List<MenuEntry>();

            foreach (MenuEntry mod in AllMenus)
            {
                List<MenuEntry> modMenus = MenusForUserRec(user, mod.Children, mod.ID);

                // só se o módulo tiver entradas de menu é que se adiciona às entradas de módulos
                foreach (var item in modMenus)
                {
                    if (item.Allows(user, mod.ID))
                    {
                        result.Add(mod);
                        break;
                    }
                }
            }

            return result;
        }

        public static List<MenuEntry> GetModuleMenus(User user, string module, bool count = false)
        {
            foreach (MenuEntry mod in AllMenus)
            {
                if (mod.ID != module)
                    continue;
                List<MenuEntry> modMenus = MenusForUserRec(user, mod.Children, mod.ID, count);

                return modMenus;
            }

            return new List<MenuEntry>();
        }

        public static List<MenuEntry> MenusForModule(User user, MenuEntry module, bool count = false)
        {
            return MenusForUserRec(user, module.Children, module.ID, count);
        }

        private static List<MenuEntry> MenusForUserRec(User user, List<MenuEntry> menus, String module, bool count = false)
        {
            List<MenuEntry> result = new List<MenuEntry>();

            foreach (MenuEntry entry in menus)
            {
                MenuEntry menu = new MenuEntry(entry);
                // se o o user tem nível de acesso adicionam-se os filhos tratados
                if ((menu.TreeLevel > -1 && menu.Allows(user, module)) || menu.TreeLevel == -1)
                {
                    if (menu.HasCondition)
                    {
                        if (!Menus.ValidateCondition(UserContext.Current, menu))
                            continue;
                    }

                    menu.Children = MenusForUserRec(user, entry.Children, module, count);
                    if (entry.Children.Count == 1)
                    {
                        MenuEntry child = entry.Children.First();

                        if (child.Type == "LIST")
                            menu.Children = entry.Children;
                        else if (!String.IsNullOrEmpty(child.Action) && child.TreeLevel == -1)
                        {
                            menu.Count = menu.Children.Select(x => x.Count).ToArray().Sum();

                            menu.Type = child.Type;
                            menu.Preview = child.Preview;
                            menu.Action = child.Action;
                            menu.Action_MVC = child.Action_MVC;
                            menu.Route_VUE = child.Route_VUE;
                            menu.Controller = child.Controller;
                            menu.WEBPAGE = child.WEBPAGE;
                            menu.QueryString = child.QueryString;
                            menu.IsForm = child.IsForm;
                            menu.Mode = child.Mode;
                            menu.Children = new List<MenuEntry>();
                            // MH - Depois duns testes detetou-se que o presente código executado no caso dos menus "finais" (ex: ... -> MB -> R).
                            // Neste caso, não faz sentido copiar imagem e help. No entanto, podemos copiar caso se o "menu" não o tiver preenchido.
                            if (string.IsNullOrEmpty(menu.Image) && !string.IsNullOrEmpty(child.Image))
                            {
                                menu.Image = child.Image;
                                menu.ImageVUE = child.ImageVUE;
                                menu.Vector = child.Vector;
                            }
                            if (string.IsNullOrEmpty(menu.Font) && !string.IsNullOrEmpty(child.Font))
                                menu.Font = child.Font;
                            if (string.IsNullOrEmpty(menu.HELPTITLE) && !string.IsNullOrEmpty(child.HELPTITLE))
                                menu.HELPTITLE = child.HELPTITLE;

                            //Menu counter of elements to be shown (using reflection)
                            if (count && child.SumMenu && menu.Count == 0)
                            {
                                string viewmodelStr = String.Format("GenioMVC.ViewModels.{0}.{1}_ViewModel", menu.Controller, menu.Action_MVC);
                                var viewmodelType = Type.GetType(viewmodelStr, false, true);
                                object newViewmodel = Activator.CreateInstance(viewmodelType, new object[] { new GenioMVC.Models.Navigation.NavigationContext() });
                                menu.Count = (int)viewmodelType.InvokeMember("GetCount", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, null, newViewmodel, new object[] { user });
                            }
                        }
                    }
                    else
                    {
                        menu.Count = menu.Children.Select(x => x.Count).ToArray().Sum();
                    }

                    if (menu.Controller != null && menu.Action != null && menu.Action_MVC != null || menu.Children.Count > 0)
                        result.Add(menu);
                    //se for uma nova página web também adiciona aos menus
                    else if (menu.Action == "GenGenio.MenuPaginaWeb")
                        result.Add(menu);
                }
            }

            return result;
        }


        /// <summary>
        /// Validate the menu condition
        /// </summary>
        /// <param name="menu">The menu entry object</param>
        /// <param name="module">The module ID</param>
        /// <returns></returns>
        public static bool ValidateCondition(UserContext userContext, MenuEntry menu, string module = "")
        {
            User user = userContext.User;
            string currentModule = (String.IsNullOrEmpty(module) ? user.CurrentModule : module);

            PersistentSupport ps = userContext.PersistentSupport;
            // If the Glob record does not exist, a new one will be created.
            //    For this it's need a previously opened connection
            ps.openConnection();
            CSGenio.business.CSGenioAglob globalConfig = CSGenio.business.CSGenioAglob.searchGlob(ps, user);
            ps.closeConnection();

            //The menu ID must be "Module + ID"
            string menuID = currentModule + menu.ID;

            switch (menuID)
            {
                default:
                    break;
            }

            return false;
        }

        public static List<string> MenuTextPath(string module, string menuID)
        {
            var path = new List<string>();

            var _mId = menuID;
            while (!string.IsNullOrEmpty(_mId))
            {
                MenuEntry menu;
                try
                {
                    menu = FindMenu(module, _mId);
                }
                catch (KeyNotFoundException)
                {
                    // algo de errado no XML ou primeiro menu não existe
                    return new List<string>();
                }

                // ex: SE e SU
                if (string.IsNullOrEmpty(menu.Title))
                {
                    _mId = menu.ParentId;
                    continue;
                }

                path.Add(Helpers.GetTextFromResources(menu.Title));

                _mId = menu.ParentId;
            }

            path.Reverse();
            return path;
        }

        public static List<string> MenuTextPathActionName(string module, string menuActionName)
        {
            var path = new List<string>();
            MenuEntry menu;
            try
            {
                menu = FindMenuActionName(module, menuActionName);
            }
            catch (KeyNotFoundException)
            {
                return new List<string>();
            }

            path = MenuTextPath(module, menu.ParentId);

            return path;
        }
    }
}
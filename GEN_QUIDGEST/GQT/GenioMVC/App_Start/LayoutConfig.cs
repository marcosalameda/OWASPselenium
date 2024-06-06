using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using GenioServer.security;

namespace GenioMVC
{
    public enum LoginStyle
    {
        single_page,
        embeded_page
    }

    public enum LogonPlacement
    {
        in_header,
        in_navmenu
    }

    public enum HeaderPlacement
    {
        in_contentPanel,
        in_menuPanel
    }

    public enum ModulesStyle
    {
        list,
        dropdown,
		collapsible
    }

    public enum MenuAlign
    {
        left,
        right
    }

	public enum HelpStyle
    {
        tooltip,
        popover
    }

    public enum MenuBackgroundColor
    {
        dark,
        light
    }

    public enum MenuBrand
    {
        Image,
        Text
    }

    public enum MenuStyle
    {
        simple_navbar,
        ribbon,
        double_navbar
    }

    public enum UserRegisterStyle
    {
        button,
        hyperlink
    }

    public enum BreadcrumbsContent
    {
        simplified,
        detailed,
        hidden
    }

    public enum DefaultSidebarState
    {   
        opened,
        closed
    }

    public enum RowActionDisplay
    {
        inline,
        dropdown
    }

    public enum ContainerWidth
    {
        whole_page,
        reduced 
    }

    /// <summary>
    /// Classe de Configuração to plataforma C#
    /// </summary>
    public class LayoutConfig
    {
        /*
            XML elements
        */
        [XmlElement("DbEditActionPlacement")]
        public String DbEditActionPlacement { get; set; }
        [XmlElement("DbEditPagerPlacement")]
        public String DbEditPagerPlacement { get; set; }
        [XmlElement("DbEditMultipleActionPlacement")]
        public String DbEditMultipleActionPlacement { get; set; }

        [XmlElement("LogonCenter")]
        public bool LogonCenter { get; set; }
        [XmlElement("LogonTop")]
        public bool LogonTop { get; set; }

        [XmlElement("LoginStyle")]
        public LoginStyle loginStyle { get; set; }
        [XmlElement("LogonPlacement")]
        public LogonPlacement logonPlacement { get; set; }
        [XmlElement("HeaderEnable")]
        public bool HeaderEnable { get; set; }
        [XmlElement("FooterEnable")]
        public bool FooterEnable { get; set; }
        [XmlElement("LogoEnable")]
        public bool LogoEnable { get; set; }
        [XmlElement("BrandIconEnable")]
        public bool BrandIconEnable { get; set; }
        [XmlElement("LoginBrandEnable")]
        public bool LoginBrandEnable { get; set; }
        [XmlElement("MenuStyle")]
        public MenuStyle menuStyle { get; set; }

        [XmlElement("HeaderPlacement")]
        public HeaderPlacement headerPlacement { get; set; }

        [XmlElement("ModulesStyle")]
        public ModulesStyle modulesStyle { get; set; }

        [XmlElement("MenuAlign")]
        public MenuAlign menuAlign { get; set; }

		[XmlElement("HelpStyle")]
        public HelpStyle helpStyle { get; set; }

        [XmlElement("MenuSearchEnable")]
        public bool MenuSearchEnable { get; set; }

        [XmlElement("BookmarkEnable")]
        public bool BookmarkEnable { get; set; }

        [XmlElement("MenuBackgroundColor")]
        public MenuBackgroundColor menuBackgroundColor { get; set; }

        [XmlElement("MenuBrand")]
        public MenuBrand menuBrand { get; set; }

        [XmlElement("UserRegisterStyle")]
        public UserRegisterStyle userRegisterStyle { get; set; }

        [XmlElement("BreadcrumbsContent")]
        public BreadcrumbsContent breadcrumbsContent { get; set; }
		
        [XmlElement("ShowPasswordToggle")]
        public bool showPasswordToggle { get; set; }


        [XmlElement("DefaultSidebarState")]
        public DefaultSidebarState defaultSidebarState { get; set; }


        [XmlElement("ContainerWidth")]
        public ContainerWidth containerWidth { get; set; }

        [XmlElement("RowActionDisplay")]
        public RowActionDisplay rowActionDisplay { get; set; }


        //-----Singleton-----
        private static LayoutConfig layoutConfig;
        public static LayoutConfig config
        {
            get
            {
                if (layoutConfig == null)
                {
                    RegisterLayout();
                }
                return layoutConfig;
            }
        }


        public static void RegisterLayout()
        {
            try
            {
                //ler o file
                string filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "layoutConfig.xml");
                using (System.IO.StreamReader input = new System.IO.StreamReader(filename))
                {
                    System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(LayoutConfig));
                    layoutConfig = (LayoutConfig)s.Deserialize(input);
                }
            }
            catch (Exception ex)
            {
                CSGenio.framework.Log.Error("Error parsing layout config: " + ex.Message);
                layoutConfig = new LayoutConfig();
            }
        }
    }

}

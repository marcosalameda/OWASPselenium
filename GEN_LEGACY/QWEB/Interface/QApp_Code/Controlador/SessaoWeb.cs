using System;
using System.Collections;
using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using CSGenio.framework;
using GenioServer.security;

namespace CSGenio
{
    /// <summary>
    /// Implementação to to a web da interface de comunicação com a sessão
    /// </summary>
    public class SessaoWeb : ISessao
    {
        Page m_page;
        ClientCertificate certificadoCliente;
        
        public SessaoWeb(Page page)
        {
            //inicializa o Logger
            //log4net.Config.XmlConfigurator.Configure();
            m_page = page;
            
            if(HttpContext.Current.Request.ClientCertificate.IsPresent)
                certificadoCliente = new ClientCertificate(HttpContext.Current.Request.ClientCertificate.Certificate, HttpContext.Current.Request.ClientCertificate.Subject);
        }

        public string SessionId
        {
            get { return m_page.Session.SessionID; }
        }

        public User User
        {
            get
            {
                return (User)m_page.Session["utilizador"];
            }
            set
            {
                m_page.Session.Remove("utilizador");
                m_page.Session.Add("utilizador", value);

                GlobalAppSessions.Instance.AddOrUpdate(m_page.Session.SessionID, value.Name, value.Location);
            }
        }

        public Hashtable UltimosLidosInicio
        {
            get
            {
                return (Hashtable)m_page.Session["ultimosLidosInicio"];
            }
            set
            {
                m_page.Session.Remove("ultimosLidosInicio");
                m_page.Session.Add("ultimosLidosInicio", value);
            }
        }

        public Hashtable UltimosLidosFim
        {
            get
            {
                return (Hashtable)m_page.Session["ultimosLidosFim"];
            }
            set
            {
                m_page.Session.Remove("ultimosLidosFim");
                m_page.Session.Add("ultimosLidosFim", value);
            }
        }

        public bool UserIsAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public string UserLogin
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        public bool IsClientCertificatePresent
        {
            get
            {
                return HttpContext.Current.Request.ClientCertificate.IsPresent;
            }
        }

        public ClientCertificate ClientCertificate
        {
            get
            {
                return this.certificadoCliente;
            }
        }

        public string IdentityName
        {
            get
            {
                IIdentity id = HttpContext.Current.User.Identity;
                if (id is WindowsIdentity)
                {
                    return id.Name.Substring(id.Name.LastIndexOf('\\') + 1);
                }
                else
                {
                    return id.Name;
                }
            }
        }

        private bool? m_useAuthenticationTicket;
        public bool UseAuthenticationTicket
        {
            get
            {
                if (m_useAuthenticationTicket == null)
                {
                    System.Configuration.Configuration webconfig = WebConfigurationManager.OpenWebConfiguration(null);
                    SystemWebSectionGroup sysweb = (SystemWebSectionGroup)webconfig.GetSectionGroup("system.web");
                    AuthenticationSection authSection = sysweb.Authentication;
                    m_useAuthenticationTicket = authSection.Mode == System.Web.Configuration.AuthenticationMode.Forms;
                }

                return m_useAuthenticationTicket.Value;
            }
        }

        public bool IsAuthenticationTicketValid()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = null;
            if (authCookie != null)
            {
                try
                {
                    ticket = FormsAuthentication.Decrypt(authCookie.Value);
                }
                catch { }
            }
            return authCookie != null 
                && ticket != null
                && HttpContext.Current.User != null
                && HttpContext.Current.User.Identity.IsAuthenticated
                && ticket.Name == IdentityName;
        }

        public void SetAuthenticationTicket(string userName, string year)
        {
            DateTime now = DateTime.UtcNow;
            int timeout = 2880; //TODO: timeout should come from configuration (in .net4 is FormsAuthentication.Timeout)
            FormsAuthenticationTicket ticket =
              new FormsAuthenticationTicket(
                  1,
                  userName,
                  now,
                  now.AddMinutes(timeout),
                  false,
                  year);

            string hashedTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket);
            cookie.Expires = now.AddMinutes(timeout);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void ClearAuthenticationTicket()
        {
            FormsAuthentication.SignOut();
            if (HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-10);
            }
        }
    }
}

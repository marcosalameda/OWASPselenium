using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;
using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using GenioMVC.Models.Exception;
using GenioMVC.Helpers;
using System.Linq;
using System.Collections.Concurrent;
using GenioServer.security;

namespace GenioMVC.Models.Navigation
{
	/// <summary>
	/// Context aggregator for a user
	/// </summary>
	[Serializable]
	public class UserContext
	{
		private readonly object m_lock = new object();
		/// <summary>
		/// The active navigations
		/// </summary>
		public ConcurrentDictionary<string, NavigationContext> Navigations
		{
			get;
			private set;
		}

        [NonSerialized]
        private PersistentSupport m_suportePersistente;
        public PersistentSupport PersistentSupport
        {
            get {
                if (m_suportePersistente != null)
                {
                    return m_suportePersistente;
                }
                m_suportePersistente =  PersistentSupport.getPersistentSupport(User.Year,User.Name);

                return m_suportePersistente;
            }
        }

		public void SetPersistenceReadOnly(bool readOnly)
        {
			if (m_suportePersistente != null)
			{
				m_suportePersistente.closeConnection();
			}
			m_suportePersistente = PersistentSupport.getPersistentSupport(User.Year, User.Name, null, readOnly);
		}

		private User m_utilizador;
		public User User
		{
			get
			{
				// We only calculate the user once per request thread, so this method can be called multiple times efficiently
				if (m_utilizador != null)
					return m_utilizador;

				//Look into the session if we already established our identity
				string user_identity = HttpContext.Current.Session["user.identity"] as string;
				string guest_identity = SecurityFactory.GetGuest().Identity.Name;

                //If the identity is not in session, then check if we need to autologin the user
                //We also retry autologin if the session previously knew we are a guest user but our http request is signaling as authenticated
                if (user_identity == null || (user_identity == guest_identity && HttpContext.Current.User.Identity.IsAuthenticated))
                {
                    user_identity = AutologinIdentity();
                }
                //if we have the user already in cache we use that instead of reconstructing it
                else
                {
                    // GetUserObjectFromCache will perform a deep clone of the User object retrieved from the cache to ensure that
                    // multiple threads do not inadvertently corrupt its transient state (such as year, language, and location), which
                    // may differ in each thread. This helps to ensure thread safety and consistency of the cached User object.
                    m_utilizador = GetUserObjectFromCache(user_identity);
                    if (m_utilizador != null) return m_utilizador;
                }

                //otherwise we have no other choice than to recreate the entire user from persistence
                if (user_identity != null && user_identity != guest_identity)
                    m_utilizador = GetUserObjectFromPersistence(user_identity);

                //We don't have a user so there is no other possible identity other than guest
                if (m_utilizador == null)
                    m_utilizador = GetUserObjectAsGuest();

                //update the session and cache
                user_identity = m_utilizador.Name;
                HttpContext.Current.Session["user.identity"] = user_identity;
                if (user_identity != guest_identity)
                    QCache.Instance.User.Put("user." + user_identity, m_utilizador);

				return m_utilizador;
			}

			set
			{
                if (value != null)
                {
                    HttpContext.Current.Session["user.identity"] = value.Name;
					if (!SecurityFactory.IsGuest(value.Name))
						QCache.Instance.User.Put("user." + value.Name, value);
                }
                m_utilizador = value;
			}
		}

		/// <summary>
        /// Creates a virtual guest user to represent an unauthenticated unknown user
        /// </summary>
        /// <returns></returns>
        private User GetUserObjectAsGuest()
		{
			//If the user identity is valid but we are unable to authorize it then we revert back to a guest identity
			IPrincipal principal = SecurityFactory.GetGuest();
			string user_identity = principal.Identity.Name;
			User user = new User(user_identity, HttpContext.Current.Session.SessionID, Configuration.DefaultYear, HttpContext.Current.Request.UserHostAddress);
			return UserFactory.FillUser(principal, user);
		}

        /// <summary>
        /// Retrieves the user information and permissions from the database persistence
        /// </summary>
        /// <param name="user_identity"></param>
        /// <returns></returns>
        private User GetUserObjectFromPersistence(string user_identity)
        {
			try
			{
                IPrincipal principal = SecurityFactory.GetUserRoles(new GenericIdentity(user_identity));
                if (principal is ErrorPrincipal)
                    return null;

				User user = new User(user_identity, HttpContext.Current.Session.SessionID, GetYearFromRoute(), HttpContext.Current.Request.UserHostAddress);
				user.Language = Thread.CurrentThread.CurrentCulture.Name.Replace("-", "").ToUpperInvariant();
				user.CurrentModule = GetModuleFromRoute();
                user = UserFactory.FillUser(principal, user);
                // An attempt will be made to recover the Initial EPH if necessary
                TryRestoreInitialEPH(ref user);
                return user;
			}
			catch
			{
            	return null;
			}
		}

        /// <summary>
        /// This method retrieves a deep clone of a User object from cache using the specified user identity.
		/// Will perform a deep clone of the User object retrieved from the cache to ensure that
		/// multiple threads do not inadvertently corrupt its transient state (such as year, language, and location), which may differ in each thread.
		/// This helps to ensure thread safety and consistency of the cached User object.
        /// </summary>
        /// <param name="user_identity"></param>
        /// <returns></returns>
        private User GetUserObjectFromCache(string user_identity)
        {
            // Retrieve the user object from cache
            var userCache = QCache.Instance.User.Get("user." + user_identity) as User;

            // If the user object is found in cache
            if (userCache != null)
            {
                try
                {
                    // Deep clone the user object to create a new instance of the User class.
                    // We need to clone the user so that multiple threads don't corrupt
                    //  its transient state (like year, language, location) that can be different in each thread
                    var user = userCache.Clone() as User;
                    // An attempt will be made to recover the Initial EPH if necessary
                    TryRestoreInitialEPH(ref user);
                    return user;
                }
                catch
                {
                    // If an exception occurs during cloning, return null
                    return null;
                }
            }

            // If the user object is not found in cache, return null
            return null;
        }

		/// <summary>
		/// Get the system (year) that comes in the route data or return the default.
		/// The function is now public to avoid code duplication.
		/// </summary>
		/// <returns>The system (year) that comes in the route data or the default.</returns>
		public string GetYearFromRoute()
		{
			var year = Configuration.DefaultYear;
			if (HttpContext.Current.Request.RequestContext.RouteData.Values.ContainsKey("system"))
			{
				year = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("system") ?? Configuration.DefaultYear;
				// Ensure that the year exists in the configuration
				if (!Configuration.Years.Contains(year))
					year = Configuration.DefaultYear;
			}
			return year;
		}

		private string GetModuleFromRoute()
		{
			string module = null;
			if (HttpContext.Current.Request.RequestContext.RouteData.Values.ContainsKey("module"))
                module = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("module");

			return module;
		}

        private string AutologinIdentity()
		{
            try
            {
				string identity_name = null;
				HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
				IPrincipal principal = HttpContext.Current.User;
				if ((authCookie != null || Configuration.LoginType == Configuration.LoginTypes.AD) && principal != null && principal.Identity.IsAuthenticated)
				{
					if (Configuration.LoginType == Configuration.LoginTypes.AD)
					{
						var id = principal.Identity;
						if (id is WindowsIdentity)
						{
							id = new GenericIdentity(id.Name.Substring(id.Name.LastIndexOf('\\') + 1));
						}
						identity_name = id.Name;

						// log login (audit)
						var user = new User(identity_name, HttpContext.Current.Session.SessionID, Configuration.DefaultYear, HttpContext.Current.Request.UserHostAddress);
						CSGenio.framework.Audit.registLoginOut(user, Resources.Resources.ENTRADA31905,
											Resources.Resources.ENTRADA_ATRAVES_DE_A53025, HttpContext.Current.Request.UserHostName, HttpContext.Current.Request.GetClientIpAddress());

					}
					else if (authCookie != null)
					{
						string encTicket = authCookie.Value;
						if (!string.IsNullOrEmpty(encTicket))
						{
							FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);
							//user data contains the default year if the authenticated cookie
							identity_name = ticket.Name;

							// log login (audit)
							var user = new User(identity_name, HttpContext.Current.Session.SessionID, ticket.UserData, HttpContext.Current.Request.UserHostAddress);
							CSGenio.framework.Audit.registLoginOut(user, Resources.Resources.ENTRADA31905,
												Resources.Resources.ENTRADA_ATRAVES_DE_C07809, HttpContext.Current.Request.UserHostName, HttpContext.Current.Request.GetClientIpAddress());
						}
					}
				}

				if (identity_name == null && SecurityFactory.AutoLoginGuest)
				{
					//create a guest user
					identity_name = SecurityFactory.GetGuest().Identity.Name;
				}

				return identity_name;
			}
            catch
            {
                //revert to guest identity anyway. We don't support null User property for now, so we need to return something.
                return "guest";
            }
        }

		/// <summary>
        /// An attempt will be made to recover the Initial EPH if necessary.
        /// </summary>
        /// <param name="user">The reference to the User</param>
        private void TryRestoreInitialEPH(ref User user)
		{
            // If necessary, try to restore the initial EPHs
            if (user != null && !user.EphOk)
            {
                var initialEphCache = HttpContext.Current.Session["user.eph.initial"] as Dictionary<string, InitialEPHCache>;
				UserFactory.FillEphRuntime(ref user, initialEphCache);
            }
        }

		/// <summary>
		/// ctor
		/// </summary>
		public UserContext()
		{
			Navigations = new ConcurrentDictionary<string, NavigationContext>();
		}

		/// <summary>
        /// Remove older navigations that are no longer used to free up memory
        /// </summary>
        public void RemoveExpiredNavigations()
		{
			try
			{
                var expiredKeys = Navigations
                        .Where(n => !n.Value.IsValid())
                        .Select(p => p.Key);
                foreach (string key in expiredKeys)
                    Navigations.TryRemove(key, out NavigationContext _);
            }
			catch(System.Exception e)
			{
				Log.Error("Error on RemoveExpiredNavigations; " + e.Message);
			}
        }

		public bool NavigationsContainsKey(string key)
		{
			if (string.IsNullOrEmpty(key))
				return false;
			else
				return Navigations.ContainsKey(key);
        }

		public bool NavigationsGet(string key, out NavigationContext nav)
		{
			if (string.IsNullOrEmpty(key))
			{
				nav = null;
				return false;
			}

			return Navigations.TryGetValue(key, out nav);
        }

        public string NavigationsAdd(NavigationContext nav)
        {
            // Generate a key that is not yet in use
            var newId = NavigationContext.createWinId();
            while (Navigations.ContainsKey(newId))
                newId = NavigationContext.createWinId(10);

            if (Navigations.TryAdd(newId, nav))
			{
				nav.NavigationId = newId;
                return newId;
            }
			else
			{
                // As a last resort, if it fails, we will try to use a larger key
                newId = Guid.NewGuid().ToString();
                if (Navigations.TryAdd(newId, nav))
				{
                    nav.NavigationId = newId;
                    return newId;
                }
            }

			// There should be some handling of cases when it fails
			Log.Error("Failed to insert a new navigation context.");
			nav.NavigationId = string.Empty;
			return string.Empty;
        }

        public string NavigationsClone(string sourceKey, out NavigationContext navContext)
        {
            if (NavigationsGet(sourceKey, out NavigationContext sourceNav))
                navContext = sourceNav.Clone();
            else
                navContext = new NavigationContext();

			return NavigationsAdd(navContext);
        }

		/// <summary>
        /// Deixa de ser guardado no CurrentNavidation e passa a ser gerido aqui
        /// No CurrentNavigation passam todos os metodos a static
        /// </summary>
        [NonSerialized]
        public NavigationContext CurrentNavigation;

		public static UserContext Current
		{
			get
			{
				//The context might have been already initialized by a request redirecting to this one
				//So if we already have a context in this thread we keep it
                UserContext ctx = HttpContext.Current.Items["appContext"] as UserContext;
				if (ctx != null)
					return ctx;

                //else create a new one
				ctx = new UserContext();

				//recover the navigations from session
                var nav = HttpContext.Current.Session["navigation"] as ConcurrentDictionary<string, NavigationContext>;
				if (nav == null)
				{
					nav = new ConcurrentDictionary<string, NavigationContext>();
					HttpContext.Current.Session["navigation"] = nav;
				}
				ctx.Navigations = nav;

                //save in the current response thread
                HttpContext.Current.Items["appContext"] = ctx;
				return ctx;
			}
		}

		public static void Destroy()
		{
            var current = HttpContext.Current.Items["appContext"] as UserContext;
			if (current != null)
				current.User = null;

            HttpContext.Current.Session["user.identity"] = null;
            HttpContext.Current.Session["navigation"] = null;
			QCache.Instance.User.Invalidate("user." + HttpContext.Current.User.Identity.Name);
		}
	}
}

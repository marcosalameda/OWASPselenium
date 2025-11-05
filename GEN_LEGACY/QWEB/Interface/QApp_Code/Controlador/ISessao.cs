using System;
using System.Collections;
using CSGenio.framework;

namespace CSGenio
{
    /// <summary>
    /// Interface to obter dados sobre a sessão do user
    /// </summary>
    public interface ISessao
    {
        string SessionId { get; }
        User User { get; set; }
        Hashtable UltimosLidosInicio { get; set; }
        Hashtable UltimosLidosFim { get; set; }
        string UserLogin { get; }
        bool UserIsAuthenticated { get; }
		bool IsClientCertificatePresent { get; }
        ClientCertificate ClientCertificate { get; }
		string IdentityName { get; }
		bool UseAuthenticationTicket { get; }

		bool IsAuthenticationTicketValid();
		void SetAuthenticationTicket(string userName, string year);
		void ClearAuthenticationTicket();
	}
}
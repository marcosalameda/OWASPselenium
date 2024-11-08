using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quidgest.Persistence.GenericQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace GenioServer.security
{
    public class CMDIdentityProviderOptions
    {
        public CMDIdentityProviderOptions(string description, string jsonOptions)
        {
            Scope = new List<String>() 
            {
                "http://interop.gov.pt/MDC/Cidadao/NIF",
				"http://interop.gov.pt/MDC/Cidadao/NomeCompleto",
                "http://interop.gov.pt/MDC/Cidadao/NomeProprio",
				"http://interop.gov.pt/MDC/Cidadao/NomeApelido",
				//The NIC is exclusive to Portuguese citizens and is mandatory
				//which is why it gives an error when CMD is not Portuguese
                "http://interop.gov.pt/MDC/Cidadao/NIC",
				//In order for the CMD to be compatible with foreign users
				//the following DocType and DocNationality and DocNumber properties have been added
				//which are used instead of the NIC when the CMD is not Portuguese
                "http://interop.gov.pt/MDC/Cidadao/DocType",
                "http://interop.gov.pt/MDC/Cidadao/DocNationality",
                "http://interop.gov.pt/MDC/Cidadao/DocNumber"
            };
            ResponseType = new List<String>()
            {
                "token" //The ID_Token is represented as a JSON Web Token (JWT), which uses JSON Web Signature (JWS) and JSON Web Encryption (JWE) specifications enabling the claims to be digitally signed or MACed and/or encrypted.                
            };
            ResponseMode = "form_post";

            //load Options from configuracoes.xml
            Description = description;

            try
            {
                dynamic jsonOp = JObject.Parse(jsonOptions.Substring(jsonOptions.IndexOf("=") + 1));
                Authority = jsonOp.Authority;// "https://accounts.google.com/o/oauth2/v2/auth";
                ClientId = jsonOp.ClientId; //"226378632051-uvoonk0qhf3ee25tpbj5lu9m4noscor1.apps.googleusercontent.com";
                DataAPI = jsonOp.DataAPI;
                UserIdField = jsonOp.UserIdField;
            }
            catch
            {
                throw new Exception("Missing options! It's mandatory Authority, ClientId, DataAPI and UserIdField");
            }
        }

        /// <summary>
        /// Used when have multiple providers to distinct them for the final user and to switch authentication code between their.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Authority are the url use when making OpenIdConnect calls.
        /// </summary>
        [SecurityProviderOption()]
        [Description("Authority is the url to use when making OpenIdConnect calls")]
        public string Authority { get; set; }        
        /// <summary>
        /// OAuth 2.0 Client Identifier valid at the Authorization Server.
        /// </summary>
        [SecurityProviderOption()]
        [Description("OAuth 2.0 Client Identifier valid at the Authorization Server")]
        public string ClientId { get; set; }        
        /// <summary>
        /// OAuth 2.0 Response Type value that determines the authorization processing flow to be used, including what parameters are returned from the endpoints used. When using the Authorization Code Flow, this value is code.
        /// </summary>
        [JsonIgnore]
        public List<string> ResponseType { get; set; }
        [JsonIgnore]
        public string ResponseMode { get; set; }
        /// <summary>
        /// Gets the list of permissions to request.
        /// </summary>
        [JsonIgnore]
        public List<string> Scope { get; private set; }

        /// <summary>
        /// API adress to get data associated with authenticated token
        /// </summary>
        [SecurityProviderOption()]
        [Description("API adress to get data associated with authenticated token")]
        public string DataAPI { get; set; }

        /// <summary>
        /// field used to connect to a database user Ex: "http://interop.gov.pt/MDC/Cidadao/NIF"
        /// </summary>
        [SecurityProviderOption()]
        [Description("Field reference to represent the unique user id: 'http://interop.gov.pt/MDC/Cidadao/NIF'")]
        public string UserIdField { get; set; }

    }


    [CredentialProvider(typeof(DomainCredential))]
    [Description("Establishes identity using citizen Digital Mobile Key.")]
    [DisplayName("Digital Mobile Key")]
    public class CMDIdentityProvider : BaseIdentityProvider
    {
        /// <inheritdoc/>
        public override bool HasRedirectLogin() => true;

        /// <inheritdoc/>
        public override string GetRedirectLoginUrl(string callback = null, string state = null)
        {
            if (String.IsNullOrEmpty(Options.Authority) || String.IsNullOrEmpty(Options.ClientId) || String.IsNullOrEmpty(callback))
                throw new Exception("It's mandatory to configure Authority, ClientId and CallbackPath options");

            var uriBuilder = new UriBuilder(Options.Authority);
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["response_type"] = string.Join("+", Options.ResponseType);
            parameters["response_mode"] = Options.ResponseMode;
            if (Options.Scope.Contains("openid")) //this parameter is mandatory when we have scope to made authentication using openid connect
                parameters["nonce"] = Guid.NewGuid().ToString("N").ToUpper(); //String value used to associate a Client session with an ID Token, and to mitigate replay attacks. 
            parameters["client_id"] = Options.ClientId;
            parameters["redirect_uri"] = callback;
            parameters["scope"] = string.Join(" ", Options.Scope);

            if (!string.IsNullOrEmpty(state))
                parameters["state"] = state;

            uriBuilder.Query = System.Web.HttpUtility.UrlDecode(parameters.ToString());

            if (Log.IsDebugEnabled)
                Log.Debug(string.Format("GetRedirectLoginUrl: {0}", uriBuilder.Uri.ToString()));

            return uriBuilder.Uri.ToString();
        }

        /// <inheritdoc/>
        public override bool RegisterExternalId(Credential credential, User user)
        {
            if (!(credential is TokenCredential tokenCredential))
                return false;

            try
            {
                string username = Validate(tokenCredential).Result;
                if (string.IsNullOrEmpty(username))
                    return false;

                var sp = PersistentSupport.getPersistentSupport(user.Year);

                //save data to PSW
                sp.openConnection();
                var userPsw = CSGenioApsw.search(sp, user.Codpsw, user);
                userPsw.ValUserid = username;
                userPsw.updateDirect(sp);
                sp.closeConnection();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return false;
            }

            return true;
        }


        [SecurityProviderOption(isJson: true)]
        public CMDIdentityProviderOptions Options { get; set; }


        public CMDIdentityProvider()
        {
            var allOpenIdAuth = Configuration.Security.IdentityProviders.FindAll(x => x.Type == typeof(CMDIdentityProvider).FullName);
            if (allOpenIdAuth.Count == 0)
                return;

            Options = new CMDIdentityProviderOptions(allOpenIdAuth[0].Name, allOpenIdAuth[0].Config);
        }

        //Legacy mechanism so we can initialize the json options without doing it in the constructor
        //TODO: The complex options configuration format needs to be refactored!
        public void InitJsonOptions()
        {
            var ip = Configuration.Security.IdentityProviders.FirstOrDefault(x => x.Name == this.Id);
            Options = new CMDIdentityProviderOptions(ip.Description, ip.Config);
        }



        private async Task<string> Validate(TokenCredential credential)
        {
            using (var http = new HttpClient()) //TODO: reuse HttpClient
            {
                http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var resp = await http.GetAsync(Options.DataAPI + "?token=" + credential.Token);
                resp.EnsureSuccessStatusCode();
                string jsonResult = await resp.Content.ReadAsStringAsync();

                string userName = "";
                JArray jsonPayload = JArray.Parse(jsonResult);
                if (jsonPayload.Count == 0)
                    return null;

                foreach (JObject item in jsonPayload)
                {
                    string name = item.GetValue("name").ToString();
                    string value = item.GetValue("value").ToString();

                    if (name.Equals(Options.UserIdField, StringComparison.OrdinalIgnoreCase))
                    {
                        userName = value;
                        break;
                    }
                }
                if (string.IsNullOrEmpty(userName))
                    return null;

                return userName;
            }
        }

        /// <inheritdoc/>
        public override IIdentity Authenticate(Credential credential)
        {
            if (credential is TokenCredential token)
                return Authenticate(token);

            return null;
        }

        private IIdentity Authenticate(string ext_username, PersistentSupport sp)
        {
            try
            {
                //if the options specify an email jwt id field, then match with psw email field
                //else match with userid field
                string psw_id_field = string.IsNullOrEmpty(Options.UserIdField) ? "userid" : "email";

                SelectQuery select = new SelectQuery()
                    .Select("psw", "status")
                    .Select("psw", "nome")
                    .From(Area.AreaPSW)
                    .Where(CriteriaSet.And().Equal("psw", psw_id_field, ext_username));

                var results = sp.executeReaderOneRow(select);
                if (results.Count < 2)
                    return null;

                int status = DBConversion.ToInteger(results[0]);
                string name = DBConversion.ToString(results[1]);

                if (status == 2)
                    return null;

                return new GenericIdentity(name);
            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Authenticate: {0}", ex.Message));
                return null;
            }
        }


        private IIdentity Authenticate(TokenCredential credential) 
        {
            string ext_username = Validate(credential).Result;
            if (string.IsNullOrEmpty(ext_username))
                return null;

            //At this moment the user is authenticated and we have to check if that user exist on database
            IList<string> anos = new List<string>(Configuration.Years);
            if (Configuration.Years.Count == 0)
                anos.Add(Configuration.DefaultYear);

            IIdentity id = null;
            foreach (string Qyear in anos)
            {
                PersistentSupport sp = PersistentSupport.getPersistentSupport(Qyear);
                try
                {
                    sp.openConnection();
                    id = Authenticate(ext_username, sp);
                }
                catch (Exception ex)
                {
                    if (Log.IsDebugEnabled)
                        Log.Debug(string.Format("OpenIdConnectProvider authentication partial fail: {0}", ex.Message));
                }
                finally
                {
                    sp.closeConnection();
                }

                if (id != null)
                    break;
            }

            return id;

        }
    }    
}

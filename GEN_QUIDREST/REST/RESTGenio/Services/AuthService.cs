using CSGenio.framework;
using GenioServer.security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace RESTGenio;

public class AuthService
{
    /// <summary>
    /// The secret key used for generating symmetric security keys.
    /// This should be securely stored and configured in environment variables or secure configuration files.
    /// </summary>
    private static readonly string Secret = Configuration.GetProperty("RESTSECRET", "default_secret_please_reconfigure_with_jwtkey_property");
    
    /// <summary>
    /// The symmetric security key generated from the configured secret.
    /// Used for signing JWTs and other cryptographic operations.
    /// </summary>
    private static readonly SymmetricSecurityKey Key = GetSymmetricSecurityKey(Secret);

    /// <summary>
    /// Maximum timeout for JWT tokens, in minutes.
    /// Configured using the RESTMAXTIME property or defaults to 60 minutes.
    /// </summary>
	private static readonly float maxtimeout = float.Parse(Configuration.GetProperty("RESTMAXTIME", "60"), System.Globalization.CultureInfo.InvariantCulture);

    /// <summary>
    /// Generates a symmetric security key using a SHA-512 hash of the provided secret.
    /// Ensures the key meets the size requirements for secure cryptographic algorithms.
    /// </summary>
    /// <param name="secret">The secret string used to derive the symmetric key.</param>
    /// <returns>A SymmetricSecurityKey derived from the hashed secret.</returns>
    private static SymmetricSecurityKey GetSymmetricSecurityKey(string secret)
    {
        if (string.IsNullOrEmpty(secret))
            throw new ArgumentException("Secret cannot be null or empty.", nameof(secret));

        // Use SHA-512 to generate a 512-bit hash from the secret
        using var sha512 = SHA512.Create();
        byte[] keyBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(secret));
        
        // Create a symmetric key from the hash
        return new SymmetricSecurityKey(keyBytes);
    }

    /// <summary>
    /// Get as close as possible representation of the hostname from where this service is running
    /// </summary>
    /// <returns>The issuer id</returns>
    private static string GetIssuer() => Configuration.GetProperty("RESTISSUER", Configuration.Application.Id);

    /// <summary>
    /// Set the audience to this application id
    /// </summary>
    /// <returns>The audience id</returns>
    private static string GetAudience() => Configuration.Application.Id;

    public static void ConfigureJwt(JwtBearerOptions o)
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = GetIssuer(),
            ValidAudience = GetAudience(),
            IssuerSigningKey = Key,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    }

    /// <summary>
    /// Creates a JWT token to encode and secure the authenticated claims
    /// </summary>
    /// <param name="user">The user object identity to encode into a token</param>
	/// <param name="timeout">Token expire timeout in minutes, pass null to use max value</param>
    /// <param name="lease">True to create a lease token that cannot be used to refresh tokens</param>
    /// <returns>A JWT token</returns>
    public static string CreateToken(User user, float? timeout, bool lease=false)
    {        
        if (timeout is null)
            timeout = maxtimeout;
        if (timeout > maxtimeout)
            throw new Exception("Requested token timeout exceeds the allowed maximum");

        // Define the jwt token which will be responsible of creating our tokens
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        // Define our token descriptor
        // We need to utilise claims which are properties in our token which gives information about the user
        var claimList = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Name),
            new Claim("year", user.Year)
        };
        if (lease) claimList.Add(new Claim("lease", "true"));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claimList),

            // The life span of the token needs to be shorter and utilise refresh token to keep the user signedin
            Expires = DateTime.UtcNow.AddMinutes(timeout.Value),
            Issuer = GetIssuer(),
            Audience = GetAudience(),

            // Encryption algorythm information which will be used to decrypt our token
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        var jwtToken = jwtTokenHandler.WriteToken(token);
        return jwtToken;
    }

	private static readonly TimeSpan cacheTimeout = TimeSpan.FromMinutes(1);

    /// <summary>
    /// Authenticates a username and password pair for a given database year
    /// </summary>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <param name="year">Data id to request or null to use the default one</param>
    /// <param name="location">Descriptor of the user remote location</param>
    /// <returns>A user with established id and roles</returns>
    public static User AuthenticateUser(string username, string password, string? year, string location)
    {
        if (year == null)
            year = Configuration.DefaultYear;
        User user = new User(username, Guid.NewGuid().ToString(), year, location);

        // falha se o login não for valido
        UserPassCredential credential = new UserPassCredential();
        credential.Username = username;
        credential.Password = password;
        credential.Year = year;

        IPrincipal principal = SecurityFactory.Authenticate(credential);
        if (principal == null) throw new Exception("Invalid credential, check username and password.");

        user = UserFactory.FillUser(principal, user);
        if (!user.Years.Contains(credential.Year)) throw new Exception("Invalid credential, check username and password.");

        if (user.Status == 2) throw new Exception("User is inactive. Connect to administration services to unlock user.");

        QCache.Instance.User.Put(username, user, cacheTimeout);
		return user;
    }

    /// <summary>
    /// Gets the applicational user permissions from a principal claim
    /// </summary>
    /// <param name="context">The http request context</param>
	/// <param name="module">The current module the user is trying to access</param>
    /// <returns>A User object containing the application permissions</returns>
    public static User ValidateAuthentication(HttpContext context, string module)
    {
		var principal = context.User;
        if (principal?.Identity == null || !principal.Identity.IsAuthenticated)
            throw new Exception("Invalid authentication");
		
		string location = context.Connection.RemoteIpAddress?.ToString() ?? "";

        var user = QCache.Instance.User.Get(principal.Identity.Name) as User;
        if (user == null)
        {
            string ano = principal.Claims.First(c => c.Type == "year").Value;

            user = new User(principal.Identity.Name, new Guid().ToString(), ano, location);
            var rolesPrincipal = SecurityFactory.GetUserRoles(principal.Identity);
            user = UserFactory.FillUser(rolesPrincipal, user);
            QCache.Instance.User.Put(user.Name, user, cacheTimeout);
        }
        else
            user = user.Clone() as User ?? throw new Exception("Unable to clone user");
		
		//transient properties
		user.CurrentModule = module;
        user.Language = Thread.CurrentThread.CurrentCulture.Name.Replace("-", "").ToUpperInvariant();

        return user;
    }
	
	/// <summary>
    /// Validates if the current authorization is allowed to refresh tokens
    /// </summary>
    /// <param name="context">The http request context</param>
    public static void ValidateLease(HttpContext context)
    {
        var principal = context.User ?? throw new Exception("Invalid authentication");
        if (principal.Claims.Any(c => c.Type == "lease"))
            throw new Exception("This is a lease token and cannot be used to request a new refresh token");
    }
}

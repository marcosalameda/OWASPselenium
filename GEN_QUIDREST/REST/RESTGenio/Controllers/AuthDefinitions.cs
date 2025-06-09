using System.ComponentModel.DataAnnotations;

namespace RESTGenio.Auth;

/// <summary>
/// Responding to a login request
/// </summary>
public class LoginResponse : Response
{
    /// <summary>
    /// Login token, required for all requests other than Login
    /// </summary>
    /// <example>fa8bfae7e4d14f12a47a994df8a4644a</example>
    public string token { get; set; } = string.Empty;
}

public class LoginRequest
{
    /// <summary>
    /// User
    /// </summary>
    /// <example>Username</example>
    [Required]
    public string username { get; set; } = string.Empty;

    /// <summary>
    /// Password
    /// </summary>
    /// <example>Password</example>
    [Required]
    public string password { get; set; } = string.Empty;

    /// <summary>
    /// Year
    /// </summary>
    /// <example>2022</example>
    public string? year { get; set; }

    /// <summary>
    /// Request a specific token expire timeout in minutes
    /// </summary>
    /// <example>0.5</example>
    public float? timeout { get; set; }
}
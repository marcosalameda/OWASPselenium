namespace GenioMVC.Helpers;

/// <summary>
/// Temporary stub attribute for ASP.Net compatibility,
/// Originally it meant the validation of a text field would allow Html content.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class AllowHtmlAttribute : Attribute
{

}
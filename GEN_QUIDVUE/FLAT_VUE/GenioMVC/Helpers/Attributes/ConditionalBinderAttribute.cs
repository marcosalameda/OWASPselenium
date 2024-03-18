namespace GenioMVC.Helpers;

/// <summary>
/// Marks a property and requiring being binded by ConditionalBinder
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class ConditionalBinderAttribute : Attribute
{
}
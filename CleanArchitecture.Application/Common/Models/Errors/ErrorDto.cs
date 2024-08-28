namespace CleanArchitecture.Application.Common.Models.Errors;

public class ErrorDto(string propertyName, List<string> messages)
{
    public string PropertyName { get; set; } = propertyName;
    public IReadOnlyList<string> Messages { get; set; } = messages;
}
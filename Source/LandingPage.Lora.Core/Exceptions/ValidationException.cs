namespace LandingPage.Lora.Core.Exceptions;

public class ValidationException : Exception
{
    public Dictionary<string, string> Errors { get; set; }

    public ValidationException() : base() { }
    public ValidationException(string message) : base(message) { }
    public ValidationException(string message, Dictionary<string, string> errors) : base(message) { Errors = errors; }
    public ValidationException(string message, Exception inner) : base(message, inner) { }

    public ValidationException(string message, string field, string fieldMessage) : base(message) {
        Errors = new Dictionary<string, string> {
            { field, fieldMessage }
        };
    }

    protected ValidationException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

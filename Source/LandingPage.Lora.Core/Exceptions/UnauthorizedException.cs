namespace LandingPage.Lora.Core.Exceptions;

[Serializable]
public class UnauthorizedException : Exception
{
    public UnauthorizedException() : base() { }
    public UnauthorizedException(string message) : base(message) { }
    public UnauthorizedException(string message, Exception inner) : base(message, inner) { }

    protected UnauthorizedException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

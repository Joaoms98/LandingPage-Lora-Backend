namespace LandingPage.Lora.Core.Exceptions;

public class DuplicateKeyException : Exception
{
    public string KeyName { get; set; }

    public DuplicateKeyException(string keyName)
        : this (keyName, null, null)
    {
    }

    public DuplicateKeyException(string keyName, string message)
        : this(keyName, message, null)
    {
    }

    public DuplicateKeyException(string keyName, string message, Exception inner)
        : base(message, inner)
    {
        KeyName = keyName;
    }
}
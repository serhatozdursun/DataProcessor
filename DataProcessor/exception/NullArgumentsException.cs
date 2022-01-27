namespace DataProcessor.exception;

public class NullArgumentsException : Exception
{
    public NullArgumentsException(){}
    
    public NullArgumentsException(string message)
        : base(message)
    {
    }
    
    public NullArgumentsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
namespace DataProcessor.exception;

public class LenghtMismatch : Exception
{
    public LenghtMismatch()
    {
        
    }
    
    public LenghtMismatch(string message)
        : base(message)
    {
    }
    
    public LenghtMismatch(string message, Exception inner)
        : base(message, inner)
    {
    }
}
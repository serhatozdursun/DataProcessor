using DataProcessor.exception;

namespace DataProcessor.output;

public class TextReverse :IOutput
{
    public void Output(object data)
    {
        var stringData =  Convert.ToString(data);
        if (stringData != null && stringData.Length < 5)
            throw new LenghtMismatch("data should be 5 character at least");
        stringData = stringData?.Substring(0, 5);
        Console.WriteLine(Reverse(stringData));
    }
    
    public static string? Reverse( string? s )
    {
        char[]? charArray = s?.ToCharArray();
        if (charArray != null)
        {
            Array.Reverse(charArray);
            return new string(charArray);
        }
        else
        {
            return null;
        }
    }
}
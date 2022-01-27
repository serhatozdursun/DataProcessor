using System.Diagnostics;
using System.Text;
using DataProcessor.exception;

namespace DataProcessor.output;

public class TextOutput : IOutput
{
    public void Output(object data)
    {
       var stringData =  Convert.ToString(data);

       Debug.Assert(stringData != null, nameof(stringData) + " != null");
       if (stringData.Length < 7)
           throw new LenghtMismatch("text data should be 7 character at least");
       stringData = stringData.Substring(0, 6);
       var utf8Bytes = Encoding.UTF8.GetBytes(stringData);
       stringData =  Encoding.UTF8.GetString(utf8Bytes);
       Console.WriteLine(stringData);
    }
}
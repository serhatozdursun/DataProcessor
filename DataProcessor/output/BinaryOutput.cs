
namespace DataProcessor.output;

public class BinaryOutput : IOutput
{
    public void Output(object data)
    {
        byte[] bytData = (byte[]) data;
        byte[] firstFive = new byte[5];
        Array.Copy(bytData, firstFive, 5);
        string result = Base64Encode( firstFive);
        Console.WriteLine(result);
    }
    
    public  string Base64Encode(byte[] plainTextBytes) {
        return Convert.ToBase64String(plainTextBytes);
    }
}
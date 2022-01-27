namespace DataProcessor.dataTypes;

public class FileDataType
{
    public string GetFileContentAsText(string? filePath)
    {
        return System.IO.File.ReadAllText(@"" + filePath + "");
    }
    
    public byte[] GetFileContentAsBinary(string? filePath)
    {
        return System.IO.File.ReadAllBytes(@"" + filePath + "");
    }
}
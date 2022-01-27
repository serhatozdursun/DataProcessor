using DataProcessor.dataTypes;
using DataProcessor.exception;
using DataProcessor.output;

namespace DataProcessor
{
    class Program
    {    
        static void Main(string[] args)
        {
            string? filePath = null;
            DataTypes dataType = DataTypes.Undefinded;
            SourceTypes sourceType = SourceTypes.Undefinded;
            foreach (var arg in args)
            {
                if (arg.StartsWith("filePath"))
                {
                    filePath = arg.Replace("filePath=", "");
                    continue;
                }
                if (arg.StartsWith("dataType"))
                {
                    var type = arg.Replace("dataType=", "");
                    CheckArgumentsIsNull(type);
                    dataType = GetDataTypes(type);
                    continue;
                }
                if (arg.StartsWith("sourceType"))
                {
                    var type = arg.Replace("sourceType", "");
                    CheckArgumentsIsNull(type);
                    sourceType = GetSourceTypes(type);
                }
            }
            
            switch(sourceType)
            {
                case SourceTypes.Database:
                    //todo
                break;
                case SourceTypes.Eventlog:
                    //todo
                break;
                default:
                    var data = GetFileData(filePath, dataType);
                    Output(dataType, data);
                    break;
            }
 
            
        }


        private static void Output(DataTypes dataTypes, object data)
        {
            IOutput output;
            switch (dataTypes)
            {
                case DataTypes.Binary:
                    output = new BinaryOutput();
                    output.Output(data);
                    break;
                case DataTypes.Text:
                    output = new TextOutput();
                    output.Output(data);
                    break;
                case DataTypes.TextReverse:
                    output = new TextReverse();
                    output.Output(data);
                    break;
            }
        }

        private static object GetFileData(string? filePath, DataTypes dataType)
        {
            var fileDataType = new FileDataType();
            
            switch (dataType)
            {
                case DataTypes.Binary:
                    return fileDataType.GetFileContentAsBinary(filePath);
                default:
                    return fileDataType.GetFileContentAsText(filePath);
            }
        }
        
        private static void CheckArgumentsIsNull(string arg)
        {
            if (arg == null)
            {
                throw new NullArgumentsException("please define filePath and dataType");
            }
        }

        private static DataTypes GetDataTypes(string type)
        {
            type = MakeFirstCharUpperCase(type);
            CheckArgumentsIsNull(type);
            return (DataTypes) Enum.Parse(typeof(DataTypes), type);
        }
        
        private static SourceTypes GetSourceTypes(string type)
        {
            type = MakeFirstCharUpperCase(type);
            CheckArgumentsIsNull(type);
            return (SourceTypes) Enum.Parse(typeof(SourceTypes), type);
        }

        private static string MakeFirstCharUpperCase(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1);
        }
    }
}
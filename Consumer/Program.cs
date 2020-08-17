using Service1;
using System;
using System.IO;
using Newtonsoft.Json;
using DataModel;
using System.Reflection.Metadata;
using System.Linq;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadProtoBuf();
            ReadJson();
        }

        static void ReadProtoBuf()
        {
            SdeProtoDto sdeProto;
            using (var input = File.OpenRead(Constants.DataStoragePath + "ProtobufData.txt"))
            {
                sdeProto = SdeProtoDto.Parser.ParseFrom(input);
            }

            Console.WriteLine("Protobuf Output");
            Console.WriteLine($"Name:{sdeProto.Name}");
            Console.WriteLine($"Id:{sdeProto.Id}");
            Console.Write($"Skills:");
            sdeProto.Skills.ToList().ForEach(skill => Console.Write(skill + " "));
            Console.WriteLine();
        }

        static void ReadJson()
        {
            string text = System.IO.File.ReadAllText(Constants.DataStoragePath + "JsonData.txt");
            SdeJsonDto sdeJson = JsonConvert.DeserializeObject<SdeJsonDto>(text);

            Console.WriteLine("JsonOutput");
            Console.WriteLine($"Name:{sdeJson.Name}");
            Console.WriteLine($"Id:{sdeJson.Id}");
            Console.WriteLine($"Skills:");
            sdeJson.Skills.ToList().ForEach(skill => Console.Write(skill + " "));
            Console.WriteLine();
        }
    }
}

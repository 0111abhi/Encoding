using Service1;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Google.Protobuf;
using DataModel;

namespace Encoding
{
    public class Program
    {
        static void Main(string[] args)
        {
            JsonSerialize();
            ProtoBufSerialize();
        }

        public static void ProtoBufSerialize()
        {
            var sde = new SdeProtoDto()
            {
                Id = 512,
                Name = "Naga",
                Skills = { "Design", "Coding" },
            };

            using (var output = File.Create(Constants.DataStoragePath + "ProtobufData.txt"))
            {
                sde.WriteTo(output);
            }
        }

        public static void JsonSerialize()
        {
            var sde = new SdeJsonDto()
            {
                Id = 512,
                Name = "Naga",
                Skills = new List<string>() { "Design", "Coding" },
            };

            var jsonSerializedData = JsonConvert.SerializeObject(sde);
            WriteToDisk(jsonSerializedData, Constants.DataStoragePath + "JsonData.txt");
        }

        public static void WriteToDisk(string data, string fileName)
        {
            using (var writer = new System.IO.StreamWriter(fileName))
            {
                writer.Write(data);
            }
        }
    }
}

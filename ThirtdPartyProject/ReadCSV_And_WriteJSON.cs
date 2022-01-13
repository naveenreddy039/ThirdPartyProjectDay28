using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ThirtdPartyProject
{
    public class ReadCSV_And_WriteJSON
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\hp\source\repos\ThirtdPartyProject\ThirtdPartyProject\address.csv";
            string exportFilePath = @"C:\Users\hp\source\repos\ThirtdPartyProject\ThirtdPartyProject\exp.json";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("ReadData successfully from address.csv");
                foreach (AddressData addressData in records)
                {
                    Console.Write(" " + addressData.firstname);
                    Console.Write(" " + addressData.lastname);
                    Console.Write(" " + addressData.address);
                    Console.Write(" " + addressData.state);
                    Console.Write(" " + addressData.city);
                    Console.Write(" " + addressData.code);
                    Console.Write("\n");
                }
                Console.WriteLine("\n *********Now RAEDING FROM csv file and write to csv file *********");

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}

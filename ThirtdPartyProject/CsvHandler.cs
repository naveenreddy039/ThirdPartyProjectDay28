using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ThirtdPartyProject;

namespace ThirdPartyProject
{
    public class CsvHandler
    {
        public static void ImplementCSVDataHandling()
        {

            string importPath = @"C:\Users\hp\source\repos\ThirtdPartyProject\ThirtdPartyProject\address.csv";
            string exportpath = @"C:\Users\hp\source\repos\ThirtdPartyProject\ThirtdPartyProject\Explore.csv";
            //Reading from CSV
            using (var reader = new StreamReader(importPath))
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
                //Writing to CSV
                using (var writer = new StreamWriter(exportpath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }

                
            }
        }
    }
}
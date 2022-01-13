using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Address14
{
    public class CsvHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importPath = @"C:\Users\hp\source\repos\Address14\Address14\Demo.csv";
            string exportpath = @"C:\Users\hp\source\repos\Address14\Address14\Demo1.csv";

            using (var reader = new StreamReader(importPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<addressData>().ToList();
                Console.WriteLine("Read Data Successfully from address.csv");
                foreach (addressData addressData in records)
                {
                    Console.WriteLine("" + addressData.FirstName);
                    Console.WriteLine("" + addressData.LastName);

                    Console.WriteLine("" + addressData.Address);

                    Console.WriteLine("" + addressData.City);

                    Console.WriteLine("" + addressData.State);
                    Console.WriteLine("" + addressData.Code);
                    Console.WriteLine("\n");


                }


                Console.WriteLine("\n ----------Now Reading From csv File and Write to csv File");
                using (var writer = new StreamWriter(exportpath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}

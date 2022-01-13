using System;
using ThirtdPartyProject;

namespace ThirdPartyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read data from CSV & Write data in CSV");
            CsvHandler.ImplementCSVDataHandling();
            ReadCSV_And_WriteJSON.ImplementCSVToJSON();
        }
    }
}
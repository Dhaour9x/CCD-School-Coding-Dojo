using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TabulateCSV
{
    class CSVHelper
    {
        static string nameAndPathOfFile = "data.csv";
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public CSVHelper( string fileName)
        {
            string[] csvEntries = fileName.Split(';');
            Name = csvEntries[0];
            Street = csvEntries[1];
            City = csvEntries[2];
            Age = Convert.ToInt32(csvEntries[3]);

        } 

        static void Main(string[] args)
        {
            Console.WriteLine(Tabulate("data.csv"));
        }

        public static IEnumerable<string> Tabulate(string CSV_zeilen)
        {
            //We change file extension here to make sure it's a .csv file
            string[] lines = File.ReadAllLines(CSV_zeilen);

            //lines.Select allows me to project each line as a CoutryModel.
            //This will give me an IEnumerable<CountryModel> back.
            return lines.Select(line =>
            {
                string[] data = line.Split(';');
                // we return a country with the data in order.

                return data[0] + "|" + data[1] + "|" + data[2] + "|" + data[3];
            });
        }
    }
}

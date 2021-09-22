using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TabulateCSV
{
    class CSVHelper
    {
        static readonly string nameAndPathOfFile = @"C:\Users\dhaoui\Documents\Github\CCD-School-Coding-Dojo\Function Katas\TabulateCSV\data.csv";

        static void Main(string[] args)
        {
            var result = Tabulate(File.ReadAllLines(nameAndPathOfFile));
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public static IEnumerable<string> Tabulate(IEnumerable<string> CSV_zeilen)
        {
            List<string> allStrings = new();

            List<string> retVal = new();
            var spalte = 0;
            int[] max = new int[100];
            for (int i = 0; i < CSV_zeilen.Count(); i++)
            {

                var zeile = CSV_zeilen.ElementAt(i).Split(";");
                //allStrings.AddRange(zeile);
                //spalte = zeile.Length;
                
                for(spalte = 0; spalte < zeile.Length; spalte++)
                {
                    max[spalte] = Math.Max(zeile[spalte].Length, max[spalte]);
                }

            }

            //int[] max = new int[spalte];
            //for(int j = 0; j < allStrings.Count(); j++)
            //{
            //    var col = j % spalte;
            //    max[col] = Math.Max(allStrings.ElementAt(j).Count(), max[col]);
                
            //}

            for(int i = 0; i < CSV_zeilen.Count(); i++)
            {
                var headers = CSV_zeilen.ElementAt(i).Split(";");
                string string_value = headers[0] + String.Concat(Enumerable.Repeat(" ", max[0] - headers[0].Length)) 
                    + "|" + headers[1] + String.Concat(Enumerable.Repeat(" ", max[1] - headers[1].Length))
                    + "|" + headers[2] + String.Concat(Enumerable.Repeat(" ", max[2] - headers[2].Length))
                    + "|" + headers[3] + String.Concat(Enumerable.Repeat(" ", max[3] - headers[3].Length)) 
                    + "|";
                retVal.Add(string_value);
                if (i == 0)
                {
                    var underline = String.Concat(Enumerable.Repeat("-", max[0]));
                    underline += "+" + string.Concat(Enumerable.Repeat("-", max[1]));
                    underline += "+" + string.Concat(Enumerable.Repeat("-", max[2]));
                    underline += "+" + string.Concat(Enumerable.Repeat("-", max[3]));
                    underline += "+";
                    retVal.Add(underline);
                }

            }
            return retVal;
        }
    }
}

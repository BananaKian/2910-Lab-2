using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using static System.Console;
using System.Formats.Asn1;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //file location will differ, so will need to be changed to accomodate that
            string FilePath = "C:\\Users\\Owner\\source\\repos\\Lab2\\Lab2\\videogames.csv";

            List<VideoGames> data = new();

            var reader = new StreamReader(FilePath);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
                HasHeaderRecord = false
            };           

            var csv = new CsvReader(reader, csvConfig);
            {
                // Skips the first row, since it won't convert right
                reader.ReadLine();

                while (csv.Read())
                {
                    var record = csv.GetRecord<VideoGames>();
                    data.Add(record);
                }
            }
          
            Dictionary<string, List<VideoGames>> dictionary = data.GroupBy(x => x.Platform).ToDictionary(gcs => gcs.Key, gcs => gcs.ToList());
            

            foreach (var kvp in dictionary)
            {
                WriteLine(kvp.Key, string.Join(",", kvp.Value));
            }
        }
    }
}
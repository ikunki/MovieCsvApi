using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ChoETL;
using MovieCsvApi.Models;

namespace MovieCsvApi.CsvData
{
    public class CsvReader
    {
        public CsvReader()
        { }

        public List<Metadata> GetMetadata()
        {
            List<Metadata> items = new List<Metadata>();
            var theMsg = string.Empty;
            //var reader = new StreamReader(csvPath);
            try
            {
                //var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                //var records = csv.GetRecords<Metadata>();
                string fileName = "metadata.csv";
                string path2csv = Path.Combine(Environment.CurrentDirectory, @"CsvData\", fileName);
                var csvMetadata = new ChoCSVReader<Metadata>(path2csv).WithFirstLineHeader();
                foreach (var e in csvMetadata)
                    items.Add(e);
            }
            catch (Exception ex)
            {
                theMsg = ex.Message;
            }
            return items;
        }

        public List<Stats> GetStats()
        {
            List<Stats> items = new List<Stats>();
            var theMsg = string.Empty;
            //var textReader = File.OpenText(csvPath);
            try
            {
                //var csv = new CsvReader(textReader, CultureInfo.InvariantCulture);
                //var records = csv.GetRecords<Stats>().ToList();
                string fileName = "stats.csv";
                string path2csv = Path.Combine(Environment.CurrentDirectory, @"CsvData\", fileName);
                var csvStats = new ChoCSVReader<Stats>(path2csv).WithFirstLineHeader();
                foreach (var e in csvStats)
                    items.Add(e);
            }
            catch (Exception ex)
            {
                theMsg = ex.Message;
            }
            return items;
        }
    }
}

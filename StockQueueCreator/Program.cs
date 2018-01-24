using System;
using System.IO;
using System.Net;
using CsvHelper;

namespace StockQueueCreator
{
    public class Program
    {
        public static void Main()
        {
            const string url = "https://functionsbatchapps01.blob.core.windows.net/sample/japan-all-stock-prices_20170104.csv";

            Console.WriteLine("Start CSV Read");

            var req = (HttpWebRequest)WebRequest.Create(url);
            var resp = (HttpWebResponse)req.GetResponse();
            var sr = new StreamReader(resp.GetResponseStream());

            using (var csv = new CsvReader(sr))
            {
                csv.Configuration.RegisterClassMap<StockMapper>();
                var stocks = csv.GetRecords<Stock>();
                foreach (var p in stocks)
                {
                    Console.WriteLine($"Ticker: {p.Ticker}, Prive: {p.Price}");
                }
            }

            sr.Close();

            Console.WriteLine("Finish CSV Read");
        }
    }
}

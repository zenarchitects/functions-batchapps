using System;
using System.IO;
using System.Net;
using CsvHelper;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace StockQueueCreator
{
    public class Program
    {
        public static void Main()
        {
            const string url = "https://functionsbatchapps01.blob.core.windows.net/sample/japan-all-stock-prices_20170104.csv";

            Console.WriteLine("Start enqueue");

            var req = (HttpWebRequest)WebRequest.Create(url);
            var resp = (HttpWebResponse)req.GetResponse();
            var sr = new StreamReader(resp.GetResponseStream());

            // Create Storage Account
            var storageAccount = CloudStorageAccount.Parse("{YOUR STORAGE CONNECTION STRING}");
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("{YOUR QUEUE NAME}");

            using (var csv = new CsvReader(sr))
            {
                csv.Configuration.RegisterClassMap<StockMapper>();
                var stocks = csv.GetRecords<Stock>();
                foreach (var p in stocks)
                {
                    Console.WriteLine($"Ticker: {p.Ticker}, Price: {p.Price}");

                    if (p.Volume != "-")
                    {
                        var message = new CloudQueueMessage(JsonConvert.SerializeObject(p));
                        queue.AddMessageAsync(message).Wait();
                    }
                }
            }
            sr.Close();

            Console.WriteLine("Completed enqueue");
        }
    }
}

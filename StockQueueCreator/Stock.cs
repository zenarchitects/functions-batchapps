using CsvHelper.Configuration;
using Newtonsoft.Json;

namespace StockQueueCreator
{
    public class Stock
    {
        [JsonProperty(PropertyName = "ticker")]
        public string Ticker { get; set; }
        [JsonProperty(PropertyName = "stockName")]
        public string StockName { get; set; }
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }
        [JsonProperty(PropertyName = "volume")]
        public string Volume { get; set; }
    }

    public sealed class StockMapper : ClassMap<Stock>
    {
        public StockMapper()
        {
            Map(s => s.Ticker).Name("SC");
            Map(s => s.StockName).Name("名称");
            Map(s => s.Price).Name("前日終値");
            Map(s => s.Volume).Name("出来高");
        }
    }
}

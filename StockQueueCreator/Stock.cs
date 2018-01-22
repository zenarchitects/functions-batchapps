using CsvHelper.Configuration;

namespace StockQueueCreator
{
    public class Stock
    {
        public string Ticker { get; set; }
        public string StockName { get; set; }
        public string Price { get; set; }
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

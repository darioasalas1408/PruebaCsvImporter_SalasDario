using System;

namespace AcmeCorporation.Model
{
    public struct StockModel 
    {
        public string PointOfSale { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public int Stock { get; set; }
    }
}

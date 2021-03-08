using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcmeCorporation.DAL
{
    public class StockProduct : IDisposable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdStock { get; set; }
        public string PointOfSale { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public int Stock { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

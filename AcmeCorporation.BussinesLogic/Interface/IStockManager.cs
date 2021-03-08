using AcmeCorporation.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic
{
    public interface IStockManager
    {
        Task AddRangeOfStock(IEnumerable<StockProduct> page);
        Task ClearAllRecords();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeCorporation.DAL
{
    public interface IStockRepository
    {
        Task ClearAllRecords();
        Task<bool> AddRange(IEnumerable<StockProduct> listStockProduct);
    }
}

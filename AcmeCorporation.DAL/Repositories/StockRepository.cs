using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace AcmeCorporation.DAL
{
    public class StockRepository: IStockRepository
    {
        private static readonly Logger logger = LogManager.GetLogger(typeof(StockRepository).FullName);

        protected readonly ImportDbContext context;
        public StockRepository(ImportDbContext importDbContext)
        {
            context = importDbContext;
        }

        //TODO: Add rest of the operations: Add, Update, Single Remove

        public async Task ClearAllRecords()
        {
            var allRecords = context.Stocks;
            context.Stocks.RemoveRange(allRecords);
            await context.SaveChangesAsync();
        }

        public async Task<bool> AddRange(IEnumerable<StockProduct> listStockProduct)
        {
            await context.BulkInsertAsync(listStockProduct);
            return true;
        }
    }
}

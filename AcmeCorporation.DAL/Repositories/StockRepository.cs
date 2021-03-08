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
            try
            {
                var allRecords = context.Stocks;
                context.Stocks.RemoveRange(allRecords);
                await context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public async Task<bool> AddRange(IEnumerable<StockProduct> listStockProduct)
        {
            try
            {
                await context.BulkInsertAsync(listStockProduct);
                return true;
            }
            catch (System.Exception ex)
            {
                logger.Error(ex);
                throw;
            }
            
        }
    }
}

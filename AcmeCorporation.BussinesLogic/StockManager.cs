using AcmeCorporation.DAL;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic
{
    public class StockManager : IStockManager
    {
        private IUnitOfWork unitOfWork;
        private static readonly Logger logger = LogManager.GetLogger(typeof(SourceRetrieverFromAzure).FullName);

        public StockManager(IUnitOfWork unitOfWork)
        {
            try
            {
                this.unitOfWork = unitOfWork;
            }
            catch (System.Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public async Task ClearAllRecords()
        {
            try
            {
                await unitOfWork.StockRepository.ClearAllRecords();
            }
            catch (System.Exception ex)
            {
                logger.Error(ex);
                throw;
            }
            
        }

        public async Task AddRangeOfStock(IEnumerable<StockProduct> page)
        {
            try
            {
                await unitOfWork.StockRepository.AddRange(page);
            }
            catch (System.Exception ex)
            {
                logger.Error(ex);
                throw;
            }
            
        }
    }
}

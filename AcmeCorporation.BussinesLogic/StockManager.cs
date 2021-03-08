using AcmeCorporation.DAL;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic
{
    /// <summary>
    ///Manager/Service to the Stock Entity
    /// </summary>
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

        //Clear all Rows in Db
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

        //Adding a list of Stock in Db. 
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

using AcmeCorporation.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic
{
    public class StockManager : IStockManager
    {
        private IUnitOfWork unitOfWork;

        public StockManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task ClearAllRecords()
        {
            await unitOfWork.StockRepository.ClearAllRecords();
        }

        public async Task AddRangeOfStock(IEnumerable<StockProduct> page)
        {
            await unitOfWork.StockRepository.AddRange(page);
        }
    }
}

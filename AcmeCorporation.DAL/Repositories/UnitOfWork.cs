namespace AcmeCorporation.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImportDbContext context;
        private IStockRepository stockRepository;

        public UnitOfWork(ImportDbContext importDbContex)
        {
            context = importDbContex;
        }

        public IStockRepository StockRepository
        {
            get
            {
                if (stockRepository == null)
                {
                    stockRepository = new StockRepository(context);
                }
                return stockRepository;
            }

        }
    }
}

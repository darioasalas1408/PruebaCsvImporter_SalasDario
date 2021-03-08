namespace AcmeCorporation.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImportDbContext context;
        private IStockRepository _StockRepository;

        public UnitOfWork(ImportDbContext importDbContex)
        {
            context = importDbContex;
        }

        public IStockRepository StockRepository
        {
            get
            {
                if (_StockRepository == null)
                {
                    _StockRepository = new StockRepository(context);
                }
                return _StockRepository;
            }

        }
    }
}

namespace AcmeCorporation.DAL
{
    public interface IUnitOfWork
    {
        IStockRepository StockRepository { get; }
    }
}

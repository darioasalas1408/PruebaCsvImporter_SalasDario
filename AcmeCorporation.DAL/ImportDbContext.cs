using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.DAL
{
    public class ImportDbContext : DbContext
    {
        public ImportDbContext(DbContextOptions<ImportDbContext> options)
           : base(options)
        {

        }

        public DbSet<StockProduct> Stocks { get; set; }
    }
}

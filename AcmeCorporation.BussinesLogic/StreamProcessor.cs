using AcmeCorporation.BussinesLogic.Interface;
using AcmeCorporation.DAL;
using CsvHelper;
using CsvHelper.Configuration;
using NLog;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic
{
    public class StreamProcessor : IStreamProcessor
    {
        private const int NumberOfRecords = 1000;
        private static readonly Logger logger = LogManager.GetLogger(typeof(StreamProcessor).FullName);
        private readonly IStockManager stockManager;


        public StreamProcessor(IStockManager stockManager)
        {
            this.stockManager = stockManager;
        }

        public async Task ProcessStream(Stream givenStream, long contentLength)
        {
            try
            {
                await stockManager.ClearAllRecords();

                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true, Delimiter = ";", HeaderValidated = null, MissingFieldFound = null };

                using (var reader = new StreamReader(givenStream))
                {
                    using (var csvReader = new CsvReader(reader, configuration))
                    {
                        for (int i = 0; i < contentLength / NumberOfRecords; i++)
                        {
                            var skip = i * NumberOfRecords;
                            logger.Info("Inserting Records from {0} to {1}", skip, NumberOfRecords + skip);

                            var recordsPage = csvReader.GetRecords<StockProduct>().Skip(skip).Take(NumberOfRecords);
                            if (recordsPage.Any())
                            {
                                await stockManager.AddRangeOfStock(recordsPage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}

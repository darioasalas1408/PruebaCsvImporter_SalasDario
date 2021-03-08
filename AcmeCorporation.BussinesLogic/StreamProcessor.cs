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
    /// <summary>
    /// Core to the main process
    /// </summary>
    public class StreamProcessor : IStreamProcessor
    {

        //Quantity of rows to process
        //TODO: This const could by set in the appsetting.json
        private const int NumberOfRecords = 1000;
        private static readonly Logger logger = LogManager.GetLogger(typeof(StreamProcessor).FullName);
        private readonly IStockManager stockManager;


        public StreamProcessor(IStockManager stockManager)
        {
            this.stockManager = stockManager;
        }

        /// <summary>
        /// Process in charge of delete all records and process the csv file, from Azure
        /// </summary>
        /// <param name="givenStream">Stream with the content of CSV</param>
        /// <param name="contentLength">Rows quantity of the CSV</param>
        /// <returns></returns>
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

                            //TODO: Use the entity StockModel and Use AutoMapper to the casting in the StockManager(in this case is not performant to requirement).
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

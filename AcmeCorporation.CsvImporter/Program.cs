using System;
using System.Threading.Tasks;
using AcmeCorporation.BussinesLogic;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace AcmeCorporation.CsvImporter
{
    public class Program
    {
        private static readonly Logger logger = LogManager.GetLogger(typeof(StreamProcessor).FullName);

        public static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Starting Process  {System.DateTime.Now}");
                await ProccessCSVFromAzure();
                Console.WriteLine($"Ending Process {System.DateTime.Now}");

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                Console.WriteLine("An unexpected Exception has happened.Please try later!");   
            }
        }

        private static async Task ProccessCSVFromAzure()
        {
            try
            {
                var fileProcessor = EnviromentSetting.Intance.Service.GetRequiredService<IFileProcessor>();
                await fileProcessor.ProcessFile();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}

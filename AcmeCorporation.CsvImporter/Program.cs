using System;
using System.Threading.Tasks;
using AcmeCorporation.BussinesLogic;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeCorporation.CsvImporter
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine($"Starting Process  {System.DateTime.Now}");
            await ProccessCSVFromAzure();
            Console.WriteLine($"Ending Process {System.DateTime.Now}");
        }

        private static async Task ProccessCSVFromAzure()
        {
            var fileProcessor = EnviromentSetting.Intance.Service.GetRequiredService<IFileProcessor>();
            await fileProcessor.ProcessFile();
        }
    }
}

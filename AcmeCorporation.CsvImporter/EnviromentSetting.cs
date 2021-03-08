using AcmeCorporation.BussinesLogic;
using AcmeCorporation.BussinesLogic.Interface;
using AcmeCorporation.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace AcmeCorporation.CsvImporter
{
    public sealed class EnviromentSetting
    {
        private static readonly EnviromentSetting _instance = new EnviromentSetting();
        private static IConfiguration _configuration;
        private static IServiceProvider _serviceCollection;

        private EnviromentSetting()
        {
            this.ConfigurationBuilder();
            this.ServiceProvider();
        }

        public static EnviromentSetting Intance
        {
            get
            {
                return _instance;
            }

        }

        public  IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        public IServiceProvider Service
        {
            get
            {
                return _serviceCollection;
            }
        }

        private void ConfigurationBuilder()
        {
            _configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();
        }

        private void ServiceProvider()
        {
            var serviceCollection = new ServiceCollection()
              .AddScoped<IStockManager, StockManager>()
              .AddScoped<IFileProcessor, FileProcessor>()
              .AddScoped<IStreamProcessor, StreamProcessor>()
              .AddScoped<IUnitOfWork, UnitOfWork>()
              .AddDbContext<ImportDbContext>(o => o.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            var blobAzure = new BlobAzureModel();
            Configuration.Bind("BlobAzure", blobAzure);

            serviceCollection.AddScoped<ISourceRetriever>(x =>
                new SourceRetrieverFromAzure(blobAzure));

            _serviceCollection = serviceCollection.BuildServiceProvider();
        }

    }
}

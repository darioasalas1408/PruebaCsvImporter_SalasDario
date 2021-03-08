using AcmeCorporation.BussinesLogic;
using AcmeCorporation.BussinesLogic.Interface;
using AcmeCorporation.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace AcmeCorporation.CsvImporter
{
    /// <summary>
    /// Class manager to Environment App, use the dependency injection and the class use singleton pattern
    /// </summary>
    public sealed class EnviromentSetting
    {
        private static readonly EnviromentSetting instance = new EnviromentSetting();
        private static IConfiguration configuration;
        private static IServiceProvider serviceCollection;

        private EnviromentSetting()
        {
            this.ConfigurationBuilder();
            this.ServiceProvider();
        }

        public static EnviromentSetting Intance
        {
            get
            {
                return instance;
            }

        }

        public  IConfiguration Configuration
        {
            get
            {
                return configuration;
            }
        }

        public IServiceProvider Service
        {
            get
            {
                return serviceCollection;
            }
        }

        //Adding the different enviroment settings
        private void ConfigurationBuilder()
        {
            configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();
        }

        //Inject the different class, use the patter UnitOfWork for the Repositories
        private void ServiceProvider()
        {
            var serviceCollection = new ServiceCollection()
              .AddScoped<IStockManager, StockManager>()
              .AddScoped<IFileProcessor, FileProcessor>()
              .AddScoped<IStreamProcessor, StreamProcessor>()
              .AddScoped<IUnitOfWork, UnitOfWork>()
              .AddDbContext<ImportDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var blobAzure = new BlobAzureModel();
            Configuration.Bind("BlobAzure", blobAzure);

            serviceCollection.AddScoped<ISourceRetriever>(x =>
                new SourceRetrieverFromAzure(blobAzure));

            EnviromentSetting.serviceCollection = serviceCollection.BuildServiceProvider();
        }

    }
}

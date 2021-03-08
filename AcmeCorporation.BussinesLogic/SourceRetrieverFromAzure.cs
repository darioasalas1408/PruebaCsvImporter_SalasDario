using AcmeCorporation.BussinesLogic.Interface;
using AcmeCorporation.CsvImporter;
using Azure.Storage.Blobs;
using NLog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic
{
    /// <summary>
    /// Class manager to connect to AZURE
    /// </summary>
    public class SourceRetrieverFromAzure : ISourceRetriever
    {
        private readonly BlobAzureModel blobAzure;
        private static readonly Logger logger = LogManager.GetLogger(typeof(SourceRetrieverFromAzure).FullName);

        public SourceRetrieverFromAzure(BlobAzureModel blobAzureModel)
        {
            this.blobAzure = blobAzureModel; 
        }

        public async Task<(Stream?, long)> RetrieveSourceAsStream()
        {
            try
            {
                logger.Info("Reading from Azure");
                Uri uriAzureBlob = new Uri(blobAzure.Uri);
                BlobServiceClient blobServiceClient = new BlobServiceClient(uriAzureBlob, null);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobAzure.ContainerClient);
                BlobClient blobClient = containerClient.GetBlobClient(blobAzure.BlobClient);

                var response = await blobClient.DownloadAsync();
                return (response.Value.Content, (response.Value.ContentLength - 1));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
            
        }
    }
}

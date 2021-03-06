using AcmeCorporation.BussinesLogic.Interface;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic
{
    /// <summary>
    /// Class to retrieve and process the stream from Azure
    /// </summary>
    public class FileProcessor : IFileProcessor
    {
        private readonly ISourceRetriever sourceRetriever;
        private readonly IStreamProcessor streamProcessor;

        public FileProcessor(ISourceRetriever sourceRetriever, IStreamProcessor streamProcessor)
        {
            this.sourceRetriever = sourceRetriever;
            this.streamProcessor = streamProcessor; 
        }

        public async Task ProcessFile()
        {
            (var sourceStream, var contentLength) = await sourceRetriever.RetrieveSourceAsStream();
            await streamProcessor.ProcessStream(sourceStream, contentLength);
        }
    }
}

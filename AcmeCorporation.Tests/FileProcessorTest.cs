using AcmeCorporation.BussinesLogic;
using AcmeCorporation.BussinesLogic.Interface;
using Moq;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AcmeCorporation.Test
{
    public class FileProcessorTest
    {
        /// <summary>
        /// Basic Test, for check if both method are using only in one times
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Call_Valid_Methods()
        {
            var sourceRetrieverMock = new Mock<ISourceRetriever>();
            var streamProcessorMock = new Mock<IStreamProcessor>();

            var processor = new FileProcessor(sourceRetrieverMock.Object, streamProcessorMock.Object);
            await processor.ProcessFile();

            sourceRetrieverMock.Verify(v => v.RetrieveSourceAsStream(), Times.Once);
            streamProcessorMock.Verify(v => v.ProcessStream(It.IsAny<Stream>(), It.IsAny<long>()), Times.Once);
        }
    }
}

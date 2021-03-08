using System.IO;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic.Interface
{
    public interface IStreamProcessor
    {
        Task ProcessStream(Stream givenStream, long contentLength);
    }
}

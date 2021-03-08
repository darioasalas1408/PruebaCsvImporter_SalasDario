using System.IO;
using System.Threading.Tasks;

namespace AcmeCorporation.BussinesLogic.Interface
{
    public interface ISourceRetriever
    {
        public Task<(Stream?, long)> RetrieveSourceAsStream();
    }
}
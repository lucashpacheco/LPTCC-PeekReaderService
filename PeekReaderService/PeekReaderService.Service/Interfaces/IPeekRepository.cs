using System.Threading.Tasks;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;

namespace PeekReaderService.Service.Interfaces
{
    public interface IPeekRepository
    {
        Task<PeekDocument> Get(GetPeeksRequest getPeeksRequest);

    }
}

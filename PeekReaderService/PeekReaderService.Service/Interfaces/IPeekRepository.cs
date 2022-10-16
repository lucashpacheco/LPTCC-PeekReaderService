using System.Collections.Generic;
using System.Threading.Tasks;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Domain = Peek.Framework.PeekServices.Domain;


namespace PeekReaderService.Service.Interfaces
{
    public interface IPeekRepository
    {
        Task<List<Domain.Peek>> Get(GetPeeksRequest getPeeksRequest);

    }
}

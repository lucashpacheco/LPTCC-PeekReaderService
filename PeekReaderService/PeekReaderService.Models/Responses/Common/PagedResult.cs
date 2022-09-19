using System.Collections.Generic;

namespace PeekReaderService.Models.Responses.Common
{
    public class PagedResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Result { get; set; }
    }
}

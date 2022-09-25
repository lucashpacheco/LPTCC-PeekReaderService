using System.Collections.Generic;

namespace PeekReaderService.Models.Common.Responses
{
    public class PagedResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Result { get; set; }
    }
}

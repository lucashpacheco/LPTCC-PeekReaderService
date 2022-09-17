using System.Collections.Generic;

namespace PeekReaderService.Models.Responses.Common
{
    public class ResponseBase<T>
    {
        public ResponseBase(bool success, List<string> errors, T data)
        {
            this.Success = success;
            this.Errors = errors;
            this.Data = data;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}

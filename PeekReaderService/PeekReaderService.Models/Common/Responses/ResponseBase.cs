using System.Collections.Generic;

namespace PeekReaderService.Models.Common.Responses
{
    public class ResponseBase<T>
    {
        public ResponseBase(bool success, List<string> errors, T data)
        {
            Success = success;
            Errors = errors;
            Data = data;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}

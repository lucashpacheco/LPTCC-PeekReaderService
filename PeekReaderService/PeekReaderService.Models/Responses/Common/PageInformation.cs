using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PeekReaderService.Models.Responses.Common
{
    public class PageInformation
    {
        [JsonIgnore]
        public int Offset
        {
            get
            {
                return (Page - 1) * PageSize;
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a number higher than 0")]
        public int Page { get; set; }

        [Range(10, int.MaxValue, ErrorMessage = "Please enter a number higher than 10")]
        public int PageSize { get; set; }

    }
}

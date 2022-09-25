using System;
using System.ComponentModel.DataAnnotations;
using PeekReaderService.Models.Common.Responses;

namespace PeekReaderService.Models.Consults
{
    public class GetCommentsRequest
    {
        [Required(ErrorMessage = "PeekId is required")]
        public Guid PeekId { get; set; }

        [Required(ErrorMessage = "Page and page size is required")]
        public PageInformation PageInformation { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using PeekReaderService.Models.Responses.Common;

namespace PeekReaderService.Models.Consults
{
    internal class GetPeeksRequest
    {
        [Required(ErrorMessage = "PeekId is required")]
        public Guid PeekId { get; set; }

        [Required(ErrorMessage = "Page and page size is required")]
        public PageInformation PageInformation { get; set; }
    }
}

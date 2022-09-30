using System;
using System.ComponentModel.DataAnnotations;
using PeekReaderService.Models.Common.Responses;

namespace PeekReaderService.Models.Consults
{
    public class GetPeeksRequest
    {
        [Required(ErrorMessage = "UserId is required")]
        public Guid UserId { get; set; }


        [Required(ErrorMessage = "Page and page size is required")]
        public PageInformation PageInformation { get; set; }
    }
}

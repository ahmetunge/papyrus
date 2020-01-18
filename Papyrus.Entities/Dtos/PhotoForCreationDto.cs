using System;
using Microsoft.AspNetCore.Http;

namespace Papyrus.Entities.Dtos
{
    public class PhotoForCreationDto
    {
        public PhotoForCreationDto()
        {
            DateAdded = DateTime.Now;
        }
        public string Url { get; set; }

        public IFormFile File { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
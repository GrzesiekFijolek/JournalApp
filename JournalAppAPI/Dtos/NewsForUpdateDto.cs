using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class NewsForUpdateDto
    {
        public string ShortTitle { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public bool IsImportant { get; set; }
        public string Section { get; set; }
        public IFormFile File { get; set; }
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class NewsParamsDto
    {
        public string Section { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}

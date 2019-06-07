using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string UrlHuge { get; set; } 
        public string UrlLarge { get; set; }
        public string UrlBig { get; set; }
        public string UrlMedium { get; set; }
        public string UrlSmall { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }    

    }
}

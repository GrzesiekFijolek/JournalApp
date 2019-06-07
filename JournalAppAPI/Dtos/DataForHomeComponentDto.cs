using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class DataForHomeComponent
    {
        public List<NewsForHomeDto> ImportantNews { get; set; }
        public List<NewsForHomeDto> SectionPolandNews { get; set; }
        public List<NewsForHomeDto> SectionWorldNews { get; set; }
        public List<NewsForHomeDto> SectionSportNews { get; set; }
        public List<NewsForHomeDto> SectionBusinessNews { get; set; }
        public List<NewsForHomeDto> SectionPolicyNews { get; set; }
        public List<LatestNewsDto> LatestNews { get; set; }
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class DataForNewsDetailsComponentDto
    {
        public NewsForDetailsDto NewsForDetails { get; set; }
        public List<LatestNewsDto> NewsForOtherInfos { get; set; }
    }
}

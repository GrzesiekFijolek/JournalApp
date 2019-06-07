using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Models
{
    public class NewsContent
    {
        [ForeignKey("News")]
        public long NewsId { get; set; }
        public List<string> Paragraphs { get; set; }
        public virtual News News { get; set; }  

        public NewsContent(long id, List<string> list)
        {
            Paragraphs = list;
            NewsId = id;
        }

        public NewsContent(List<string> list)
        {
            Paragraphs = list;
        }

        public NewsContent() { }
    }
}
    
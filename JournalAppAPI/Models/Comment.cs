using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Models
{
    public class Comment
    {   
        public int Id { get; set; }
        public AppUser Author { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; } 
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class CommentForCreateDto
    {
        public int AuthorId { get; set; }
        public string Content { get; set; }
        public int NewsId { get; set; }
    }
}

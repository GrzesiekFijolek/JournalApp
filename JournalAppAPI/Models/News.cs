

using JournalAppAPI.Dtos;
using System;
using System.Collections.Generic;

namespace JournalAppAPI.Models
{
    public class News: IEquatable<News>
    {
        public int Id { get; set; }
        public AppUser Author { get; set; } 
        public int AuthorId { get; set; }
        public string ShortTitle { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string  Content { get; set; }
        public Photo Photo { get; set; }
        public string Section { get; set; } 
        public bool IsImportant { get; set; }
        public DateTime AddedAt { get; set; }
        public List<Comment> Comments { get; set; }

        public News()   
        {
        }

        public bool Equals(News other)
        {
            if (other is null)
                return false;

            return Id == other.Id;
        }
        public override bool Equals(object obj) => Equals(obj as News);
        public override int GetHashCode() => (Id, Section).GetHashCode();

    }
}
    
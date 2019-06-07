using JournalAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string AuthorPhoto { get; set; }

        public static CommentDto Map(Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Author = comment.Author.UserName,
                Content = comment.Content,
                AuthorPhoto = comment.Author.PhotoUrl
            };
        }

        public static List<CommentDto> Map(List<Comment> comments)
        {
            var x = new List<CommentDto>();
            foreach(var item in comments)
            {
                x.Add(Map(item));
            }

            return x;
        }

    }
}

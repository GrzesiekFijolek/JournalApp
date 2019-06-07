using JournalAppAPI.Data;
using JournalAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class NewsForDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public string Section { get; set; }
        public string Author { get; set; }
        public string AuthorPhoto { get; set; }
        public DateTime AddedAt { get; set; }
        public List<CommentDto> Comments { get; set; }

        public static NewsForDetailsDto Map(News news)
        {

            return new NewsForDetailsDto
            {
                Id = news.Id,
                Title = news.Title,
                Heading = news.Heading,
                Content = news.Content,
                PhotoUrl = news.Photo.UrlHuge,
                Section = news.Section,
                Author = news.Author.UserName,
                AuthorPhoto = news.Author.PhotoUrl,
                AddedAt = news.AddedAt,
                Comments = null
            };
        }
    }
}

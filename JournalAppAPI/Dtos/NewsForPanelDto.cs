using JournalAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class NewsForPanelDto
    {
        public int Id { get; set; }
        public string ShortTitle { get; set; }
        public string Section { get; set; }
        public string Author { get; set; }
        public string NewsPhoto { get; set; }
        public string AuthorPhoto { get; set; }

        private static NewsForPanelDto Map(News news)
        {
            return new NewsForPanelDto
            {
                Id = news.Id,
                ShortTitle = news.ShortTitle,
                Section = news.Section,
                Author = news.Author.UserName,
                NewsPhoto = news.Photo.UrlSmall,
                AuthorPhoto = news.Author.PhotoUrl
            };
        }

        public static List<NewsForPanelDto> Map(List<News> news)
        {
            var x = new List<NewsForPanelDto>();
            foreach(var item in news)
            {
                x.Add(Map(item));
            }

            return x;
        }
    }
}
    
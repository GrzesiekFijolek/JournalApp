using JournalAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class NewsForEditDto
    {
        public string ShortTitle { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public bool IsImportant { get; set; }
        public string Section { get; set; }
        public string Photo { get; set; }

        public static NewsForEditDto Map(News news)
        {
            return new NewsForEditDto 
            {
                ShortTitle = news.ShortTitle,
                Title = news.Title,
                Heading = news.Heading,
                Content = news.Content,
                IsImportant = news.IsImportant,
                Section = news.Section,
                Photo = news.Photo.UrlHuge
            };
        }
    }


}

using JournalAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class NewsForHomeDto
    {
        public int Id { get; set; }
        public string ShortTitle { get; set; }
        public string PhotoUrlMedium { get; set; }
        public string PhotoUrlBig { get; set; }
        public string PhotoUrlLarge { get; set; }
        public string PhotoUrlHuge { get; set; }    
        public string Section { get; set; }
        public DateTime AddedAt { get; set; }

        public static NewsForHomeDto Map(News news)
        {
            return new NewsForHomeDto
            {
                Id = news.Id,
                ShortTitle = news.ShortTitle,
                PhotoUrlMedium = news.Photo.UrlMedium,
                PhotoUrlBig = news.Photo.UrlBig,
                PhotoUrlLarge = news.Photo.UrlLarge,
                PhotoUrlHuge = news.Photo.UrlHuge,
                Section = news.Section,
                AddedAt = news.AddedAt
            };
        }

        public static List<NewsForHomeDto> Map(List<News> news)
        {
            var x = new List<NewsForHomeDto>();
            foreach (var item in news)
            {
                x.Add(Map(item));
            }

            return x;
        }

    }
}

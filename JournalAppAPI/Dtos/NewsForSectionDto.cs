using JournalAppAPI.Models;
using System;
using System.Collections.Generic;

namespace JournalAppAPI.Dtos
{
    public class NewsForSectionDto
    {
        public int Id { get; set; }
        public string ShortTitle { get; set; }
        public string PhotoUrl{ get; set; }
        public string Section { get; set; }
        public DateTime AddedAt { get; set; }

        private static NewsForSectionDto Map(News news)
        {
            return new NewsForSectionDto
            {
                Id = news.Id,
                ShortTitle = news.ShortTitle,   
                PhotoUrl= news.Photo.UrlBig,
                Section = news.Section,
                AddedAt = news.AddedAt
            };
        }

        public static List<NewsForSectionDto> Map(List<News> news)
        {
            var x = new List<NewsForSectionDto>();
            foreach(var item in news)
            {
                x.Add(Map(item));
            }

            return x;
        }
    }
}
    
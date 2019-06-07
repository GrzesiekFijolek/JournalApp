using JournalAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class LatestNewsDto
    {
        public long Id { get; set; }
        public DateTime AddedAt { get; set; }
        public string ShortTitle { get; set; }
        public string Section { get; set; }

        public string PhotoUrl { get; set; }

        private static LatestNewsDto Map(News news)
        {
            return new LatestNewsDto()
            {
                Id = news.Id,
                AddedAt = news.AddedAt,
                ShortTitle = news.ShortTitle,
                PhotoUrl = news.Photo.UrlSmall,
                Section = news.Section
            };
        }

        public static List<LatestNewsDto> Map(List<News> news)
        {
            var x = new List<LatestNewsDto>();
            foreach(var item in news)
            {
                x.Add(LatestNewsDto.Map(item));
            }

            return x;
        }
    }
}
    
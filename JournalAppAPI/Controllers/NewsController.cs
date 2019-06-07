using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalAppAPI.Data;
using JournalAppAPI.Dtos;
using JournalAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public NewsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNews(long id)
        {
            News news = await _dbContext.News.Include(u => u.Author).Include(p => p.Photo)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (news != null)
            {
                var newsToReturn = NewsForDetailsDto.Map(news);

                List<Comment> comments = await _dbContext.Comments.Include(a => a.Author)
                    .Where(c => c.NewsId == id).ToListAsync();

                var commentsToReturn = CommentDto.Map(comments);
                newsToReturn.Comments = commentsToReturn;
      
                List<News> x = await _dbContext.News.Include(p => p.Photo)
                    .Where(s => s.Section == newsToReturn.Section && s.Id != id)
                    .OrderByDescending(z => z.AddedAt).ToListAsync();
                List<LatestNewsDto> otherInfotoReturn = LatestNewsDto.Map(x.Take(5).ToList());

                return Ok(new DataForNewsDetailsComponentDto
                {
                    NewsForDetails = newsToReturn,
                    NewsForOtherInfos = otherInfotoReturn
                });
            }
            else return NoContent();
        }

        [HttpGet("home")]
        public async Task<IActionResult> GetLatestNews()
        {
            var iNews = await _dbContext.News.Include(p => p.Photo).Where(inews => inews.IsImportant == true).OrderByDescending(x => x.AddedAt).ToListAsync();
            var importantNewsFromAllSections = iNews.Take(7).ToList();
            var importantNewsToReturn = NewsForHomeDto.Map(importantNewsFromAllSections).ToList();


            var polandNews = await GetNewsForHomeComponent("poland", importantNewsFromAllSections);
            var policyNews = await GetNewsForHomeComponent("policy", importantNewsFromAllSections);
            var sportNews = await GetNewsForHomeComponent("sport", importantNewsFromAllSections);
            var businessNews = await GetNewsForHomeComponent("business", importantNewsFromAllSections);
            var worldNews = await GetNewsForHomeComponent("world", importantNewsFromAllSections);

            var lNews = await _dbContext.News.Include(p => p.Photo).OrderByDescending(x => x.AddedAt).ToListAsync();
            var latestNews = LatestNewsDto.Map(lNews.Take(30).ToList());

            var dataToReturn = new DataForHomeComponent()
            {
                ImportantNews = importantNewsToReturn,
                SectionPolandNews = polandNews,
                SectionBusinessNews = businessNews,
                SectionPolicyNews = policyNews,
                SectionSportNews = sportNews,
                SectionWorldNews = worldNews,
                LatestNews = latestNews
            };

            return Ok(dataToReturn);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetNews([FromQuery] NewsParamsDto newsParams)
        {
            List<News> newsFromRepo = await _dbContext.News.Include(p => p.Photo)
                .Where(n => n.Section == newsParams.Section.ToString())
                .OrderByDescending(n => n.AddedAt).ToListAsync();

            if (newsFromRepo.Any())
            {
                if (Int32.TryParse(newsParams.PageSize.ToString(), out int size) && Int32.TryParse(newsParams.PageNumber.ToString(), out int part))
                {
                    var temp = newsFromRepo.Skip(part * size).Take(size).ToList();
                    List<NewsForSectionDto> newsToReturn = NewsForSectionDto.Map(temp);

                    if (newsToReturn == null) return Ok();

                    return Ok(newsToReturn);
                }
                else throw new Exception("invalid params");
            }
            else return NoContent();
        }

       

        private async Task<List<NewsForHomeDto>> GetNewsForHomeComponent(string section, List<News> importantNewsFromAllSections)
        {
            var news = await _dbContext.News.Include(p => p.Photo)
                .Where(n => n.Section == section).OrderByDescending(x => x.AddedAt).ToListAsync();

            var importantNewsFromThisSection = news.Except(importantNewsFromAllSections).
                Where(n => n.IsImportant == true).Take(2).ToList();

            var newsToReturn = new List<NewsForHomeDto>();
            
            foreach(var item in importantNewsFromThisSection)
            {
                newsToReturn.Add(NewsForHomeDto.Map(item));
            }
            var importantNewsCount = importantNewsFromThisSection.Count();

            int numberOfLatestNews;

            if (importantNewsCount == 2) numberOfLatestNews = 4;
            else if (importantNewsCount == 1) numberOfLatestNews = 5;
            else numberOfLatestNews = 6;

            var otherLatestNews = await _dbContext.News.Include(p => p.Photo)
                .Where(s => s.Section == section).Except(importantNewsFromThisSection)
                .OrderByDescending(x => x.AddedAt)
                .Take(numberOfLatestNews).ToListAsync();

            foreach(var item in otherLatestNews)
            {
                newsToReturn.Add(NewsForHomeDto.Map(item));
            }

            return newsToReturn;
        }

    }
}

    
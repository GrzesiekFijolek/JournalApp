using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using JournalAppAPI.Data;
using JournalAppAPI.Dtos;
using JournalAppAPI.Helpers;
using JournalAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JournalAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy ="RequireModeratorRole")]
    [AllowAnonymous]
    public class ModeratorController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IOptions<CloudinarySettings> _cloudinaryOptions;
        private Cloudinary _cloudinary;

        public ModeratorController(AppDbContext dbContext, IOptions<CloudinarySettings> cloudinaryOptions)
        {
            _dbContext = dbContext;
            _cloudinaryOptions = cloudinaryOptions;
            Account acc = new Account(
             _cloudinaryOptions.Value.CloudName,
             _cloudinaryOptions.Value.ApiKey,
             _cloudinaryOptions.Value.ApiSecret
           );
            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetNews([FromQuery] NewsParamsDto newsParams)
        {
            var newsFromRepo = await _dbContext.News.Include(a => a.Author)
                .Include(p => p.Photo).OrderByDescending(x => x.AddedAt).ToListAsync();

            if (newsParams.Section != "all")
            {
                newsFromRepo = newsFromRepo.Where(s => s.Section == newsParams.Section).ToList();
            }

            if (newsFromRepo.Any())
            {
                if (Int32.TryParse(newsParams.PageSize.ToString(), out int size) && Int32.TryParse(newsParams.PageNumber.ToString(), out int part))
                {
                    List<NewsForPanelDto> newsToReturn = NewsForPanelDto.Map(newsFromRepo.Skip(part * size).Take(size).ToList());

                    return Ok(newsToReturn);
                }
                else throw new Exception("invalid params");
            }
            else return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var news = await _dbContext.News.FirstOrDefaultAsync(n => n.Id == id);

            if (news == null)
                return BadRequest("no news found");

            _dbContext.News.Remove(news);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNews([FromForm] NewsForCreateDto newsForCreation)
        {
            var file = newsForCreation.File;

            var photo = await UploadPhoto(file);

            if (photo == null)
                return BadRequest("failed to upload photo");

            var news = new News()
            {
                AuthorId = newsForCreation.AuthorId,
                AddedAt = DateTime.Now,
                Content = newsForCreation.Content,
                Heading = newsForCreation.Heading,
                ShortTitle = newsForCreation.ShortTitle,
                Title = newsForCreation.Title,
                IsImportant = newsForCreation.IsImportant,
                Section = newsForCreation.Section,
                Photo = photo
            };

            await _dbContext.News.AddAsync(news);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("newstoedit/{id}")]
        public async Task<IActionResult> GetNewsToEdit(int id)
        {
            var newsFromRepo = await _dbContext.News.Include(p => p.Photo).FirstOrDefaultAsync(n => n.Id == id);

            var newsToRetun = NewsForEditDto.Map(newsFromRepo);

            return Ok(newsToRetun);
        }

        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> EditNews(int id, [FromForm] NewsForUpdateDto newsForUpdate)
        {
            var news = await _dbContext.News.Include(p => p.Photo).FirstOrDefaultAsync(n => n.Id == id);

            if (news == null)
                return BadRequest("no news found");
            else
            {
                news.Heading = newsForUpdate.Heading;
                news.Title = newsForUpdate.Title;
                news.ShortTitle = newsForUpdate.ShortTitle;
                news.IsImportant = newsForUpdate.IsImportant;
                news.Section = newsForUpdate.Section;
                news.Content = newsForUpdate.Content;

                if (newsForUpdate.File != null)
                {
                    var photo = await UploadPhoto(newsForUpdate.File);

                    if (photo == null)
                        return BadRequest("failed to upload photo");

                    news.Photo.UrlBig = photo.UrlBig;
                    news.Photo.UrlHuge = photo.UrlHuge;
                    news.Photo.UrlLarge = photo.UrlLarge;
                    news.Photo.UrlMedium = photo.UrlMedium;
                    news.Photo.UrlSmall = photo.UrlSmall;
                }
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("comment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
                return BadRequest("comment not found");

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

           return NoContent();
        }

        [HttpPost("addcomment")]
        public async Task<IActionResult> AddComment([FromBody] CommentForCreateDto commentForCreate)
        {
            if (commentForCreate == null)
                return BadRequest("input was not valid");

            var comment = new Comment
            {
                NewsId = commentForCreate.NewsId,
                AuthorId = commentForCreate.AuthorId,
                Content = commentForCreate.Content
            };

            var x = _dbContext.Add<Comment>(comment);
            await _dbContext.SaveChangesAsync();

            var commentsFromRepo = await _dbContext.Comments.Include(a => a.Author)
                .Where(n => n.NewsId == comment.NewsId).ToListAsync();

            var commentFromRepo = commentsFromRepo.TakeLast(1).FirstOrDefault();

            var commentToReturn = CommentDto.Map(commentFromRepo);

            return Ok(commentToReturn);
        }

        private async Task<Photo> UploadPhoto(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            string url;

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Folder = "journalApp"
                    };

                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
                url = uploadResult.Uri.ToString();

                string photoUrl = url.Replace(CloudinarySettings.url, "");
                CloudinarySettings.Transformations(photoUrl, out string urlHuge, out string urlLarge,
                                                        out string urlBig, out string urlMedium, out string urlSmall);

                return new Photo
                {
                    UrlHuge = urlHuge,
                    UrlLarge = urlLarge,
                    UrlBig = urlBig,
                    UrlMedium = urlMedium,
                    UrlSmall = urlSmall
                };
            }

            else return null;
        }
    }
}
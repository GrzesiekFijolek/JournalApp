using JournalAppAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using Faker;
using JournalAppAPI.Helpers;

namespace JournalAppAPI.Data
{
    public class Seed
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly AppDbContext _dbContext;

        public Seed(UserManager<AppUser> userManager, RoleManager<Role> roleManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public void InitializeUsers()
        {
            if (!_userManager.Users.Any())
            {
                var roles = new List<Role>
                {
                    new Role {Name = "User"},
                    new Role {Name = "Moderator"},
                    new Role {Name = "Admin"}
                };

                foreach(var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                var url = "https://randomuser.me/api/portraits/";


                var admin = new AppUser()
                {
                    UserName = "Admin",
                    PhotoUrl = url + "men/54.jpg"
                };
                _userManager.CreateAsync(admin, "Password123").Wait();
                _userManager.AddToRoleAsync(admin, "User").Wait();
                _userManager.AddToRoleAsync(admin, "Moderator").Wait();
                _userManager.AddToRoleAsync(admin, "Admin").Wait();

                var moderator = new AppUser()
                {
                    UserName = "Moderator",
                    PhotoUrl = url + "men/2.jpg"
                };
                _userManager.CreateAsync(moderator, "Password123").Wait();
                _userManager.AddToRoleAsync(moderator, "User").Wait();
                _userManager.AddToRoleAsync(moderator, "Moderator").Wait();

                var moderator2 = new AppUser()
                {
                    UserName = "Eva Jarvis",
                    PhotoUrl = url + "women/1.jpg"
                };
                _userManager.CreateAsync(moderator2, "Password123").Wait();
                _userManager.AddToRoleAsync(moderator2, "User").Wait();
                _userManager.AddToRoleAsync(moderator2, "Moderator").Wait();

                var moderator3 = new AppUser()
                {
                    UserName = "Sam Mitchell",
                    PhotoUrl = url + "men/3.jpg"
                };
                _userManager.CreateAsync(moderator3, "Password123").Wait();
                _userManager.AddToRoleAsync(moderator3, "User").Wait();
                _userManager.AddToRoleAsync(moderator3, "Moderator").Wait();

                var moderator4 = new AppUser()
                {
                    UserName = "Connor Moss",
                    PhotoUrl = url + "men/4.jpg"
                };
                _userManager.CreateAsync(moderator4, "Password123").Wait();
                _userManager.AddToRoleAsync(moderator4, "User").Wait();
                _userManager.AddToRoleAsync(moderator4, "Moderator").Wait();

                var user1 = new AppUser()
                {
                    UserName = "Tia",
                    PhotoUrl = url + "women/2.jpg"
                };
                _userManager.CreateAsync(user1, "Password123").Wait();
                _userManager.AddToRoleAsync(user1, "User").Wait();

                var user2 = new AppUser()
                {
                    UserName = "Scarlett",
                    PhotoUrl = url + "women/3.jpg"
                };
                _userManager.CreateAsync(user2, "Password123").Wait();
                _userManager.AddToRoleAsync(user2, "User").Wait();

                var user3 = new AppUser()
                {
                    UserName = "Linda",
                    PhotoUrl = url + "women/4.jpg"
                };
                _userManager.CreateAsync(user3, "Password123").Wait();
                _userManager.AddToRoleAsync(user3, "User").Wait();

                var user4 = new AppUser()
                {
                    UserName = "Judy",
                    PhotoUrl = url + "women/5.jpg"
                };
                _userManager.CreateAsync(user4, "Password123").Wait();
                _userManager.AddToRoleAsync(user4, "User").Wait();

                var user5 = new AppUser()
                {
                    UserName = "Eva",
                    PhotoUrl = url + "women/6.jpg"
                };
                _userManager.CreateAsync(user5, "Password123").Wait();
                _userManager.AddToRoleAsync(user5, "User").Wait();

                var user6 = new AppUser()
                {
                    UserName = "Amelie",
                    PhotoUrl = url + "women/7.jpg"
                };
                _userManager.CreateAsync(user6, "Password123").Wait();
                _userManager.AddToRoleAsync(user6, "User").Wait();

                var user7 = new AppUser()
                {
                    UserName = "Chelsea",
                    PhotoUrl = url + "women/8.jpg"
                };
                _userManager.CreateAsync(user7, "Password123").Wait();
                _userManager.AddToRoleAsync(user7, "User").Wait();

                var user8 = new AppUser()
                {
                    UserName = "Bethany",
                    PhotoUrl = url + "women/9.jpg"
                };
                _userManager.CreateAsync(user8, "Password123").Wait();
                _userManager.AddToRoleAsync(user8, "User").Wait();

                var user9 = new AppUser()
                {
                    UserName = "Madison",
                    PhotoUrl = url + "women/10.jpg"
                };
                _userManager.CreateAsync(user9, "Password123").Wait();
                _userManager.AddToRoleAsync(user9, "User").Wait();


                var user10 = new AppUser()
                {
                    UserName = "Tom",
                    PhotoUrl = url + "men/5.jpg"
                };
                _userManager.CreateAsync(user10, "Password123").Wait();
                _userManager.AddToRoleAsync(user10, "User").Wait();

                var user11 = new AppUser()
                {
                    UserName = "Andrew",
                    PhotoUrl = url + "men/6.jpg"
                };
                _userManager.CreateAsync(user11, "Password123").Wait();
                _userManager.AddToRoleAsync(user11, "User").Wait();

                var user12 = new AppUser()
                {
                    UserName = "Henry",
                    PhotoUrl = url + "men/7.jpg"
                };
                _userManager.CreateAsync(user12, "Password123").Wait();
                _userManager.AddToRoleAsync(user12, "User").Wait();

                var user13 = new AppUser()
                {
                    UserName = "Alfie",
                    PhotoUrl = url + "men/8.jpg"
                };
                _userManager.CreateAsync(user13, "Password123").Wait();
                _userManager.AddToRoleAsync(user13, "User").Wait();

                var user14 = new AppUser()
                {
                    UserName = "Samuel",
                    PhotoUrl = url + "men/9.jpg"
                };
                _userManager.CreateAsync(user14, "Password123").Wait();
                _userManager.AddToRoleAsync(user14, "User").Wait();

                var user15 = new AppUser()
                {
                    UserName = "Leo Wyatt",
                    PhotoUrl = url + "men/10.jpg"
                };
                _userManager.CreateAsync(user15, "Password123").Wait();
                _userManager.AddToRoleAsync(user15, "User").Wait();

            }
        }

        public void InitializeNews()
        {
            if (!_dbContext.News.Any())
            {
                News news;
                int numberOfDummyNews = 150;
                Random r = new Random();
                DateTime dateTime = new DateTime(2019, 04, 01, 0, 0, 0);
                List<string> sections = new List<string>() { "poland", "sport", "business", "world", "policy" };

                CloudinarySettings.Transformations(_dummyPhoto, out string urlHuge, out string urlLarge,
                                                        out string urlBig, out string urlMedium, out string urlSmall);

                for (int i = 0; i < numberOfDummyNews; i++)
                {
                    dateTime = dateTime.Add(new TimeSpan(days: 0, hours: r.Next(0, 15), minutes: r.Next(0, 100), seconds: r.Next(0, 100)));

                    string title;
                    do
                    {
                        title = Lorem.Sentence(6);
                    } while (title.Length < 35);

                    string shortTitle;
                    do
                    {
                        shortTitle = Lorem.Sentence(5);
                    } while (shortTitle.Length < 25);

                    news = new News()
                    {
                        ShortTitle = shortTitle,
                        Title = title,
                        Heading = Lorem.Sentence(11),
                        Content = Lorem.Paragraph(35),
                        Section = sections[r.Next(0, 5)],
                        AddedAt = dateTime,
                        IsImportant = r.Next(0, 7) > 2 ? true : false,
                        AuthorId = r.Next(2, 7)
                    };

                    var photo = new Photo()
                    {
                        UrlHuge = urlHuge,
                        UrlLarge = urlLarge,
                        UrlBig = urlBig,
                        UrlMedium = urlMedium,
                        UrlSmall = urlSmall,
                        NewsId = i,
                        News = news
                    };

                    var comments = new List<Comment>();

                    var x = r.Next(0, 10) - 4;
                    if (x > 0)
                    {
                        for (int z = 0; z < x; z++)
                        {
                            var comment = new Comment()
                            {
                                AuthorId = r.Next(5, 20),
                                Content = Lorem.Sentence(12),
                                NewsId = i,
                                News = news
                            };
                            _dbContext.Add<Comment>(comment);
                            comments.Add(comment);
                        }
                    }

                    news.Photo = photo;
                    news.Comments = comments;

                    _dbContext.Add<News>(news);
                    _dbContext.Add<Photo>(photo);
                }

                AddNews("policy", _policyImgs, dateTime);
                AddNews("poland", _polandImgs, dateTime);
                AddNews("world", _worldImgs, dateTime);
                AddNews("business", _businessImgs, dateTime);
                AddNews("sport", _sportImgs, dateTime);

                _dbContext.SaveChanges();
            }

        }

        private void AddNews(string section, List<string> imgs, DateTime dateTime)
        {
            News news;
            int numberOfDummyNews = 10;
            Random r = new Random();
            imgs.Shuffle();

            for (int i = 0; i < numberOfDummyNews; i++)
            {
                dateTime = dateTime.Add(new TimeSpan(days: 0, hours: r.Next(0, 15), minutes: r.Next(0, 100), seconds: r.Next(0, 100)));

                string title;
                do
                {
                    title = Lorem.Sentence(6);
                } while (title.Length < 35);

                string shortTitle;
                do
                {
                    shortTitle = Lorem.Sentence(5);
                } while (shortTitle.Length < 25);

                news = new News()
                {
                    ShortTitle = shortTitle,
                    Title = title,
                    Heading = Lorem.Sentence(11),
                    Content = Lorem.Paragraph(35),
                    Section = section,
                    AddedAt = dateTime,
                    IsImportant = true,
                    AuthorId = r.Next(2, 7)
                };

                CloudinarySettings.Transformations(imgs[i], out string urlHuge, out string urlLarge,
                                                    out string urlBig, out string urlMedium, out string urlSmall);

                var photo = new Photo()
                {
                    UrlHuge = urlHuge,
                    UrlLarge = urlLarge,
                    UrlBig = urlBig,
                    UrlMedium = urlMedium,
                    UrlSmall = urlSmall,
                    NewsId = i,
                    News = news
                };

                var comments = new List<Comment>();

                var x = r.Next(0, 10) - 4;
                if (x > 0)
                {
                    for (int z = 0; z < x; z++)
                    {
                        var comment = new Comment()
                        {
                            AuthorId = r.Next(5, 20),
                            Content = Lorem.Sentence(12),
                            NewsId = i,
                            News = news
                        };
                        _dbContext.Add<Comment>(comment);
                        comments.Add(comment);
                    }
                }

                news.Photo = photo;
                news.Comments = comments;

                _dbContext.Add<News>(news);
                _dbContext.Add<Photo>(photo);
            }
        }

        private  List<string> _policyImgs = new List<string>()
        {
            "v1559839428/journalApp/policy/p5.jpg",
            "v1559839418/journalApp/policy/p1.jpg",
            "v1559839415/journalApp/policy/p2.jpg",
            "v1559839401/journalApp/policy/p9.jpg",
            "v1559839405/journalApp/policy/p3.jpg",
            "v1559839399/journalApp/policy/p8.jpg",
            "v1559839398/journalApp/policy/p6.jpg",
            "v1559839398/journalApp/policy/p10.jpg",
            "v1559839398/journalApp/policy/p7.jpg",
            "v1559839388/journalApp/policy/p4.jpg"
        };

        private  List<string> _polandImgs = new List<string>()
        {
            "v1559859392/journalApp/poland/s7.jpg",
            "v1559859391/journalApp/poland/p1.jpg",
            "v1559859391/journalApp/poland/p2.jpg",
            "v1559859391/journalApp/poland/p4.jpg",
            "v1559859391/journalApp/poland/p0.jpg",
            "v1559859391/journalApp/poland/s8.jpg",
            "v1559859391/journalApp/poland/p3.jpg",
            "v1559859390/journalApp/poland/p6.jpg",
            "v1559859390/journalApp/poland/p9.jpg",
            "v1559859390/journalApp/poland/p5.jpg"
        };

        private  List<string> _sportImgs = new List<string>()
        {
            "v1559858474/journalApp/sport/s1.jpg",
            "v1559858474/journalApp/sport/s9.jpg",
            "v1559858473/journalApp/sport/s8.jpg",
            "v1559858473/journalApp/sport/s0.jpg",
            "v1559858473/journalApp/sport/s5.jpg",
            "v1559858473/journalApp/sport/s4.jpg",
            "v1559858473/journalApp/sport/s2.jpg",
            "v1559858473/journalApp/sport/s7.jpg",
            "v1559858473/journalApp/sport/s6.jpg",
            "v1559858473/journalApp/sport/s3.jpg"
        };

        private List<string> _worldImgs = new List<string>()
        {
            "v1559860736/journalApp/world/w6.png",
            "v1559860735/journalApp/world/w0.png",
            "v1559860735/journalApp/world/w9.jpg",
            "v1559860735/journalApp/world/w8.jpg",
            "v1559860735/journalApp/world/w1.jpg",
            "v1559860735/journalApp/world/w5.jpg",
            "v1559860735/journalApp/world/w4.jpg",
            "v1559860735/journalApp/world/w2.jpg",
            "v1559860735/journalApp/world/w7.jpg",
            "v1559860734/journalApp/world/w3.jpg"
        };

        private List<string> _businessImgs = new List<string>()
        {
            "v1559860066/journalApp/business/b9.png",
            "v1559860063/journalApp/business/b7.jpg",
            "v1559860063/journalApp/business/b8.jpg",
            "v1559860063/journalApp/business/b4.jpg",
            "v1559860063/journalApp/business/b6.jpg",
            "v1559860062/journalApp/business/b5.jpg",
            "v1559860062/journalApp/business/b3.jpg",
            "v1559860062/journalApp/business/b0.jpg",
            "v1559860062/journalApp/business/b2.jpg",
            "v1559860062/journalApp/business/b1.jpg"
        };


        private string _dummyPhoto = "v1559840438/journalApp/dummy.png";


    }
}

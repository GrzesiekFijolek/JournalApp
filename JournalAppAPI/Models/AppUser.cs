using JournalAppAPI.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Models
{
    public class AppUser : IdentityUser<int>
    {
        //public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Comment> Comments { get; set; }  

        public static AppUser Map(UserForRegisterDto userForRegisterDto, string photoUrl)
        {
            return new AppUser
            {
                UserName = userForRegisterDto.Username,
                PhotoUrl = photoUrl
            };
        }
    }   
}
        
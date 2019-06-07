using JournalAppAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Dtos
{
    public class UserForAdminPanelDto
    { 

        public string Username { get; set; }
        public IList<string> UserRoles { get; set; }
        public string Photo { get; set; }
    }
}

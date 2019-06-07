
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public Role Role { get; set; }
    }
}
    
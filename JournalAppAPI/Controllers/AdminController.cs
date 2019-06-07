using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalAppAPI.Data;
using JournalAppAPI.Dtos;
using JournalAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy ="RequireAdminRole")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(AppDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUserList([FromQuery] AdminParams adminParams)
        {
            var usersFromRepo = await _dbContext.Users.Include(u => u.UserRoles).ToListAsync();

            if (usersFromRepo.Any())
            {
                if (Int32.TryParse(adminParams.PageSize.ToString(), out int size) && Int32.TryParse(adminParams.PageNumber.ToString(), out int part))
                {
                    var usersToReturn = usersFromRepo.Skip(part * size).Take(size).Select(x => new UserForAdminPanelDto
                    {
                        Username = x.UserName,
                        UserRoles = _userManager.GetRolesAsync(x).Result,
                        Photo = x.PhotoUrl
                    });

                    return Ok(usersToReturn);
                }
                else throw new Exception("invalid params");
            }

            else return NoContent();
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            if (username == "Admin")
                return BadRequest("you cannot delete the admin");

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null) return BadRequest("no user found");

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("editroles/{username}")]
        public async Task<IActionResult> EditRoles(string username, RolesDto roles)
        {
            var user = await _userManager.FindByNameAsync(username);
            var currentRoles = _userManager.GetRolesAsync(user);
            
            if(roles.isAdmin && !currentRoles.Result.Contains("Admin"))
            {
               var result = await _userManager.AddToRoleAsync(user, "Admin");
               if (!result.Succeeded)
                    return BadRequest("Failed to add admin role");
            }
            else if(!roles.isAdmin && currentRoles.Result.Contains("Admin"))
            {
                var result = await _userManager.RemoveFromRoleAsync(user, "Admin");
                if (!result.Succeeded)
                    return BadRequest("Failed to remove admin role");
            }

            if(roles.isModerator && !currentRoles.Result.Contains("Moderator"))
            {
                var result = await _userManager.AddToRoleAsync(user, "Moderator");
                if (!result.Succeeded)
                    return BadRequest("Failed to add moderator role");
            }
            else if(!roles.isModerator && currentRoles.Result.Contains("Moderator"))
            {
                var result = await _userManager.RemoveFromRoleAsync(user, "Moderator");
                if (!result.Succeeded)
                    return BadRequest("Failed to remove moderator role");
            }

            var x = await _userManager.GetRolesAsync(user);
            return Ok(x);
        }

    }
}
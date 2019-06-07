using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalAppAPI.Dtos;
using JournalAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using JournalAppAPI.Helpers;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace JournalAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;
        private readonly IConfiguration _configuration;
        private readonly IOptions<CloudinarySettings> _cloudinaryOptions;
        private readonly int _minUsernameLength = 3;
        private readonly int _maxUsernameLength = 30;
        private Cloudinary _cloudinary;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            IConfiguration configuration, IOptions<CloudinarySettings> cloudinaryOptions)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _configuration = configuration;
            _cloudinaryOptions = cloudinaryOptions;

            Account acc = new Account(
              _cloudinaryOptions.Value.CloudName,
              _cloudinaryOptions.Value.ApiKey,
              _cloudinaryOptions.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
            if (user != null)
            {
                var result = await _singInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

                if (result.Succeeded)
                {
                    var userForReturn = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == userForLoginDto.Username.ToUpper());

                    return Ok(new
                    {
                        token = GenerateToken(user).Result,
                        username = userForReturn.UserName,
                        photo = userForReturn.PhotoUrl
                    });

                }

                return Unauthorized();
            }

            return Unauthorized();
            
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserForRegisterDto userForRegisterDto)
        {
            if (!checkUsernameMinlength(userForRegisterDto.Username))
                throw new Exception("username must be at least " + _minUsernameLength.ToString() + " characters");

            if (!checkUsernameMaxlength(userForRegisterDto.Username))
                throw new Exception("username must be at most " + _maxUsernameLength.ToString() + " characters");

            var file = userForRegisterDto.File;
            var uploadResult = new ImageUploadResult();
            string photoUrl;

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = Extensions.SquareTransformation(),
                        Folder = "journalApp"
                    };

                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }

                photoUrl = uploadResult.Uri.ToString();

                var userToCreate = AppUser.Map(userForRegisterDto, photoUrl);

                var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);
                if (result.Succeeded)
                {
                    return Ok();
                }

                return BadRequest(result.Errors);
            }

            else throw new Exception("nie znaleziono fotografii");
        }

        private async Task<string> GenerateToken(AppUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credencials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private bool checkUsernameMinlength(string username)
        {
            if (username.Length < _minUsernameLength)
                return false;

            return true;
        }

        private bool checkUsernameMaxlength(string username)
        {
            if (username.Length > _maxUsernameLength)
                return false;

            return true;
        }

    }
}
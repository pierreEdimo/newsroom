using findaDoctor.DTO;
using findaDoctor.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using findaDoctor.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace findaDoctor.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _context; 

        public UserController(UserManager<UserEntity> userManager,
                              SignInManager<UserEntity> signInManager,
                              IConfiguration configuration,
                              DatabaseContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context; 
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            using (var Context = new DatabaseContext())
            {
                return await _userManager.Users.ToListAsync();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDTo modelLogin)
        {
            var user = await _userManager.FindByEmailAsync(modelLogin.Email);

            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, modelLogin.Password, false, false);

                if (signInResult.Succeeded)
                {
                    var loggedUser = _userManager.Users.SingleOrDefault(u => u.Email == modelLogin.Email);
                    return GenerateJwtToken(modelLogin.Email, loggedUser);
                }
            }

            throw new ApplicationException("UNKNOWN_ERROR");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Register([FromBody] RegisterDTo model)
        {
            var user = new UserEntity
            {

                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                location = model.location,
                city = model.city,
                country = model.country,
                poBox = model.poBox,
                Email = model.Email,
                firstName = model.firstName,
                lastName = model.lastName

            };

            var result = await _userManager.CreateAsync(user, model.passWord);

            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(user, model.passWord, false, false);
                return GenerateJwtToken(model.Email, user);
            }

            throw new ApplicationException("UNKNOWN_ERROR");
        }


        private object GenerateJwtToken(string email, UserEntity user)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(1));

            var token = new JwtSecurityToken(
                 _configuration["JwtIssuer"],
                 _configuration["JwtIssuer"],
                 claims,
                 expires: expires,
                 signingCredentials: credentials
                 );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<ActionResult<FavoriteDoctorDTo>> GetFavoriteDoctor(int Id)
        {
            var favorite = await _context.FavoriteDoctors.FindAsync(Id);

            if(favorite == null)
            {
                return NotFound(); 
            }

            return favoriteDoctorToDTo(favorite);
        }


        [HttpPost]
        public async Task<ActionResult<FavoriteDoctorDTo>> addFavorteDoctor(FavoriteDoctorDTo favoriteDoctor)
        {
            var favorite = new FavoriteDoctor
            {
                userId = favoriteDoctor.userId, 
                doctorId = favoriteDoctor.doctorId
            };

            _context.FavoriteDoctors.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavoriteDoctor), new { id = favorite.Id }, favoriteDoctorToDTo(favorite)); 
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFavoriteDoctor(int Id)
        {
            var favorite = await _context.FavoriteDoctors.FindAsync(Id);
            if (favorite == null)
            {
                return NotFound(); 
            }
            _context.FavoriteDoctors.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        public static FavoriteDoctorDTo favoriteDoctorToDTo(FavoriteDoctor favorite) => new FavoriteDoctorDTo
        {
            Id = favorite.Id,
            userId = favorite.userId,
            doctorId = favorite.doctorId,
            Doctor = favorite.Doctor,
            UserPatient = favorite.UserPatient
        };


        public async Task<ActionResult<FavoriteArticleDTo>> GetFavoriteArticle(int Id)
        {
            var favorite = await _context.FavoriteeArticles.FindAsync(Id); 
            if(favorite == null)
            {
                return NotFound(); 
            }
            return favoriteArticleToDTo(favorite); 
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteArticleDTo>> addFavoriteArticle(FavoriteArticleDTo favorite)
        {
            var favoriteArticle = new FavoriteArticle
            {
                userId = favorite.userId,
                articleId = favorite.articleId
            };

            _context.FavoriteeArticles.Add(favoriteArticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavoriteArticle), new { id = favoriteArticle.Id }, favoriteArticleToDTo(favoriteArticle)); 
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFavoriteArticle(int Id)
        {
            var favoriteArticle = await _context.FavoriteeArticles.FindAsync(Id); 
            if(favoriteArticle == null)
            {
                return NotFound(); 
            }

            _context.FavoriteeArticles.Remove(favoriteArticle);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        public static FavoriteArticleDTo favoriteArticleToDTo(FavoriteArticle favorite) => new FavoriteArticleDTo
        {
            Id = favorite.Id,
            userId = favorite.userId,
            articleId = favorite.articleId,
            Article = favorite.Article,
            UserEntity = favorite.UserEntity
        }; 


    }
}

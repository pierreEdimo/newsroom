using newsroom.DTO;
using newsroom.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using newsroom.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AutoMapper; 


namespace newsroom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper; 
        private readonly DatabaseContext _context;


        public UserController(UserManager<UserEntity> userManager,
                              SignInManager<UserEntity> signInManager,
                              IConfiguration configuration,
                              IMapper mapper,
                              DatabaseContext context
                              )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
            _mapper = mapper; 

        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserToken>> updateEmail([FromBody] UpdateEmailDTO emailDTO )
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;;

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return NotFound(); 

            user.Email = emailDTO.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var loggedUser = await _userManager.FindByEmailAsync(emailDTO.Email);

            return GenerateJwtToken(loggedUser.Email, loggedUser); 
         }

        [AllowAnonymous]
        [HttpGet(Name = nameof(GetAllUsers))]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            using (var Context = new DatabaseContext())
            {
               var users = await _userManager.Users.ToListAsync();

                return _mapper.Map<List<UserDTO>>(users); 
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginDTo modelLogin)
        {
            var user = await _userManager.FindByEmailAsync(modelLogin.email);

            if (user == null) return NotFound();

            var result = await _signInManager.PasswordSignInAsync(user, modelLogin.password, false, false);

            if (!result.Succeeded) return BadRequest("Invalid Login");

            return GenerateJwtToken(modelLogin.email, user); 
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserToken>> Register([FromBody] RegisterDTo model)
        {
            var user = new UserEntity
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.passWord);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return GenerateJwtToken(model.Email, user); 
        }


        private UserToken GenerateJwtToken(string email, UserEntity user)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                 _configuration["JwtIssuer"],
                 _configuration["JwtIssuer"],
                 claims,
                 signingCredentials: credentials
                 );

            var loggedUserDto = _mapper.Map<UserDTO>(user);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserDto = loggedUserDto
            }; 

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserToken>> ForgotPassWord([FromBody] LoginDTo login)
        {
            var user = await _userManager.FindByEmailAsync(login.email);

            if (user == null) return NotFound();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, login.password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _signInManager.PasswordSignInAsync(user, login.password, false, false);

            return GenerateJwtToken(login.email, user); 
        }

    }
}

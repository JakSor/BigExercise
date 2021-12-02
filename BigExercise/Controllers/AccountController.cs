using Domain;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BigExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccountController : ControllerBase
    {
        private SignInManager<WebShopUser> _signInManager;
        private UserManager<WebShopUser> _userManager;
        private IConfiguration _config;

        public AccountController(UserManager<WebShopUser> userManager, IConfiguration configuration,SignInManager<WebShopUser> sign)
        {
            _signInManager = sign;
            _userManager = userManager;
            _config = configuration;
        }
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] WebShopUserDTO dto)
        {
            var user = new WebShopUser {  PasswordHash = dto.Password, UserName = dto.UserName};
             var result = _userManager.CreateAsync(user, dto.Password);
            if (!result.Result.Succeeded)
            {
                return BadRequest(result.Result.Errors);
            }

            return Ok();
        }

        [HttpPost, Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] WebShopUserDTO user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, false);
            if (loginResult.Succeeded)
            {
                var applicationUser = _signInManager.UserManager.FindByNameAsync(user.UserName).GetAwaiter().GetResult();
                var claims = await _signInManager.UserManager.GetClaimsAsync(applicationUser);

                //_logger.LogInformation($"User '{user.UserName}' logged in.");

                var tokenString = GenerateJSONWebToken(claims);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
        private string GenerateJSONWebToken(IEnumerable<Claim> claims)
        {
          
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var signinCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

                var token = tokenHandler.WriteToken(tokeOptions);
                
                return token;
        }
        
    }

}


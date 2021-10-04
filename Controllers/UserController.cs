using E_Commerce.Dtos;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserController
            (
                IUserRepository userRepository,
                IConfiguration configuration,
                SignInManager<ApplicationUser> signInManager,
                UserManager<ApplicationUser> userManager
            )
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();
            Debug.WriteLine("User length: " + users.Count());
            return Ok(users.ToList());
        }

        [AllowAnonymous]
        [HttpPost(Name = "login")]
        public async Task<IActionResult> Login
            (
                [FromBody]LoginDto loginDto
            )
        {
            if (loginDto == null)
            {
                return BadRequest();
            }

            var loginResult = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

            if (!loginResult.Succeeded)
            {
                return BadRequest("Credentials are not correct");
            }

            var user = await _userManager.FindByNameAsync(loginDto.Email);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var roleNames = await _userManager.GetRolesAsync(user);
            foreach (var roleName in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }

            var secretByte = Encoding.UTF8.GetBytes(_configuration["JWTSecretKey"]);
            var signingKey = new SymmetricSecurityKey(secretByte);
            var sigingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: "E-Commerce",
                    audience: "E-Commerce",
                    claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    sigingCredentials

                );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        [AllowAnonymous]
        [HttpPost("register", Name = "register")]
        public async Task<IActionResult> Create
            (
                [FromBody]RegisterDto registerDto
            )
        {
            if (!registerDto.Password.Equals(registerDto.ConfirmedPassword))
            {
                return BadRequest("Password and Confirmed password are not the same");
            }

            var user = new ApplicationUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(user);
            }

            return NoContent();
        }
    }
}

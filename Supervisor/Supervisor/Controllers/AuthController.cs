using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bank.Interfaces;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Bank.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IClientService _clientService;

        public AuthController(IConfiguration configuration, IClientService userService)
        {
            _configuration = configuration;
            _clientService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ClientLogin user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
                {
                    var loggedInUser = await _clientService.Get(user);
                    if (loggedInUser is null) return NotFound("User Not Found");

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, loggedInUser.Id.ToString()),
                        new Claim(ClaimTypes.Email, loggedInUser.Email),
                        new Claim(ClaimTypes.Name, loggedInUser.Name),
                        new Claim(ClaimTypes.Role, loggedInUser.Role),
                    };

                    var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                            SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        role = loggedInUser.Role
                    });
                }

                return BadRequest("Invalid User Credentials");
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
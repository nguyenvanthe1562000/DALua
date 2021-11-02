using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private ThucPhamContext db;
        private readonly AppSettings _appSettings;
        public UserController(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            db = new ThucPhamContext(configuration);
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] User model)
        {
            var Taikhoan = model.Acc;
            var Matkhau = model.Pass;
            var user = db.Users.SingleOrDefault(x => x.Acc == Taikhoan && x.Pass == Matkhau);
            // return null if user not found
            if (user == null)
                return Ok(new { data = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.DenyOnlyWindowsDeviceGroup, user.Pass)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tmp);
            return Ok(new { Taikhoan = user.Acc, Token = token });
        }
    }
}

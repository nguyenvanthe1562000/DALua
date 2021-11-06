using API.Models;
using Common.Helper;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.ExtensionModel;
using Newtonsoft.Json;
using ShopVT.Extensions;
using ShopVT.Model;
using ShopVT.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class LoginAdminController : ControllerBase
    {

        private ThucPhamContext db;
        private IConfiguration _config;
        private ILoginAdminRepository _iLoginAdmin;

        public LoginAdminController(IConfiguration configuration, ILoginAdminRepository iLoginAdmin)
        {
            db = new ThucPhamContext(configuration);
            _config = configuration;
            _iLoginAdmin = iLoginAdmin;

        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] DangNhapAdmin model)
        {
            try
            {
                var result = await _iLoginAdmin.Login(model);
                var identity= SetObjectValueDefault.SetValueDefault<IdentityModel>(result);
                string token = await GenerateJSONWebToken(await identity);

                return Ok(new { token });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task<string> GenerateJSONWebToken(IdentityModel identity)
        {

            var json = Task.Run(() =>
            {
                var rolesModel = JsonConvert.DeserializeObject<List<RolesModel>>(identity.Roles);
                List<Roles> listRoles = new List<Roles>();
                foreach (var item in rolesModel)
                {
                    Roles roles = new Roles();
                    roles.Function = item.FunctionCode;
                    roles.CanRead = item.CanRead ? ClaimAction.CANREAD : "";
                    roles.CanCreate = item.CanCreate ? ClaimAction.CANCREATE : "";
                    roles.CanUpdate = item.CanUpdate ? ClaimAction.CANUPDATE : "";
                    roles.CanDelete = item.CanDelete ? ClaimAction.CANDELETE : "";
                    roles.CanReport = item.CanReport ? ClaimAction.CANREPORT : "";
                    listRoles.Add(roles);

                }
                return JsonConvert.SerializeObject(listRoles);
            });
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>() {
                    new Claim(JwtRegisteredClaimExtension.UserCode, identity.Code),
                    new Claim(JwtRegisteredClaimExtension.EmpCode, identity.EmployeeCode),
                    new Claim(JwtRegisteredClaimExtension.UserId, identity.Id.ToString()),
                    new Claim(JwtRegisteredClaimExtension.FulName, identity.FullName),
                    new Claim(JwtRegisteredClaimNames.NameId,identity.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };
            claims.Add(new Claim(ClaimTypes.Role, await json));
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/nhacungcap")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private ThucPhamContext db;
        public NhaCungCapController(IConfiguration configuration)
        {
            db = new ThucPhamContext(configuration);
        }
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = db.NhaCungCaps.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
    
    }
}

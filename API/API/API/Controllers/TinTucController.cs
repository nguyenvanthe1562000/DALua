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
    [Route("api/tintuc")]
    [ApiController]
    public class TinTucController : ControllerBase
    {
        private ThucPhamContext db;
        public TinTucController(IConfiguration configuration)
        {
            db = new ThucPhamContext(configuration);
        }
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = db.TinTucs.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        [Route("get-all1")]
        [HttpGet]
        public IActionResult GetAll1()
        {
            try
            {
                var result = db.TinTucs.Select(s => new { s.Id, s.TieuDe,s.HinhAnh,s.NoiDung,s.NgayDang,s.TrangThai }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
    }
}

using API.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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

        [Route("get-by-id/{id}")]
        [HttpGet]
        public IActionResult GetById(string id)
        {
            try
            {
                var result = db.TinTucs.Where(s => s.Id == id).FirstOrDefault();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }

        // Phân trang
        [Route("get-all-paginate")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var tieude = "";
                if (formData.Keys.Contains("tieude") && !string.IsNullOrEmpty(Convert.ToString(formData["tieude"]))) { tieude = Convert.ToString(formData["tieude"]); }
                var result1 = db.TinTucs.Where(s => s.TieuDe.Contains(tieude)).ToList();
                long total = result1.Count();
                var result2 = result1.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                return Ok(
                    new KQ
                    {
                        page = page,
                        total = total,
                        pageSize = pageSize,
                        data = result2
                    }
                  );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

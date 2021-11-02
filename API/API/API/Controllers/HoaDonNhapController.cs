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
    [Route("api/hoadonnhap")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        private ThucPhamContext db;
        public HoaDonNhapController(IConfiguration configuration)
        {
            db = new ThucPhamContext(configuration);
        }
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                var reCT = (from ch in db.CthoaDonNhaps join it in db.SanPhams on ch.MaSp equals it.MaSp select new { ch.MaHoaDonNhap, ch.MaCthdnhap, ch.MaSp, it.TenSp, ch.SoLuong, it.Dongia, ch.HanSuDung }).ToList();
                var result = (from hd in db.HoaDonNhaps
                              select new
                              {
                                  hd.MaHoaDonNhap,
                                  hd.NgayNhap,
                                  hd.MaNcc,
                                  hd.TongTien,
                                  cthoaDons = reCT

                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
    }
}

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
    [Route("api/dondathang")]
    [ApiController]
    public class DonDatHangController : ControllerBase
    {
        private ThucPhamContext db;
        public DonDatHangController(IConfiguration configuration)
        {
            db = new ThucPhamContext(configuration);
        }
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                var reCT = (from ch in db.CtdonDatHangs join it in db.SanPhams on ch.MaSp equals it.MaSp select new { ch.MaDonHang, ch.MaCtdonDatHang, ch.MaSp, it.TenSp, ch.SoLuong, it.Dongia }).ToList();
                var result = (from hd in db.DonDatHangs
                              select new
                              {
                                  hd.MaDonHang,
                                  hd.MaKh,
                                  hd.DiaChiNhan,
                                  hd.Sdtnhan,
                                  hd.TinhTrang,
                                  hd.ThanhTien,
                                  hd.NgayDat,
                                  hd.NgayGiao,
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

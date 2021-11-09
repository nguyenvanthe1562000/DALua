using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> DatHang([FromBody] DonDatHangDTO hoaDonDTO)
        {
            try
            {
                DonDatHang donDatHang = new DonDatHang()
                {
                    MaDonHang = Guid.NewGuid().ToString(),
                    DiaChiNhan = hoaDonDTO.DiaChiNhan,
                    Sdtnhan = hoaDonDTO.Sdtnhan,
                    TinhTrang = false,
                    ThanhTien = hoaDonDTO.ThanhTien,
                    NgayDat = DateTime.Now,
                    NgayGiao = DateTime.Now.AddDays(4)
                };
                List<CtdonDatHang> ctdonDatHangs = new List<CtdonDatHang>();
                foreach (var item in hoaDonDTO.HoaDonChiTietDTO)
                {
                    CtdonDatHang ctdonDatHang = new CtdonDatHang()
                    {
                        MaCtdonDatHang = Guid.NewGuid().ToString(),
                        MaDonHang = donDatHang.MaDonHang,
                        MaSp = item.MaSp,
                        TenSp = item.TenSp,
                        hinhAnh = item.hinhAnh,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    };
                    ctdonDatHangs.Add(ctdonDatHang);
                }
                donDatHang.CtdonDatHangs = ctdonDatHangs;
                db.DonDatHangs.Add(donDatHang);
                await db.SaveChangesAsync();
                return Ok();
                //return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public IActionResult GetById(string MaDonHang)
        {
            try
            {
                var dondathang = db.DonDatHangs.Include(x => x.CtdonDatHangs).FirstOrDefault(x => x.MaDonHang == MaDonHang);
                return Ok(dondathang);
                //return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> UpdateDonDatHang([FromBody] DonDatHang hoaDon)
        {
            try
            {
                var dondh = db.DonDatHangs.FirstOrDefault(x => x.MaDonHang == hoaDon.MaDonHang);
                if (dondh != null)
                {
                    dondh.DiaChiNhan = hoaDon.DiaChiNhan;
                    dondh.Sdtnhan = hoaDon.Sdtnhan;
                    dondh.TinhTrang = false;
                    dondh.ThanhTien = hoaDon.ThanhTien;
                    dondh.NgayDat = dondh.NgayDat;
                    dondh.NgayGiao = dondh.NgayGiao;

                    List<CtdonDatHang> ctdonDatHangs = new List<CtdonDatHang>();
                    foreach (var item in hoaDon.CtdonDatHangs)
                    {
                        CtdonDatHang ctdonDatHang = new CtdonDatHang()
                        {
                            MaCtdonDatHang = Guid.NewGuid().ToString(),
                            MaDonHang = dondh.MaDonHang,
                            MaSp = item.MaSp,
                            TenSp = item.TenSp,
                            hinhAnh = item.hinhAnh,
                            SoLuong = item.SoLuong,
                            DonGia = item.DonGia
                        };
                        ctdonDatHangs.Add(ctdonDatHang);
                    }
                    dondh.CtdonDatHangs = ctdonDatHangs;
                    db.DonDatHangs.Update(dondh);
                    await db.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest("null");
                //return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Err");
            }
        }
        [Route("get-all-paginate")]
        [HttpPost]
        public IActionResult GetAllPaginate([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var result1 = db.DonDatHangs.ToList();
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

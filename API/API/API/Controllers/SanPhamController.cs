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
    [Route("api/sanpham")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ThucPhamContext db;
        public SanPhamController(IConfiguration configuration)
        {
            db = new ThucPhamContext(configuration);
        }
        //get all dữ liệu
        [Route("get-all-item")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = db.SanPhams.OrderByDescending(o => o.MaSp).Take(10).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        [Route("get-sp-lienquan/{maLoaiSp}")]
        [HttpGet]
        public IActionResult GetSpLienQuan(string maLoaiSp)
        {
            try
            {
                var result = db.SanPhams.Where(x=>x.MaLoaiSp==maLoaiSp).OrderByDescending(o => o.MaSp).Take(5).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        [Route("get-all-id")]
        [HttpGet]
        public IActionResult GetAllId()
        {
            try
            {
                var result = (db.LoaiSanPhams.Select(s => s.MaLoaiSp)).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        [Route("get-all-item1")]
        [HttpGet]
        public IActionResult GetAll1()
        {
            try
            {
                var result = (from sp in db.SanPhams
                              select new
                              {
                                  sp.MaSp,
                                  sp.TenSp,
                                  sp.MaLoaiSp,
                                  sp.DonVi,
                                  sp.MoTa,
                                  sp.HinhAnh,
                                  sp.SoLuongTon,
                                  sp.LuotXem,
                                  sp.LuotBinhLuan,
                                  sp.SoLanMua,
                                  sp.Dongia
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        [Route("get-all-item1-ten/{ten}")]
        [HttpGet]
        public IActionResult GetAllTen(string ten)
        {
            try
            {
                var result = (from sp in db.SanPhams
                              where sp.TenSp == ten
                              select new
                              {
                                  sp.MaSp,
                                  sp.TenSp,
                                  sp.MaLoaiSp,
                                  sp.DonVi,
                                  sp.MoTa,
                                  sp.HinhAnh,
                                  sp.SoLuongTon,
                                  sp.LuotXem,
                                  sp.LuotBinhLuan,
                                  sp.SoLanMua,
                                  sp.Dongia
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        //[Route("get-all-item-id/{id}")]
        //[HttpGet]
        //public IActionResult GetitemID(string id)
        //{
        //    try
        //    {
        //        var result = (from sp in db.SanPhams
        //                      where sp.MaLoaiSp == id
        //                      select new
        //                      {
        //                          sp.MaSp,
        //                          sp.TenSp,
        //                          sp.MaLoaiSp,
        //                          sp.DonVi,
        //                          sp.MoTa,
        //                          sp.HinhAnh,
        //                          sp.SoLuongTon,
        //                          sp.LuotXem,
        //                          sp.LuotBinhLuan,
        //                          sp.SoLanMua,
        //                          sp.Dongia
        //                      }).ToList();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok("Err");
        //    }
        //}
        //get 1 sản phẩm
        [Route("get-by-id/{id}")]
        [HttpGet]
        public IActionResult GetById(string id)
        {
            try
            {
                var result = db.SanPhams.Where(s => s.MaSp == id).FirstOrDefault();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        //thêm sản phẩm
        [Route("create-item")]
        [HttpPost]
        public IActionResult CreateItem([FromBody] SanPham model)
        {
            db.SanPhams.Add(model);
            db.SaveChanges();
            return Ok(new { data = "OK" });
        }

        //sửa sản phẩm
        [Route("update-item")]
        [HttpPost]
        public IActionResult UpdateItem([FromBody] SanPham model)
        {
            var obj = db.SanPhams.Where(s => s.MaSp == model.MaSp).SingleOrDefault();
            if (obj != null)
            {
                obj.TenSp = model.TenSp;
                obj.MaLoaiSp = model.MaLoaiSp;
                obj.DonVi = model.DonVi;
                obj.MoTa = model.MoTa;
                obj.HinhAnh = model.HinhAnh;
                obj.SoLuongTon = model.SoLuongTon;
                obj.LuotXem = model.LuotXem;
                obj.LuotBinhLuan = model.LuotBinhLuan;
                obj.SoLanMua = model.SoLanMua;
                obj.Dongia = model.Dongia;
                db.SaveChanges();
            }

            return Ok(new { data = "OK" });
        }
        [Route("update-item1/{id}")]
        [HttpPost]
        public IActionResult UpdateItem1([FromBody] SanPham model, string id)
        {
            var obj = db.SanPhams.Where(s => s.MaSp == id).SingleOrDefault();
            if (obj != null)
            {
                obj.TenSp = model.TenSp;
                obj.MaLoaiSp = model.MaLoaiSp;
                obj.DonVi = model.DonVi;
                obj.MoTa = model.MoTa;
                obj.HinhAnh = model.HinhAnh;
                obj.SoLuongTon = model.SoLuongTon;
                obj.LuotXem = model.LuotXem;
                obj.LuotBinhLuan = model.LuotBinhLuan;
                obj.SoLanMua = model.SoLanMua;
                obj.Dongia = model.Dongia;
                db.SaveChanges();
            }

            return Ok(new { data = "OK" });
        }

        [Route("update1-item")]
        [HttpPut]
        public IActionResult UpdateItem1([FromBody] SanPham model)
        {
            var obj = db.SanPhams.Where(s => s.MaSp == model.MaSp).SingleOrDefault();
            if (obj != null)
            {
                obj.TenSp = model.TenSp;
                obj.MaLoaiSp = model.MaLoaiSp;
                obj.DonVi = model.DonVi;
                obj.MoTa = model.MoTa;
                obj.HinhAnh = model.HinhAnh;
                obj.SoLuongTon = model.SoLuongTon;
                obj.LuotXem = model.LuotXem;
                obj.LuotBinhLuan = model.LuotBinhLuan;
                obj.SoLanMua = model.SoLanMua;
                obj.Dongia = model.Dongia;
                db.SaveChanges();
            }
            return Ok(new { data = "OK" });
        }
        //xóa sản phẩm
        [Route("delete-item/{item_id}")]
        [HttpPost]
        public IActionResult Delete1Item(string item_id)
        {
            var obj = db.SanPhams.Where(s => s.MaSp == item_id).SingleOrDefault();
            db.SanPhams.Remove(obj);
            db.SaveChanges();
            return Ok(new { data = "OK" });
        }
        [Route("delete-sanpham1")]
        [HttpPost]
        public IActionResult DeleteSanPham([FromBody] Dictionary<string, object> formData)
        {
            string masp = "";
            if (formData.Keys.Contains("maSp") && !string.IsNullOrEmpty(Convert.ToString(formData["maSp"])))
            { masp = Convert.ToString(formData["maSp"]); }
            var obj = db.SanPhams.Where(s => s.MaSp == masp).SingleOrDefault();
            db.SanPhams.Remove(obj);
            db.SaveChanges();
            return Ok(new { data = "OK" });
        }

        //tìm kiếm.
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var tenSp = "";
                if (formData.Keys.Contains("tenSp") && !string.IsNullOrEmpty(Convert.ToString(formData["tenSp"]))) { tenSp = Convert.ToString(formData["tenSp"]); }
                var result1 = db.SanPhams.Where(s => s.TenSp.Contains(tenSp)).ToList();
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
        
        // Phân trang
        [Route("get-all-paginate")]
        [HttpPost]
        public IActionResult GetAllPaginate([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var result1 = db.SanPhams.ToList();
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

        [Route("get-all-item-id/{id}")]
        [HttpGet]
        public IActionResult GetitemID([FromBody] Dictionary<string, object> formData, string id)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var result1 = (from sp in db.SanPhams
                              where sp.MaLoaiSp == id
                              select new
                              {
                                  sp.MaSp,
                                  sp.TenSp,
                                  sp.MaLoaiSp,
                                  sp.DonVi,
                                  sp.MoTa,
                                  sp.HinhAnh,
                                  sp.SoLuongTon,
                                  sp.LuotXem,
                                  sp.LuotBinhLuan,
                                  sp.SoLanMua,
                                  sp.Dongia
                              }).ToList();
                long total = result1.Count();
                var result2 = result1.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                return Ok(new KQ
                {
                    page = page,
                    total = total,
                    pageSize = pageSize,
                    data = result2
                });
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
    }
}

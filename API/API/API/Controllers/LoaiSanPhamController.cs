using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShopVT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/loaisanpham")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        private ThucPhamContext db;
        public LoaiSanPhamController(IConfiguration configuration)
        {
            db = new ThucPhamContext(configuration);
        }
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = db.LoaiSanPhams.Select(s => new { text = s.TenLoai, value = s.MaLoaiSp }).ToList();
               
               
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
                var result = db.LoaiSanPhams.Select(s => new { s.TenLoai, s.MaLoaiSp }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        // get 1 loại sản phẩm
        [Route("get-by-id/{id}")]
        [HttpGet]
        public IActionResult GetById(string id)
        {
            try
            {
                var result = db.LoaiSanPhams.Where(s => s.MaLoaiSp == id).FirstOrDefault();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        [Route("get-by-ten/{ten}")]
        [HttpGet]
        public IActionResult GetByTen(string ten)
        {
            try
            {
                var result = (from lsp in db.LoaiSanPhams
                              where lsp.TenLoai.Contains(ten)
                              select new
                              {
                                  lsp.MaLoaiSp,
                                  lsp.TenLoai
                              }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }
        }
        //thêm loại sản phẩm
        [Route("create-loai")]
        [HttpPost]
        [Authorize]
        [ClaimRequirement(ClaimFunction.PRODUCTCATEGORY, ClaimAction.CANCREATE)]
        public IActionResult CreateItem([FromBody] LoaiSanPham model)
        {
            model.MaLoaiSp = Guid.NewGuid().ToString();
            db.LoaiSanPhams.Add(model);
            db.SaveChanges();
            return Ok(new { data = "OK" });
        }
        [Route("create-loai1")]
        [HttpPost]
        [Authorize]
        [ClaimRequirement(ClaimFunction.PRODUCTCATEGORY, ClaimAction.CANCREATE)]
        public IActionResult CreateItem1([FromBody] LoaiSanPham model)
        {
            //model.MaLoai = Guid.NewGuid().ToString();
            db.LoaiSanPhams.Add(model);
            db.SaveChanges();
            return Ok(new { data = "OK" });
        }

        //sửa loại sản phẩm
        [Route("update-loai")]
        [HttpPost]
        [Authorize]
        [ClaimRequirement(ClaimFunction.PRODUCTCATEGORY, ClaimAction.CANUPDATE)]
        public IActionResult UpdateItem([FromBody] LoaiSanPham model)
        {
            var obj = db.LoaiSanPhams.Where(s => s.MaLoaiSp == model.MaLoaiSp).SingleOrDefault();
            if (obj != null)
            {
                obj.TenLoai = model.TenLoai;
                db.SaveChanges();
            }

            return Ok(new { data = "OK" });
        }
        [Route("update-loai1/{id}")]
        [HttpPost]
        [Authorize]
        [ClaimRequirement(ClaimFunction.PRODUCTCATEGORY, ClaimAction.CANUPDATE)]
        public IActionResult UpdateItem1([FromBody] LoaiSanPham model, string id)
        {
            var obj = db.LoaiSanPhams.Where(s => s.MaLoaiSp == id).SingleOrDefault();
            if (obj != null)
            {
                obj.TenLoai = model.TenLoai;
                db.SaveChanges();
            }

            return Ok(new { data = "OK" });
        }

        //xóa loai sản phẩm
        [Route("delete-lsp/{id}")]
        [HttpDelete]
        [Authorize]
        [ClaimRequirement(ClaimFunction.PRODUCTCATEGORY, ClaimAction.CANDELETE)]
        public IActionResult Delete1Item(string id)
        {
            var obj = db.LoaiSanPhams.Where(s => s.MaLoaiSp == id).SingleOrDefault();
            db.LoaiSanPhams.Remove(obj);
            db.SaveChanges();
            return Ok(new { data = "OK" });
        }

        [Route("update1-loai")]
        [HttpPut]
        [Authorize]
        [ClaimRequirement(ClaimFunction.PRODUCTCATEGORY, ClaimAction.CANUPDATE)]
        public IActionResult UpdateItem1([FromBody] LoaiSanPham model)
        {
            var obj = db.LoaiSanPhams.Where(s => s.MaLoaiSp == model.MaLoaiSp).SingleOrDefault();
            if (obj != null)
            {
                obj.TenLoai = model.TenLoai;
                db.SaveChanges();
            }
            return Ok(new { data = "OK" });
        }
        //xóa loại sản phẩm
        [Route("delete-loaisanpham1")]
        [HttpPost]
        [Authorize]
        [ClaimRequirement(ClaimFunction.PRODUCTCATEGORY, ClaimAction.CANDELETE)]
        public IActionResult DeleteLoaiSanPham([FromBody] Dictionary<string, object> formData)
        {
            string maloai = "";
            if (formData.Keys.Contains("maLoaiSp") && !string.IsNullOrEmpty(Convert.ToString(formData["maLoai"])))
            { maloai = Convert.ToString(formData["maLoaiSp"]); }
            var obj = db.LoaiSanPhams.Where(s => s.MaLoaiSp == maloai).SingleOrDefault();
            db.LoaiSanPhams.Remove(obj);
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
                var tenLoai = "";
                if (formData.Keys.Contains("tenLoai") && !string.IsNullOrEmpty(Convert.ToString(formData["tenLoai"]))) { tenLoai = Convert.ToString(formData["tenLoai"]); }
                var result1 = db.LoaiSanPhams.Where(s => s.TenLoai.Contains(tenLoai)).ToList();
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

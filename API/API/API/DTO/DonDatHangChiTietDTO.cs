using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class DonDatHangChiTietDTO
    {
        public string MaCtdonDatHang { get; set; }
        public string MaDonHang { get; set; }
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string hinhAnh { get; set; }
        public double? SoLuong { get; set; }
        public double? DonGia { get; set; }
       

    }
}

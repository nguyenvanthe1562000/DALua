using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class CthoaDonNhap
    {
        public string MaCthdnhap { get; set; }
        public string MaHoaDonNhap { get; set; }
        public string MaSp { get; set; }
        public double? SoLuong { get; set; }
        public double? DonGia { get; set; }
        public DateTime? HanSuDung { get; set; }

        public virtual HoaDonNhap MaHoaDonNhapNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
